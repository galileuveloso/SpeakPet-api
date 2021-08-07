using Dapper;
using SpeakPet.Dominio.Interfaces.DAO;
using SpeakPet.Dominio.Models;
using System.Text;

namespace SpeakPet.DAL
{
    public class ReproducaoDAO : IReproducaoDAO
    {
        public void InserirReproducao(ReproducaoModel reproducao)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"
                        INSERT INTO Reproducao (idAudio, idUsuario, dataReproducao, Ativo)
                        VALUES (@IdAudio, IdUsuario, DataReproducao, Ativo)
                        ");

            Conexao.GetConnection().Execute(sql.ToString(), reproducao);
        }

        public void DesativarReproducao(int idReproducao)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"
                        UPDATE Reproducao
                        SET Ativo = 0
                        WHERE id = @IdReproducao
                        ");

            Conexao.GetConnection().Execute(sql.ToString(), new { IdReproducao = idReproducao });
        }
    }
}
