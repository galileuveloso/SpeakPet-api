using SpeakPet.Dominio.Models;

namespace SpeakPet.Dominio.Interfaces.Servico
{
    public interface IAcaoAudioService
    {
        void RegistrarAcaoAudio(AcaoAudioModel acaoAudio);
        bool ValidarReproducaoAudio(int idUsuario);
    }
}
