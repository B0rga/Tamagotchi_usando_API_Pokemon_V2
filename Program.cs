
using System.Text.Json;
using Projeto35.Controller;
using Projeto35.Models;
using Projeto35.Service;
using RestSharp;

class Program{
    static void Main(){
        PokemonController pokemonController = new PokemonController();
        pokemonController.Jogar();        
    }
}