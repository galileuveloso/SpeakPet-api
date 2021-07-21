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

        public int? Id { get; set; }
        public string Titulo { get; set; }
        public byte[] Bytes { get; set; }
        public int IdUsuario { get; set; }
    }
}
