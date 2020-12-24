using PDVCPP01._001.Config;
using PDVCPP01._001.Guardian;
using PDVCPP01._001.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._001.ServiceLog
{
    public enum Tipo
    {
        Iniciado, Finalizado, Erro, Auditoria
    }

    public enum Acao
    {
        Cadastro, Atualização, Deleção, Importação, DeleçãoAntigo, Atendido, Integração
    }

    public enum Status
    {
        Sucesso, Falha
    }

    public class Guardian_Log
    {
        public static void Log_Rotina(string nomeRotina, Tipo tipo, string textoLivre)
        {
            LogRotina logRotina = new LogRotina
            {
                Origem = "APLICACAO",
                Data = DateTime.Now.ToString("yyyyMMdd"),
                Hora = DateTime.Now.ToString("HH:mm:ss"),
                Tipo = tipo.ToString(),
                Rotina = nomeRotina,
                Log = textoLivre,
            };

            LogDAO logDAO = new LogDAO();
            logDAO.RegistrarLogRotina(logRotina, ConexaoERP.Conexao());
        }
    }
}
