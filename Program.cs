using System;
using System.IO;
using System.Windows.Forms;

namespace CopyAllModels
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string dir = args[0];
            string[] files = Directory.GetFiles(dir, "*.mdl", SearchOption.AllDirectories);
            string models = "";

            foreach (string file in files)
            {
                try
                {
                    string mdl = GetRightPartOfPath(file, "models");
                    models += mdl + ",";
                }
                catch (Exception)
                {
                    Console.WriteLine("Couldn't get folder wtf.");
                }
            }

            models = models.Replace("\\", "/");
            Clipboard.SetText(models);
        }

        private static string GetRightPartOfPath(string path, string startAfterPart)
        {
            string[] pathParts = path.Split(Path.DirectorySeparatorChar);

            int startAfter = Array.IndexOf(pathParts, startAfterPart);

            if (startAfter == -1)
            {
                return null;
            }

            string lastPartWasDirectory = pathParts[pathParts.Length - 1];
            return string.Join(
                Path.DirectorySeparatorChar.ToString(),
                pathParts, startAfter,
                pathParts.Length - startAfter);
        }
    }
}
