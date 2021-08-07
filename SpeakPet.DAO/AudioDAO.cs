using Dapper;
using SpeakPet.Dominio.Interfaces.DAO;
using SpeakPet.Dominio.Models;
using SpeakPet.Dominio.Models.Visualizacao;
using System.Collections.Generic;
using System.Text;

namespace SpeakPet.DAL
{
    public class AudioDAO : IAudioDAO
    {
        public void InserirAudios(IList<AudioModel> audios)
        {
            StringBuilder sqlAudio = new StringBuilder();

            sqlAudio.Append(@"
                            INSERT INTO dbo.Audio(titulo, arquivo, idusuario)
                            VALUES(@Titulo, @Bytes, @IdUsuario)
                            ");

            foreach (AudioModel audio in audios)
                Conexao.GetConnection().Execute(sqlAudio.ToString(), audio);
        }

        public void InserirAudioYoutube(AudioYouTubeModel audioYouTube)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"
                        INSERT INTO dbo.Audio(titulo, linkYouTube, idusuario)
                        VALUES(@Titulo, @LinkYouTube, @IdUsuario)
                        ");

            Conexao.GetConnection().Execute(sql.ToString(), audioYouTube);
        }

        public AudioModel ObterAudio(int idAudio)
        {
            StringBuilder sqlAudio = new StringBuilder();

            sqlAudio.Append(@"
                            SELECT Titulo as Titulo,
                            Arquivo as Bytes,
                            FROM Audio
                            WHERE id = @IdAudio
                            ");

            AudioModel audio = Conexao.GetConnection().QuerySingleOrDefault<AudioModel>(sqlAudio.ToString(), new { IdAudio = idAudio });

            return audio;
        }

        public void ExcluirAudio(int idAudio)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"
                        DELETE FROM Audio
                        WHERE id = @IdAudio
                        ");

            Conexao.GetConnection().Execute(sql.ToString(), new { IdAudio = idAudio });
        }

        public void EditarAudio(int idAudio, string novoTitulo)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"
                        UPDATE Audio
                        SET titulo = @NovoTitulo
                        WHERE id = @IdAudio
                        ");

            Conexao.GetConnection().Execute(sql.ToString(), new { IdAudio = idAudio, NovoTitulo = novoTitulo });
        }

        public IEnumerable<ItemListaAudio> ListarAudios(int idUsuario)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"
                        SELECT Titulo as Titulo,
                            Id as Id
                        FROM Audio
                        WHERE idUsuario = @IdUsuario
                        ");

            return Conexao.GetConnection().Query<ItemListaAudio>(sql.ToString(), new { IdUsuario = idUsuario });
        }
    }
}
