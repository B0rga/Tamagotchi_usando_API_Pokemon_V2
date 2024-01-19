using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Projeto35.Models;
using Projeto35.Service;
using RestSharp;

namespace Projeto35.Controller{
    public class PokemonController{
        
        private Menu menu { get; set; }
        private ListaPokemons listaPokemons { get; set; }
        private PokemonAPIService pokemonAPIService { get; set; }
        
        public PokemonController(){
            menu = new Menu();
            pokemonAPIService = new PokemonAPIService();
            
             // O novo objeto de ListaPokemons irá obter os valores retornados pelo método da classe PokemonAPIService
            listaPokemons = pokemonAPIService.ObterPokemons();
        }

        public void Jogar(){

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

                menu.MenuInicial(nomeUsuario);
                switch(Console.ReadLine()){
                    case "1":
                        listaPokemons.ExibirPokemons();
                        Console.Write("\nQual pokémon você escolhe? ");
                        pokemonEscolhido = Console.ReadLine();

                        // verificação se o nome do pokemon existe:
                        foreach(var pokemon in listaPokemons.pokemonsDisponiveis){
                            if(pokemonEscolhido.Equals(pokemon.nome)){
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
                                        listaPokemons.AdotarPokemon(pokemonEscolhido);
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
                        listaPokemons.ExibirMeusPokemons();
                        break;
                    case "3":
                        Console.WriteLine($"\nSessão encerrada com êxito. Até a próxima {nomeUsuario}!\n");
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