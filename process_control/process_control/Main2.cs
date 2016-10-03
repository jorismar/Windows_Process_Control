using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Main2
{
    static void Main(string[] args)
    {
        Program prog = new Program("c:\\Python27\\python.exe", "E:\\testando.py");

        prog.Start();
        System.Threading.Thread.Sleep(5000);
        prog.Terminate();
    }
}
