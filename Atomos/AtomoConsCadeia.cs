using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorORM.Atomos
{
    public class AtomoConsCadeia
    {
        private bool dentroCadeia = false; // Flag para indicar se está dentro de uma consCadeia
        private string consCadeiaAtual = ""; // String para armazenar a consCadeia encontrada
        private List<Caracter> lista_Caracter = new List<Caracter>(); // Lista para armazenar os caracteres de uma cadeia
        public List<List<Caracter>> lista_Atomo_ConsCadeia = new List<List<Caracter>>(); // Lista de listas de caracteres de cadeias encontradas

        // Define os caracteres válidos para o miolo da consCadeia
        private HashSet<char> caracteresValidos = new HashSet<char>
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', // Letras minúsculas
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', // Letras maiúsculas
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', // Dígitos
            ' ', // Espaço em branco
            '$', // Caractere especial
            '_', // Caractere especial
            '.'  // Ponto
        };

        // Função para processar um único elemento (caractere)
        public void ProcessarElemento(Caracter caracterAtual)
        {
            // Verifica início de consCadeia (Aspas duplas)
            if (!dentroCadeia && caracterAtual.NomeCaracter == '\"')
            {
                dentroCadeia = true; // Inicia uma nova consCadeia
                consCadeiaAtual = ""; // Reseta a string da consCadeia
                lista_Caracter = new List<Caracter>(); // Reseta a lista de caracteres da cadeia
                return; // Termina o processamento deste caractere
            }

            // Verifica fim de consCadeia (Aspas duplas)
            if (dentroCadeia && caracterAtual.NomeCaracter == '\"')
            {
                dentroCadeia = false; // Finaliza a consCadeia
                lista_Atomo_ConsCadeia.Add(lista_Caracter); // Adiciona a cadeia encontrada à lista
                lista_Caracter = new List<Caracter>(); // Limpa a lista de caracteres
                return; // Termina o processamento deste caractere
            }

            // Se estiver dentro de uma consCadeia, verifica se o caractere é válido para miolo
            if (dentroCadeia)
            {
                if (caracteresValidos.Contains(caracterAtual.NomeCaracter))
                {
                    consCadeiaAtual += caracterAtual.NomeCaracter.ToString(); // Adiciona o caractere à consCadeia
                    lista_Caracter.Add(caracterAtual); // Adiciona o caractere à lista de caracteres da cadeia
                }
            }
        }
    }
}
