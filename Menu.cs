using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int escolha;

        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Pesquisar em arquivo");
            Console.WriteLine("2 - Analise de Frase");
            Console.WriteLine("3 - Validando Parenteses");
            Console.WriteLine("4 - Trabalhando com Pilha");
            Console.WriteLine("5 - Chomsky");
            Console.WriteLine("6 - Maquina de Turing");
            Console.WriteLine("7 - Ordenar Array com Bubble Sort");
            Console.WriteLine("8 - Sair");
            Console.Write("Escolha uma opcao: ");

            if (int.TryParse(Console.ReadLine(), out escolha))
            {
                if (escolha == 1)
                {
                    PesquisarEmArquivo();
                }
                else if (escolha == 2)
                {
                    AnaliseDeFrase();
                }
                else if (escolha == 3)
                {
                    ValidandoParenteses();
                }
                else if (escolha == 4)
                {
                    TrabalhandoComPilha();
                }
                else if (escolha == 5)
                {
                    Chomsky();
                }
                else if (escolha == 6)
                {
                    ExecutarMaquinaDeTuring();
                }
                else if (escolha == 7)
                {
                    OrdenarArrayComBubbleSort();
                }
                else if (escolha == 8)
                {
                    Console.WriteLine("Saindo...");
                    break;
                }
                else
                {
                    Console.WriteLine("\n Codigo inexistente. Tente novamente.");
                }
            }
            else
            {
                Console.WriteLine("\n Codigo inexistente. Tente novamente.");
            }

            Console.WriteLine();
        } while (true);
    }

    static void PesquisarEmArquivo()
    {
        string caminhoArquivo = "nomes.txt";

        try
        {
            string[] linhas = File.ReadAllLines(caminhoArquivo);

            Console.WriteLine("Nomes que contêm 'ilva':");

            foreach (string linha in linhas)
            {
                if (linha.Contains("ilva"))
                {
                    Console.WriteLine(linha);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocorreu um erro ao ler o arquivo: " + e.Message);
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void AnaliseDeFrase()
    {
        Console.WriteLine("Digite a frase para análise:");
        string frase = Console.ReadLine();

        if (ValidarFrase(frase))
        {
            Console.WriteLine($"A frase '{frase}' é válida de acordo com a gramática especificada.");
        }
        else
        {
            Console.WriteLine($"A frase '{frase}' não é válida de acordo com a gramática especificada.");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static bool ValidarFrase(string frase)
    {
        var artigos = new List<string> { "o", "a" };
        var substantivos = new List<string> { "gato", "casa" };
        var verbos = new List<string> { "correu", "é" };
        var adjetivos = new List<string> { "grande", "pequena" };

        var palavras = frase.ToLower().Split(' ');

        if (palavras.Length != 3)
        {
            Console.WriteLine($"Erro na frase '{frase}'; A frase deve conter um artigo, um substantivo e um verbo/adjetivo.");
            return false;
        }

        var artigoValido = artigos.Contains(palavras[0]);
        var substantivoValido = substantivos.Contains(palavras[1]);
        var verboOuAdjetivoValido = verbos.Contains(palavras[2]) || adjetivos.Contains(palavras[2]);

        if (!artigoValido || !substantivoValido || !verboOuAdjetivoValido)
        {
            Console.WriteLine($"Erro na frase '{frase}'; Estrutura Gramatical Inválida");
            return false;
        }

        return true;
    }

    static void ValidandoParenteses()
    {
        string exemplo1 = "(())";
        string exemplo2 = "(()))";

        Console.WriteLine("Exemplo 1: " + VerificarParenteses(exemplo1));
        Console.WriteLine("Exemplo 2: " + VerificarParenteses(exemplo2));

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static bool VerificarParenteses(string entrada)
    {
        Stack<char> pilha = new Stack<char>();

        foreach (char simbolo in entrada)
        {
            if (simbolo == '(')
            {
                pilha.Push('(');
            }
            else if (simbolo == ')')
            {
                if (pilha.Count == 0 || pilha.Pop() != '(')
                {
                    return false;
                }
            }
        }

        return pilha.Count == 0;
    }

    static void TrabalhandoComPilha()
    {
        Stack<int> stack = new Stack<int>();

        Console.WriteLine("\n=== Menu ===");
        Console.WriteLine("1 - Sair do programa");
        Console.WriteLine("2 - Verificar se Pilha está vazia");
        Console.WriteLine("3 - Empilhar");
        Console.WriteLine("4 - Desempilhar");
        Console.WriteLine("5 - Tamanho da pilha");
        Console.WriteLine("6 - Mostrar topo");
        Console.WriteLine("7 - Limpar pilha");

        Console.Write("\nEscolha uma opção: ");
        int escolha;

        if (!int.TryParse(Console.ReadLine(), out escolha))
        {
            Console.WriteLine("Opção inválida. Por favor, escolha um número de 1 a 7.");
            return;
        }

        switch (escolha)
        {
            case 1:
                return;
            case 2:
                VerificarPilhaVazia(stack);
                break;
            case 3:
                Empilhar(stack);
                break;
            case 4:
                Desempilhar(stack);
                break;
            case 5:
                TamanhoDaPilha(stack);
                break;
            case 6:
                MostrarTopo(stack);
                break;
            case 7:
                LimparPilha(stack);
                break;
            default:
                Console.WriteLine("Opção inválida. Por favor, escolha um número de 1 a 7.");
                break;
        }
    }

    static void VerificarPilhaVazia(Stack<int> stack)
    {
        if (stack.Count == 0)
            Console.WriteLine("A pilha está vazia.");
        else
            Console.WriteLine("A pilha não está vazia.");
    }

    static void Empilhar(Stack<int> stack)
    {
        Console.Write("Digite um número para empilhar: ");
        int numero;

        if (!int.TryParse(Console.ReadLine(), out numero))
        {
            Console.WriteLine("Valor inválido. Apenas números inteiros são permitidos.");
            return;
        }

        stack.Push(numero);
        Console.WriteLine(numero + " empilhado com sucesso.");
    }

    static void Desempilhar(Stack<int> stack)
    {
        if (stack.Count == 0)
        {
            Console.WriteLine("A pilha está vazia. Não é possível desempilhar.");
            return;
        }

        int topo = stack.Pop();
        Console.WriteLine("Topo da pilha (" + topo + ") desempilhado com sucesso.");
    }

    static void TamanhoDaPilha(Stack<int> stack)
    {
        Console.WriteLine("Tamanho da pilha: " + stack.Count);
    }

    static void MostrarTopo(Stack<int> stack)
    {
        if (stack.Count == 0)
            Console.WriteLine("A pilha está vazia. Não há topo para mostrar.");
        else
            Console.WriteLine("Topo da pilha: " + stack.Peek());
    }

    static void LimparPilha(Stack<int> stack)
    {
        stack.Clear();
        Console.WriteLine("Pilha limpa com sucesso.");
    }

    static void Chomsky()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Quem é Noam Chomsky?");
            Console.WriteLine("2 - Qual a sua importância?");
            Console.WriteLine("3 - Qual a sua relação com a computação?");
            Console.WriteLine("4 - Voltar");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Noam Chomsky é um renomado linguista, filósofo, cientista cognitivo, ativista político e autor norte-americano. Ele é conhecido por sua teoria revolucionária da gramática gerativa, que propõe que os seres humanos têm uma capacidade inata para adquirir linguagem. Além disso, Chomsky é um crítico ferrenho das políticas externas dos Estados Unidos e de outros países, bem como das estruturas de poder global, sendo conhecido por sua postura crítica em relação ao imperialismo, militarismo, capitalismo e mídia corporativa.");
                    Console.WriteLine("Como autor prolífico, Chomsky escreveu mais de cem livros sobre uma ampla gama de assuntos, incluindo linguística, política, filosofia e mídia. Sua influência vai além da academia, impactando movimentos sociais em todo o mundo. Admirado por sua inteligência e coragem em questionar o status quo, Chomsky é uma figura controversa, sendo criticado por alguns por suas posições políticas radicais, mas é inegavelmente uma das vozes mais influentes no debate intelectual contemporâneo.");
                    break;
                case 2:
                    Console.WriteLine("A importância de Noam Chomsky reside em sua capacidade de transcender fronteiras disciplinares, oferecendo contribuições significativas tanto para a linguística quanto para a política e a filosofia. Sua teoria da gramática gerativa revolucionou o campo da linguística, desafiando paradigmas estabelecidos e influenciando gerações de estudiosos. Além disso, sua incansável crítica às injustiças sociais, políticas externas agressivas e estruturas de poder global o tornou uma voz proeminente na defesa dos direitos humanos e na luta por uma sociedade mais justa e igualitária, inspirando ativistas em todo o mundo. Sua capacidade de unir rigor intelectual com um compromisso fervoroso com a justiça social o torna uma figura singular e profundamente relevante no cenário intelectual contemporâneo.");
                    break;
                case 3:
                    Console.WriteLine("A relação de Noam Chomsky com a computação é principalmente indireta, mas significativa. Sua teoria da gramática gerativa influenciou o desenvolvimento de linguagens de programação e teorias da computação, especialmente no campo da inteligência artificial e do processamento de linguagem natural. Os conceitos de estruturas sintáticas e regras gramaticais propostos por Chomsky forneceram uma base teórica importante para o desenvolvimento de algoritmos de análise linguística e sistemas de tradução automática. Além disso, suas ideias sobre a natureza da mente humana e da linguagem têm influenciado pesquisas em áreas como aprendizado de máquina e modelagem computacional da cognição. Embora Chomsky não seja um especialista em computação, suas contribuições para a compreensão da linguagem humana tiveram um impacto duradouro no campo da ciência da computação, especialmente em áreas relacionadas à linguagem e à inteligência artificial.");
                    break;
                case 4:
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma das opções listadas.");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void ExecutarMaquinaDeTuring()
    {
        TuringMachine tm = new TuringMachine();
        Console.WriteLine("Digite o número binário de entrada:");
        string input = Console.ReadLine().Trim();

        tm.SetInput(input);
        tm.Run();
    }

    static void OrdenarArrayComBubbleSort()
    {
        int[] array = { 64, 34, 25, 12, 22, 11, 90 };

        Console.WriteLine("Array original:");
        ImprimirArray(array);

        BubbleSort(array);

        Console.WriteLine("Array ordenado:");
        ImprimirArray(array);

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void ImprimirArray(int[] array)
    {
        Console.WriteLine(string.Join(", ", array));
    }

    static void BubbleSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Troca os elementos array[j] e array[j+1]
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
}

class TuringMachine
{
    private Dictionary<Tuple<int, char>, Tuple<int, char, char>> transitions;
    private HashSet<int> acceptingStates;
    private int currentState;
    private int tapeHeadIndex;
    private List<char> tape;

    public TuringMachine()
    {
        transitions = new Dictionary<Tuple<int, char>, Tuple<int, char, char>>();
        acceptingStates = new HashSet<int>();

        // Definindo as transições
        AddTransition(0, '0', 0, '1', 'R');
        AddTransition(0, '1', 0, '0', 'R');
        AddTransition(0, ' ', 1, ' ', 'L');

        // Definindo o estado de aceitação
        acceptingStates.Add(1);

        currentState = 0;
        tapeHeadIndex = 0;
        tape = new List<char>();
    }

    public void AddTransition(int fromState, char readSymbol, int toState, char writeSymbol, char moveDirection)
    {
        transitions[new Tuple<int, char>(fromState, readSymbol)] = new Tuple<int, char, char>(toState, writeSymbol, moveDirection);
    }

    public void SetInput(string input)
    {
        tape.Clear();
        tape.AddRange(input);
    }

    public void Run()
    {
        while (!acceptingStates.Contains(currentState))
        {
            char currentSymbol = tapeHeadIndex < tape.Count ? tape[tapeHeadIndex] : ' ';
            Tuple<int, char, char> transition = transitions[new Tuple<int, char>(currentState, currentSymbol)];
            currentState = transition.Item1;
            tape[tapeHeadIndex] = transition.Item2;

            if (transition.Item3 == 'R')
            {
                tapeHeadIndex++;
            }
            else if (transition.Item3 == 'L')
            {
                tapeHeadIndex--;
            }

            if (tapeHeadIndex < 0)
            {
                tape.Insert(0, ' ');
                tapeHeadIndex = 0;
            }
            else if (tapeHeadIndex == tape.Count)
            {
                tape.Add(' ');
            }
        }

        Console.WriteLine("Resultado: " + string.Join("", tape));
    }
}
