using System;
using Reform;

namespace BasicSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = DateTime.Now.TryTransform<DateTime, Foo>(out var c);
            Console.WriteLine(b);
        }
    }
}