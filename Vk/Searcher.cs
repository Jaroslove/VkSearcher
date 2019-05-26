using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vk.Searching;

namespace Vk
{
    class Searcher
    {
        ConvertorToResult convertorToResult;

        public Searcher()
        {
            convertorToResult = new ConvertorToResult();            
        }

        public async Task<Wall> Search(AccessToken accessToken, SearchableObject searchableObject, 
            CancellationToken cancellationToken, IProgress<int> progress)
        {
            try
            {
                var builder = new BuildSearch(accessToken.Token, searchableObject.IdObject);

                await builder.GetGetterPost(cancellationToken);

                await builder.GetGetterComment(cancellationToken, progress);

                return await new Searching.Searcher().Search(builder.Get(), searchableObject.ValuesToSearch, searchableObject.SinceDate, cancellationToken);
            }
            catch (Exception ex)
            {
                return convertorToResult.ConvertIfError(ex.Message);
            }
        }
    }
}
