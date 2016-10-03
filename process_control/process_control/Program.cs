using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = @"C:\Windows\Notepad.exe";
            process.StartInfo.Verb = "runas";
            process.Start();
            System.Threading.Thread.Sleep(10000);
            process.Kill();
            process.WaitForExit();
        }
    }
}
