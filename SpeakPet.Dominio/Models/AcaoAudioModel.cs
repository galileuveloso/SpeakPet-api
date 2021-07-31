using SpeakPet.Dominio.Enums;

namespace SpeakPet.Dominio.Models
{
    public class AcaoAudioModel
    {
        public int Id { get; set; }
        public AcaoEnum Acao { get; set; }
        public int IdUsuario { get; set; }
    }
}
