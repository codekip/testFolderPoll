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
            string textfilepath = @"C:\Users\sawe.nk\Desktop\binthese\files.txt";
            string tdbpath = @"L:\02 Technical Database";

                Stopwatch ss = new Stopwatch();

                ss.Start();

                var x = Filer.GetFiles(tdbpath);

                File.WriteAllLines(textfilepath, x);
                ss.Stop();

           // Debug.Print("done");

                //using (StreamWriter swriter = new StreamWriter(textfilepath, true))
                //{
                //    swriter.WriteLine(ss.Elapsed.TotalSeconds + " seconds for " + x.Count() + " files");
                //}


            // Console.WriteLine(ss.Elapsed.TotalSeconds + " seconds for " + x.Count() + " files");
            //Console.ReadLine();
        }
    }
}
