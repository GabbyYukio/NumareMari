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

        public static NumMare sum(NumMare x, NumMare y)
        {
            NumMare solutie = new NumMare();

            int xx = x.data.Length+1, yy = y.data.Length+1, carry = 0, n = 0;
            if (x.pozitiv==true && y.pozitiv==true)
            {
                while(xx!=0||yy!=0)
                {
                    if (xx == 1)
                        solutie.data[n] = y.data[yy-1] + carry;
                    else if (yy == 1)
                        solutie.data[n] = x.data[xx-1] + carry;


                    if (x.data[xx] + y.data[yy] >= 10)
                        carry = 1;
                    xx--;
                    yy--;
                    n++;
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
                copie[data.Length - i] = this.data[i];
            for (int i = 0; i < this.data.Length; i++)
                this.data[i] = copie[i];

        }
        public void Resizing(int a) //reduces the array length up to a
        {
            int[] copie = new int[a];
            for(int i=0;i<a;i++)
                copie[i] = this.data[i];
            
            this.data = new int[a];
            for(int i=0;i<a; i++)
                this.data[i] = copie[i];
        }
    }
}
