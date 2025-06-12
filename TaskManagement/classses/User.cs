using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.@enum;
using TaskManagement.interfaces;

namespace TaskManagement.classses
{
    public class User:ITaskSubscriber
    {
        private INotifier _notifier;
        public User() 
        { 
            _notifier = ConsoleNotify.Instance;
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

        //Observer - Subscriber
        public void GetTaskChange(string taskTitle, string changeType)
        {
            _notifier.notify($"{Name} received a notification about a change in task {taskTitle} in {changeType} property.");
        }
        public override string ToString()
        {
            return $"Name:{Name}, Email{Email}, Role:{Role}";
        }
    }
}
