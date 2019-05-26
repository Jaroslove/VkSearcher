using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vk
{
    /// <summary>
    /// use it to create settings and search values of wall from vk site
    /// </summary>
    public class Builder
    {
        /// <summary>
        /// set auth for an user from vk site
        /// </summary>
        public AccessToken AccessToken { get; set; }

        /// <summary>
        /// set the object with data
        /// </summary>
        public SearchableObject SearchableObject { get; set; }

        /// <summary>
        /// search it and get result
        /// this method use multy thread, so please use async and await here
        /// </summary>
        /// <returns></returns>
        public async Task<Wall> SearchAsync()
        {
            try
            {
                return await searcher.Search(AccessToken, SearchableObject, cts.Token, progress);
            }
            catch (OperationCanceledException)
            {
                return new Wall();            
            }
        }

        /// <summary>
        /// cancel the current search
        /// </summary>
        public void CancelSearch()
        {
            cts?.Cancel();
        }

        Searcher searcher;

        CancellationTokenSource cts;

        IProgress<int> progress;

        public Builder()
        {
            searcher = new Searcher();

            cts = new CancellationTokenSource();            
        }

        public Builder(Action<int> doProgress) : this()
        {
            progress = new Progress<int>(doProgress);
        }
    }
}
