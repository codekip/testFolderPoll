using System;
using System.Collections.Generic;
using System.IO;

namespace testFolderPoll
{
    public static class Filer
    {

        public static IEnumerable<string> GetFiles(string path)
        {
            List<string> thefiles = null;

                if (File.Exists(path))
                {
                    // This path is a file
                    ProcessFile(path, ref thefiles);

                }
                else if (Directory.Exists(path))
                {
                    // This path is a directory
                    ProcessDirectory(path, ref thefiles);
                }
                else
                {
                    Console.WriteLine("{0} is not a valid file or directory.", path);
                }
            
            return thefiles;

        }

        private static void ProcessDirectory(string path, ref List<string> thefiles)
        {
            
            //Process files in the directory
            IEnumerable<string> filesindir = Directory.GetFiles(path);
            foreach (var filename in filesindir)
            {
                if (!filename.Contains("~"))
                {
                    ProcessFile(filename, ref thefiles);
                }
            }

            //Recurse subdirectories
            IEnumerable<string> subdirectories = Directory.GetDirectories(path);
            foreach (var sub in subdirectories)
            {
                ProcessDirectory(sub, ref thefiles);
            }

        }

        private static void ProcessFile(string path, ref List<string> thefiles)
        {
            if (thefiles == null)
            {
                thefiles = new List<string>();
                thefiles.Add(path);
            }
            else
            {
                thefiles.Add(path);
            }
        }
    }
}