using SpeakPet.Dominio.Models;

namespace SpeakPet.Dominio.Interfaces.DAO
{
    public interface IUsuarioDAO
    {
        void InserirUsuario(UsuarioModel usuario);
        UsuarioModel EfetuarLogin(string login, string senha);
    }
}
