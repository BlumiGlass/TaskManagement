using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.interfaces;

namespace TaskManagement.classses
{
    public class ConsoleNotify : INotifier
    {
        //Singelton
        private static ConsoleNotify? _instance = null;
        public static ConsoleNotify Instance=>_instance ??= new ConsoleNotify();
        public void notify(string message)
        {
            Console.WriteLine(message);
        }
    }
}
