using System;

namespace OM1
{
    class Function
    {

        double a, b, delta, eps = 0.1, min;
        public double Min => min;

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


            while (Math.Abs(Y(a)-Y(b))>eps)
            {
                double x1 = (a + b - delta) / 2;
                double x2 = (a + b + delta) / 2;
                double y1 = Y(x1);
                double y2 = Y(x2);
                if (y2>y1)
                {
                    b = x2;
                    continue;
                }
                if (y1>y2)
                {
                    a = x1;
                    continue;
                }
                a = x1;
                b = x2;
            }
            min = Y((a + b) / 2);

        }


    }
}
