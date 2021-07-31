using SpeakPet.Dominio.Models;

namespace SpeakPet.Dominio.Interfaces.DAO
{
    public interface IAcaoAudioDAO
    {
        void RegistrarAcaoAudio(AcaoAudioModel acaoAudio);
    }
}
