using System;
using Reform;

namespace BasicSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var fooValue = DateTime.Now.Transform<DateTime, Foo>();
            Console.WriteLine(fooValue.Date);
            // or in case it could fail, you can try:

            if (DateTime.Now.TryTransform<DateTime, Foo>(out var fooObj))
            {
                Console.WriteLine(fooObj.Date);
            }
            else
            {
                Console.WriteLine("):");
            }
        }
    }
}