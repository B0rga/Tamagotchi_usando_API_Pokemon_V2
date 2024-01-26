using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto35.Models{

    // esta classe serve para representar os dados deserializados da rota "https://pokeapi.co/api/v2/pokemon" 
    public class PokemonResultsAPI{
        public List<PokemonDetalhesAPI> results { get; set;} // "results" é uma lista (dentro arquivo JSON) que armazena os nomes dos Pokemons
    }
}