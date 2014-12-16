using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGP
{
    public class Tools
    {
        public static int ConvertToNumeric(object value)
        {
            int retVal = 0;
            if (IsNumeric(value))
            {
                retVal = Convert.ToInt32(value);
            }
            return retVal;
        }
        public static bool IsNumeric(object value)
        {
            long lTemp;
            bool bVal = true;
            try
            {
                lTemp = System.Convert.ToInt64(value);
            }
            catch
            {
                bVal = false;
            }

            return bVal;
        }
    }
}
