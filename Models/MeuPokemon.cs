using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto35.Models{
    // esta classe representará cada pokémon adotado pelo usuário, trazendo consigo todos seus detalhes 
    public class MeuPokemon{
        public string nome { get; set; }
        public int altura { get; set; }
        public int idade { get; set; } = 1;

        public int pesoOriginal { get; set; }
        public int pesoAtual { get; set; }

        public List<string> habilidades { get; set; }

        public int fome {get; set; } = 0;
        public int tristeza { get; set; } = 0;
        public int fraqueza { get; set; } = 0;
    }
}