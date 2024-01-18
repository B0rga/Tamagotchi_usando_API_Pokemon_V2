
using System.Text.Json;
using Projeto35.Models;
using Projeto35.View;
using RestSharp;

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

// ==============================================================================================

MenuInterface menuInterface = new MenuInterface();

string nomeUsuario;
string pokemonEscolhido;
bool menuInicialAtivo = true;
bool pokemonEstaNalista;

Console.Clear();
Console.Write("Sejam bem-vindo(a) a nossa adoção de mascotes!\nPrimeiro, insira seu nome: ");
nomeUsuario = Console.ReadLine();

while(menuInicialAtivo==true){
    
    pokemonEstaNalista = false;
    bool menuAdocaoAtivo = true; // e menu de adoção deve sempre começar true para poder ser executada mais de uma vez

    menuInterface.MenuInicial(nomeUsuario);
    switch(Console.ReadLine()){
        case "1":
            menu.ExibirPokemons();
            Console.Write("\nQual pokémon você escolhe? ");
            pokemonEscolhido = Console.ReadLine();

            // verificação se o nome do pokemon existe:
            foreach(var pokemon in menu.pokemonsDisponiveis){
                if(pokemonEscolhido.Equals(pokemon.nome)){
                    pokemonEstaNalista = true;
                }
            }

            if(pokemonEstaNalista == true){
                while(menuAdocaoAtivo == true){
                    menuInterface.MenuAdocao(nomeUsuario, pokemonEscolhido);
                    switch(Console.ReadLine()){
                        case "1":
                            menu.MostrarDetalhesPokemon(pokemonEscolhido);
                            break;
                        case "2":
                            menu.AdotarPokemon(pokemonEscolhido);
                            menuAdocaoAtivo = false;
                            break;
                        case "3":
                            menuAdocaoAtivo = false;
                            break;
                        default:
                            break;
                    }   
                }
            }
            else{
                menuInterface.NomeNaoEncontrado();
            }
            break;
        case "2":
            menu.ExibirMeusPokemons();
            break;
        case "3":
            Console.WriteLine($"\nSessão encerrada com êxito. Até a próxima {nomeUsuario}\n");
            menuInicialAtivo = false;
            break;
        default:
            Console.WriteLine("\nOpção inválida.\n");
            Thread.Sleep(2000);
            break;
    }
}