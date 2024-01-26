using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Projeto35.Models;
using Projeto35.Service;

namespace Projeto35.Controller{
    public class PokemonController{
        
        private Menu menu { get; set; }
        private PokemonAPIService pokemonAPIService { get; set; }
        private ListaPokemons listaPokemons { get; set; }
        private ListaMeusPokemons listaMeusPokemons { get; set; }
        
        public PokemonController(){
            menu = new Menu();
            pokemonAPIService = new PokemonAPIService();
            listaMeusPokemons = new ListaMeusPokemons();
            
            // o novo objeto de ListaPokemons irá obter os valores retornados pelo método da classe PokemonAPIService
            listaPokemons = pokemonAPIService.ObterPokemons();
        }

        public void Jogar(){

            string nomeUsuario;
            string pokemonEscolhido;
            bool menuInicialAtivo = true;
            bool menuAdocaoAtivo;
            bool menuMeuPokemonAtivo;
            bool pokemonEstaNalista;
            bool existemPokemonsAdotados;

            Console.Clear();
            Console.Write("Sejam bem-vindo(a) a nossa adoção de mascotes!\nPrimeiro, insira seu nome: ");
            nomeUsuario = Console.ReadLine();
            while(nomeUsuario == string.Empty){
                Console.Clear();
                Console.WriteLine("O campo do nome deve ser preenchido!");
                Console.Write("Insira seu nome: ");
                nomeUsuario = Console.ReadLine();
            }

            while(menuInicialAtivo==true){
                
                pokemonEstaNalista = false;
                menuAdocaoAtivo = true; // e menu de adoção deve sempre começar true para poder ser executada mais de uma vez
                menuMeuPokemonAtivo = true;
                existemPokemonsAdotados = false;

                menu.MenuInicial(nomeUsuario);
                switch(Console.ReadLine()){
                    case "1":
                        listaPokemons.ExibirPokemons();
                        Console.Write("\nQual pokémon você escolhe? ");
                        pokemonEscolhido = Console.ReadLine();

                        // verificação se o nome do pokemon existe:
                        foreach(var pokemon in listaPokemons.pokemonsDisponiveis){
                            if(pokemonEscolhido.ToUpper().Equals(pokemon.nome.ToUpper())){
                                pokemonEstaNalista = true;
                            }
                        }

                        if(pokemonEstaNalista == true){
                            while(menuAdocaoAtivo == true){
                                menu.MenuAdocao(nomeUsuario, pokemonEscolhido);
                                switch(Console.ReadLine()){
                                    case "1":
                                        listaPokemons.MostrarDetalhesPokemon(pokemonEscolhido);
                                        break;
                                    case "2":
                                        listaMeusPokemons = listaPokemons.AdotarPokemon(pokemonEscolhido); // objeto "listaMeusPokemons" está recebendo o pokémon escolhido através do método AdotarPokemon
                                        menuAdocaoAtivo = false;
                                        break;
                                    case "3":
                                        menuAdocaoAtivo = false;
                                        break;
                                    default:
                                        Console.WriteLine("\nOpção inválida.\n");
                                        Thread.Sleep(2000);
                                        break;
                                }   
                            }
                        }
                        else{
                            menu.NomeNaoEncontrado();
                        }
                        break;
                    case "2":
                        // no processo abaixo eu uso uma variável to tipo bool para verificar se há um pokémon adotado, antes de realizar qualquer outra ação
                        existemPokemonsAdotados = listaMeusPokemons.ExibirMeusPokemons();
                        if(existemPokemonsAdotados == true){
                            Console.Write("\nInsira o nome de um pokémon (ou qualquer valor para sair): ");
                            pokemonEscolhido = Console.ReadLine();

                            // verificação se o nome do pokemon existe:
                            foreach(var pokemon in listaMeusPokemons.meusPokemons){
                                if(pokemonEscolhido.ToUpper().Equals(pokemon.nome.ToUpper())){
                                    pokemonEstaNalista = true;
                                }
                            }

                            if(pokemonEstaNalista == true){
                                while(menuMeuPokemonAtivo == true){
                                    menu.MeuPokemon(nomeUsuario, pokemonEscolhido);
                                    switch(Console.ReadLine()){
                                        case "1":
                                            listaMeusPokemons.MostrarDetalhesMeuPokemon(pokemonEscolhido);
                                            break;
                                        case "2":
                                            listaMeusPokemons.AlimentarMeuPokemon(pokemonEscolhido);
                                            break;
                                        case "3":
                                            listaMeusPokemons.BrincarComMeuPokemon(pokemonEscolhido);
                                            break;
                                        case "4":
                                            listaMeusPokemons.TreinarMeuPokemon(pokemonEscolhido);
                                            break;
                                        case "5":
                                            menuMeuPokemonAtivo = false;
                                            break;
                                        default:
                                            Console.WriteLine("\nOpção inválida.\n");
                                            Thread.Sleep(2000);
                                            break;
                                    }
                                }
                            }
                        }
                        break;
                    case "3":
                        Console.WriteLine($"\nSessão encerrada com êxito. Até a próxima {nomeUsuario}!\n");
                        Thread.Sleep(2000);
                        menuInicialAtivo = false;
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida.\n");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }
    }
}