using SpeakPet.DAO;
using SpeakPet.Dominio.Enums;
using SpeakPet.Dominio.Interfaces.DAO;
using SpeakPet.Dominio.Interfaces.Servico;
using SpeakPet.Dominio.Models;
using System.Collections.Generic;
using System.Linq;

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

        public void LimparRegistrosAcaoAudio(int idUsuario)
        {
            ObterDAO().LimparRegistrosAcaoAudio(idUsuario);
        }

        public bool ValidarReproducaoAudio(int idUsuario)
        {
            IList<AcaoAudioModel> acoes = ObterDAO().ObterAcoesAudio(idUsuario);

            if (acoes.Count == 0)
                return true;

            IList<AcaoAudioModel> reproduzir = acoes.Where(x => x.Acao == AcaoEnum.Reproduzir).ToList();
            IList<AcaoAudioModel> parar = acoes.Where(x => x.Acao == AcaoEnum.Parar).ToList();

            foreach (AcaoAudioModel acao in reproduzir)
            {
                if (!parar.Any(x => x.Acao == AcaoEnum.Parar && x.IdAudio == acao.IdAudio))
                    return false;
            }

            return true;
        }
    }
}
