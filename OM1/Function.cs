using System;

namespace OM1
{
    class Function
    {

        double a, b, delta, eps = 0.1, min;
        public double Min => min;
        public int iterations = 0;

        public Function(double a, double b,double eps)
        {
            this.a = a;
            this.b = b;
            this.eps = eps;
        }
        private double Y(double x)
        {
            return x * x + 2 * x - 4;
        }
        public void Dih()
        {
            delta = eps / 4;

            double x1 = (a + b - delta) / 2;
            double x2 = (a + b + delta) / 2;
            double ya = Y(a);
            double yb = Y(b);
            double y1, y2;
            double l = b - a;
            while (Math.Abs(ya-yb)>eps)
            {
                iterations++;
                //Console.WriteLine($"{iterations} {a} {b} {l / (b - a)} {x1} {x2} {Y(x1)} {Y(x2)}");
                x1 = (a + b - delta) / 2;
                x2 = (a + b + delta) / 2;
                y1 = Y(x1);
                y2 = Y(x2);
                if (y2>y1)
                {
                    l = b - a;
                    b = x2;
                    yb = Y(x2);
                    continue;
                }
                if (y1>y2)
                {
                    l = b - a;
                    a = x1;
                    ya = Y(x1);
                    continue;
                }

                a = x1;
                b = x2;
                ya = Y(x1);
                yb = Y(x2);
            }
            min = Y((a + b) / 2);
        }

        public void Goden()
        {
            double r = (-1 + Math.Sqrt(5)) / 2;
            double x1 = a+(1-r)*(b-a);
            double l = b - a;
            double x2 = a+r*(b-a);
            double ya = Y(a);
            double yb = Y(b);
            double y1, y2;

            while (Math.Abs(ya-yb)>eps)
            {
                iterations++;
                //Console.WriteLine($"{iterations} {a} {b} {l/(b-a)} {x1} {x2} {Y(x1)} {Y(x2)}");
                y1 = Y(x1);
                y2 = Y(x2);
                if (y1>y2)
                {
                    l = b - a;
                    a = x1;
                    x1 = x2;
                    x2 = a + r * (b - a);
                    ya = y1;
                    y1 = y2;
                    y2 = Y(x2);
                    continue;
                }

                if (y1<y2)
                {
                    l = b - a;
                    b = x2;
                    x2 = x1;
                    x1 = a + (1 - r) * (b - a);
                    yb = y2;
                    y2 = y1;
                    y1 = Y(x1);
                    continue;
                }
            }

            min = Y((a + b) / 2);
        }


    }
}
