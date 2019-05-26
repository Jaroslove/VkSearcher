using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk
{
    /// <summary>
    /// use this class for create the date for searching
    /// </summary>
    public class SearchableObject
    {
        /// <summary>
        /// user's id which wall will be scan 
        /// </summary>
        public long IdObject { get; set; }

        /// <summary>
        /// strings which will be searched,
        /// if it's null or empty, the result will be all data
        /// </summary>
        public IEnumerable<string> ValuesToSearch { get; set; }

        /// <summary>
        /// the date since will be searching
        /// if it's null, the result will be for all time
        /// </summary>
        public DateTime? SinceDate { get; set; }
    }
}
