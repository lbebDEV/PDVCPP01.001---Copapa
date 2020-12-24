using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._001.Guardian
{
    class Guardian_Util
    {
        public string FormatarCaracter(string str)
        {
            string validos = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789,.-";

            foreach (char c in str)
            {
                if (c == (char)13 || c == (char)10 || c == ' ')
                {
                    continue;
                }
                else if (!validos.Contains(c))
                {
                    str = str.Replace(c, '-');
                }
            }

            return str;
        }
    }
}
