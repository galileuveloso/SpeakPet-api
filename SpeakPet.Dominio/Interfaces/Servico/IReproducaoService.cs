using SpeakPet.Dominio.Models;

namespace SpeakPet.Dominio.Interfaces.Servico
{
    public interface IReproducaoService
    {
        void InserirReproducao(ReproducaoModel reproducao);
        void DesativarReproducao(int idReproducao);
    }
}
