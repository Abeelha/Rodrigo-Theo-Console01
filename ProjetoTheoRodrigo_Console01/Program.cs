using System;
using System.IO;
using System.Collections.Generic;

//Autors : Theodoro Bertol, Rodrigo Izidoro

namespace ProjetoTheoRodrigo_Console01
{
    class Program
    {
        static void Main(string[] args)
        {
            CriaTela("Sistema de Quinta ");
            EscolhaInput();
        }

        public class Registro
        {
            public int RegistroID { get; set; }
            public string Nome { get; set; }    
            public string CPF { get; set; }
            public string RG { get; set; }
            public string Habilitacao { get; set; }
            public string Titulo { get; set; }
        }

        //Criação da interface
        class Menuprincipal
        {
            public static void imprimeTelaPrincipal()
            {
                PrintUtils.printHeader();
                Console.WriteLine("\nF1 - Cadastrar documentos");
                Console.WriteLine("F2 - Pesquisar documentos");
                Console.WriteLine("F3 - Listar Documentos");
                Console.WriteLine("");
                Console.WriteLine("F7 - Carregar documentos");
                Console.WriteLine("F8 - Salvar documentos");
                Console.WriteLine("");
                Console.WriteLine("F9 - Sair");

                PrintUtils.printFooter(new List<String>());

                ConsoleKeyInfo tecla;
                while (true)
                {
                    tecla = Console.ReadKey();
                    switch (tecla.Key)
                    {
                        case ConsoleKey.F1:
                            Console.WriteLine("Tela de Cadastro");
                            break;
                        default:
                            Console.WriteLine("Opção inválida, por favor utilize uma das opções mencionadas");
                            break;
                    }
                }
            }
        }

        class PrintUtils
        {
            private static String ajusteTexto(String titulo, int tamanho)
            {
                return titulo.Length >= tamanho ? titulo.Substring(0, 25) : titulo + " ".PadRight(tamanho - titulo.Length);
            }

            public static void printHeader(String titulo = "Sistema de Quinta")
            {
                Console.WriteLine("{0, -25}{1, -45}{2, 10}\n", "Xablau", ajusteTexto(titulo, 25), DateTime.Now.ToString("dd/MM/yyyy"));
                Console.WriteLine("".PadRight(80, '='));
            }

            public static void printFooter(List<String> opcoes)
            {
                Console.WriteLine("\n".PadRight(80, '='));

                Console.WriteLine("Opção de rodapé");
            }
        }
    }

    //Entrada de comando do usuário para selecionar o que fazer:
    private static void EscolhaInput()
        {
            Console.WriteLine("F1 - Cadastrar documentos");
            Console.WriteLine("F2 - Pesquisar documentos");
            Console.WriteLine("F3 - Listar documentos");
            Console.WriteLine("F7 - Carregar documentos");
            Console.WriteLine("F8 - Salvar documentos");
            Console.WriteLine("F9 - Sair");

            ConsoleKeyInfo tecla;
            string nomeArquivo = "";
            while (true)
            {
                tecla = Console.ReadKey();
                if (tecla.Key == ConsoleKey.F1)
                {
                    Console.WriteLine("PreciosnadoF1");
                    //Cadastro(); //Acessa a rotina Cadastro ao pressionar F1
                }
                else if (tecla.Key == ConsoleKey.F2)
                {
                    Console.WriteLine("PreciosnadoF2");
                    //Pesquisa(); //Acessa a rotina Pesquisa ao pressionar F2
                }
                else if (tecla.Key == ConsoleKey.F3)
                {
                    Console.WriteLine("PreciosnadoF3");
                    //Listar(); //Acessa a rotina Listar ao pressionar F3
                }
                else if (tecla.Key == ConsoleKey.F7)
                {
                    Console.WriteLine("PreciosnadoF7");
                    Console.Write("Digite o nome do arquivo .dat a ser carregado: ");
                    nomeArquivo = Console.ReadLine(); //Solicita o nome do arquivo a ser carregado
                    //CarregarLista(nomeArquivo); //Chama a função para carregar a lista de documentos
                }
                else if (tecla.Key == ConsoleKey.F8)
                {
                    if (nomeArquivo == "")
                    {
                        Console.WriteLine("PreciosnadoF8");
                        Console.Write("Digite o nome do arquivo .dat a ser gravado: ");
                        nomeArquivo = Console.ReadLine(); //Solicita o nome do arquivo a ser gravado
                    }
                    else
                    {
                        Console.WriteLine("Arquivo " + nomeArquivo + " gravado com sucesso!"); //Mostra o nome do arquivo já gravado caso já tenha sido informado antes
                    }
                    //GravarLista(nomeArquivo); //Chama a função para gravar a lista de documentos
                }
                else if (tecla.Key == ConsoleKey.F9)
                {
                    Console.WriteLine("Msg: Você deseja realmente sair? Pressione Y para confirmar ou N para cancelar."); //Solicita uma confirmação de saída
                    tecla = Console.ReadKey();
                    if (tecla.KeyChar == 'Y' || tecla.KeyChar == 'y')
                    {
                        Environment.Exit(0); //Caso o usuário confirme, finaliza o programa
                    }
                    else
                    {
                        Console.WriteLine("Ainda estamos trabalhando..."); //Caso o usuário cancele, mantém o programa em execução
                    }
                }
            }
        }
        public class GerenciadorArquivo
        {
            private readonly string _caminho;

