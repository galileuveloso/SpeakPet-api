using SpeakPet.DAL;
using SpeakPet.Dominio.Interfaces.DAO;
using SpeakPet.Dominio.Interfaces.Servico;
using SpeakPet.Dominio.Models;

namespace SpeakPet.Servicos
{
    public class ReproducaoService : IReproducaoService
    {
        private IReproducaoDAO _reproducaoDAO;

        private IReproducaoDAO ObterDAO()
        {
            if (_reproducaoDAO == null)
                _reproducaoDAO = new ReproducaoDAO();
            return _reproducaoDAO;
        }

        public void InserirReproducao(ReproducaoModel reproducao)
        {
            ObterDAO().InserirReproducao(reproducao);
        }

        public void DesativarReproducao(int idReproducao)
        {
            ObterDAO().DesativarReproducao(idReproducao);
        }

        public int? ObterReproducaoAtual(int idUsuario)
        {
            return ObterDAO().ObterReproducaoAtual(idUsuario);
        }
    }
}
