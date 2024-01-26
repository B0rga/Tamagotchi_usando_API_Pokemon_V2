using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto35.Models{

    // esta classe serve para representar os nomes dos pokemons que estão nas lista "results"
    public class PokemonDetalhesAPI{
        public string name { get; set; }
    }

    // esta classe serve para representar as propriedades de cada pokemon, obtidas da rota "https://pokeapi.co/api/v2/pokemon/{cont}/"
    public class Propriedades{ 
        public int height { get; set; }
        public int weight { get; set; }
        public List<Habilidades> abilities { get; set; }
    }

    // esta classe representa o conjunto de habilidades de cada Pokemon, obtidas da rota "https://pokeapi.co/api/v2/pokemon/{cont}/"
    public class Habilidades{
        public Ability ability { get; set; } // como geralmente existem duas ou mais habilidades, é preciso criar uma propriedade que represente cada uma delas
    }

    // esta classe é referenciada pela classe acima, e representa cada habilidade individualmente
    public class Ability{
        public string name { get; set; } // nome da habilidade
    }
}