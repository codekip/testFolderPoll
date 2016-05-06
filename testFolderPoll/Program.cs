using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace testFolderPoll
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch ss = new Stopwatch();

            ss.Start();
            var x = Filer.GetFiles(@"L:\02 Technical Database");

            File.WriteAllLines(@"C:\Users\sawe.nk\Desktop\binthese\files.txt", x);

            //foreach (var f in x)
            //{
            //    Console.WriteLine(f);
                
            //}

            ss.Stop();

            Console.WriteLine(ss.Elapsed.TotalSeconds + " seconds for " + x.Count() + " files");
            Console.ReadLine();
        }
    }
}
