using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumareMari
{
    class UI
    {
        private static void adunare()
        {
            string input;
            Console.WriteLine("Dati primul numar ");
            input= Console.ReadLine();

            NumMare a = new NumMare(input);

            Console.WriteLine("Dati al doilea numar ");
            input= Console.ReadLine();

            NumMare b= new NumMare(input);

            NumMare solutie=NumMare.Sum(a,b);
            Console.Write("Numarul obtinut este: ");
            solutie.Print();
        }

        private static void scadere()
        {
            string input;
            Console.WriteLine("Dati primul numar ");
            input = Console.ReadLine();

            NumMare a = new NumMare(input);

            Console.WriteLine("Dati al doilea numar ");
            input = Console.ReadLine();

            NumMare b = new NumMare(input);

            NumMare solutie = NumMare.Substraction(a, b);
            Console.Write("Numarul obtinut este: ");
            solutie.Print();
        }
        private static void inmultire()
        {
            string input;
            Console.WriteLine("Dati primul numar ");
            input = Console.ReadLine();

            NumMare x= new NumMare(input);

            Console.WriteLine("Dati al doilea numar (mai mic decat 10)");
            int a =int.Parse( Console.ReadLine());

            NumMare solutie = NumMare.Multiplication_by_Digit(x, a);
            Console.Write("Rezultatul este: ");
            solutie.Print();
        }

        private static void inmultire_mare()
        {
            string input;
            Console.WriteLine("Dati primul numar ");
            input = Console.ReadLine();

            NumMare a = new NumMare(input);

            Console.WriteLine("Dati al doilea numar ");
            input = Console.ReadLine();

            NumMare b = new NumMare(input);

            NumMare solutie = NumMare.Multiplication_by_NumMare(a, b);
            Console.Write("Numarul obtinut este: ");
            solutie.Print();
        }


        private static void printmenu()
        {
            Console.WriteLine("Alegeti dintre optiunile: ");
            Console.WriteLine("+ Adunarea a doua numere mari");
            Console.WriteLine("- Scaderea a doua numere mari");
            Console.WriteLine("* Inmultirea a unui numar mare cu unui numar mare");
            Console.WriteLine("** Inmultirea a doua numere mari");
            
        }

        private static void alegere()
        {
            Console.Write(">>> ");
            string operand = Console.ReadLine();

            switch(operand)
            {
                case "+":
                    adunare();
                    break;
                case "-":
                    scadere();
                    break;
                case "*":
                    inmultire();
                    break;
                case "**":
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
