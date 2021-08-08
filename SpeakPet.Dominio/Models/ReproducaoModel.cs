using System;

namespace SpeakPet.Dominio.Models
{
    public class ReproducaoModel
    {
        public int Id { get; set; }
        public int IdAudio { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataReproducao { get; set; }
        public bool Ativo { get; set; }

        public int AtivoBit
        {
            get
            {
                if (Ativo == true)
                    return 1;
                return 0;
            }
        }
    }
}
