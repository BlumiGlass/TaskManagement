using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagement.classses;
using TaskManagement.classses.status;
using TaskManagement.@enum;

namespace TaskManagement.classses.Handler
{
    public class DeveloperHandler:StatusHandler
    {
        public override bool Handle(Task1 task, User user)
        {
            if(user.Role == Role.developer && task.Status.GetType() == typeof(ToDo))
            {
                task.Status.ChangeStatus();
            }
            return base.Handle(task, user);
        }
    }
}
