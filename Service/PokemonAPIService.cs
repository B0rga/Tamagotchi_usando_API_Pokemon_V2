using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Projeto35.Models;
using RestSharp;

namespace Projeto35.Service{
    public class PokemonAPIService{

        private ListaPokemons listaPokemons { get; set; }

        public PokemonAPIService(){
            listaPokemons = new ListaPokemons();
        }

        public ListaPokemons ObterPokemons(){
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon");
            RestRequest request = new RestRequest("", Method.Get); 
            var response = client.Execute(request);
            PokemonResultsAPI pokemonResultsAPI = JsonSerializer.Deserialize<PokemonResultsAPI>(response.Content);

            int cont = 0;
            for(int i=0; i<pokemonResultsAPI.results.Count; i++){
                cont++;
                List<string> listaHabilidades = new List<string>(); 

                var prop = new RestClient($"https://pokeapi.co/api/v2/pokemon/{cont}/");
                RestRequest requestProp = new RestRequest("", Method.Get);
                var responseProp = prop.Execute(requestProp);
                Propriedades propriedades = JsonSerializer.Deserialize<Propriedades>(responseProp.Content);

                foreach(var abilityDetail in propriedades.abilities){
                    listaHabilidades.Add(abilityDetail.ability.name);
                }
                
                listaPokemons.pokemonsDisponiveis.Add(new PokemonDisponivel{
                    nome = pokemonResultsAPI.results[i].name,
                    altura = propriedades.height,
                    peso = propriedades.weight,
                    habilidades = listaHabilidades
                });
            }
            
            return listaPokemons;
        }
    }
}