using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto35.Models{
    public class ListaMeusPokemons{
        public List<MeuPokemon> meusPokemons { get; set; }

        public ListaMeusPokemons(){
            meusPokemons = new List<MeuPokemon>();
        }

        public bool ExibirMeusPokemons(){
            Console.Clear();
            if(meusPokemons.Any()){
                Console.WriteLine("\nMeus pokémons:\n");
                for(int i=0; i<meusPokemons.Count; i++){
                    Console.Write($"- {meusPokemons[i].nome.ToUpper()}");
                    Console.Write($" | Idade: {meusPokemons[i].idade}");
                    Console.Write($" | Altura: {meusPokemons[i].altura} | ");
                    Console.Write($"Peso: {meusPokemons[i].pesoAtual} | ");
                    foreach(string habilidade in meusPokemons[i].habilidades){
                        Console.Write($"{habilidade.ToUpper()} ");
                    }
                    Console.WriteLine("");
                }
                Thread.Sleep(1000);
                return true;
            }
            else{
                Console.WriteLine("\nAinda não há pokémons por aqui...");
                Thread.Sleep(1000);
                Console.Write("\nQualquer tecla para voltar: ");
                Console.ReadKey();
                return false;
            }
        }

        public void MostrarDetalhesMeuPokemon(string pokemonEscolhido){
            Console.Clear();
            Random randNum = new Random(); // classe que gera números aleatórios

            Console.WriteLine(" ");
            for(int i=0; i<meusPokemons.Count; i++){                

                if(meusPokemons[i].nome.Equals(pokemonEscolhido.ToLower())){

                    if(meusPokemons[i].pesoAtual<meusPokemons[i].pesoOriginal/2){
                        Console.WriteLine($"\nBulbasaur perdeu muito peso e por isso virou estrelinha ( X ͜ʖ X )");
                        meusPokemons.RemoveAt(i);

                    }else{
                        // Aumento de idade e altura ==========================================
                        meusPokemons[i].idade += randNum.Next(0,2);
                        meusPokemons[i].altura += randNum.Next(0,2);

                        // Aumento da fome ====================================================
                        meusPokemons[i].fome += randNum.Next(0,15);

                        if(meusPokemons[i].fome>=10){
                            meusPokemons[i].pesoAtual -= randNum.Next(10,12);
                            meusPokemons[i].fome = 0;
                        }

                        // Aumento da tristeza ================================================
                        meusPokemons[i].tristeza += randNum.Next(0,8);

                        // Aumento da fraqueza ================================================
                        meusPokemons[i].fraqueza += randNum.Next(0,8);

                        // Mostrando dados do pokemon =========================================
                        Console.WriteLine($"Nome: {meusPokemons[i].nome.ToUpper()}");
                        if(meusPokemons[i].idade==1){
                            Console.WriteLine($"Idade: {meusPokemons[i].idade} ano");
                        }else{
                            Console.WriteLine($"Idade: {meusPokemons[i].idade} anos");
                        }                    
                        Console.WriteLine($"Altura: {meusPokemons[i].altura}");
                        Console.WriteLine($"Peso: {meusPokemons[i].pesoAtual}\n");

                        // Alertas do Pokemon =================================================
                        if(meusPokemons[i].pesoOriginal > meusPokemons[i].pesoAtual){
                            Console.WriteLine($"{meusPokemons[i].nome} está com fome! (ಠ╭╮ಠ)");
                        }
                        if(meusPokemons[i].tristeza>=10){
                            Console.WriteLine($"{meusPokemons[i].nome} está triste! (ಥ ﹏ಥ)");
                        }
                        if(meusPokemons[i].fraqueza>=10){
                            Console.WriteLine($"{meusPokemons[i].nome} está fraco! (; -_-)");
                        }
                        if(meusPokemons[i].pesoAtual >= meusPokemons[i].pesoOriginal && meusPokemons[i].tristeza<10 && meusPokemons[i].fraqueza<10){
                            Console.WriteLine($"Está tudo ok com {meusPokemons[i].nome}! (👍 ͡° ͜ʖ ͡°)");
                        }
                    }
                }
            }
            Thread.Sleep(1000);
            Console.Write("\nQualquer tecla para voltar: ");
            Console.ReadKey();
        }

        public void AlimentarMeuPokemon(string pokemonEscolhido){
            Console.Clear();
            Random randNum = new Random();
            int pontosPeso;
            int pontosAlegria;

            for(int i=0; i<meusPokemons.Count; i++){
                if(meusPokemons[i].nome.Equals(pokemonEscolhido)){
                    pontosPeso = randNum.Next(5,12);
                    pontosAlegria = randNum.Next(1,3);
                    meusPokemons[i].pesoAtual+=pontosPeso;
                    meusPokemons[i].tristeza-=pontosAlegria;

                    Console.WriteLine("\n༼ つ ˘ڡ˘ ༽つ🍔");
                    Console.Write($"\nAlimentando {meusPokemons[i].nome}");
                    for(int j=0; j<3; j++){
                        Console.Write(".");
                        Thread.Sleep(1000);
                    }

                    Console.Clear();
                    Console.WriteLine("\n༼ 👍 ͡° ͜ʖ ͡° ༽");
                    Console.WriteLine($"\n{pokemonEscolhido} foi alimentado! ");
                    Console.WriteLine($"\nPeso +{pontosPeso}");
                    Console.WriteLine($"Alegria +{pontosAlegria}");
                    
                    Thread.Sleep(1000);
                    Console.Write("\nQualquer tecla para voltar: ");
                    Console.ReadKey();
                }
            }
        }

        public void BrincarComMeuPokemon(string pokemonEscolhido){
            Console.Clear();
            Random randNum = new Random();
            int pontosAlegria;
            int pontosFome;

            for(int i=0; i<meusPokemons.Count; i++){
                if(meusPokemons[i].nome.Equals(pokemonEscolhido)){
                    pontosAlegria = randNum.Next(10,20);
                    pontosFome = randNum.Next(2,4);
                    meusPokemons[i].tristeza-=pontosAlegria;
                    meusPokemons[i].fome+=pontosFome;

                    Console.WriteLine("\n༼ つ ◕ ‿ ◕ ༽つ🕹️");
                    Console.Write($"\nBrincando com {meusPokemons[i].nome}");
                    for(int j=0; j<3; j++){
                        Console.Write(".");
                        Thread.Sleep(1000);
                    }

                    Console.Clear();
                    Console.WriteLine("\n༼ 👍｡ ͡° ͜ʖ ͡°｡ ༽");
                    Console.WriteLine($"\n{pokemonEscolhido} gostou de ter brincado! ");
                    Console.WriteLine($"\nAlegria +{pontosAlegria}");
                    Console.WriteLine($"Fome +{pontosFome}");
                    
                    Thread.Sleep(1000);
                    Console.Write("\nQualquer tecla para voltar: ");
                    Console.ReadKey();
                }
            }
        }

        public void TreinarMeuPokemon(string pokemonEscolhido){
            Console.Clear();
            Random randNum = new Random();
            int pontosForca;
            int pontosAlegria;
            int pontosFome;

            for(int i=0; i<meusPokemons.Count; i++){
                if(meusPokemons[i].nome.Equals(pokemonEscolhido)){
                    pontosForca = randNum.Next(10,20);
                    pontosAlegria = randNum.Next(1,3);
                    pontosFome = randNum.Next(2,4);
                    meusPokemons[i].fraqueza-=pontosForca;
                    meusPokemons[i].tristeza-=pontosAlegria;
                    meusPokemons[i].fome+=pontosFome;

                    Console.WriteLine("\n༼ ᕙ ‶⇀`‸´↼ ༽ᕗ");
                    Console.Write($"\nTreinando com {meusPokemons[i].nome}");
                    for(int j=0; j<3; j++){
                        Console.Write(".");
                        Thread.Sleep(1000);
                    }

                    Console.Clear();
                    Console.WriteLine("\n༼ 💪 ͡▀ ͜͞ʖ▀ ༽=/̵͇̿̿/’̿’̿ ̿ ̿̿ ̿̿ ̿̿");
                    Console.WriteLine($"\n{pokemonEscolhido} está ficando mais forte! ");
                    Console.WriteLine($"\nForça +{pontosForca}");
                    Console.WriteLine($"Alegria +{pontosAlegria}");
                    Console.WriteLine($"Fome +{pontosFome}");
                    
                    Thread.Sleep(1000);
                    Console.Write("\nQualquer tecla para voltar: ");
                    Console.ReadKey();
                }
            }
        }
    }
}