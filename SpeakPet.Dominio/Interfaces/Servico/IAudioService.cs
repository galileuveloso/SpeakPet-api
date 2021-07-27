using SpeakPet.Dominio.Models;
using System.Collections.Generic;

namespace SpeakPet.Dominio.Servico.Interfaces
{
    public interface IAudioService
    {
        void InserirAudios(IList<AudioModel> audios);
        AudioModel ObterAudio(int idAudio);
        void ExcluirAudio(int idAudio);
        void EditarAudio(int idAudio, string novoTitulo);
        IEnumerable<AudioModel> ListarAudios(int idUsuario);
    }
}
