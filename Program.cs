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
            
            //Ler entrada
            Console.Write("[Digite o nome do arquivo] ");
            string nomeArquivo = Console.ReadLine();
            Console.WriteLine(">>> " + nomeArquivo + " <<<");
            
            //Caminho Arquivo
            Console.Write("[Digite o caminho do arquivo (use barra invertida duas vezes \\\\)] ");
            string? caminhoDoUsuario = Console.ReadLine();
            
            //Abrir diretorio
            ControleArquivo controleArquivo = new ControleArquivo(nomeArquivo);
            controleArquivo.SetDiretorio(caminhoDoUsuario);
            var lista_caracteres = controleArquivo.LerArquivo();

            //RELATORIO LEX
            controleArquivo.GerarRelatorioLex();

            //Filtro Termos Inválidos (primeiro nivel)
            Filtros filtros = new Filtros();
            filtros.Filtro_PalavraInvalidas(lista_caracteres);
            PrintListaCaracteres(lista_caracteres);

            //Filtro de comentario (segundo nivel)
            filtros.Filtro_Comentario(lista_caracteres.Where(x => x.Status).ToList());
            PrintListaCaracteres(lista_caracteres);

            lista_caracteres = lista_caracteres.Where(x => x.Status).ToList();
            PrintListaCaracteres(lista_caracteres);




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

    private static void PrintListaCaracteres(List<Caracter> lista_caracteres)
    {
        Console.WriteLine("====================================");
        Console.WriteLine("          LISTA                     ");
        Console.WriteLine("====================================");
        Console.WriteLine("{0,-15} {1,-10} {2,-10} {3,-15} {4,-15} {5,-10}",
                    "NomeCaracter",
                    "CodigoASC",
                    "Linha",
                    "OrdemLinha",
                    "OrdemGeral",
                    "Status");
        //Exibição lista de caracteres
        foreach (var caracter in lista_caracteres)
        {
          
            Console.WriteLine("{0,-15} {1,-10} {2,-10} {3,-15} {4,-15} {5,-10}",
                caracter.NomeCaracter,
                caracter.CodigoASC,
                caracter.Linha,
                caracter.OrdemLinha,
                caracter.OrdemGeral,
                caracter.Status);
        }
    }
}