using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Controlador_PLC
{
    class Program
    {
        static void Main(string[] args)
        {
         try
            {
            ProcesadorDeListas procesador = new ProcesadorDeListas();
            List<Archivo2> archivo2 = new List<Archivo2>();
            var t1 = Task.Factory.StartNew(() =>
            {
                string path = @"c:\csv\archivo2.csv";
                using (StreamReader readFile = new StreamReader(path))
                {
                    readFile.ReadLine();
                    while (readFile.Peek() != -1)
                    {
                        string line = readFile.ReadLine();
                        string[] datos = line.Split(new Char[] { '-', ';' });
                        Archivo2 arch2 = new Archivo2(int.Parse(datos[0]), int.Parse(datos[1]), double.Parse(datos[2]));
                        archivo2.Add(arch2);
                    }
                    readFile.Close();
                }
            });
         
            List<Archivo1> archivo1 = new List<Archivo1>();
            var t2 = Task.Factory.StartNew(() =>
            {

                string[] path = new string[] { @"c:\csv\archivo1b.csv", @"c:\csv\archivo1a.csv" };
                foreach (string i in path)
                {
                    using (StreamReader readFile = new StreamReader(i))
                    {

                        readFile.ReadLine();
                        while (readFile.Peek() != -1)
                        {
                            string line = readFile.ReadLine();
                            string[] datos = line.Split(new Char[] { ';', '|' });
                            Archivo1 arch1 = new Archivo1(int.Parse(datos[0]), double.Parse(datos[1]) + double.Parse(datos[2]) + double.Parse(datos[3]));
                            archivo1.Add(arch1);
                        }
                        readFile.Close();
                    }

                }
                archivo1 = procesador.sumarFlags(archivo1);
            
            });

            Task.WaitAll(t1, t2);
            var t3 = Task.Factory.StartNew(() =>
            {
                var result = procesador.resolvercociente(archivo2, archivo1);

                Console.WriteLine("lista final ");
                foreach (Archivo1 i in result)
                {
                    i.imprimir2();
                }
            });

            t3.Wait();

        }
          catch (AggregateException e)
              {
                 foreach(var ex in e.InnerExceptions)
                 {
                     Console.WriteLine(ex.Message);
                 }
              }
            Console.WriteLine("ejercicio terminado");
            Console.WriteLine("precione una tecla para salir");
            Console.ReadLine();
        }

    }
}
