using PDVCPP01._001.Config;
using PDVCPP01._001.Guardian;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._001.DAO
{
    class ConfigBancoDAO
    {
        public void BuscarConfigs()
        {
            string query =
                "SELECT CADASTRO, DELAY_CICLO, EMAIL_VALIDACAO, TIPO_UPLOAD, VALOR_UPLOAD, DELAY_UPLOAD, HORA_INICIO, HORA_FIM, TOKEN " +
                "FROM " + Tabelas_Portal.ConfigUpload + " " +
                "WHERE ROTINA = 'CLIENTE'";

            using (SqlConnection conexao = new SqlConnection(ConexaoERP.Conexao()))
            {
                using (SqlCommand command = new SqlCommand(query, conexao))
                {
                    conexao.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["CADASTRO"].ToString().TrimStart().TrimEnd() == "S")
                                Service_Config.CadastroHabilitado = true;

                            Service_Config.DelayCiclo = Convert.ToDouble(reader["DELAY_CICLO"].ToString().TrimStart().TrimEnd());
                            Service_Config.EmailValidacao = reader["EMAIL_VALIDACAO"].ToString().TrimStart().TrimEnd();
                            Service_Config.TipoUpload = reader["TIPO_UPLOAD"].ToString().TrimStart().TrimEnd();
                            Service_Config.ValorUpload = reader["VALOR_UPLOAD"].ToString().TrimStart().TrimEnd();
                            Service_Config.DelayUpload = Convert.ToDouble(reader["DELAY_UPLOAD"].ToString().TrimStart().TrimEnd());
                            Service_Config.UploadHoraInicio = Convert.ToDateTime(reader["HORA_INICIO"].ToString().TrimStart().TrimEnd());
                            Service_Config.UploadHoraFim = Convert.ToDateTime(reader["HORA_FIM"].ToString().TrimStart().TrimEnd());
                            Service_Config.Token = reader["TOKEN"].ToString().TrimStart().TrimEnd();
                        }
                    }
                }
            }
        }
    }
}
