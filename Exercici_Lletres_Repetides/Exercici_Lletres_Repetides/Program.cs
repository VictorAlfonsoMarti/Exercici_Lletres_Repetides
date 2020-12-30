using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Exercici_Lletres_Repetides
{
    class Program
    {
        static void Main(string[] args)
        {
            Milestone1();
            //Milestone2Numeros();
            //Milestone2Asterisc();
            //Milestone3();
        }

        static void Milestone1()
        {
            // fase 1
            string nomComplet = "Victor";
            char[] arrayComplet = nomComplet.ToCharArray();  // convertim el string en array

            //recorrem l'arrai i el printem
            foreach (char x in arrayComplet)
            {
                Console.WriteLine(x);
            }

            //fase 2
            List<char> llistaNom = arrayComplet.ToList(); //convertim el array en llista

            string vocal = "aeiouAEIOU"; // variables de comprobacio
            string numero = "1234567890";
            string espai = " ";

            foreach (char x in llistaNom) //recorrem la llista
            {
                if (vocal.IndexOf(x) >= 0) //fem indexof per saber si coincideix amb el string que hem declarat abans
                {
                    Console.WriteLine("VOCAL");
                }
                else if (numero.IndexOf(x) >= 0)
                {
                    Console.WriteLine("Els noms de persones no contenen números!");
                }
                else if (espai.IndexOf(x) >=0)
                {
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine("CONSONANT");
                }
            }

            //fase 3
            Dictionary<char, int> mapaLletres = new Dictionary<char, int>(); // creamos el diccionario

            for (int x = 0; x < llistaNom.Count; x++) //recorremos toda la lista
            {
                if (mapaLletres.TryGetValue(llistaNom[x], out int y)) // intentamos traer valor del diccionario = a posicion actual de lista, da boolean. si true
                {
                    mapaLletres[llistaNom[x]] = mapaLletres[llistaNom[x]] + 1; //buscamos contenido actual de la posicion de la lista, añadimos valor actual + 1 a la clave valor de ese contenido.
                }
                else
                {
                    mapaLletres.Add(llistaNom[x], 1); // si no esta, añadimos la key con valor 1
                }

            }

            Console.WriteLine(string.Join("", mapaLletres));

            //fase 4

            string cognom = "Alfonso";
            List<char> llistaCognoms = cognom.ToList(); // afegim el cognom a la llista

            List<char> nomCognom = new List<char>(); 

            nomCognom.AddRange(llistaNom); // unifiquem les dos llistes amb un espai 
            nomCognom.Add(' ');
            nomCognom.AddRange(llistaCognoms);

            Console.WriteLine("[{0}]", string.Join(", ", nomCognom));
        }


        static void Milestone2Numeros()
        {
            Console.WriteLine("Piramide de números, introdueix un número: ");
            int numeroFinal = Convert.ToInt32(Console.ReadLine());
            List<int> llistaNumeros = new List<int>();


            for (int x = 0; x < numeroFinal; x++)
            {
                llistaNumeros.Add(x + 1);
                Console.WriteLine(string.Join("", llistaNumeros));
            }
            

        }

        static void Milestone2Asterisc()
        {
            Console.WriteLine("Piramide de Astericos, introdueix un número de pisos: ");
            int numeroAsteriscos = Convert.ToInt32(Console.ReadLine());
            string[] piramide = new string[numeroAsteriscos*2+1];// el creem del doble per aconseguir les files introduides

            for (int x = 0; x < piramide.Length; x++) //afegim * a cada posicio del array
            {
                piramide[x] = "*";
            }

            for (int x =0; x < (piramide.Length-x); x++) //recorrem l'arrai fins que es trobin els dos valos x, el incrementat i el tope(que va disminuint cada vegada)
            {
                piramide[x] = " "; // al valor inicial e incrementantment cambiem el * per espai
                piramide[piramide.Length-x-1] = " "; // fem lo mateix pero al valor inicial - el tamany de la piramide -1(per a que no peti)
                Console.WriteLine(string.Join("", piramide));
            }
        }

        static void Milestone3()
        {
            DateTime date = DateTime.Now; // Agafem el objecte data per poder insertar la hora del moment exacte en que s'engega el programa. 

            int segon = date.Second; // asignem segons actuals
            int minut = date.Minute; // minuts actual
            int hora = date.Hour; //hora actual

            while (true) // bucle infinit
            {
                if (segon <= 59)
                {
                    segon = segon + 1;
                }
                if (segon >= 60)
                {
                    segon = 0;
                    minut = minut + 1;
                }
                if (minut > 59)
                {
                    minut = 0;
                    hora = hora + 1;
                }
                if (hora == 24)
                {
                    segon = 0;
                    minut = 0;
                    hora = 0;
                }
                Console.Write("{0:00}:{1:00}:{2:00}",hora,minut,segon); //imprimim amb format de dos integers com a mínim
                Thread.Sleep(1000); // espera de 1000 milisegons entre execució i execució del while
                Console.Clear(); // netegem consola per a que no se quedi impres el temps pasat.
            }

        }


    }
}
