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

            NumMare solutie;
        }

        private static void scadere()
        {

        }
        private static void printmenu()
        {
            Console.WriteLine("Alegeti dintre optiunile: ");
            Console.WriteLine("+ Adunarea a doua numere mari");
            Console.WriteLine("- Scaderea a doua numere mari");
            Console.WriteLine("* Inmultirea a unui numar mare cu unui numar mare");
            Console.WriteLine("** Inmultirea a doua numere mari");
            Console.WriteLine("^ Un numar mare la o putere");
            Console.Write(">>> ");
        }

        private static void alegere()
        {
            string operand = Console.ReadLine();

            switch(operand)
            {
                case "+":
                    adunare();
                    break;
                case "-":
                    scadere();
                    break;
            }
        }
        public static void run()
        {
            printmenu();
        }
    }
}
