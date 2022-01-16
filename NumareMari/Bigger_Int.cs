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

        public NumMare(string input)
        {
            this.data=new int[input.Length];
            if(input.Contains("-"))
            {
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

        public static NumMare sum(NumMare x, NumMare y)//returns solutie as sum of x and y
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
            solutie.data[n] = carry;
            solutie.Resizing(n+1);
            solutie.Reverse();
            return solutie;
        }

        public static NumMare scad(NumMare x, NumMare y)//returneaza x-y 
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


        public void Reverse()//reverses the elements of MareNum
        {
            int[] copie = new int[this.data.Length];

            for(int i=data.Length; i>0;i--)
                copie[data.Length - i] = this.data[i-1];
            for (int i = 0; i < this.data.Length; i++)
                this.data[i] = copie[i];

        }
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
        public void Afis()
        {
            if (this.pozitiv!=true)
                Console.Write("-");            
            for(int i=0;  i<this.data.Length; i++)
                Console.Write("{0}",this.data[i]);
        }
    }
}
