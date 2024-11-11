public class Delegates
{
    public Delegates()
    {
        // Callback delegates
        new CallBackDelegate();
    }
}

public class CallBackDelegate
{
    // Define a method that matches a callback delegate
    public void OnProcessComplete(string message)
    {
        System.Console.WriteLine("Delegate function is called!");
        System.Console.WriteLine(message);
    }
    public CallBackDelegate()
    {
        // Pass the OnProcessComplete callback method
        var newProcess = new Process();
        newProcess.ProcessStart(OnProcessComplete);
    }
}
public class Process
{
    // Define a delegate
    public delegate void ProcessCompleteCallBack(string message);
    public void ProcessStart(ProcessCompleteCallBack calllBack)
    {
        System.Console.WriteLine("Process Started...");
        System.Threading.Thread.Sleep(5000);
        calllBack("Process completed!");
    }
}