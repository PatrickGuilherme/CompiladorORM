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
    private static List<Caracter> lista_caractere = new List<Caracter>();
    private static List<ElementoTabelaSimbolo> tabelaSimbolos = new List<ElementoTabelaSimbolo>();

    public static void Main(string[] args)
    {
        
        try
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("          STATIC CHECKER            ");
            Console.WriteLine("====================================");//id == entrada
            
            //Ler entrada
            Console.Write("[Digite o nome do arquivo] ");
            string nomeArquivo = Console.ReadLine();
            Console.WriteLine(">>> " + nomeArquivo + " <<<");

            //Informar caminho para o arquivo?
            Console.Write("[Deseja informar um caminho para o texto fonte(s/n)?] ");
            string? infCaminho = Console.ReadLine();
            string? caminhoDoUsuario = string.Empty;

            //Caminho Arquivo
            if (infCaminho.ToLower() != "s") 
            {
                Console.Write("[Digite o caminho do arquivo (use barra invertida duas vezes \\\\)] ");
                caminhoDoUsuario = Console.ReadLine();
            }
            
            //Abrir diretorio
            ControleArquivo controleArquivo = new ControleArquivo(nomeArquivo);
            controleArquivo.SetDiretorio(caminhoDoUsuario);
            lista_caractere = controleArquivo.LerArquivo();

            //Filtro Termos Inválidos
            Filtros filtros = new Filtros();
            filtros.Filtro_PalavraInvalidas(lista_caractere);
            lista_caractere = lista_caractere.Where(x => x.Status).ToList();

            //Filtro Comentários
            filtros.Filtro_Comentario(lista_caractere.Where(x => x.Status).ToList());
            lista_caractere = lista_caractere.Where(x => x.Status).ToList();

            //Tabela de simbolos
            AtomoConsCadeia ConsCadeia = new AtomoConsCadeia();
            foreach (var caracter in lista_caractere) 
            {
                ConsCadeia.ProcessarElemento(caracter);
            }


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

    public void CarregarTabelaSimbolos_ConsCadeia(AtomoConsCadeia ConsCadeia)
    {
        #region Atomo ConsCadeia
        // Acessar as cadeias encontradas
        foreach (var cadeia in ConsCadeia.lista_Atomo_ConsCadeia)
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
    }

}