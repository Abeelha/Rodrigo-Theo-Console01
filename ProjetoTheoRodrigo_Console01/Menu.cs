namespace ProjetoTheoRodrigo_Console01;

public class Menu
{
    public static void ImprimeTelaPrincipal()
    {
        Console.Clear();
        PrintUtils.PrintHeader();
        Console.WriteLine("\nF1 - Cadastrar documentos");
        Console.WriteLine("F2 - Pesquisar documentos");
        Console.WriteLine("F3 - Listar Documentos");
        Console.WriteLine("");
        Console.WriteLine("F7 - Carregar documentos");
        Console.WriteLine("F8 - Salvar documentos");
        Console.WriteLine("");
        Console.WriteLine("F9 - Sair");

        PrintUtils.PrintFooter(new List<String>());
        escolhaInputTelaPrincipal();
    }

    public static void ImprimeTelaCadastro(List<Registro>? listaRegistro = default, int idRegistro = -1)
    {
        Console.Clear();
        listaRegistro ??= new List<Registro>();

        Registro registroAtual = listaRegistro.Count.Equals(0)
            ? new Registro()
            : listaRegistro.First(r => r.RegistroID == idRegistro);

        PrintUtils.PrintHeader("Cadastro de Documentos");
        Console.WriteLine($"\nRegistro....: {idRegistro}  de {listaRegistro.Count}");
        Console.WriteLine($"Nome........: {registroAtual.Nome}");
        Console.WriteLine($"RG..........:");
        Console.WriteLine($"CPF.........:");
        Console.WriteLine($"Habilitação.:");
        Console.WriteLine($"Tit.Eleitor.:");
        PrintUtils.PrintFooter(new List<String>());
    }

    private static void escolhaInputTelaPrincipal()
    {
        ConsoleKeyInfo tecla;
        while (true)
        {
            tecla = Console.ReadKey();
            if (tecla.Key == ConsoleKey.F1)
            {
                ImprimeTelaCadastro();
            }
            else if (tecla.Key == ConsoleKey.F2)
            {
                Console.WriteLine("PressionandoF2");
                //Pesquisa(); //Acessa a rotina Pesquisa ao pressionar F2
            }
            else if (tecla.Key == ConsoleKey.F3)
            {
                Console.WriteLine("Pressionando F3");
                //Listar(); //Acessa a rotina Listar ao pressionar F3
            }
            else if (tecla.Key == ConsoleKey.F7)
            {
                Console.WriteLine("Pressionando F7");
                Console.Write("Digite o nome do arquivo .dat a ser carregado: ");
                // nomeArquivo = Console.ReadLine(); //Solicita o nome do arquivo a ser carregado
                // gerenciadorRegistro.ListarRegistros(); //Chama a função para carregar a lista de documentos
            }
            else if (tecla.Key == ConsoleKey.F8)
            {
                Console.WriteLine("Preciosnado F8");
                Console.Write("Digite o nome do arquivo .dat a ser gravado: ");
            }
            else if (tecla.Key == ConsoleKey.F9)
            {
                Console.WriteLine(
                    "Msg: Você deseja realmente sair? Pressione Y para confirmar ou N para cancelar."); //Solicita uma confirmação de saída
                tecla = Console.ReadKey();
                if (tecla.KeyChar == 'Y' || tecla.KeyChar == 'y')
                {
                    Environment.Exit(0); //Caso o usuário confirme, finaliza o programa
                }
                else
                {
                    Console.WriteLine(
                        "Ainda estamos trabalhando..."); //Caso o usuário cancele, mantém o programa em execução
                }
            }
        }
    }
}