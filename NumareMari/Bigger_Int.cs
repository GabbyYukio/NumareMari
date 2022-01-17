using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumareMari
{
    class NumMare
    {
        public int[] data;
        public bool pozitiv;
        //:::::::::::::::Constructori:
        public NumMare(string input)
        {
            
            if(input.Contains("-"))
            {
                this.data = new int[input.Length-1];
                this.pozitiv = false;
                int n = input.Length - 1;
                for(int i=1;i<n;i++)
                {
                    char c=input[i];
                    data[i]= int.Parse(c.ToString());
                }
            }
            else
            {
                this.data = new int[input.Length];
                this.pozitiv = true;
                int n = input.Length;
                for(int i=0; i<n; i++)
                {
                    char c = input[i];
                    data[i]= int.Parse(c.ToString());
                }
            }
        }
        public NumMare()
        {
            this.data = new int[int.MaxValue];
        }

        //:::::::::::::::::::::::Operatii: 
        public static NumMare Sum(NumMare x, NumMare y)//returns solutie as sum of x and y
        {
            NumMare solutie = new NumMare();

            int xx = x.data.Length, yy = y.data.Length, n=xx;
            if (xx < yy)
                n = yy;
            int carry = 0;
            for(int i=0; i<n; i++)
            {
                if (xx < i)
                {
                    solutie.data[i] = y.data[yy - i] + carry;
                    carry = 0;
                }
                if (yy < i)
                {
                    solutie.data[i] = x.data[xx - i] + carry;
                    carry = 0;
                }
                else if (x.data[xx] + y.data[yy] > 10)
                {
                    solutie.data[i] = (y.data[yy-i] + x.data[xx-i]) % 10 + carry;
                    carry = 1;
                }
                else
                {
                    solutie.data[i] = x.data[xx-i] + y.data[yy-i] + carry;
                    carry = 0;
                }
            }
            if (carry != 0)
                solutie.data[n] = carry;
            solutie.Reverse();
            return solutie;
        }

        public static NumMare Substraction(NumMare x, NumMare y)//returns solutie as x-y
        {
            NumMare solutie = new NumMare();
            solutie.pozitiv = true;

            int xx = x.data.Length, yy = y.data.Length, n = xx;
            if (xx < yy)
                n = yy;
            int carry = 0;
            for (int i = 0; i < n; i++)
            {
                if (xx < i)
                {
                    solutie.data[i] = 10-y.data[yy - i] + carry;
                    solutie.pozitiv = false;
                    carry = 0;
                }
                if (yy < i)
                {
                    solutie.data[i] = x.data[xx - i] + carry;
                    carry = 0;
                }
                else if (x.data[xx] - y.data[yy] < 0)
                {
                    solutie.data[i] = (10+x.data[xx-i])-y.data[yy-i] + carry;
                    carry = -1;
                }
                else
                {
                    solutie.data[i] = x.data[xx - i] - y.data[yy - i] + carry;
                    carry = 0;
                }
            }
            solutie.Resizing(n);
            solutie.Reverse();
            return solutie;
        }
        public static NumMare Multiplication_by_Digit(NumMare x, int a)//multiplica numarul x cu a<10 si il returneaza ca un nou obiect
        {

            NumMare solutie = new NumMare();
            int xx = x.data.Length, carry = 0;
            for(int i=0; i<xx; i++)
            {
                if(x.data[xx-i]*a>10)
                {
                    solutie.data[i] = (x.data[xx - i] * a) % 10+carry;
                    carry = (x.data[xx - i] * a) / 10;
                }
                else
                {
                    solutie.data[i] = x.data[xx - i] + carry;
                    carry = 0;
                }
            }
            solutie.data[xx] = carry;
            solutie.Resizing(xx);
            solutie.Reverse();
            return solutie;
        }
        public static NumMare Multiplication_by_10Pow(NumMare x, int a)//multiplica NumMare cu 10 (accepta doar numere 10 la putere)
        {
            int n=x.data.Length;
            NumMare solutie = new NumMare();

            Copy(x, solutie);
            while(a%10==0)
            {
                solutie.data[n] = 0;
                n++;
                a /= 10;
            }
            solutie.Resizing(n);

            return solutie;
        }

        public static NumMare Multiplication_by_NumMare(NumMare x, NumMare y)
        {
            NumMare Solutie = new NumMare("0");
            NumMare placeholder = new NumMare();
            int xx = x.data.Length, yy=y.data.Length, n=xx, sub, pow=0;
            if (xx < yy)
            {
                n = yy;
                for (int i = 0; i < n; i++)
                {
                    sub = x.data[xx - i];
                    placeholder = Multiplication_by_Digit(y, sub);
                    pow = Convert.ToInt32(Math.Pow(10, i));
                    Solutie = Sum(Multiplication_by_10Pow(placeholder, pow), Solutie);
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    sub = y.data[yy - i];
                    placeholder = Multiplication_by_Digit(x, sub);
                    pow = Convert.ToInt32(Math.Pow(10, i));
                    Solutie = Sum(Multiplication_by_10Pow(placeholder, pow), Solutie);
                }
            }
            return Solutie;
        }

        public void Reverse()//reverses the elements of MareNum
        {
            int[] copie = new int[this.data.Length];

            for(int i=data.Length; i>0;i--)
                copie[data.Length - i] = this.data[i-1];
            for (int i = 0; i < this.data.Length; i++)
                this.data[i] = copie[i];

        }


        //:::::::::::::::::Proprietati pentru NumMare
        public void Resizing(int a) //reduces the array length up to a 
        {
            
            if(this.data[a-1]!=0)//checks if the first element of the array wont be 0
            {
                int[] copie = new int[a];
                for (int i=0; i<a; i++)
                   copie[i]=this.data[i];
                this.data = new int[a];
                for (int i = 0; i < a; i++)
                    this.data[i] = copie[i];
            }
            else//if it is, it excludes it
            {
                int[] copie = new int[a-1];
                for (int i=0; i<a-1; i++)
                    copie[i] = this.data[i];
                this.data = new int[a];
                for (int i = 0; i < a - 1; i++)
                    this.data[i] = copie[i];
            }
        }
        public void Print()//Afiseaza numarul ca string
        {
            if (this.pozitiv!=true)//daca nu e pozitiv arata minus la sfarsit
                Console.Write("-");            
            for(int i=0;  i<this.data.Length; i++)
                Console.Write("{0}",this.data[i]);
        }
        public static void Copy(NumMare x, NumMare y)//copiaza elementele din x in y, cu y avand intMaxValue ca si numar de elemente
        {
            y.data = new int[int.MaxValue];
            for (int i = 0; i < x.data.Length; i++)
                y.data[i] = x.data[i];
        }
    }
}
