using System.Collections.Generic;

namespace GeradorDeApostas.Models
{
    public class MegaSena
    {
        public int Id { get; set; }
        public List<int> Numeros { get; set; }

        public MegaSena()
        {
            Numeros = new List<int>();
        }
    }

    
}
