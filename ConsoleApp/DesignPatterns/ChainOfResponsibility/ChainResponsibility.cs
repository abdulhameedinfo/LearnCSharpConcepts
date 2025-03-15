
namespace ChainOfResponsibilities
{

    public class ChainOfResponsibility
    {
        public ChainOfResponsibility()
        {
            var infoLogger = new InfoLogger();
            var errorLogger = new ErrorLogger();

            // Chain the handlers (responsibilities)
            infoLogger.SetSuccessor(errorLogger);

            infoLogger.HandleRequest(2, "This is a request to log the information");
            infoLogger.HandleRequest(3, "This is a request to log the error");

        }
    }

    internal class ErrorLogger : Logger
    {
        public ErrorLogger()
        {
        }
        protected override void WriteMessage(string message)
        {
            System.Console.WriteLine("Request handled by " + this.GetType().Name);
            Console.WriteLine("ErrorLogger: " + message);
        }
        protected override bool CanHandleRequest(int requestCode)
        {
            return requestCode == 3;
        }
    }

    internal class InfoLogger : Logger
    {
        public InfoLogger()
        {
        }

        protected override bool CanHandleRequest(int requestCode)
        {
            return requestCode == 2;
        }
        protected override void WriteMessage(string message)
        {
            System.Console.WriteLine("Request handled by " + this.GetType().Name);
            Console.WriteLine("InfoLogger: " + message);

        }
    }

    internal abstract class Logger
    {
        private Logger? successor;
        internal void SetSuccessor(Logger successor)
        {
            this.successor = successor;
        }

        internal void HandleRequest(int requestCode, string message)
        {
            if (CanHandleRequest(requestCode))
            {
                WriteMessage(message);
            }
            else if (successor != null)
            {
                successor.HandleRequest(requestCode, message);
            }
        }

        protected abstract void WriteMessage(string message);

        protected abstract bool CanHandleRequest(int requestCode);
    }
}