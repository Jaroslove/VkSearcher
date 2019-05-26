using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk
{
    class ConvertorToResult
    {
        public Wall ConvertIfError(string textOfError)
        {
            return new Wall(0, 0, null, true, textOfError);
        }
    }
}
