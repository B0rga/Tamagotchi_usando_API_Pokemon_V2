using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Projeto35.Models;
using RestSharp;

namespace Projeto35.Service{
    public class PokemonAPIService{

        private ListaPokemons listaPokemons { get; set; } // criando uma propriedade da classe ListaPokemons para adicionar os Pokemons da API ao nosso sistema

        public PokemonAPIService(){
            listaPokemons = new ListaPokemons(); // é preciso instanciar a classe dentro do constructor
        }

        public ListaPokemons ObterPokemons(){ // este método irá retornar o objeto listaPokemons, com seus devidos valores
            try{
                var client = new RestClient("https://pokeapi.co/api/v2/pokemon"); // especificando a rota do request de dados
                RestRequest request = new RestRequest("", Method.Get); // criando request do tipo GET  
                var response = client.Execute(request); // criando a resposta do request (ela conterá todos os dados do JSON da rota especificada)
                
                // abaixo estou instanciando uma classe que irá conter apenas os dados que eu quero do JSON, por meio de um método conhecido como Deserializador
                PokemonResultsAPI pokemonResultsAPI = JsonSerializer.Deserialize<PokemonResultsAPI>(response.Content);

                int cont = 0; // contador será utilizado para alterar para alterar as rotas
                for(int i=0; i<pokemonResultsAPI.results.Count; i++){ // este loop serve para recebermos os detalhes de todos os pokémons, com base na sua quantidade
                    cont++; // o contador já começa com 1

                    // esta rota especifica o Pokémon que queremos com base na numeração. Ex: se o bulbasaur está em "pokemon/1", será retornado o peso, altura e habilidades dele
                    var prop = new RestClient($"https://pokeapi.co/api/v2/pokemon/{cont}/");
                    RestRequest requestProp = new RestRequest("", Method.Get);
                    var responseProp = prop.Execute(requestProp);
                    Propriedades propriedades = JsonSerializer.Deserialize<Propriedades>(responseProp.Content); // instanciando a classe Propriedades (do pokemon) e deserializando os dados para pegar apenas os que eu achar útil

                    // é necessário com que criemos uma lista para recebemos as habilidades dos pokemons
                    List<string> listaHabilidades = new List<string>();
                    foreach(var abilityDetail in propriedades.abilities){
                        listaHabilidades.Add(abilityDetail.ability.name); // para cada habilidade em Propriedades.abilities, eu adicionarei o nome da habilidade á lista
                    }
                    
                    // o loop se encerra ao criarmos um novo objeto de PokemonDisponivel, 
                    // que recebe os dados das classe PokemonResulstAPI (nome) e da classe
                    // Propriedades (altura, peso, habilidades). 
                    listaPokemons.pokemonsDisponiveis.Add(new PokemonDisponivel{
                        nome = pokemonResultsAPI.results[i].name,
                        altura = propriedades.height,
                        peso = propriedades.weight,
                        habilidades = listaHabilidades
                    });
                }
            }catch{
                throw new Exception("Serviço indipovível no momento: pokeApi");
            }
            return listaPokemons; // ao finalizar o loop e todo recebimento de dados, retornamos o objeto que armazena todas esses valores (que serão utilizados mais pra frente)
        }
    }
}