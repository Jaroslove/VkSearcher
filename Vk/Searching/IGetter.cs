using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vk.Searching
{
    interface IGetter<T> where T : class
    {
        Task<T> Get(CancellationToken cancellationToken);

    }
}
