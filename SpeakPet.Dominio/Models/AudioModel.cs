namespace SpeakPet.Dominio.Models
{
    public class AudioModel
    {
        public AudioModel()
        {
        }

        public AudioModel(string titulo, byte[] bytes, int idUsuario)
        {
            Titulo = titulo;
            Bytes = bytes;
            IdUsuario = idUsuario;
        }

        public AudioModel(string titulo, int idUsuario, string linkYouTube)
        {
            Titulo = titulo;
            IdUsuario = idUsuario;
            LinkYouTube = linkYouTube;
        }

        public int? Id { get; set; }
        public string Titulo { get; set; }
        public byte[] Bytes { get; set; }
        public int IdUsuario { get; set; }
        public string LinkYouTube { get; set; }
    }
}
