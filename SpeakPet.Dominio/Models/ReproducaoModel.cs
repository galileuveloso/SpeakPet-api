using System;

namespace SpeakPet.Dominio.Models
{
    public class ReproducaoModel
    {
        public int Id { get; set; }
        public int IdAudio { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataReproducao { get; set; }
        private int ativo;
        public bool Ativo
        {
            get
            {
                return ativo == 1;
            }
        }
    }
}
