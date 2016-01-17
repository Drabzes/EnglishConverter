using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishConverter
{
    class Swapwoordjes
    {
        public static string swap(string woord, string zin)
        {
            zin = zin.Replace(woord, "........");

            return zin;
        }
    }
}
