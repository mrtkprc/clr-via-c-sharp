using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AssemblyLinker;

namespace AssemblyBinding
{
    class Program
    {
        static void Main(string[] args)
        {
			FUT f = new FUT();
			var result = f.Add(2,3);
            Console.WriteLine("Hello Assembly Binding.");
			Console.WriteLine("Sum operation is done by .netmodule.");
			Console.WriteLine($"Result: 2 + 3 = {result}");
            Console.ReadLine();
        }
    }
}
