using System;
using System.Collections.Generic;
using System.IO;

namespace testFolderPoll
{
    public static class Filer
    {

        public static IEnumerable<string> GetFiles(string path, string filefilter = "")
        {
            List<string> thefiles = null;

            try
            {
                if (File.Exists(path))
                {
                    // This path is a file
                    ProcessFile(path, ref thefiles);
                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
             

             
            try
            {
                if (Directory.Exists(path))
                {
                    // This path is a directory
                    ProcessDirectory(path, ref thefiles, filefilter);
                }
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            return thefiles;

        }

        private static void ProcessDirectory(string path, ref List<string> thefiles, string filefilter)
        {

            //Process files in the directory
            IEnumerable<string> filesindir = Directory.GetFiles(path);
            foreach (var filename in filesindir)
            {
                if (filefilter != string.Empty)
                {
                    if (filename.Contains(filefilter))
                    {
                        ProcessFile(filename, ref thefiles);
                    }
                }
                else
                {
                    ProcessFile(filename, ref thefiles);
                }
            }

            //Recurse subdirectories
            IEnumerable<string> subdirectories = Directory.GetDirectories(path);
            foreach (var sub in subdirectories)
            {
                ProcessDirectory(sub, ref thefiles, filefilter);
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