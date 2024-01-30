using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Projeto35.Models;
using Projeto35.Service;

namespace Projeto35.Controller{
    public class PokemonController{
        
        // a classe Controller é responsável por concentrar todas as outras classes e funcionalidades
        // em um só lugar. Estou instanciando as classes necessárias para obter os dados da API,
        // adotar pokémons e também desempenhar o papel de Tamagotchi.
        private Menu menu { get; set; }
        private PokemonAPIService pokemonAPIService { get; set; }
        private ListaPokemons listaPokemons { get; set; }
        private ListaMeusPokemons listaMeusPokemons { get; set; }
        
        // instanciando classes / criando novos objetos
        public PokemonController(){
            menu = new Menu();
            pokemonAPIService = new PokemonAPIService();
            listaMeusPokemons = new ListaMeusPokemons();
            
            // o novo objeto de ListaPokemons irá obter os valores retornados pelo método da classe PokemonAPIService
            listaPokemons = pokemonAPIService.ObterPokemons();
        }

        public void Jogar(){

            string nomeUsuario;
            string pokemonEscolhido; // variável que representará o nome de um pokémon que o usuário deverá escolher
            bool menuInicialAtivo = true; // variável booleana responsável por manter o menu principal ativo
            bool menuAdocaoAtivo; // variável responsável por manter o menu de adoção ativo
            bool menuMeuPokemonAtivo; // variável responsável por manter o menu do Tamagotchi ativo
            bool pokemonEstaNalista; // variável que verifica se o nome do pokemonEscolhido se encontra em alguma lista (seja na lista de pokemonsDisponiveis ou meusPokemons)
            bool existemPokemonsAdotados; // variável que verifica se a lista de meusPokemons está ou não vazia

            Console.Clear();
            Console.Write("Sejam bem-vindo(a) a nossa adoção de mascotes!\nPrimeiro, insira seu nome: ");
            nomeUsuario = Console.ReadLine();
            while(nomeUsuario == string.Empty){ // impede com que o usuário deixe seu nome em branco
                Console.Clear();
                Console.WriteLine("O campo do nome deve ser preenchido!");
                Console.Write("Insira seu nome: ");
                nomeUsuario = Console.ReadLine();
            }

            while(menuInicialAtivo==true){ // menu inicial se encontra ativo enquanto for true
                
                pokemonEstaNalista = false; // por default, pokemonEstaNalista deve começar false
                menuAdocaoAtivo = true; // o menu de adoção deve sempre começar true para poder ser executado mais de uma vez
                menuMeuPokemonAtivo = true; // o menu de Tamagotchi deve sempre começar true para poder ser executado mais de uma vez
                existemPokemonsAdotados = false; // por default, existemPokemonsAdotados deve começar false

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

                        if(pokemonEstaNalista == true){ // caso for true; o processo de adoção poderá ser continuado
                            while(menuAdocaoAtivo == true){
                                menu.MenuAdocao(nomeUsuario, pokemonEscolhido); // exibição do menu de adoção
                                switch(Console.ReadLine()){
                                    case "1":
                                        // mostrar detalhes do pokemonEscolhido
                                        listaPokemons.MostrarDetalhesPokemon(pokemonEscolhido);
                                        break;
                                    case "2":
                                        // adotar pokemonEscolhido
                                        listaMeusPokemons = listaPokemons.AdotarPokemon(pokemonEscolhido); // objeto "listaMeusPokemons" está recebendo o pokémon escolhido através do método AdotarPokemon
                                        menuAdocaoAtivo = false; // menu de adoção se encerra automaticamente
                                        break;
                                    case "3":
                                        // saindo do menu de adoção
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
                            // método que notifica o usuário de que o nome do pokémon inserido não está na lista
                            menu.NomeNaoEncontrado(pokemonEscolhido);
                        }
                        break;
                    case "2":
                        // no processo abaixo eu uso uma variável to tipo bool para verificar se há um pokémon adotado, antes de realizar qualquer outra ação
                        existemPokemonsAdotados = listaMeusPokemons.ExibirMeusPokemons();
                        if(existemPokemonsAdotados == true){ // se for true, a lista de pokémons do usuário será exibida
                            Console.Write("\nInsira o nome de um pokémon (ou qualquer valor para sair): ");
                            pokemonEscolhido = Console.ReadLine();

                            // verificação se o nome do pokemon inserido existe:
                            foreach(var pokemon in listaMeusPokemons.meusPokemons){
                                if(pokemonEscolhido.ToUpper().Equals(pokemon.nome.ToUpper())){
                                    pokemonEstaNalista = true;
                                }
                            }

                            if(pokemonEstaNalista == true){
                                while(menuMeuPokemonAtivo == true){
                                    menu.MeuPokemon(nomeUsuario, pokemonEscolhido); // exibição do menu de Tamacotchi
                                    switch(Console.ReadLine()){
                                        case "1":
                                            // mostrar detalhes do pokémon escolhido
                                            listaMeusPokemons.MostrarDetalhesMeuPokemon(pokemonEscolhido);
                                            break;
                                        case "2":
                                            // alimentar do pokémon escolhido
                                            listaMeusPokemons.AlimentarMeuPokemon(pokemonEscolhido);
                                            break;
                                        case "3":
                                            // brincar com pokémon escolhido
                                            listaMeusPokemons.BrincarComMeuPokemon(pokemonEscolhido);
                                            break;
                                        case "4":
                                            // treinar pokémon escolhido
                                            listaMeusPokemons.TreinarMeuPokemon(pokemonEscolhido);
                                            break;
                                        case "5": 
                                            // saindo do menu de Tamagotchi
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