using SpeakPet.DAL;
using SpeakPet.Dominio.Interfaces.DAO;
using SpeakPet.Dominio.Interfaces.Servico;
using SpeakPet.Dominio.Models;
using System.Security.Cryptography;
using System.Text;

namespace SpeakPet.Servicos
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioDAO _usuarioDAO;

        private IUsuarioDAO ObterDAO()
        {
            if (_usuarioDAO == null)
                _usuarioDAO = new UsuarioDAO();
            return _usuarioDAO;
        }

        private string CriptografarSenha(string senha)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public void InserirUsuario(UsuarioModel usuario)
        {
            usuario.Senha = CriptografarSenha(usuario.Senha);
            ObterDAO().InserirUsuario(usuario);
        }

        public UsuarioModel EfetuarLogin(string login, string senha)
        {
            return ObterDAO().EfetuarLogin(login, CriptografarSenha(senha));
        }
    }
}
