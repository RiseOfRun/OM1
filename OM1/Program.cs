using System;

namespace OM1
{
    class Program
    {
        static void Main(string[] args)
        {
            Function first = new Function(-10,20,0.001);
            first.Dih();
            Console.WriteLine($"{first.Min}");
        }
    }
}
