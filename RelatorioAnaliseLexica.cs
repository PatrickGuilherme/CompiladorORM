using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorORM
{
    public class RelatorioAnaliseLexica
    {
        public string Lexeme { get; set; }
        public int Codigo { get; set; }
        public int IndiceTabelSimbolos { get; set; }
        public int Linha { get; set; }
    }
}
