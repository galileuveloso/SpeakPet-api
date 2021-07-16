using SpeakPet.Dominio.Models;

namespace SpeakPet.Dominio.Interfaces.Servico
{
    public interface IUsuarioService
    {
        void InserirUsuario(UsuarioModel usuario);
        UsuarioModel EfetuarLogin(string login, string senha);
    }
}
