using CompiladorORM;
using System;
using System.IO;
using System.Reflection;

public class Program
{
    public static void Main(string[] args)
    {
        
        try
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("          STATIC CHECKER            ");
            Console.WriteLine("====================================");

            Console.Write("[Digite o nome do arquivo] ");
            string nomeArquivo = Console.ReadLine();
            Console.WriteLine(">>> " + nomeArquivo + " <<<");

            Console.Write("[Digite o caminho do arquivo (use barra invertida duas vezes \\\\)] ");
            string? caminhoDoUsuario = Console.ReadLine();

            ControleArquivo controleArquivo = new ControleArquivo(nomeArquivo);
            controleArquivo.SetDiretorio(caminhoDoUsuario);

            var lista_caracteres = controleArquivo.LerArquivo();

            controleArquivo.GerarRelatorioLex();
            Filtros filtros = new Filtros();
            filtros.Filtro_EspacosEmBranco(lista_caracteres);

        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("          TRATAMENTO DE ERRO        ");
            Console.WriteLine("====================================");
            Console.WriteLine(ex.Message);
        }

    }
}