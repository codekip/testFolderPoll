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
            string tdbpath = @"L:\"; // @"L:\02 Technical Database";

            Stopwatch ss = new Stopwatch();

            ss.Start();

            var filelist = Filer.GetFiles(tdbpath);

            File.WriteAllLines(textfilepath, filelist);

            var totalsize = 0;
            foreach (var file in filelist)
            {
                 
                FileInfo fi = null;
                try
                {
                    fi = new FileInfo(file);
                    totalsize += (int)fi.Length/1000;
                }
                catch (FileNotFoundException e)
                {

                    Console.WriteLine(e.Message);
                }

            }

            ss.Stop();

            // Debug.Print("done");

            //can comm out this using bit
            using (StreamWriter swriter = new StreamWriter(textfilepath, true))
            {
                swriter.WriteLine(ss.Elapsed.TotalSeconds + " seconds for " + filelist.Count() + " files");
            }


            //Console.WriteLine(ss.Elapsed.TotalSeconds + " seconds for " + filelist.Count() + " files" + " filesize " + totalsize);
            //Console.ReadLine();
        }
    }
}
