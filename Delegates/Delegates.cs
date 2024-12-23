public class DelegatesExample
{
    public DelegatesExample()
    {
        // Execute callback delegate example
        CallbackHandler.Execute();

        // Execute lambda function using a built-in delegate
        System.Console.WriteLine(Divide(6, 2));
    }

    // Built-in .NET delegate representing a method with 2 input parameters and one return type (e.g., int Divide(int a, int b)).
    // Lambda expression: (a, b) => a / b
    public Func<int, int, int> Divide = (a, b) => a / b;
}

public static class CallbackHandler
{
    //Delegate function to handle process completion. 
    public static void OnProcessComplete(string message)
    {
        System.Console.WriteLine(message);
        System.Console.WriteLine("Callback delegate executed successfully.");
    }

    // Method to demonstrate passing delegate as an argument. 
    public static void Execute()
    {
        // Pass Delegate as an argument
        var processExecutor = new ProcessExecutor();
        processExecutor.StartProcess(OnProcessComplete);
    }
}
public class ProcessExecutor
{
    // Delegate to handle process completion
    public delegate void ProcessCompletionDelegate(string message);

    // Method that accepts a delegate as a parameter
    public void StartProcess(ProcessCompletionDelegate completionCallback)
    {
        System.Console.WriteLine("Process execution started...");
        completionCallback("Process execution completed successfully.");
    }
}