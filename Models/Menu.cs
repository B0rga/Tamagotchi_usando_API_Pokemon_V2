using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto35.Models{
    public class Menu{

        public List<PokemonDisponivel> pokemonsDisponiveis { get; set; }
        public List<MeuPokemon> meusPokemons { get; set; }

        public string pokemonEscolhido { get; set; }

        public Menu(){
            pokemonsDisponiveis = new List<PokemonDisponivel>();
            meusPokemons = new List<MeuPokemon>();
        }

        public void ExibirPokemons(){
            Console.WriteLine(" ");
            for(int i=0; i<pokemonsDisponiveis.Count; i++){
                Console.Write(pokemonsDisponiveis[i].nome);
                Console.Write($" | {pokemonsDisponiveis[i].altura} | ");
                Console.Write($"{pokemonsDisponiveis[i].peso} | ");
                foreach(string habilidade in pokemonsDisponiveis[i].habilidades){
                    Console.Write($"{habilidade} ");
                }
                Console.WriteLine("");
            }
        }

        public void EscolherPokemon(){
            Console.Write("Insira o nome de um pokémon: ");
            string nomeEscolhido = Console.ReadLine();
            bool nomeEstaNaLista = false;

            for(int i=0; i<pokemonsDisponiveis.Count; i++){
                if(pokemonsDisponiveis[i].nome.Equals(nomeEscolhido)){
                    nomeEstaNaLista = true;
                    pokemonEscolhido = nomeEscolhido;
                }
            }

            if(nomeEstaNaLista == false){
                Console.WriteLine("Pokémon não encontrado");
            }
        }

        public void MostrarDetalhesPokemon(){
            for(int i=0; i<pokemonsDisponiveis.Count; i++){
                if(pokemonsDisponiveis[i].nome.Equals(pokemonEscolhido)){
                    Console.Write(pokemonsDisponiveis[i].nome);
                    Console.Write($" | {pokemonsDisponiveis[i].altura} | ");
                    Console.Write($"{pokemonsDisponiveis[i].peso} | ");
                    foreach(string habilidade in pokemonsDisponiveis[i].habilidades){
                        Console.Write($"{habilidade} ");
                    }
                    Console.WriteLine("");
                }
            }
        }

        public void AdotarPokemon(){
            for(int i=0; i<pokemonsDisponiveis.Count; i++){
                if(pokemonsDisponiveis[i].nome.Equals(pokemonEscolhido)){
                    meusPokemons.Add(new MeuPokemon{
                        nome = pokemonsDisponiveis[i].nome,
                        altura = pokemonsDisponiveis[i].altura,
                        peso = pokemonsDisponiveis[i].peso,
                        habilidades = pokemonsDisponiveis[i].habilidades
                    });
                    pokemonsDisponiveis.RemoveAt(i);
                }
            }
            Console.WriteLine("Pokémon adotado com sucesso!");
        }

        public void ExibirMeusPokemons(){
            Console.WriteLine("\nMeus pokémons:");
            for(int i=0; i<meusPokemons.Count; i++){
                Console.Write(meusPokemons[i].nome);
                Console.Write($" | {meusPokemons[i].altura} | ");
                Console.Write($"{meusPokemons[i].peso} | ");
                foreach(string habilidade in meusPokemons[i].habilidades){
                    Console.Write($"{habilidade} ");
                }
                Console.WriteLine("");
            }
        }
    }
}