using Dapper;
using SpeakPet.Dominio.Interfaces.DAO;
using SpeakPet.Dominio.Models;
using System.Text;

namespace SpeakPet.DAO
{
    public class AcaoAudioDAO : IAcaoAudioDAO
    {
        public void RegistrarAcaoAudio(AcaoAudioModel acaoAudio)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"INSERT INTO AcaoAudio(codAcao, idAudio, idUsuario)
                         VALUES (@CodAcao, @IdAudio, @IdUsuario)");

            Conexao.GetConnection().Execute(sql.ToString(), acaoAudio);
        }
    }
}
