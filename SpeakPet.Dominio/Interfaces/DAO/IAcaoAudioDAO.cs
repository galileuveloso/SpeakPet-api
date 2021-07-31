using SpeakPet.Dominio.Models;
using System.Collections.Generic;

namespace SpeakPet.Dominio.Interfaces.DAO
{
    public interface IAcaoAudioDAO
    {
        void RegistrarAcaoAudio(AcaoAudioModel acaoAudio);
        void LimparRegistrosAcaoAudio(int idUsuario);
        IList<AcaoAudioModel> ObterAcoesAudio(int idUsuario);
    }
}
