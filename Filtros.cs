using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorORM
{
    public class Filtros
    {


        //Espaços em branco duplicados são removidos
        public void Filtro_EspacosEmBranco(List<Caracter> lista_original)
        {
            lista_original = lista_original.OrderBy(x => x.OrdemGeral).ToList();
            List<Caracter> itensEspacoBranco = new List<Caracter>();
            int qtdEspacoBranco = 0;
            


            foreach (var caracter in lista_original) 
            {
                if (caracter.CodigoASC == 32)
                {
                    qtdEspacoBranco++;
                    if(qtdEspacoBranco > 1)
                    {
                        itensEspacoBranco.Add(caracter);
                    }
                }
                else
                {
                    if (qtdEspacoBranco >= 2) 
                    {
                        foreach(var i  in itensEspacoBranco)
                        {
                            lista_original.Remove(i);
                        }
                    }
                    else
                    {
                        itensEspacoBranco.RemoveAll(x => x.OrdemGeral >= 0);

                    }
                    qtdEspacoBranco = 0;
                }
            }
        }

    }
}
