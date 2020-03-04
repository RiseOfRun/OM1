using System;

namespace OM1
{
    class Program
    {
        static void Main(string[] args)
        {
            double eps=1;
            for (int i = 1; i < 8; i++)
            {
                eps /=10;
                Function f1 = new Function(-10, 20, eps);
                Function f2 = new Function(-10, 20, eps);
                f1.Dih();
                f2.Goden();
                Console.WriteLine($"{eps} {f1.iterations*2} {f2.iterations+1}");
            }
        }
    }
}
