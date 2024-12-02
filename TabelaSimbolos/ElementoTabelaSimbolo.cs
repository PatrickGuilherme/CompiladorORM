using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorORM.TabelaSimbolos
{
    public class ElementoTabelaSimbolo
    {
        public int Entrada { get; set; }
        public string Codigo { get; set; }
        public string Lexeme { get; set; }
        public int QtdCharAntesTrunc { get; set; }
        public int QtdCharDepoisTrunc { get; set; }
        public string TipoSimb { get; set; }
        public List<int> Linhas { get; set; } = new List<int>();
    }
}
