using System;
using System.Collections.Generic;

namespace BigInt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int[] v1 = new int[n1];
            int[] v2 = new int[n2];
            Random rnd = new Random();
            for (int i = 0; i < n1; i++)
            {
                v1[i] = rnd.Next(9);
                Console.Write($"{v1[i] }");
              
            }
            Console.WriteLine();

            for (int i = 0; i < n2; i++)
            {
                 v2[i] = rnd.Next(9);
                 Console.Write($"{v2[i] }");
               
            }
            Console.WriteLine();
             
             int[] a = Add(v1, v2);
             PrintResult(a);
             int[] s = Subtract(v1, v2);
              PrintResult(s);
              int[] m = Multiply(v1, v2);
              PrintResult(m);
              int[] p = Power(v1, v2);
              PrintResult(p);
         
        }
        private static void PrintResult(int[] v)
        {
            foreach(var item in v)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
        private static int[] Add(int[] v1, int[] v2)
        {
            int j = v1.Length - 1, k = v2.Length - 1, x = 0;
            Stack<int> add = new Stack<int>();
            while (j >= 0 && k >= 0)
            {
                if (v1[j] + v2[k] + x > 9)
                {
                    add.Push((v1[j] + v2[k] + x) % 10);
                    x = 1;

                }
                else
                {
                    add.Push(v1[j] + v2[k] + x);
                    x = 0;
                }
                try
                {
                    j--;
                    k--;
                }
                catch (IndexOutOfRangeException e)
                {
                    throw;
                }
            }
            while (j <= 0 && k >= 0)
            {
                add.Push(v2[k] + x);
                x = 0;
                try
                {
                    k--;
                }
                catch (IndexOutOfRangeException e)
                {
                    throw;
                }

            }
            while (j >= 0 && k <= 0)
            {
                add.Push(v1[j] + x);
                x = 0;
                try
                {
                    j--;
                }
                catch (IndexOutOfRangeException e)
                {
                    throw;
                }

            }
            /* foreach (int digit in add)
             {
                 Console.Write($"{digit}");
             }
             Console.WriteLine();*/
            while (add.Count > 0 && add.Peek() == 0)
            {
                try
                {
                    add.Pop();
                }
                catch(InvalidOperationException)
                {
                    throw;
                }
            }
            int[] addition = add.ToArray();
            return addition;
        }
        private static int[] Subtract(int[] v1, int[] v2)
        {
            int neg = 0, j, k, x, n1 = v1.Length, n2 = v2.Length;
            if ((n1 == n2 && v1[0] < v2[0]) || n2 > n1)
            {
                int n3 = n2;
                int[] v3 = new int[n3];
                Array.Copy(v2, v3, n2);
                n2 = n1;
                n1 = n3;
                Array.Resize(ref v1, n3);
                Array.Copy(v1, v2, n2);
                Array.Copy(v3, v1, n1);
                neg = 1;
            }
            Stack<int> sub = new Stack<int>();
            j = n1 - 1;
            k = n2 - 1;
            x = 0;
            while (j >= 0 && k >= 0)
            {
                if (v1[j] - v2[k] + x < 0)
                {
                    sub.Push((10 + v1[j]) - v2[k] + x);
                    x = -1;

                }
                else
                {
                    sub.Push(v1[j] - v2[k] + x);
                    x = 0;
                }
                try
                {
                    j--;
                    k--;
                }
                catch (IndexOutOfRangeException e)
                {
                    throw;
                }
            }
            while (j <= 0 && k >= 0)
            {
                sub.Push(v2[k] + x);
                x = 0;
                try
                {
                    k--;
                }
                catch (IndexOutOfRangeException e)
                {
                    throw;
                }

            }
            while (j >= 0 && k <= 0)
            {
                sub.Push(v1[j] + x);
                x = 0;
                try
                {
                    j--;
                }
                catch (IndexOutOfRangeException e)
                {
                    throw;
                }

            }
            if (neg == 1)
            {
                Console.Write("-");
            }
            /*foreach (int digit in sub)
            {
                Console.Write($"{digit}");
            }
            Console.WriteLine();*/
            while (sub.Count != 0 && sub.Peek() == 0)
            {
                sub.Pop();
            }
            int[] subtraction = sub.ToArray();
            return subtraction;
        }
        private static int[] Multiply(int[] v1, int[] v2)
        {
            int i, j, n1 = v1.Length, n2 = v2.Length, k, x;
            if (n2 > n1)
            {
                int n3 = n2;
                int[] v3 = new int[n3];
                Array.Copy(v2, v3, n2);
                n2 = n1;
                n1 = n3;
                Array.Resize(ref v1, n3);
                Array.Copy(v1, v2, n2);
                Array.Copy(v3, v1, n1);

            }
            int[,] elem = new int[n2, n1 + n2];

            int end = n1 + n2 - 1, line = 0, column = end;

            k = n2 - 1;
            while (k >= 0)
            {

                x = 0;
                j = n1 - 1;
                while (j >= 0)
                {

                    elem[line, column] = (v1[j] * v2[k] + x) % 10;
                    x = (v1[j] * v2[k] + x) / 10;
                    column--;
                    if (j == 0 && x != 0)
                    {
                        elem[line, column] = x;
                        column--;
                    }

                    try
                    {
                        j--;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        throw;
                    }

                }
                try
                {
                    k--;
                }
                catch (IndexOutOfRangeException e)
                {
                    throw;
                }
                x = 0;
                line++;
                end--;
                column = end;
            }
           
           // Console.WriteLine();
            column = n1 + n2 - 1;
            Stack<int> mult = new Stack<int>();
            int result;
            x = 0;
            while (column >= 0)
            {
                result = 0;
                for (line = 0; line < n2; line++)
                {
                    result += elem[line, column];
                }

                mult.Push((result + x) % 10);
                x = (result + x) / 10;

               /* if (column == 1 && x != 0 && elem[line, 0] == 0)
                {
                    mult.Push(x);
                }*/

                try
                {
                    column--;
                }
                catch (IndexOutOfRangeException e)
                {
                    throw;
                }
            }

          /*  foreach (int item in mult)
            {
                Console.Write($"{item}");
            }*/
            while(mult.Count != 0 && mult.Peek() == 0)
            {
                mult.Pop();
            }
            int[] multiplication = mult.ToArray(); 
            return multiplication;
        }
        /// <summary>
        /// calculeaza v1 la puterea v2
        /// </summary>
        /// <param name="v2">putere</param>
        /// <param name="v1">baza</param>
        /// <returns></returns>
        private static int[] Power(int[]v1, int[]v2)
        {
            
           /* foreach (var item in v2)
            {
                Console.Write(item);
            }*/
            Console.WriteLine();
            int[] one = { 1 };
            int[] two = { 2 };
            v2 = Subtract(v2, two);
            int[] result = Multiply(v1, v1);
            while (Array.FindIndex(v2, (elem) => elem != 0) != -1)
            { 
                
                result = Multiply(result, v1);
                v2 = Subtract(v2, one);
               /*foreach (var item in result)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
                foreach (var item in v2)
                {
                    Console.Write(item);
                }
                Console.WriteLine();*/



            }
              
            return result;
        }
        
       
        
    }
}
