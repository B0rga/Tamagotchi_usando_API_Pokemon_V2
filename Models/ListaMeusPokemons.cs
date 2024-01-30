using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto35.Models{

    // esta classe representa toda a interatividade do usuário com seus pokémons
    public class ListaMeusPokemons{

        public List<MeuPokemon> meusPokemons { get; set; } // lista de objetos dos pokemons adotados pelo usuário

        public ListaMeusPokemons(){
            meusPokemons = new List<MeuPokemon>(); // é preciso instanciar a classe no constructor
        }

        public bool ExibirMeusPokemons(){ // método booleano que lista todos os pokémons do usuário, mostrando alguns de seus detalhes
            Console.Clear();
            if(meusPokemons.Any()){ //verificação se existe algum pokémon adotado para ser exibido
                Console.WriteLine("\nMeus pokémons:\n");
                for(int i=0; i<meusPokemons.Count; i++){ // percorrendo por todos pokémons adotados da lista para exibir seus detalhes correspondentes (baseados no índice)
                    Console.Write($"- {meusPokemons[i].nome.ToUpper()}"); // meusPokemons[i] representa cada pokémon da lista
                    Console.Write($" | Idade: {meusPokemons[i].idade}");
                    Console.Write($" | Altura: {meusPokemons[i].altura} | ");
                    Console.Write($"Peso: {meusPokemons[i].pesoAtual} | ");
                    foreach(string habilidade in meusPokemons[i].habilidades){
                        Console.Write($"{habilidade.ToUpper()} ");
                    }
                    Console.WriteLine("");
                }
                Thread.Sleep(1000);
                return true; // se houver pokémons na lista, retorna true
            }
            else{
                Console.WriteLine("\nAinda não há pokémons por aqui...");
                Thread.Sleep(1000);
                Console.Write("\nQualquer tecla para voltar: ");
                Console.ReadKey();
                return false; 
                // se NÃO houver pokémons na lista, retorna false. Este valor será útil para o
                // Controller: 
                // if(existemPokemonsAdotados == true){
                // Console.Write("\nInsira o nome de um pokémon (ou qualquer valor para sair): ");
                // pokemonEscolhido = Console.ReadLine();
            }
        }
        
        // O método abaixo é importante pois além de mostrar detalhes do pokémon, ele
        // randomiza o aumento da idade, altura, fome, tristeza e fraqueza do pokémon.
        // O aumento da fome causa a queda de peso do mascote. Se perder metade do peso
        // original, o pokemons vem a falecer. Além da fome, atributos como tristeza e fraqueza
        // virão iminentemente, o que incentiva o usuário a ter um maior cuidado e atenção
        // com seu mascote.
        public void MostrarDetalhesMeuPokemon(string pokemonEscolhido){
            Console.Clear();
            Random randNum = new Random(); // classe que gera números aleatórios

            Console.WriteLine(" ");
            for(int i=0; i<meusPokemons.Count; i++){                

                if(meusPokemons[i].nome.Equals(pokemonEscolhido.ToLower())){ // verifica se o nome do pokemonEscolhido existe na lista

                    if(meusPokemons[i].pesoAtual<meusPokemons[i].pesoOriginal/2){ // verifica se o pokémon está com um peso aceitável
                        Console.WriteLine($"\n{meusPokemons[i].nome} perdeu muito peso e por isso virou estrelinha ( X-X)");
                        meusPokemons.RemoveAt(i);

                    }else{
                        // Aumento de idade e altura ==========================================
                        meusPokemons[i].idade += randNum.Next(0,2); // aumento de 0 a 2
                        meusPokemons[i].altura += randNum.Next(0,2);

                        // Aumento da fome ====================================================
                        meusPokemons[i].fome += randNum.Next(0,15); // aumento de 0 a 15

                        if(meusPokemons[i].fome>=10){ // se a fome passar do valor 10, o peso atual diminui
                            meusPokemons[i].pesoAtual -= randNum.Next(10,12); // diminuição do peso
                            meusPokemons[i].fome = 0; 
                            // a fome reseta assim que passar de 10. Isso signfica que, sempre que ela
                            // passar deste valor, o peso irá diminuir. Desta forma um loop é criado, 
                            // o que incentiva o usuário a alimentar seu mascote regularmente
                        }

                        // Aumento da tristeza ================================================
                        meusPokemons[i].tristeza += randNum.Next(0,8); // aumento de 0 a 8

                        // Aumento da fraqueza ================================================
                        meusPokemons[i].fraqueza += randNum.Next(0,8); // aumento de 0 a 8

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
                        if(meusPokemons[i].pesoOriginal > meusPokemons[i].pesoAtual){ // caso o pokémon esteja abaixo do peso, o aviso será disparado
                            Console.WriteLine($"{meusPokemons[i].nome} está com fome! ( '~')");
                        }
                        if(meusPokemons[i].tristeza>=10){ // se a tristeza passar de 10, um aviso será disparado. É preciso brincar com o pokémon
                            Console.WriteLine($"{meusPokemons[i].nome} está triste! ( T_T)");
                        }
                        if(meusPokemons[i].fraqueza>=10){ // se a fraqueza passar de 10, um aviso será disparado. É preciso treinar o pokémon
                            Console.WriteLine($"{meusPokemons[i].nome} está fraco! (; -_-)");
                        }
                        if(meusPokemons[i].pesoAtual >= meusPokemons[i].pesoOriginal && meusPokemons[i].tristeza<10 && meusPokemons[i].fraqueza<10){
                            Console.WriteLine($"Está tudo ok com {meusPokemons[i].nome}! ( ^-^)");
                            // se estiver tudo ok, não haverá nenhum aviso
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
            Random randNum = new Random(); // classe que randomiza valores
            int pontosPeso; 
            int pontosAlegria;
            // estes pontos servirão para receber os valores randomizados, que serão atribuídos
            // aos atributos e também exibidos na tela (para maior entendimento do usuário)

            for(int i=0; i<meusPokemons.Count; i++){
                if(meusPokemons[i].nome.Equals(pokemonEscolhido)){
                    pontosPeso = randNum.Next(5,14); // recebendo valores de 5 a 14
                    pontosAlegria = randNum.Next(1,3); // recebendo valores de 1 a 3
                    meusPokemons[i].pesoAtual+=pontosPeso; // aumentando o peso do pokémon escolhido (com base nos pontos de peso obtidos)
                    meusPokemons[i].tristeza-=pontosAlegria; // diminuindo a tristeza do pokémon escolhido (com base nos pontos de alegria obtidos)

                    for(int j=1; j<5; j++){
                        if(j%2==0){
                            Console.WriteLine($"\nAlimentando {meusPokemons[i].nome}...");
                            Console.WriteLine("\n( ^-^)");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }else{
                            Console.WriteLine($"\nAlimentando {meusPokemons[i].nome}...");
                            Console.WriteLine("\n( ^O^)*");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                    }

                    Console.Clear();
                    Console.WriteLine($"\n{pokemonEscolhido} foi alimentado! ");
                    Console.WriteLine("\n( 'w')");
                    Console.WriteLine($"\nPeso +{pontosPeso}"); // exibindo peso obtido
                    Console.WriteLine($"Alegria +{pontosAlegria}"); // exibindo alegria obtida
                    
                    Thread.Sleep(1000);
                    Console.Write("\nQualquer tecla para voltar: ");
                    Console.ReadKey();
                }
            }
        }

        public void BrincarComMeuPokemon(string pokemonEscolhido){
            Console.Clear();
            Random randNum = new Random(); // classe que randomiza valores
            int pontosAlegria;
            int pontosFome;
            // estes pontos servirão para receber os valores randomizados, que serão atribuídos
            // aos atributos e também exibidos na tela (para maior entendimento do usuário)

            for(int i=0; i<meusPokemons.Count; i++){
                if(meusPokemons[i].nome.Equals(pokemonEscolhido)){
                    pontosAlegria = randNum.Next(10,20); // recebendo valores de 10 a 20
                    pontosFome = randNum.Next(2,4); // recebendo valores de 2 a 4
                    meusPokemons[i].tristeza-=pontosAlegria; // diminuindo a tristeza do pokémon escolhido (com base nos pontos de alegria obtidos)
                    meusPokemons[i].fome+=pontosFome; // aumentando a fome do pokémon escolhido (com base nos pontos de fome obtidos)

                    for(int j=1; j<5; j++){
                        if(j%2==0){
                            Console.WriteLine($"\nBrincando com {meusPokemons[i].nome}...");
                            Console.WriteLine("\n( ^v^)");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }else{
                            Console.WriteLine($"\nBrincando com {meusPokemons[i].nome}...");
                            Console.WriteLine("\n( 'V')");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                    }

                    Console.Clear();
                    Console.WriteLine($"\n{pokemonEscolhido} gostou de ter brincado! ");
                    Console.WriteLine("\n( 'U')/");
                    Console.WriteLine($"\nAlegria +{pontosAlegria}"); // exibindo peso obtido
                    Console.WriteLine($"Fome +{pontosFome}"); // exibindo fome obtida
                    
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

                    for(int j=1; j<5; j++){
                        if(j%2==0){
                            Console.WriteLine($"\nTreinando {meusPokemons[i].nome}...");
                            Console.WriteLine("\n( `n´)_");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }else{
                            Console.WriteLine($"\nTreinando {meusPokemons[i].nome}...");
                            Console.WriteLine("\n( `o´)_/");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                    }

                    Console.Clear();
                    Console.WriteLine($"\n{pokemonEscolhido} está ficando mais forte! ");
                    Console.WriteLine("\n<( `V´)>");
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