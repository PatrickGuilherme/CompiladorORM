using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorORM
{
    public class Caracter
    {
        public char NomeCaracter { get; set; }
        public int CodigoASC { get; set; }
        public int Linha { get; set; }
        public int OrdemLinha { get; set; }
        public int OrdemGeral { get; set; }
        public bool Status { get; set; }

    }
}
