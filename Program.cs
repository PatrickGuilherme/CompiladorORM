using CompiladorORM;
using CompiladorORM.Atomos;
using CompiladorORM.TabelaSimbolos;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

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



            //Filtro Termos Inválidos (primeiro nivel)
            Filtros filtros = new Filtros();
            filtros.Filtro_PalavraInvalidas(lista_caracteres);
            lista_caracteres = lista_caracteres.Where(x => x.Status).ToList();
            filtros.Filtro_Comentario(lista_caracteres.Where(x => x.Status).ToList());
            lista_caracteres = lista_caracteres.Where(x => x.Status).ToList();

            //Tabela de simbolos
            List<ElementoTabelaSimbolo> tabelaSimbolos = new List<ElementoTabelaSimbolo>();

            #region Atomo ConsCadeia
            AtomoConsCadeia processor = new AtomoConsCadeia();
            foreach (var caracter in lista_caracteres) // lista_original é a lista de caracteres que será processada
            {
                processor.ProcessarElemento(caracter); // Processa cada caractere
            }
            // Acessar as cadeias encontradas
            foreach (var cadeia in processor.lista_Atomo_ConsCadeia)
            {
                string atomo = string.Empty;
                List<int> lista = new List<int>();
                foreach (var caractere in cadeia)
                {
                    atomo += caractere.NomeCaracter;
                    lista.Add(caractere.Linha);
                }
                 
                ElementoTabelaSimbolo elemento = new ElementoTabelaSimbolo();
                elemento.QtdCharAntesTrunc = atomo.Count();    
                elemento.QtdCharDepoisTrunc = atomo.Count();
                elemento.Lexeme = atomo;
                elemento.TipoSimb = "consCadeia";
                elemento.Codigo = "C01";
                elemento.Entrada = 1;
                elemento.Linhas = lista.Distinct().ToList();
                tabelaSimbolos.Add(elemento);
            }
            #endregion

            //RELATORIO LEX
            controleArquivo.GerarRelatorioTab(tabelaSimbolos);
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