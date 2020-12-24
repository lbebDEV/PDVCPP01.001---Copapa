using PDVCPP01._001.Config;
using PDVCPP01._001.DAO;
using PDVCPP01._001.HttpClients;
using PDVCPP01._001.Model;
using PDVCPP01._001.Service;
using PDVCPP01._001.ServiceLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._001.Controllers
{
    class ClientesController : RotinaContinua
    {
        ClienteDAO clienteDAO = new ClienteDAO();
        public ClientesController()
        {
            Nome = "Cliente Cadastro";
        }

        public override void Executar()
        {
            try
            {
                HttpClientBase<ClientResult> httpClientBase = new HttpClientBase<ClientResult>("https://painel.velocepdv.com.br/");

                if (Service_Config.CadastroHabilitado)
                {
                    ClientResult resultados = httpClientBase.Get("api/v1/cliente/pesquisa");
                    List<Client> resultadosERP = clienteDAO.BuscarERP();
                    SincronizarNovos(resultadosERP, resultados.result);
                }
            }
            catch (Exception ex)
            {
                Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Erro, "Erro na Rotina de Cliente. " + ex.ToString());
            }
        }

        public void SincronizarNovos(List<Client> clienteERP, List<Client> clienteAPI)
        {
            int countCadastrados = 0;

            HashSet<string> listaPortal = new HashSet<string>(clienteERP.Select(s => s.id_tbl_cliente));

            List<Client> novosAcessos = clienteAPI.Where(m => !listaPortal.Contains(m.id_tbl_cliente)).ToList();

            foreach (var client in novosAcessos)
            {
                if (clienteDAO.Inserir(client, Nome))
                    countCadastrados++;
            }
            Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Auditoria, "Numero de Clientes cadastrados: " + countCadastrados);
        }
        
    }
}
