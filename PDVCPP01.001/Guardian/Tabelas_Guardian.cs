using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._001.Guardian
{
    class Tabelas_Guardian
    {
#if (DEBUG)
        public static string Empresa = "990";
#else
        public static string Empresa = "010";
#endif

        public static string ZA0 { get; set; } = "ZA0" + Empresa;

        public static string ZA1 { get; set; } = "ZA1" + Empresa;

    }
}
