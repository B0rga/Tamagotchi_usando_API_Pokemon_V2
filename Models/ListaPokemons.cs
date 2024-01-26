using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto35.Service;

namespace Projeto35.Models{
    // esta classe tem como objetivo criar métodos que trabalham com a interação do usuário com os pokemons para adoção
    public class ListaPokemons{
        public List<PokemonDisponivel> pokemonsDisponiveis { get; set; }
        private ListaMeusPokemons listaMeusPokemons { get; set; }

        public ListaPokemons(){
            pokemonsDisponiveis = new List<PokemonDisponivel>();
            listaMeusPokemons = new ListaMeusPokemons();
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
                if(pokemonsDisponiveis[i].nome.Equals(pokemonEscolhido.ToLower())){
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

        public ListaMeusPokemons AdotarPokemon(string pokemonEscolhido){
            for(int i=0; i<pokemonsDisponiveis.Count; i++){
                if(pokemonsDisponiveis[i].nome.Equals(pokemonEscolhido.ToLower())){
                    listaMeusPokemons.meusPokemons.Add(new MeuPokemon{
                        nome = pokemonsDisponiveis[i].nome,
                        altura = pokemonsDisponiveis[i].altura,
                        pesoOriginal = pokemonsDisponiveis[i].peso,
                        pesoAtual = pokemonsDisponiveis[i].peso,
                        habilidades = pokemonsDisponiveis[i].habilidades
                    });
                    pokemonsDisponiveis.RemoveAt(i);
                }
            }
            Console.WriteLine("\nPokémon adotado com sucesso!\n");
            Thread.Sleep(1000);
            Console.Write("Qualquer tecla para voltar: ");
            Console.ReadKey();

            return listaMeusPokemons;
        }
    }
}