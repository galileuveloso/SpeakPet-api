using SpeakPet.Dominio.Enums;

namespace SpeakPet.Dominio.Models
{
    public class AcaoAudioModel
    {
        public AcaoAudioModel(AcaoEnum acao, int idAudio, int idUsuario)
        {
            Acao = acao;
            IdAudio = idAudio;
            IdUsuario = idUsuario;
        }

        public int Id { get; set; }
        public AcaoEnum Acao { get; set; }
        public int IdAudio { get; set; }
        public int IdUsuario { get; set; }
    }
}
