using System.Threading;
using System.Diagnostics;

class Program
{
    private Process process;

    public Program(string exec_path, string args, bool hidden=false) {
        this.process = new Process();
        this.process.StartInfo.UseShellExecute = true;
        this.process.StartInfo.FileName = exec_path;
        this.process.StartInfo.Verb = "runas";
        this.process.StartInfo.Arguments = args;

        if (hidden)
            this.process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    }

    public bool Start() {
        bool success;

        try {
            success = this.process.Start();
        } catch(System.Exception e) {
            throw e;
        }

        return success;
    }

    public void Terminate() {
        try {
            this.process.Kill();
            this.process.WaitForExit();
        }
        catch (System.Exception e) {
            throw e;
        }
    }
}

