using System;
using Reform;

namespace BasicSample
{
    // public class DateToFooTransformer : ITransformer<Foo, DateTime>
    // {
    //     public Foo Transform(DateTime from)
    //     {
    //         return new Foo {Date = from};
    //     }
    // }

    public class Foo
    {
        public DateTime Date { get; set; }
    }
}