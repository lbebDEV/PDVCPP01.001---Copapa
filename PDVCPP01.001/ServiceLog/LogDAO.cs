using PDVCPP01._001.Config;
using PDVCPP01._001.Guardian;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._001.ServiceLog
{
    class LogDAO
    {
        Guardian_Util guardian_Util = new Guardian_Util();
        public void RegistrarLogRotina(LogRotina logRotina, string conexao)
        {
            if (!Log_Config.LogRotina)
                return;

            byte[] log = Encoding.UTF8.GetBytes(guardian_Util.FormatarCaracter(logRotina.Log));

            string query =
                "INSERT INTO " + Tabelas_Guardian.ZA0 + " " +
                "(ZA0_ORIGEM, ZA0_DATA, ZA0_HORA, ZA0_TIPO, ZA0_ROTINA, ZA0_LOG) " +
                "VALUES (" +
                "'" + logRotina.Origem + "', " + 
                "'" + logRotina.Data + "', " + 
                "'" + logRotina.Hora + "', " +
                "'" + logRotina.Tipo + "', " +
                "'" + logRotina.Rotina + "', " +
                "@log " +
                ")";

            try
            {
                using (SqlConnection connection = new SqlConnection(conexao))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@log", log);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Guardian_LogTxt.LogAplicacao("Registrar Log Rotina ", "Erro " + ex.ToString() + Environment.NewLine + " Status: " + Log_Config.LogRotina + " Query: " + query);
            }
        }
        
        public int DeletarLog(string tabela, int quantDias, string conexao)
        {
            int countDeletado = 0;

            string query =
                "DELETE FROM " + tabela + " " +
                "WHERE DATA <= '" + DateTime.Now.AddDays(-quantDias).ToString("yyyyMMdd") + "' ";

            using (SqlConnection connection = new SqlConnection(conexao))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    countDeletado = command.ExecuteNonQuery();
                }
            }

            return countDeletado;
        }
    }
}
