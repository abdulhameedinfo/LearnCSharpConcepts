public class Delegates
{
    public Delegates()
    {
        // Callback delegates
        new CallBackDelegate();

        // Generic delegate to High Order function 


        System.Console.WriteLine(devide(6, 2));
    }

    // built-in delegate in .NET used to represent methods with 2 input parameters and one return type. like int Divide(int t1, int t2);
    // The part (t1, t2) => t1 / t2 is a lambda expression.
    public Func<int, int, int> devide = (t1, t2) => t1 / t2;
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