using System;
using System.Collections.Generic;
using System.Text;

namespace Controlador_PLC
{
    class ProcesadorDeListas
    {
        public List<Archivo1> sumarFlags(List<Archivo1> listaoriginal)
        {

            List<Archivo1> listarepetidos = new List<Archivo1>();
            for (int i = 0; i < listaoriginal.Count; i++)
            {
                for (int j = i + 1; j < listaoriginal.Count; j++)
                {
                    if (listaoriginal[i].Codigo == listaoriginal[j].Codigo)
                    {
                        listarepetidos.Add(new Archivo1(listaoriginal[i].Codigo, listaoriginal[j].Flag + listaoriginal[i].Flag));
                        // lista.RemoveAt(i);
                    }

                }

            }

            return Union(listarepetidos, listaoriginal);
        }

        public List<Archivo1> Union(List<Archivo1> listarepetidos, List<Archivo1> listaoriginal)
        {
            for (int i = 0; i < listaoriginal.Count; i++)
            {

                for (int j = 0; j < listarepetidos.Count; j++)
                {
                    if (listaoriginal[i].Codigo.Equals(listarepetidos[j].Codigo))
                    {
                        listaoriginal.RemoveAt(i);

                    }

                }

            }
            listaoriginal.AddRange(listarepetidos);
            return listaoriginal;
        }
        public List<Archivo1> resolvercociente(List<Archivo2> listacocientes, List<Archivo1> listaflags)
        {

            for (int i = 0; i < listaflags.Count; i++)
            {

                for (int j = 0; j < listacocientes.Count; j++)
                {

                    listaflags[i].Resultado = calculoCociente(listaflags[i].Flag, listacocientes);
                }

            }
            return listaflags;
        }

        public double calculoCociente(double flags, List<Archivo2> listacocientes)
        {
            double flagresult = 0;
            for (int i = 0; i < listacocientes.Count; i++)
            {
                if (flags >= listacocientes[i].ValorInicial && flags <= listacocientes[i].ValorFinal)
                {

                    if (listacocientes[i].Coeficiente == 0)
                    {
                        throw new Exception(" no se puede dividir por cero/fallo la tarea 3 ");
                    }
                    else
                    {
                        flagresult = flags / listacocientes[i].Coeficiente;
                    }
                   
                                
                }
            }

            return flagresult;
        }
    }
}
