using System;
using System.Collections.Generic;

class Program
{
    // Listas de tarefas
    static List<string> aFazer = new List<string>();
    static List<string> emProgresso = new List<string>();
    static List<string> concluido = new List<string>();

    static void Main(string[] args)
    {
        while (true)
        {
            ExibirMenu();
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    AdicionarTarefa();
                    break;
                case 2:
                    ExibirTarefas();
                    break;
                case 3:
                    MoverTarefa();
                    break;
                case 4:
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }

    // Método para exibir o menu
    static void ExibirMenu()
    {
        Console.WriteLine("1 - Adicionar nova tarefa");
        Console.WriteLine("2 - Exibir tarefas");
        Console.WriteLine("3 - Mover tarefa");
        Console.WriteLine("4 - Sair");
        Console.Write("Escolha uma opção: ");
    }

    // Método para adicionar nova tarefa
    static void AdicionarTarefa()
    {
        Console.Write("\nDigite o nome da nova tarefa: ");
        string tarefa = Console.ReadLine();
        aFazer.Add(tarefa);
        Console.WriteLine("\nTarefa adicionada com sucesso!");
    }

    // Método para exibir as tarefas
    static void ExibirTarefas()
    {
        Console.WriteLine("\nTarefas A Fazer:");
        ExibirLista(aFazer);

        Console.WriteLine("\nTarefas Em Progresso:");
        ExibirLista(emProgresso);

        Console.WriteLine("\nTarefas Concluídas:");
        ExibirLista(concluido);
    }

    // Método auxiliar para exibir uma lista de tarefas
    static void ExibirLista(List<string> lista)
    {
        if (lista.Count == 0)
        {
            Console.WriteLine("\nNenhuma tarefa");
        }
        else
        {
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {lista[i]}");
            }
        }
    }

    // Método para mover tarefas
    static void MoverTarefa()
    {
        Console.WriteLine("\nEscolha a lista da qual deseja mover a tarefa:");
        Console.WriteLine("\n1 - A Fazer -> Em Progresso");
        Console.WriteLine("\n2 - Em Progresso -> Concluído");
        Console.WriteLine("\n3 - Concluído -> Em Progresso");
        Console.WriteLine("\n4 - A Fazer -> Concluído"); // Nova opção
        int origem = int.Parse(Console.ReadLine());

        List<string> listaOrigem = null;
        List<string> listaDestino = null;

        switch (origem)
        {
            case 1:
                listaOrigem = aFazer;
                listaDestino = emProgresso;
                break;
            case 2:
                listaOrigem = emProgresso;
                listaDestino = concluido;
                break;
            case 3:
                listaOrigem = concluido;
                listaDestino = emProgresso;
                break;
            case 4:
                listaOrigem = aFazer;
                listaDestino = concluido;
                break;
            default:
                Console.WriteLine("\nOpção inválida.");
                return;
        }

        if (listaOrigem.Count == 0)
        {
            Console.WriteLine("\nNão há tarefas para mover.");
            return;
        }

        Console.WriteLine("\nEscolha o número da tarefa que deseja mover:");
        ExibirLista(listaOrigem);
        int indiceTarefa = int.Parse(Console.ReadLine()) - 1;

        if (indiceTarefa < 0 || indiceTarefa >= listaOrigem.Count)
        {
            Console.WriteLine("\nNúmero inválido.");
            return;
        }

        // Move a tarefa
        string tarefa = listaOrigem[indiceTarefa];
        listaOrigem.RemoveAt(indiceTarefa);
        listaDestino.Add(tarefa);

        Console.WriteLine("\nTarefa movida com sucesso!");
    }
}
