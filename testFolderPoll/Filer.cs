using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace testFolderPoll
{
    public static class Filer
    {
        public static IEnumerable<string> GetFiles(string cUsersNickDesktopNewFolder)
        {
            var thefiles = Directory.GetFiles(cUsersNickDesktopNewFolder).ToList();

            var subdir = Directory.GetDirectories(cUsersNickDesktopNewFolder);

            foreach (var s in subdir)
            {
                var subdirfiles = ProcessDir(s);

                thefiles.AddRange(subdirfiles);
            }
            return thefiles;

        }

        private static IEnumerable<string> ProcessDir(string dir)
        {
            var thefiles = Directory.GetFiles(dir).ToList();

            return thefiles;
        }
    }
}