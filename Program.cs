
using System.Text.Json;
using Projeto35.Models;
using RestSharp;

Console.Clear();

var client = new RestClient("https://pokeapi.co/api/v2/pokemon");
RestRequest request = new RestRequest("", Method.Get); 
var response = client.Execute(request);
PokemonResultsAPI pokemonResultsAPI = JsonSerializer.Deserialize<PokemonResultsAPI>(response.Content);

Menu menu = new Menu();

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
    
    menu.pokemonsDisponiveis.Add(new PokemonDisponivel{
        nome = pokemonResultsAPI.results[i].name,
        altura = propriedades.height,
        peso = propriedades.weight,
        habilidades = listaHabilidades
    });
}

menu.ExibirPokemons();

menu.EscolherPokemon();
menu.MostrarDetalhesPokemon();
menu.AdotarPokemon();

menu.EscolherPokemon();
menu.MostrarDetalhesPokemon();
menu.AdotarPokemon();

menu.EscolherPokemon();
menu.MostrarDetalhesPokemon();
menu.AdotarPokemon();

menu.EscolherPokemon();
menu.MostrarDetalhesPokemon();
menu.AdotarPokemon();

menu.ExibirMeusPokemons();

menu.ExibirPokemons();

menu.EscolherPokemon();