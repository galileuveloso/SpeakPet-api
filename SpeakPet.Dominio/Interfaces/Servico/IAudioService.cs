using SpeakPet.Dominio.Models;
using SpeakPet.Dominio.Models.Visualizacao;
using System.Collections.Generic;

namespace SpeakPet.Dominio.Servico.Interfaces
{
    public interface IAudioService
    {
        void InserirAudios(IList<AudioModel> audios);
        void InserirAudioYoutube(AudioYouTubeModel audioYouTube);
        AudioModel ObterAudio(int idAudio);
        void ExcluirAudio(int idAudio);
        void EditarAudio(int idAudio, string novoTitulo);
        IEnumerable<ItemListaAudio> ListarAudios(int idUsuario);
    }
}
