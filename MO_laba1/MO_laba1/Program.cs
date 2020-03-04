using System;
using System.Collections;
using System.IO;
namespace MO_laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            string writePath = @"C:\Users\User\source\repos\MO_laba1\MO_laba1\out.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine();
            }
            //Dich(0.001, -10, 20);
            for (int i = 1; i < 8; i++)
            {
                double a = -Math.PI / 2;
                double b = Math.PI / 2;
                Console.WriteLine(1 / Math.Pow(10, i));
                Fib(1 / Math.Pow(10, i), a, b);
                Golden(1 / Math.Pow(10, i), a, b);
                Dich(1 / Math.Pow(10, i), a, b);

            }
            //Find_area_min(0.01, 0, -10, 20);
        }
        static double F(double x)
        {
            return x * x + 2 * x - 4;
        }
        static void Dich(double eps, double a, double b)
        {
            double x1, x2, f1, f2;
            int i = 0;
            string writePath = @"C:\Users\User\source\repos\MO_laba1\MO_laba1\out.txt";
            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine("Dih");
            }
            double l = b - a;
            while (Math.Abs(a - b) > 2 * eps)
            {
                i += 2;
                x1 = (a + b - eps) / 2;
                x2 = (a + b + eps) / 2;
                f1 = F(x1);
                f2 = F(x2);
                if (f1 > f2)
                    a = x1;
                else
                    b = x2;
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine($"{i}\t{a}\t{b}\t{l / (b - a)}\t{x1}\t{x2}\t{F(x1)}\t{F(x2)}");
                }
                l = b - a;
            }
            //Console.WriteLine((a + b) / 2);
            Console.WriteLine(i);
        }

        static void Find_area_min(double delta, double x0, double a, double b)
        {
            string writePath = @"C:\Users\User\source\repos\MO_laba1\MO_laba1\out.txt";
            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine("Min area");
            }
            double f0 = F(x0), x1 = x0 + delta, f1 = F(x1), h = delta;
            int i = 1;
            if (f0 < f1)
            {
                x1 = x0 - delta;
                h *= -1;
            }
            bool flag = false;
            double l = a - b;
            while (!flag)
            {
                h *= 2;
                x0 = x1 + h;
                f0 = F(x0);

                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine($"{i}\t{x0}\t{x1}\t{l / (x1 - x0)}");
                }
                i++;

                if (f1 > f0)
                {
                    x1 = x0;
                    f1 = f0;
                    l = b - a;
                }
                else
                {
                    flag = true;
                    x1 = x0;
                    x0 -= h + h / 2;
                    l = b - a;
                }

            }
            a = x1;
            b = x0;
            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine($"{i}\t{a}\t{b}\t{l / (b - a)}");
            }

        }

        static void Fib(double eps, double a, double b)
        {
            string writePath = @"C:\Users\User\source\repos\MO_laba1\MO_laba1\out.txt";
            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine("Fib");
            }
            double x1, x2, f1, f2, max = (b - a) / eps;

            int add_fib, n = 2;
            bool flag = true;
            ArrayList fib_numbers = new ArrayList();
            fib_numbers.Add(1);
            fib_numbers.Add(1);
            do
            {
                add_fib = (int)fib_numbers[n - 1] + (int)fib_numbers[n - 2];
                fib_numbers.Add(add_fib);
                n++;
            } while (max > add_fib);
            n = fib_numbers.Count - 3;
            
            x1 = a + (int)fib_numbers[n] * (b - a) / (int)fib_numbers[n + 2];
            x2 = a + (int)fib_numbers[n + 1] * (b - a) / (int)fib_numbers[n + 2];
            //x2 = a + b - x1;
            f1 = F(x1);
            f2 = F(x2);
            int i = 2;
            double l = b - a;
            for (int k = 1; k < n; k++)
            {
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine($"{i}\t{a}\t{b}\t{l / (b - a)}\t{x1}\t{x2}\t{F(x1)}\t{F(x2)}");
                }
                if (f1 < f2)
                {
                    l = b - a;
                    b = x2;
                    x2 = x1;
                    f2 = f1;
                    flag = true;
                }
                else
                {
                    l = b - a;
                    a = x1;
                    x1 = x2;
                    f1 = f2;
                    flag = false;
                }
                if (flag)
                {
                    x1 = a + (int)fib_numbers[n - k + 1] * (b - a) / (int)fib_numbers[n - k + 3];
                    f1 = F(x1);
                }
                else
                {
                    x2 = a + (int)fib_numbers[n - k + 2] * (b - a) / (int)fib_numbers[n - k + 3];
                    f2 = F(x2);
                }
                i++;
            }
            
            Console.WriteLine(i);

        }

        static void Golden(double eps, double a, double b)
        {
            string writePath = @"C:\Users\User\source\repos\MO_laba1\MO_laba1\out.txt";
            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine("Gold");
            }
            //double r = (-1 + Math.Sqrt(5)) / 2;
            double r = (3 - Math.Sqrt(5)) / 2;
            //double x1 = a + (1 - r) * (b - a);
            double x1 = a + r * (b - a);
            double x2 = b - r * (b - a);
            double l = b - a;
             //double x2 = a + r * (b - a);
             double y1 = F(x1);
             double y2 = F(x2);
             int i = 2;
            while (Math.Abs(a-b) > eps)
            {
                i++;
                //Console.WriteLine($"{iterations} {a} {b} {l/(b-a)} {x1} {x2} {Y(x1)} {Y(x2)}");
                if (y1 < y2)
                {
                    l = b - a;
                    b = x2;
                    x2 = x1;
                    //x1 = a + (1 - r) * (b - a);
                    x1 = a + r * (b - a);
                    y2 = y1;
                    y1 = F(x1);
                }
                else
                {
                    l = b - a;
                    a = x1;
                    x1 = x2;
                    //x2 = a + r * (b - a);
                    x2 = b - r * (b - a);
                    y1 = y2;
                    y2 = F(x2);
                }
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine($"{i}\t{a}\t{b}\t{l / (b - a)}\t{x1}\t{x2}\t{F(x1)}\t{F(x2)}");
                }
            }
             Console.WriteLine(i);
        }
    }

}
