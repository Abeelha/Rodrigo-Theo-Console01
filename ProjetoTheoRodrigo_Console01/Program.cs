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
            Menu.ImprimeTelaPrincipal();
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
                        writer.WriteLine(
                            $"{registro.RegistroID},{registro.Nome},{registro.CPF},{registro.RG},{registro.Habilitacao},{registro.Titulo}");
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