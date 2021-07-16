using SpeakPet.Dominio.Models;
using System.Collections.Generic;

namespace SpeakPet.Dominio.Interfaces.DAO
{
    public interface IAudioDAO
    {
        void InserirAudio(AudioModel audio);
        AudioModel ObterAudio(int idAudio);
        void ExcluirAudio(int idAudio);
        void EditarAudio(int idAudio, string novoTitulo);
        IEnumerable<AudioModel> ListarAudios(int idUsuario);
    }
}
