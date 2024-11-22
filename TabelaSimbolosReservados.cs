using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorORM
{
    public class TabelaSimbolosReservados
    {
        public string Codigo { get; set; }
        public string Atomo { get; set; }
        public List<TabelaSimbolosReservados> Lista_tabelaSimbolosReservados { get; set; }

        public TabelaSimbolosReservados()
        {
            this.Lista_tabelaSimbolosReservados = new List<TabelaSimbolosReservados>();
            ASimbolos();
            BSimbolos();
        }

        private void ASimbolos()
        {
            TabelaSimbolosReservados tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A01";
            tabelaSimbolos.Atomo = "cadeia";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A02";
            tabelaSimbolos.Atomo = "caracter";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A03";
            tabelaSimbolos.Atomo = "declaracoes";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A04";
            tabelaSimbolos.Atomo = "enquanto";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A05";
            tabelaSimbolos.Atomo = "false";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A06";
            tabelaSimbolos.Atomo = "fimDeclaracoes";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A07";
            tabelaSimbolos.Atomo = "fimEnquanto";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A08";
            tabelaSimbolos.Atomo = "fimFunc";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A09";
            tabelaSimbolos.Atomo = "fimFuncoes";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A10";
            tabelaSimbolos.Atomo = "fimPrograma";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A11";
            tabelaSimbolos.Atomo = "fimSe";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A12";
            tabelaSimbolos.Atomo = "funcoes";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A13";
            tabelaSimbolos.Atomo = "imprime";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A14";
            tabelaSimbolos.Atomo = "inteiro";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A15";
            tabelaSimbolos.Atomo = "logico";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A16";
            tabelaSimbolos.Atomo = "pausa";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A17";
            tabelaSimbolos.Atomo = "programa";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A18";
            tabelaSimbolos.Atomo = "real";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A19";
            tabelaSimbolos.Atomo = "retorna";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A20";
            tabelaSimbolos.Atomo = "se";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A21";
            tabelaSimbolos.Atomo = "senao";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A22";
            tabelaSimbolos.Atomo = "tipoFunc";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A23";
            tabelaSimbolos.Atomo = "tipoParam";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A24";
            tabelaSimbolos.Atomo = "tipoVar";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A25";
            tabelaSimbolos.Atomo = "true";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "A26";
            tabelaSimbolos.Atomo = "vazio";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

        }

        private void BSimbolos()
        {
            TabelaSimbolosReservados tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B01";
            tabelaSimbolos.Atomo = "%";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B02";
            tabelaSimbolos.Atomo = "(";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B03";
            tabelaSimbolos.Atomo = ")";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B04";
            tabelaSimbolos.Atomo = ",";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B05";
            tabelaSimbolos.Atomo = ".";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B06";
            tabelaSimbolos.Atomo = ":=";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B07";
            tabelaSimbolos.Atomo = ";";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B08";
            tabelaSimbolos.Atomo = "?";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B09";
            tabelaSimbolos.Atomo = "[";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B10";
            tabelaSimbolos.Atomo = "]";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B11";
            tabelaSimbolos.Atomo = "{";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B12";
            tabelaSimbolos.Atomo = "}";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B13";
            tabelaSimbolos.Atomo = "-";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B14";
            tabelaSimbolos.Atomo = "*";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B15";
            tabelaSimbolos.Atomo = "/";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B16";
            tabelaSimbolos.Atomo = "+";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B17";
            tabelaSimbolos.Atomo = "!=";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B18";
            tabelaSimbolos.Atomo = "<";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B19";
            tabelaSimbolos.Atomo = "<=";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B20";
            tabelaSimbolos.Atomo = "==";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B21";
            tabelaSimbolos.Atomo = ">";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);

            tabelaSimbolos = new TabelaSimbolosReservados();
            tabelaSimbolos.Codigo = "B22";
            tabelaSimbolos.Atomo = ">=";
            this.Lista_tabelaSimbolosReservados.Add(tabelaSimbolos);


        }

    }
}
