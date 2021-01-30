using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TempElementsLib.Interfaces;

namespace TempElementsLib
{
    public class TempDir : ITempDir
    {
        private DirectoryInfo dirInfo;
        public string DirPath => dirInfo.FullName;
        public bool IsEmpty => Directory.GetDirectories(dirInfo.FullName).Length == 0 ? true : false;
        public bool IsDestroyed => Directory.Exists(dirInfo.FullName);
        public TempDir()
        {
            string tempDirectory = string.Empty;
            do
            {
                tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            }
            while (Directory.Exists(tempDirectory));
            //Directory.CreateDirectory(tempDirectory);
            dirInfo = new DirectoryInfo(tempDirectory);
            dirInfo.Create();
            Console.WriteLine($"Created directory: {tempDirectory}");
        }
        public TempDir(string path)
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine("Path already exists.");
                return;
            }
            try
            {
                Path.GetFullPath(path);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                return;
            }
            dirInfo = new DirectoryInfo(path);
            dirInfo.Create();
            Console.WriteLine($"Created directory: {path}");

        }
        ~TempDir() { Dispose(false); }
        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Empty();
            }
            dirInfo?.Delete();
            Console.WriteLine("deleted");
        }
        public void Empty()
        {
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}
