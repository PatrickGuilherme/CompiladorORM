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
            
            
            int comentarioLinha=0;
            int comentarioBloco=0;
            int linhaComentada = -1;

            foreach (var caracter in lista_original) 
            {
                if(caracter.CodigoASC == 42){//Barra (/) 
                    comentarioLinha++;
                    comentarioBloco++;
                }
                
                //Comentario bloco (inicio)
                else if(caracter.CodigoASC == 47  && (comentarioLinha == 1 || comentarioBloco == 1)){
                    comentarioLinha = 0;
                    comentarioBloco++;
                }
                //Comentario de linha (inicio)
                else if(caracter.CodigoASC == 42  && (comentarioLinha == 1 || comentarioBloco == 1)){
                    comentarioBloco = 0;
                    comentarioLinha++;
                    linhaComentada = caracter.Linha;
                }else{
                    comentarioBloco = 0;
                    comentarioLinha = 0;
                }

                if(comentarioLinha == 2){
                    
                else if(comentarioBloco > 1 || comentarioLinha > 1){
                    
                }
                    

                
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
