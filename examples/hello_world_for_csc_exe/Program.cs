using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpBinSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello DumpBin Sample.");
            Console.WriteLine($"Is OS 64Bits: {Environment.Is64BitOperatingSystem}");
            Console.WriteLine($"Is Process 64Bits: {Environment.Is64BitProcess}");
            Console.ReadLine();
        }
    }
}
