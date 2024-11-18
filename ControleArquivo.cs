using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorORM
{
    public class ControleArquivo
    {
        public string NomeArquivo { get; set; }
        public string NomeArquivoExt { get; set; }

        public string DiretorioExt { get; set; }
        public string Diretorio { get; set; }


        public ControleArquivo(string nomeArquivo)
        {
            this.NomeArquivoExt = nomeArquivo + ".242";
            this.NomeArquivo = nomeArquivo;
        }

        public void SetDiretorio(string? caminhoDoUsuario)
        {
            string caminhoAtual = ObterDiretorioRaizProjeto();

            //Construir o Endereço completo
            string enderecoNomeExtensaoArquivo = "";
            if (!string.IsNullOrEmpty(caminhoDoUsuario))
            {
                enderecoNomeExtensaoArquivo = caminhoDoUsuario;
                Console.WriteLine("[Caminho do arquivo] " + enderecoNomeExtensaoArquivo);
            }
            else
            {
                enderecoNomeExtensaoArquivo = caminhoAtual;
                Console.WriteLine("[Caminho do arquivo] " + enderecoNomeExtensaoArquivo);
            }

            try
            {
                if (File.Exists(enderecoNomeExtensaoArquivo + "\\" + this.NomeArquivoExt))
                {
                    DiretorioExt = enderecoNomeExtensaoArquivo + "\\" + this.NomeArquivoExt;
                    Diretorio = enderecoNomeExtensaoArquivo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Diretorio fornecido é inválido.");
            }
        }

        private string ObterDiretorioRaizProjeto()
        {
            // Obtém o caminho completo do assembly (executável ou DLL)
            string caminhoAssembly = Assembly.GetExecutingAssembly().Location;

            // Navega até o diretório do projeto saindo da pasta 'bin' e suas subpastas
            DirectoryInfo diretorioAtual = Directory.GetParent(caminhoAssembly);
            while (diretorioAtual != null && diretorioAtual.Name != "bin")
            {
                diretorioAtual = diretorioAtual.Parent;
            }

            // Sobe mais uma vez para sair da pasta 'bin' e retornar à raiz do projeto
            if (diretorioAtual != null)
            {
                return diretorioAtual.Parent.FullName;
            }
            else
            {
                throw new Exception("Não foi possível localizar a raiz do projeto.");
            }
        }

        public void GerarRelatorioLex()
        {
            string nomeArquivoExt = NomeArquivo;
            string DiretorioRaiz = this.ObterDiretorioRaizProjeto();

            // Caminho do arquivo
            string caminhoDoArquivo = DiretorioRaiz + "\\" + nomeArquivoExt + ".LEX";

            // Texto a ser escrito no arquivo, com quebras de linha
            string textoParaEscrever = "Código da Equipe: EQ01" + "\n" +
                                       "Componentes:" + "\n" +
                                       "\tPatrick Guilherme da Silva; patrick.silva@aln.senaicimatec.edu.br; (71) 99945-8148" + "\n" +
                                       "\tGuilherme Garcia Oliveira; guilherme.g.oliveira@aln.senaicimatec.edu.br; (71) 98134-0749" + "\n" +
                                       "\tVictor Lima Conceição; victor.Conceicao@aln.senaicimatec.edu.br; (71) 98600-1311" + "\n" +
                                       "\tIgor Cunha Lobato Souza; igor@aln.senaicimatec.edu.br; (71) 99147-4206" + "\n\n";

            textoParaEscrever += "RELATÓRIO DE ANÁLISE LÉXICA. Texto fonte analisado: " + this.NomeArquivo + "\n";
            textoParaEscrever += "---------------------------------------------------------------------------------------------------------" + "\n";
            try
            {
             
                int i = 1;
                while (File.Exists(caminhoDoArquivo))
                {
                    caminhoDoArquivo = DiretorioRaiz + "\\" + nomeArquivoExt + i + ".LEX";
                    i++;
                }

                // Escrever o texto no arquivo (irá sobrescrever se o arquivo já existir)
                File.WriteAllText(caminhoDoArquivo, textoParaEscrever);
                
               
             

                Console.WriteLine("Texto escrito no arquivo com sucesso!");
            }
            catch (Exception e)
            {
                // Captura de erro
                Console.WriteLine($"Ocorreu um erro ao criar ou escrever no arquivo: {e.Message}");
            }
        }
        
        public List<Caracter> LerArquivo()
        {
            try
            {
                // Usando StreamReader para ler o arquivo linha por linha
                using (StreamReader leitor = new StreamReader(DiretorioExt))
                {

                    string linha;
                    int NumLinha=0;
                    int ordemGeral = 0;
                    Caracter caracter;
                    List<Caracter> lista_caracter = new List<Caracter>();
                    while ((linha = leitor.ReadLine()) != null)
                    {
                        for(int i = 0; i < linha.Length; i++)
                        {
                            caracter = new Caracter();
                            caracter.NomeCaracter = linha[i];
                            caracter.CodigoASC = Convert.ToInt32(linha[i]);
                            caracter.OrdemLinha = i;
                            caracter.OrdemGeral = ordemGeral;
                            caracter.Linha = NumLinha;
                            ordemGeral++;
                            lista_caracter.Add(caracter);
                        }
                        NumLinha++;
                    }
                    return lista_caracter;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Ocorreu um erro ao ler o arquivo: {e.Message}");
            }
        }
    }
}
