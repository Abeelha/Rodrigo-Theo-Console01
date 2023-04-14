namespace ProjetoTheoRodrigo_Console01;

public class PrintUtils
{
    private static String AjusteTamanhoTexto(String texto, int tamanho)
    {
        return texto.Length >= tamanho
            ? texto.Substring(0, 25)
            : texto + " ".PadRight(tamanho - texto.Length);
    }

    public static void PrintHeader(String titulo = "Sistema de Quinta")
    {
        Console.WriteLine("{0, -25}{1, -45}{2, 10:dd/MM/yyyy}\n", "Xablau", AjusteTamanhoTexto(titulo, 25),
            DateTime.Now);
        Console.WriteLine("".PadRight(80, '='));
    }

    public static void PrintFooter(String message = "")
    {
        Console.WriteLine("\n".PadRight(81, '='));
        Console.WriteLine("{0, -25}{1, -44}{2, 11}\n", "Usuário: Trigo", AjusteTamanhoTexto("Terminal1", 25),
            "Nivel: User");
        if (!String.IsNullOrEmpty(message)) Console.WriteLine($"\nMsg: {message}");
    }
}