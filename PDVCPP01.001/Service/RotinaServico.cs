using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._001.Service
{
    abstract class RotinaServico
    {
        public bool Habilitado { get; set; }
        public string Nome { get; set; }
        
        public abstract void Executar();
    }
}
