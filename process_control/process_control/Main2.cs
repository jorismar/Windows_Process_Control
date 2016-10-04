using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Main2
{
    static void Main(string[] args)
    {
        Program program = new Program("C:\\Windows\\System32\\notepad.exe");

        program.Start();
        System.Threading.Thread.Sleep(5000);
        program.Terminate();
        System.Threading.Thread.Sleep(5000);
    }
}
