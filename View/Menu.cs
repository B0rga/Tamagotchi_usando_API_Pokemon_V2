using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto35.Models{
    public class Menu{

        public void MenuInicial(string nomeUsuario){
            Console.Clear();
            Console.WriteLine($"========== MENU PRINCIPAL ==========\n");
            Console.WriteLine($"{nomeUsuario}, você deseja:\n");
            Console.WriteLine("1 - Adotar um mascote");
            Console.WriteLine("2 - Ver meus mascotes");
            Console.WriteLine("3 - Sair");
            Console.Write("\nOpção: ");
        }

        public void MenuAdocao(string nomeUsuario, string pokemonEscolhido){
            Console.Clear();
            Console.WriteLine($"========== MENU DE ADOÇÃO ==========\n");
            Console.WriteLine($"{nomeUsuario}, você deseja:\n");
            Console.WriteLine($"1 - Saber mais sobre {pokemonEscolhido.ToLower()}");
            Console.WriteLine($"2 - Adotar {pokemonEscolhido.ToLower()}");
            Console.WriteLine($"3 - Voltar");
            Console.Write("\nOpção: ");
        }

        public void NomeNaoEncontrado(string pokemonEscolhido){
            Console.WriteLine($"\nPokémon '{pokemonEscolhido}' não encontrado na lista.\n");
            Thread.Sleep(1000);
            Console.Write("Qualquer tecla para voltar: ");
            Console.ReadKey();
        }

        public void MeuPokemon(string nomeUsuario, string pokemonEscolhido){
            Console.Clear();
            Console.WriteLine($"========== {pokemonEscolhido.ToUpper()} ==========\n");
            Console.WriteLine($"{nomeUsuario}, você deseja:\n");
            Console.WriteLine($"1 - Saber como {pokemonEscolhido.ToLower()} está");
            Console.WriteLine($"2 - Alimentar {pokemonEscolhido.ToLower()}");
            Console.WriteLine($"3 - Brincar com {pokemonEscolhido.ToLower()}");
            Console.WriteLine($"4 - Treinar {pokemonEscolhido.ToLower()}");
            Console.WriteLine($"5 - Voltar");
            Console.Write("\nOpção: ");
        }
    }
}