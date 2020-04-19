using System;
using System.Collections.Generic;
using System.Text;

namespace Controlador_PLC
{
    class Archivo1
    {
        private int codigo;
        private double flag;
        private double resultado;

        public Archivo1(int codigo, double flag)
        {
            this.codigo = codigo;
            this.flag = flag;

        }
        public void imprimir()
        {
            Console.WriteLine(" el codigo es " + this.codigo + " el flag es : " + this.flag);
        }
        public void imprimir2()
        {
            Console.WriteLine(" el codigo es " + this.codigo + 
                " la sumatorioa de flags es  : " + this.flag+" los flags dividos por el coeficiente es : "+this.Resultado);
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public double Flag { get => flag; set => flag = value; }
        public double Resultado { get => resultado; set => resultado = value; }
    }
}
