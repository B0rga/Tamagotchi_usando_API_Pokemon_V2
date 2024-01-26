using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto35.Models{
    // esta classe representará cada pokémon disponível na lista de pokémons do sistema, trazendo consigo todos os seus detalhes
    public class PokemonDisponivel{
        public string nome { get; set; }
        public int altura { get; set; }
        public int peso { get; set; }
        public List<string> habilidades { get; set; }
    }
}