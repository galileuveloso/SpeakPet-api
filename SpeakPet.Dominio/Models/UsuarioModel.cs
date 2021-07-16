namespace SpeakPet.Dominio.Models
{
    public class UsuarioModel
    {
        public UsuarioModel()
        {
        }

        public UsuarioModel(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }

        public UsuarioModel(int? idUsuario, string login, string senha)
        {
            IdUsuario = idUsuario;
            Login = login;
            Senha = senha;
        }

        public UsuarioModel(int idUsuario, string login)
        {
            IdUsuario = idUsuario;
            Login = login;
        }

        public int? IdUsuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
