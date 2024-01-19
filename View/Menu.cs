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
            Console.WriteLine($"1 - Saber mais sobre {pokemonEscolhido}");
            Console.WriteLine($"2 - Adotar {pokemonEscolhido}");
            Console.WriteLine($"3 - Voltar");
            Console.Write("\nOpção: ");
        }

        public void NomeNaoEncontrado(){
            Console.WriteLine("\nPokémon não encontrado.\n");
            Console.Write("Qualquer tecla para voltar: ");
            Console.ReadKey();
        }
    }
}