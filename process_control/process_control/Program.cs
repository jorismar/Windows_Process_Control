using System.Threading;
using System.Diagnostics;

class Program
{
    private Process process;

    public Program(string exec_path, string args="", bool hidden=false) {
        this.process = new Process();
        this.process.StartInfo.UseShellExecute = true;
        this.process.StartInfo.FileName = exec_path;
        this.process.StartInfo.Verb = "runas";
        this.process.StartInfo.Arguments = args;

        if (hidden)
            this.process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    }

    public bool Start() {
        bool success = false;

        try {
            success = this.process.Start();
        } catch(System.ComponentModel.Win32Exception exc) {
            System.Console.WriteLine("There was an error opening the associated file.");
        } catch (System.ObjectDisposedException exc) {
            System.Console.WriteLine("The process object has already been disposed.");
        } catch (System.InvalidOperationException exc) {
            System.Console.WriteLine("No file name was specified in the Process component's StartInfo.");
        }

        return success;
    }

    public void Terminate() {
        try
        {
            this.process.Kill();
        } catch (System.ComponentModel.Win32Exception exc) {
            System.Console.WriteLine("The associated process could not be terminated.");
        } catch (System.NotSupportedException exc) {
            System.Console.WriteLine("You are attempting to call Kill for a process that is running on a remote computer.");
        } catch (System.InvalidOperationException exc) {
            System.Console.WriteLine("The process has already exited.");
        }

        try
        {
            this.process.WaitForExit();
        } catch (System.ComponentModel.Win32Exception exc) {
            System.Console.WriteLine("The wait setting could not be accessed.");
        } catch (System.SystemException exc) {
            System.Console.WriteLine("There is no process associated with this Process object.");
        }
    }
}

