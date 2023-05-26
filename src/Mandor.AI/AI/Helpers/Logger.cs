using System.Diagnostics;

namespace Mandor.AI.Helpers
{
    public class Logger
    {
        public static void WriteLine(string Message)
        {
            Debug.WriteLine(Message);
        }
        
        public static void WriteLine(string Format, params object[] arguments)
        {
            Debug.WriteLine(Format,arguments);
        }

    }
}
