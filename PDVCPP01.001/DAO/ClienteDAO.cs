using PDVCPP01._001.Config;
using PDVCPP01._001.Guardian;
using PDVCPP01._001.HttpClients;
using PDVCPP01._001.Model;
using PDVCPP01._001.ServiceLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._001.DAO
{
    class ClienteDAO
    {

        public bool Inserir(Client client, string nome)
        {
            string query = "";

            try
            {
                query = "INSERT INTO " + Tabelas_Guardian.ZA1 + " " +
                   "(ZA1_IDCLIE, ZA1_NOME, ZA1_SNOME, " +
                   "ZA1_TIPO, ZA1_ID, ZA1_RG, ZA1_EMAIL, " +
                   "ZA1_SEXO, ZA1_DTCAD, ZA1_DTALT, ZA1_DTEXC, " +
                   "ZA1_DTNAS, ZA1_DDIT, ZA1_DDDT, ZA1_TEL, " +
                   "ZA1_DDIC, ZA1_DDDC, ZA1_CEL, ZA1_IDCLIC, ZA1_NOTAS, ZA1_ID_T_C) " +
                   "VALUES " +
                   "(" +
                   " '" + client.fk_tbl_cliente_id_empresa + "', " +
                   " '" + client.nome + "', " +
                   " '" + client.sobrenome + "', " +
                   " '" + client.tipo + "', " +
                   " '" + client.identificador + "', " +
                   " '" + client.rg + "', " +
                   " '" + client.email + "', " +
                   " '" + client.sexo + "', " +
                   " '" + client.dt_cadastro + "', " +
                   " '" + client.dt_alteracao + "', " +
                   " '" + client.dt_exclusao + "', " +
                   " '" + client.dt_nascimento + "', " +
                   " '" + client.ddi_telefone + "', " +
                   " '" + client.ddd_telefone + "', " +
                   " '" + client.telefone + "', " +
                   " '" + client.ddi_celular + "', " +
                   " '" + client.ddd_celular + "', " +
                   " '" + client.celular + "', " +
                   " '" + client.fk_tbl_cliente_id_cliente + "', " +
                   " '" + client.anotacao + "', " +
                   " '" + client.id_tbl_cliente + "' " +
                   ")";

                using (SqlConnection connection = new SqlConnection(ConexaoERP.Conexao()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Guardian_Log.Log_Rotina(Service_Config.NomeServico, Tipo.Erro, "Erro na Rotina de inserção de Cliente. " + ex.ToString());
                return false;
            }
        }

        public List<Client> BuscarERP()
        {
            List<Client> Clientes = new List<Client>();

            string query = "";

            try
            {
                query =
                 "SELECT " +
                "ZA1_IDCLIE, ZA1_NOME, ZA1_SNOME, " +
                "ZA1_TIPO, ZA1_ID, ZA1_RG, ZA1_EMAIL, " +
                "ZA1_SEXO, ZA1_DTCAD, ZA1_DTALT, ZA1_DTEXC, " +
                "ZA1_DTNAS, ZA1_DDIT, ZA1_DDDT, ZA1_TEL, " +
                "ZA1_DDIC, ZA1_DDDC, ZA1_CEL, ZA1_IDCLIC, ZA1_NOTAS, ZA1_ID_T_C " +
                "FROM " + Tabelas_Guardian.ZA1; 

                using (SqlConnection connection = new SqlConnection(ConexaoERP.Conexao()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandTimeout = 500;
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Client cliente = new Client
                                {
                                    fk_tbl_cliente_id_empresa = reader["ZA1_IDCLIE"].ToString().Trim(),
                                    nome = reader["ZA1_NOME"].ToString().Trim(),
                                    sobrenome = reader["ZA1_SNOME"].ToString().Trim(),
                                    tipo = reader["ZA1_TIPO"].ToString().Trim(),
                                    identificador = reader["ZA1_ID"].ToString().Trim(),
                                    rg = reader["ZA1_RG"].ToString().Trim(),
                                    email = reader["ZA1_EMAIL"].ToString().Trim(),
                                    sexo = reader["ZA1_SEXO"].ToString().Trim(),
                                    dt_cadastro = reader["ZA1_DTCAD"].ToString().Trim(),
                                    dt_alteracao = reader["ZA1_DTALT"].ToString().Trim(),
                                    dt_exclusao = reader["ZA1_DTEXC"].ToString().Trim(),
                                    dt_nascimento = reader["ZA1_DTNAS"].ToString().Trim(),
                                    ddi_telefone = reader["ZA1_DDIT"].ToString().Trim(),
                                    ddd_telefone = reader["ZA1_DDDT"].ToString().Trim(),
                                    telefone = reader["ZA1_TEL"].ToString().Trim(),
                                    ddi_celular = reader["ZA1_DDIC"].ToString().Trim(),
                                    ddd_celular = reader["ZA1_DDDC"].ToString().Trim(),
                                    celular = reader["ZA1_CEL"].ToString().Trim(),
                                    fk_tbl_cliente_id_cliente = reader["ZA1_IDCLIC"].ToString().Trim(),
                                    anotacao = reader["ZA1_NOTAS"].ToString().Trim(),
                                    id_tbl_cliente = reader["ZA1_ID_T_C"].ToString().Trim(),
                                };

                                Clientes.Add(cliente);
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Query: " + query + Environment.NewLine, ex);
            }
            return Clientes;
        }

    }
}
