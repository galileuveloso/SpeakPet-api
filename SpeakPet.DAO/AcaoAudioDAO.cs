using Dapper;
using SpeakPet.Dominio.Interfaces.DAO;
using SpeakPet.Dominio.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeakPet.DAO
{
    public class AcaoAudioDAO : IAcaoAudioDAO
    {
        public void RegistrarAcaoAudio(AcaoAudioModel acaoAudio)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"INSERT INTO AcaoAudio(codAcao, idAudio, idUsuario)
                         VALUES (@Acao, @IdAudio, @IdUsuario)");

            Conexao.GetConnection().Execute(sql.ToString(), acaoAudio);
        }

        public void LimparRegistrosAcaoAudio(int idUsuario)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"DELETE FROM AcaoAudio
                         WHERE IdUsuario = @IdUsuario");

            Conexao.GetConnection().Execute(sql.ToString(), new { IdUsuario = idUsuario });
        }

        public IList<AcaoAudioModel> ObterAcoesAudio(int idUsuario)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"SELECT codAcao as Acao,
                            idAudio as idAudio
                        FROM AudioAcao
                        WHERE idUsuario = @IdUsuario
                        ");

            return Conexao.GetConnection().Query<AcaoAudioModel>(sql.ToString(), new { IdUsuario = idUsuario }).ToList();
        }
    }
}
