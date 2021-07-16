using Dapper;
using SpeakPet.Dominio.Interfaces.DAO;
using SpeakPet.Dominio.Models;
using System.Text;

namespace SpeakPet.DAO
{
    public class UsuarioDAO : IUsuarioDAO
    {
        public void InserirUsuario(UsuarioModel usuario)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"
                        INSERT INTO Usuario(Login, Senha)
                        VALUES(@Login, @Senha)
                        ");

            Conexao.GetConnection().Execute(sql.ToString(), usuario);
        }
        
        public UsuarioModel EfetuarLogin(string login, string senha)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"
                        SELECT Login as Login,
                            Id as Id,
                            Senha as Senha
                        FROM Usuario
                        WHERE login = @Login
                            AND senha = @Senha
                        ");

            return Conexao.GetConnection().QuerySingleOrDefault<UsuarioModel>(sql.ToString(), new { Login = login, Senha = senha });
        }
    }
}
