using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto35.Service;

namespace Projeto35.Models{
    // esta classe tem como objetivo criar métodos que trabalham com a interação do usuário com os pokemons para adoção
    public class ListaPokemons{

        // estou utilizando outras classes como propriedades desta e as instanciando no constructor (para depois utilizá-las nos métodos a baixo)
        public List<PokemonDisponivel> pokemonsDisponiveis { get; set; } // lista de objetos dos pokémons disponívels
        private ListaMeusPokemons listaMeusPokemons { get; set; }

        public ListaPokemons(){
            pokemonsDisponiveis = new List<PokemonDisponivel>();
            listaMeusPokemons = new ListaMeusPokemons();
        }

        // método que irá exibir os nomes dos pokémons dsponíveis através da lista "pokemonsDisponiveis"
        public void ExibirPokemons(){
            Console.Clear();
            for(int i=0; i<pokemonsDisponiveis.Count; i++){ // percorrendo por cada pokémon da lista
                Console.WriteLine($"- {pokemonsDisponiveis[i].nome.ToUpper()}");
            }
        }

        // método que irá exibir todos os detalhes de um pokémon baseado no parâmetro "pokemonEscolhido". Ele representa a escolha do usuário feita no Controller
        public void MostrarDetalhesPokemon(string pokemonEscolhido){
            Console.WriteLine(" ");
            for(int i=0; i<pokemonsDisponiveis.Count; i++){ // percorrendo por cada pokémon da lista
                if(pokemonsDisponiveis[i].nome.Equals(pokemonEscolhido.ToLower())){ // verificando qual nome da lista é igual ao "pokemonEscolhido", para assim poder exibir seus detalhes correspondentes (baseados no mesmo índice)
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

        // método em que o usuário será capaz de adotar um pokémon baseado no parâmetro "pokemonEscolhido"
        public ListaMeusPokemons AdotarPokemon(string pokemonEscolhido){
            for(int i=0; i<pokemonsDisponiveis.Count; i++){ // percorrendo por cada pokémon da lista
                if(pokemonsDisponiveis[i].nome.Equals(pokemonEscolhido.ToLower())){ // verificando qual nome da lista é igual ao "pokemonEscolhido", para assim poder prosseguir com a adoção
                    listaMeusPokemons.meusPokemons.Add(new MeuPokemon{ // assim que ocorrer a verificação, o sistema irá adicionar o pokémon disponível à lista de pokémons do usuário
                        nome = pokemonsDisponiveis[i].nome, // este processo se dá pela seguinte forma: através do metódo "Add", passamos todos os dados que queremos para um novo objeto (MeuPokemon), que se encontra dentro de uma lista (meusPokemons) de outra classe (ListaMeusPokemons)
                        altura = pokemonsDisponiveis[i].altura,
                        pesoOriginal = pokemonsDisponiveis[i].peso,
                        pesoAtual = pokemonsDisponiveis[i].peso,
                        habilidades = pokemonsDisponiveis[i].habilidades
                    });
                    pokemonsDisponiveis.RemoveAt(i); // para evitar com que o mesmo pokémon seja adotado múltiplas vezes, o removemos da lista de pokemonsDisponiveis assim que adotado
                }
            }
            Console.WriteLine("\nPokémon adotado com sucesso!\n");
            Thread.Sleep(1000);
            Console.Write("Qualquer tecla para voltar: ");
            Console.ReadKey();

            return listaMeusPokemons; 
            // este método irá retornar o objeto criado/modificado, que seria a lista com os 
            // pokémons adotados. O valor retornado será utilizado no Controller para que 
            // esta lista de pokemons do usuário (listaMeusPokemons) seja atualizada assim que 
            // o pokemon for adotado (listaMeusPokemons = listaPokemons.AdotarPokemon(pokemonEscolhido);)
        }
    }
}