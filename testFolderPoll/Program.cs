using System;
using System.Diagnostics;
using System.Linq;

namespace testFolderPoll
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch ss = new Stopwatch();
            ss.Start();
            var x = Filer.GetFiles(@"C:\Users\nick");//C:\Users\nick\Desktop\New folder\
            foreach (var f in x)
            {
                Console.WriteLine(f);
            }

            ss.Stop();
            Console.WriteLine(ss.Elapsed.TotalSeconds + " seconds for " + x.Count() + " files");
            Console.ReadLine();
        }
    }
}
