using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._001.Model
{
    class Client
    {
        public string id_tbl_cliente { get; set; }
        public string fk_tbl_cliente_id_empresa { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string tipo { get; set; }
        public string identificador { get; set; }
        public string rg { get; set; }
        public string email { get; set; }
        public string sexo { get; set; }
        public string dt_cadastro { get; set; }
        public string dt_alteracao { get; set; }
        public string dt_exclusao { get; set; }
        public string dt_nascimento { get; set; }
        public string ddi_telefone { get; set; }
        public string ddd_telefone { get; set; }
        public string telefone { get; set; }
        public string ddi_celular { get; set; }
        public string ddd_celular { get; set; }
        public string celular { get; set; }
        public string fk_tbl_cliente_id_cliente { get; set; }
        public string anotacao { get; set; }
        public string api_referencia { get; set; }
        public string ie { get; set; }
        public string im { get; set; }
        public string senha { get; set; }
    }
}
