using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.classses;

namespace TaskManagement.classses.Handler
{
    //Chain of responsibility
    public class StatusHandler
    {
      private  StatusHandler _next;
        public void SetNext(StatusHandler next)
        {
            _next = next;
        }
        public virtual bool Handle(Task1 task, User user)
        {
            if (_next != null)
            {
                return  _next.Handle(task, user);
            }
            return false;
        }

    }
}
