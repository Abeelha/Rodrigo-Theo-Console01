﻿namespace ProjetoTheoRodrigo_Console01;

public class Registro
{
    public int RegistroID { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string RG { get; set; }
    public string Habilitacao { get; set; }
    public string Titulo { get; set; }

    public Registro()
    {
        RegistroID = -1;
        Nome = "";
        CPF = "";
        RG = "";
        Habilitacao = "";
        Titulo = "";
    }
}