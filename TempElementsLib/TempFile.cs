using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.IO.Path;
using TempElementsLib.Interfaces;

namespace TempElementsLib
{
    public class TempFile : ITempFile
    {
        public readonly FileStream fileStream;
        public readonly FileInfo fileInfo;
        private bool isDestroyed = false;
        public string FilePath => fileInfo.FullName;
        public bool IsDestroyed => isDestroyed;

        public TempFile(string fileName)
        {
            if (Directory.Exists(fileName))
            {
                if (!File.Exists(fileName))
                {
                    string tempPath = Path.GetTempFileName();
                    fileInfo = new FileInfo(tempPath);
                }
                else
                {
                    Console.WriteLine("File already exists.");
                    return;
                }
            }
            else
            {
                string path = Path.GetTempPath() + fileName;
                fileInfo = new FileInfo(path);
            }
            fileStream = new FileStream(
            fileInfo.FullName, FileMode.OpenOrCreate,
            FileAccess.ReadWrite);
            fileInfo.Attributes = FileAttributes.Temporary;
            Console.WriteLine($"File {fileInfo.FullName} created");
        }
        public TempFile()
        {
            string path = Path.GetTempFileName();
            fileInfo = new FileInfo(path);
            fileStream = new FileStream(
                fileInfo.FullName, FileMode.OpenOrCreate,
                FileAccess.ReadWrite);
            Console.WriteLine($"File {fileInfo.FullName} created");
        }
        public void AddText(string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fileStream.Write(info, 0, info.Length);
            fileStream.Flush();
        }
        ~TempFile() { Dispose(false); }
        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                fileStream?.Dispose();
            }
            isDestroyed = true;
            fileInfo?.Delete();
            Console.WriteLine("deleted");
        }
    }
}
