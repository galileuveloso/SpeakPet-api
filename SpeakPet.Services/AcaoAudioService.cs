using SpeakPet.DAO;
using SpeakPet.Dominio.Interfaces.DAO;
using SpeakPet.Dominio.Interfaces.Servico;
using SpeakPet.Dominio.Models;

namespace SpeakPet.Servicos
{
    public class AcaoAudioService : IAcaoAudioService
    {
        private IAcaoAudioDAO _acaoAudioDAO;

        private IAcaoAudioDAO ObterDAO()
        {
            if (_acaoAudioDAO == null)
                _acaoAudioDAO = new AcaoAudioDAO();
            return _acaoAudioDAO;
        }

        public void RegistrarAcaoAudio(AcaoAudioModel acaoAudio)
        {
            ObterDAO().RegistrarAcaoAudio(acaoAudio);
        }
    }
}
