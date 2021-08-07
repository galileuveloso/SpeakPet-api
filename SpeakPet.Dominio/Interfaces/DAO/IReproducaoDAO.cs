using SpeakPet.Dominio.Models;

namespace SpeakPet.Dominio.Interfaces.DAO
{
    public interface IReproducaoDAO
    {
        void InserirReproducao(ReproducaoModel reproducao);
        void DesativarReproducao(int idReproducao);
    }
}
