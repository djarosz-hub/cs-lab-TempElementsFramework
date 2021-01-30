using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TempElementsLib
{
    public class TempTxtFile : TempFile
    {
        public readonly StreamWriter txtWriter;
        public readonly StreamReader txtReader;
        public TempTxtFile() : base() { }
        public TempTxtFile(string fileName) : base(fileName)
        {
            txtReader = new StreamReader(fileStream);
            txtWriter = new StreamWriter(fileStream);
        }
        public void Write(string text)
        {
            txtWriter.Write(text);
            txtWriter.Flush();
        }
        public void WriteLine(string text)
        {
            txtWriter.WriteLine(text);
            txtWriter.Flush();
        }
        public void ReadLine()
        {
            string output = txtReader.ReadLine();
            Console.WriteLine("--Reading The File--" + Environment.NewLine + output + Environment.NewLine);
        }
        public void ReadAllText()
        {
            string output = txtReader.ReadToEnd();
            Console.WriteLine("--Reading The File--" + Environment.NewLine + output + Environment.NewLine);
        }
        ~TempTxtFile() { Dispose(false); }
        public new void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        public new void Dispose(bool disposing)
        {
            if (disposing)
            {
                fileStream?.Dispose();
            }
            txtWriter?.Dispose();
            txtReader?.Dispose();
            isDestroyed = true;
            fileInfo?.Delete();
            Console.WriteLine("deleted");
        }
    }
}
