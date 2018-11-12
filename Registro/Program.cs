using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro
{
    class Program
    {
        static void Main(string[] args)
        {
            var diario = new bitacora();

             string nombre;
            int cant;
            Console.WriteLine("Cuantos Usuarios Desea Ingresar ?");
            cant = Convert.ToInt32(Console.ReadLine());
            Console.Clear();


            for (int i = 0; i < cant; i++)
            {
                Console.WriteLine("Ingrese un Registro");
                nombre = Console.ReadLine();
                Console.Clear();
                diario.AgregarEntrada("Nombre: " +nombre +"Fecha Registro: " + DateTime.Now);
            }
           

           Console.WriteLine(diario.ToString());
                      
           //este codigo sirbe para poner una pausa
            Console.ReadKey();

        }

        //Bitacora
        public class bitacora
        {
            private readonly List<string> entradas2 = new List<string>();
            private static int count = 0;

            public int AgregarEntrada(string texto)
            {
                entradas2.Add($"{++count}:{texto}");
                return count;
            }

          

            public override string ToString()
            {
                return string.Join(Environment.NewLine, entradas2);
            }
        }


     
        public class Guardar 
        {

            public void GuardarArchivo(bitacora bitacora, string fileName, bool overwrite = false)
            {
                if (overwrite || !File.Exists(fileName))
                {
                    File.WriteAllText(fileName, bitacora.ToString());
                }
            }
            public bool ExistFile(string FileName)
            {
                return File.Exists(FileName);
            }
        }
    }
}
