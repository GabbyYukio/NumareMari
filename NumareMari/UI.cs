using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumareMari
{
    class UI
    {
        private static string citire(string mesaj)
        {
            string input;
            Console.WriteLine(mesaj);
            Console.Write(">>> ");
            input = Console.ReadLine();
            return input;
        }
        private static void adunare()
        {
            
            NumMare a = new NumMare(citire("Va rog dati primul numar"));
            NumMare b = new NumMare(citire("Va rog dati al doilea numar"));

            NumMare solutie =NumMare.Sum(a,b);
            Console.Write("Numarul obtinut este: ");
            solutie.Print();
        }

        private static void scadere()
        {
            NumMare a = new NumMare(citire("Dati va rog primul numar "));
            NumMare b = new NumMare(citire("Va rog dati al doilea numar"));

            NumMare solutie = NumMare.Substraction(a, b);
            Console.Write("Numarul obtinut este: ");
            solutie.Print();
        }
        private static void inmultire()
        {
            NumMare x = new NumMare(citire("Dati va rog primul numar "));
            int z = int.Parse(citire("Va rog dati al doilea numar (mai mic decat 10) "));

            NumMare solutie = NumMare.Multiplication_by_Digit(x, z);
            Console.Write("Rezultatul este: ");
            solutie.Print();
        }

        private static void inmultire_mare()
        {
            NumMare a = new NumMare(citire("Dati va rog primul numar "));
            NumMare b = new NumMare(citire("Va rog dati al doilea numar"));

            NumMare solutie = NumMare.Multiplication_by_NumMare(a, b);
            Console.Write("Numarul obtinut este: ");
            solutie.Print();
        }


        private static void printmenu()
        {
            Console.WriteLine("Alegeti dintre optiunile: ");
            Console.WriteLine("1 Adunarea a doua numere mari");
            Console.WriteLine("2 Scaderea a doua numere mari");
            Console.WriteLine("3 Inmultirea unei cifre cu un numar mare");
            Console.WriteLine("4 Inmultirea a doua numere mari");   
        }

        private static void alegere()
        {
            Console.Write(">>> ");
            string operand = Console.ReadLine();

            switch(operand)
            {
                case "1":
                    adunare();
                    break;
                case "2":
                    scadere();
                    break;
                case "3":
                    inmultire();
                    break;
                case "4":
                    inmultire_mare();
                    break;
                default:
                    Console.WriteLine("Optiune invalida. Incercati din nou: ");
                    alegere();
                    break;
            }
        }
        public static void run()
        {
            printmenu();
            alegere();
        }
    }
}
