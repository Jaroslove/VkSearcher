using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.Helper
{
    class ConvertorDate
    {
        public static DateTime ConvertDateTimeFromUnix(int date)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return start.AddSeconds(date).ToLocalTime();
        }
    }
}
