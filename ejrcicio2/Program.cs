using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Program
    {
        static Persona[] lista = new Persona[0];
        static int cont = 0;
        static void Main(string[] args)
        {
            //LeerArchivo();
            int op = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("::::MENU DE REGISTROS::::");
                Console.WriteLine("1. Registrar Persona");
                Console.WriteLine("2. Mostrar lista de personas");
                Console.WriteLine("0. Salir");
                Console.Write("Ingrese una opcion: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 0:
                        Console.WriteLine("Saliendo");
                        break;
                    case 1:
                        RegistrarPersona();
                        break;
                    case 2:
                        MostrarLista();
                        break;
                    default:
                        Console.WriteLine("opcion no valida");
                        break;
                }

                Console.ReadKey();
            }
            while (op != 0);
        }
        public static void RegistrarPersona()
        {
            Array.Resize(ref lista, cont + 1);
            Console.Write("Ingrese el DNI de la persona: ");
            int dni = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el nombre de la persona: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese numero telefonico de la persona: ");
            string telefono = Console.ReadLine();

            Persona per = new Persona();
            per.dni = dni;
            per.nombre = nombre;
            per. telefono = telefono;

            lista[cont] = per;

            Console.WriteLine("Persona registrada");
            EscribirArchivo();
            cont++;
        }
        public static void MostrarLista()
        {
            Console.WriteLine("LISTA DE PERSONAS:");
            foreach (Persona item in lista)
            {
                Console.WriteLine(item);
            }
        }
        public static void EscribirArchivo()
        {
            StreamWriter escritor = new StreamWriter("dataPersonas.txt");
            foreach (Persona item in lista)
            {
                escritor.WriteLine(item);
            }
            escritor.Close();
        }
        public static void LeerArchivo()
        {
            try
            {
                //codigo que puede generar errores
                StreamReader lector = new StreamReader("dataPersonas.txt");

                string linea;
                do
                {
                    linea = lector.ReadLine();
                    if (linea == null) { break; }
                    Array.Resize(ref lista, cont + 1);
                    //lista[cont] = linea;
                    cont++;

                } while (linea != null);
                lector.Close();
            }
            catch (Exception)
            {
                //el control del error encontrado en el intento
                //Console.WriteLine("Se encontro un error "+ex.Message);
                //Console.ReadKey();
                Console.WriteLine("Bienvenido por primera vez");
            }

            for (int i = 0; i < 30; i++)
            {
                Console.Write("█");
                Thread.Sleep(200);
            }
        }
    }
}
