using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto35.Service;

namespace Projeto35.Models{
    public class ListaPokemons{
        
        public List<PokemonDisponivel> pokemonsDisponiveis { get; set; }
        public List<MeuPokemon> meusPokemons { get; set; }

        public ListaPokemons(){
            pokemonsDisponiveis = new List<PokemonDisponivel>();
            meusPokemons = new List<MeuPokemon>();
        }

        public void ExibirPokemons(){
            Console.Clear();
            for(int i=0; i<pokemonsDisponiveis.Count; i++){
                Console.WriteLine($"- {pokemonsDisponiveis[i].nome.ToUpper()}");
            }
        }

        public void MostrarDetalhesPokemon(string pokemonEscolhido){
            Console.WriteLine(" ");
            for(int i=0; i<pokemonsDisponiveis.Count; i++){
                if(pokemonsDisponiveis[i].nome.Equals(pokemonEscolhido)){
                    Console.WriteLine($"Nome: {pokemonsDisponiveis[i].nome.ToUpper()}");
                    Console.WriteLine($"Altura: {pokemonsDisponiveis[i].altura}");
                    Console.WriteLine($"Peso: {pokemonsDisponiveis[i].peso}");
                    Console.WriteLine("Habilidades: ");
                    foreach(string habilidade in pokemonsDisponiveis[i].habilidades){
                        Console.Write($"- {habilidade.ToUpper()}\n");
                    }
                }
            }
            Thread.Sleep(1000);
            Console.Write("\nQualquer tecla para voltar: ");
            Console.ReadKey();
        }

        public void AdotarPokemon(string pokemonEscolhido){
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
            Console.WriteLine("\nPokémon adotado com sucesso!\n");
            Thread.Sleep(1000);
            Console.Write("Qualquer tecla para voltar: ");
            Console.ReadKey();
        }

        public void ExibirMeusPokemons(){
            Console.Clear();
            if(meusPokemons.Any()){
                Console.WriteLine("\nMeus pokémons:\n");
                for(int i=0; i<meusPokemons.Count; i++){
                    Console.Write($"- {meusPokemons[i].nome.ToUpper()}");
                    Console.Write($" | {meusPokemons[i].altura} | ");
                    Console.Write($"{meusPokemons[i].peso} | ");
                    foreach(string habilidade in meusPokemons[i].habilidades){
                        Console.Write($"{habilidade.ToUpper()} ");
                    }
                    Console.WriteLine("");
                }
            }
            else{
                Console.WriteLine("Ainda não há pokémons por aqui...");
            }
            Thread.Sleep(1000);
            Console.Write("\nQualquer tecla para voltar: ");
            Console.ReadKey();
        }
    }
}