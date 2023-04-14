namespace ProjetoTheoRodrigo_Console01;

public class Menu
{
    private static String msg = "";
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

        PrintUtils.PrintFooter();
        EscolhaInputTelaPrincipal();
    }

    private static void ImprimeTelaCadastro(List<Registro>? listaRegistro = default, int idRegistro = -1)
    {
        Console.Clear();
        listaRegistro ??= new List<Registro>();

        var registroAtual = listaRegistro.Count.Equals(0)
            ? new Registro()
            : listaRegistro.First(r => r.RegistroID == idRegistro);

        PrintUtils.PrintHeader("Cadastro de Documentos");
        Console.WriteLine($"\nRegistro....: {idRegistro}  de {listaRegistro.Count}");
        Console.WriteLine($"Nome........: {registroAtual.Nome}");
        Console.WriteLine($"RG..........:");
        Console.WriteLine($"CPF.........:");
        Console.WriteLine($"Habilitação.:");
        Console.WriteLine($"Tit.Eleitor.:");
        
        Console.WriteLine("\n <F1> Insere novo <F2> Anterior <F3> Próximo <F5> Editar <F9> Sair");
        PrintUtils.PrintFooter(" ");
    }

    private static void EscolhaInputTelaPrincipal()
    {
        while (true)
        {
            var tecla = Console.ReadKey();
            switch (tecla.Key)
            {
                case ConsoleKey.F1:
                    ImprimeTelaCadastro();
                    break;
                case ConsoleKey.F2:
                    //Pesquisa(); //Acessa a rotina Pesquisa ao pressionar F2
                    break;
                case ConsoleKey.F3:
                    //Listar(); //Acessa a rotina Listar ao pressionar F3
                    break;
                case ConsoleKey.F7:
                    Console.Write("Digite o nome do arquivo .dat a ser carregado: ");
                    // nomeArquivo = Console.ReadLine(); //Solicita o nome do arquivo a ser carregado
                    // gerenciadorRegistro.ListarRegistros(); //Chama a função para carregar a lista de documentos
                    break;
                case ConsoleKey.F8:
                    Console.Write("Digite o nome do arquivo .dat a ser gravado: ");
                    break;
                case ConsoleKey.F9:
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

                        break;
                    }
            }
        }
    }
}