using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using Site_SmartComfort.Models;
using Site_SmartComfort.Repository.Contract;
using System.Data;

namespace Site_SmartComfort.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _conexaoMySQL;

        public UsuarioRepository(IConfiguration conf)
        {
            // Obtenha a string de conexão como uma string, não como uma instância de MySqlConnection
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public Usuario LoginUsuario(string EmailUsu, string SenhaUsu)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                var query = "CALL sp_LoginUsuario (@EmailUsu, @SenhaUsu)"; // Chama a procedure

                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.Add("@EmailUsu", MySqlDbType.VarChar).Value = EmailUsu;
                cmd.Parameters.Add("@SenhaUsu", MySqlDbType.VarChar).Value = SenhaUsu;

                using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.Read()) // Verifica se encontrou um usuário
                    {
                        Usuario usuario = new Usuario
                        {
                            IdUsu = Convert.ToInt32(dr["IdUsu"]),
                            EmailUsu = Convert.ToString(dr["EmailUsu"]),
                            SenhaUsu = Convert.ToString(dr["SenhaUsu"]),
                            TelefoneUsu1 = Convert.ToInt64(dr["TelefoneUsu1"]),
                            TelefoneUsu2 = dr.IsDBNull(dr.GetOrdinal("TelefoneUsu2")) ? (long?)null : Convert.ToInt64(dr["TelefoneUsu2"]),
                            DataCadUsu = Convert.ToString(dr["DataCadUsu"])
                        };

                        // Verifica o tipo de usuário (PF ou PJ)
                        string tipoUsuario = Convert.ToString(dr["TipoUsu"]);

                        if (tipoUsuario == "PF")
                        {
                            usuario.Cpf = dr.IsDBNull(dr.GetOrdinal("Cpf")) ? (long?)null : Convert.ToInt64(dr["Cpf"]);
                            usuario.NomeCompleto = dr.IsDBNull(dr.GetOrdinal("NomeCompleto")) ? null : Convert.ToString(dr["NomeCompleto"]);
                        }
                        else if (tipoUsuario == "PJ")
                        {
                            usuario.Cnpj = dr.IsDBNull(dr.GetOrdinal("Cnpj")) ? (long?)null : Convert.ToInt64(dr["Cnpj"]);
                            usuario.RazaoSocial = dr.IsDBNull(dr.GetOrdinal("RazaoSocial")) ? null : Convert.ToString(dr["RazaoSocial"]);
                            usuario.NomeResponsavel = dr.IsDBNull(dr.GetOrdinal("NomeResponsavel")) ? null : Convert.ToString(dr["NomeResponsavel"]);
                        }

                        return usuario; // Retorna o usuário encontrado
                    }
                }
            }

            // Retorna null se nenhum usuário for encontrado
            return null;
        }

        public IEnumerable<Usuario> ObterTodosUsuarios()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObterUsuario(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UsuarioExiste(string EmailUsu)
        {
            throw new NotImplementedException();
        }
    }
}
