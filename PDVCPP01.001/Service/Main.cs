using PDVCPP01._001.Config;
using PDVCPP01._001.Controllers;
using PDVCPP01._001.Guardian;
using PDVCPP01._001.ServiceLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._001.Service
{
    class Main
    {
        public static string IdCiclo { get; set; }

        public void ExecucaoServico()
        {
            IdCiclo = DateTime.Now.ToString("yyyyMMddHHmmss");

            try
            {
                Service_Config.CarregarConfiguracoes();
                Guardian_LogTxt.LogControle(TipoControle.Ciclo_Iniciado);
                Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Iniciado,"");
                if (Service_Config.Status)
                {
                    ClientesController clientesController = new ClientesController();
                    clientesController.Executar();
                }
                Guardian_LogTxt.LogControle(TipoControle.Ciclo_Finalizado);
                Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Finalizado,"");
            }
            catch (Exception ex)
            {
                Guardian_LogTxt.LogAplicacao(Service_Config.NomeServico, ex.ToString());
                Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Erro, "Erro na Rotina Principal. " + ex.ToString());
            }
        }
    }
}
