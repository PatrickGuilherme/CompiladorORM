using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorORM
{
    public class Filtros
    {

        public void Filtro_Comentario(List<Caracter> lista_original)
        {
            lista_original = lista_original.OrderBy(x => x.OrdemGeral).ToList();
            bool dentroComentario = false; // Flag para indicar se está dentro do comentário

            for (int i = 0; i < lista_original.Count; i++)
            {
                var caracterAtual = lista_original[i];

                // Verifica início de comentário de bloco /* */
                if (!dentroComentario &&
                    i < lista_original.Count - 1 &&
                    caracterAtual.NomeCaracter == '/' &&
                    lista_original[i + 1].NomeCaracter == '*')
                {
                    dentroComentario = true;
                    caracterAtual.Status = false;           // Inativa o '/'
                    lista_original[i + 1].Status = false;   // Inativa o '*'
                    i++; // Avança o índice para pular o próximo
                    continue;
                }

                // Verifica fim de comentário de bloco */
                if (dentroComentario && i < lista_original.Count - 1 &&
                    caracterAtual.NomeCaracter == '*' &&
                    lista_original[i + 1].NomeCaracter == '/')
                {
                    caracterAtual.Status = false;           // Inativa o '*'
                    lista_original[i + 1].Status = false;   // Inativa o '/'
                    dentroComentario = false;
                    i++; // Avança o índice para pular o próximo
                    continue;
                }

                // Inativa caracteres dentro do comentário de bloco
                if (dentroComentario)
                {
                    caracterAtual.Status = false;
                    continue;
                }

                // Verifica início de comentário de linha //
                if (i < lista_original.Count - 1 &&
                    caracterAtual.NomeCaracter == '/' &&
                    lista_original[i + 1].NomeCaracter == '/')
                {
                    caracterAtual.Status = false;           // Inativa a primeira '/'
                    lista_original[i + 1].Status = false;   // Inativa a segunda '/'
                    int linhaAtual = caracterAtual.Linha;

                    // Desativa todos os caracteres até o final da linha
                    while (i + 1 < lista_original.Count && lista_original[i + 1].Linha == linhaAtual)
                    {
                        i++;
                        lista_original[i].Status = false;
                    }
                    continue;
                }
            }

        }

        public string Filtro_AtomoPalavrasReservada(string textofonte)
        {
            TabelaSimbolosReservados tabelaSimbolosReservados = new TabelaSimbolosReservados();
            string codigoSimboloReservado = string.Empty;
            foreach(var simbReservado in tabelaSimbolosReservados.Lista_tabelaSimbolosReservados)
            {
                if (simbReservado.Equals(textofonte.ToLower()))
                {
                    codigoSimboloReservado = simbReservado.Codigo;
                }
            }
            return codigoSimboloReservado;
        }

        public void Filtro_PalavraInvalidas(List<Caracter> lista_original)
        {
            // Lista contendo todos os símbolos
            List<char> simbolos = new List<char>
            {
                ';',
                ':',
                '[',
                ']',
                ',',
                '(',
                ')',
                '?',
                '{',
                '}',
                ':',
                '=',
                '<',
                '>',
                '!',
                '#',
                '-',
                '+',
                '*',
                '/',
                '%',
                '_',
                '\'',
                '$',
                '_',
                '.',
                'a',
                'b',
                'c',
                'd',
                'e',
                'f',
                'g',
                'h',
                'i',
                'k',
                'l',
                'm',
                'n',
                'o',
                'p',
                'q',
                'r',
                's',
                't',
                'u',
                'v',
                'w',
                'x',
                'y',
                'z',
                '1',
                '2',
                '3',
                '4',
                '5',
                '6',
                '7',
                '8',
                '9',
                '0',
                '\"',
                ' ',
            };

            foreach (var termo in lista_original)
            {
                char? encontrou = simbolos.Find(x => x.Equals(char.ToLower(termo.NomeCaracter)));
                if (encontrou == null) { termo.Status = false; } else { termo.Status = true; }
            }

        }
    }
}