            public GerenciadorArquivo(string caminho)
            {   
                _caminho = caminho;
            }

            public List<Registro> LerRegistros()
            {
                var registros = new List<Registro>();

                using (var reader = new StreamReader(_caminho))
                {
                    while (!reader.EndOfStream)
                    {
                        var campos = reader.ReadLine().Split(',');
                        registros.Add(new Registro
                        {
                            RegistroID = int.Parse(campos[0]),
                            Nome = campos[1],
                            CPF = campos[2],
                            RG = campos[3],
                            Habilitacao = campos[4],
                            Titulo = campos[5]
                        });
                    }
                }

                return registros;
            }

            public void GravarRegistros(List<Registro> registros)
            {
                using (var writer = new StreamWriter(_caminho, false))
                {
                    foreach (var registro in registros)
                    {
                        writer.WriteLine($"{registro.RegistroID},{registro.Nome},{registro.CPF},{registro.RG},{registro.Habilitacao},{registro.Titulo}");
                    }
                }
            }
        }

        public class GerenciadorRegistro
        {
            private readonly GerenciadorArquivo _gerenciadorArquivo;

            public GerenciadorRegistro(GerenciadorArquivo gerenciadorArquivo)
            {
                _gerenciadorArquivo = gerenciadorArquivo;
            }

            public List<Registro> ListarRegistros()
            {
                return _gerenciadorArquivo.LerRegistros();
            }

            public void AdicionarRegistro(Registro registro)
            {
                var registrosExistentes = ListarRegistros();

                if (registrosExistentes.Count > 0)
                {
                    registro.RegistroID = registrosExistentes.Max(r => r.RegistroID) + 1;
                }
                else
                {
                    registro.RegistroID = 1;
                }

                registrosExistentes.Add(registro);

                _gerenciadorArquivo.GravarRegistros(registrosExistentes);
            }

            public void AtualizarRegistro(int id, Registro registroAtualizado)
            {
                var registrosExistentes = ListarRegistros();

                var registroAntigo = registrosExistentes.FirstOrDefault(r => r.RegistroID == id);

                if (registroAntigo != null)
                {
                    registroAntigo.Nome = registroAtualizado.Nome;  
                    registroAntigo.CPF = registroAtualizado.CPF;
                    registroAntigo.RG = registroAtualizado.RG;
                    registroAntigo.Habilitacao = registroAtualizado.Habilitacao;
                    registroAntigo.Titulo = registroAtualizado.Titulo;

                    _gerenciadorArquivo.GravarRegistros(registrosExistentes);
                }
            }

            public void RemoverRegistro(int id)
            {
                var registrosExistentes = ListarRegistros();

                var registroRemover = registrosExistentes.FirstOrDefault(r => r.RegistroID == id);

                if (registroRemover != null)
                {
                    registrosExistentes.Remove(registroRemover);

                    _gerenciadorArquivo.GravarRegistros(registrosExistentes);
                }
            }
        }

    }
}