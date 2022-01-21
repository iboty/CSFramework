using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFramework.Common.Helper
{
    public static  class StringHelper
    {
        public static string InsertFormat(string input, int interval, string value)
        {
            if (string.IsNullOrEmpty(input)) return input;

            for (var i = interval; i < input.Length; i += interval + 1)
                input = input.Insert(i, value);

            return input;
        }

    }
}
