using SpeakPet.DAO;
using SpeakPet.Dominio.Interfaces.DAO;
using SpeakPet.Dominio.Models;
using SpeakPet.Dominio.Models.Visualizacao;
using SpeakPet.Dominio.Servico.Interfaces;
using System.Collections.Generic;

namespace SpeakPet.Servicos
{
    public class AudioService : IAudioService
    {
        private IAudioDAO _audioDAO;

        private IAudioDAO ObterDAO()
        {
            if (_audioDAO == null)
                _audioDAO = new AudioDAO();
            return _audioDAO;
        }

        public void InserirAudios(IList<AudioModel> audios)
        {
            ObterDAO().InserirAudios(audios);
        }

        public void InserirAudioYoutube(AudioYouTubeModel audioYouTube)
        {
            ObterDAO().InserirAudioYoutube(audioYouTube);
        }

        public AudioModel ObterAudio(int idAudio)
        {
            return ObterDAO().ObterAudio(idAudio);
        }

        public void ExcluirAudio(int idAudio)
        {
            ObterDAO().ExcluirAudio(idAudio);
        }

        public void EditarAudio(int idAudio, string novoTitulo)
        {
            ObterDAO().EditarAudio(idAudio, novoTitulo);
        }

        public IEnumerable<ItemListaAudio> ListarAudios(int idUsuario)
        {
            return ObterDAO().ListarAudios(idUsuario);
        }
    }
}
