using System;
using System.Collections.Generic;
using System.Text;

namespace Controlador_PLC
{
    class Archivo2
    {
        private int valorInicial;
        private double coeficiente;

        public Archivo2(int valorInicial, int valorFinal, double coeficiente)
        {
            this.valorInicial = valorInicial;
            this.ValorFinal = valorFinal;
            this.coeficiente = coeficiente;
        }
        public void imprimir()
        {
            Console.WriteLine(" valor inicial es " + this.valorInicial + "" +
                " valor final es : " + this.ValorFinal + " el coeficiente es : " + this.coeficiente);
        }


        public int ValorInicial { get => valorInicial; set => valorInicial = value; }
        public int ValorFinal { get; set; }
        public double Coeficiente { get => coeficiente; set => coeficiente = value; }
    }
}
