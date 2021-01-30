using System;
using System.IO;
using static System.IO.Path;
using TempElementsLib;
using System.Threading;

namespace TempElementsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region test 1 ex
            //using(var x = new TempFile("mojplik.txt"))
            // {
            //     x.AddText("testowy tekst");
            //     Thread.Sleep(20000);
            // }
            //var x = new TempFile("mojplik.txt");
            //x.AddText("test");
            //Thread.Sleep(1000);
            //x.Dispose();
            //try
            //{
            //    x.AddText("test po dispose");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            #endregion
            #region test 2 ex
            //using (var x = new TempTxtFile("mojplik.txt"))
            //{
            //    x.Write("testtekst");
            //    x.Write("tekst2");
            //    x.WriteLine("linetext");
            //    x.WriteLine("linetext2");
            //    x.WriteLine("linetext3");
            //    x.WriteLine("linetext4");
            //    x.WriteLine("linetext5");
            //    x.WriteLine("linetext6");
            //    x.WriteLine("linetext7");
            //    x.WriteLine("linetext8");
            //    //Thread.Sleep(5000);
            //}
            #endregion
            #region test 3 ex
            //using (var dir = new TempDir("c:/test"))
            //{
            //    Console.WriteLine(dir.DirPath);
            //    Console.WriteLine(dir.IsEmpty);
            //    Thread.Sleep(10000);
            //}
            #endregion
        }
    }
}
