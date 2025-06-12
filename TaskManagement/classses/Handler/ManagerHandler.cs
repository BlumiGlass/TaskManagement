using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagement.classses;
using TaskManagement.classses.status;
using TaskManagement.@enum;

namespace TaskManagement.classses.Handler
{
    public class ManagerHandler:StatusHandler
    {
        public override bool Handle(Task1 task, User user)
        {
            if (user.Role == Role.manager && task.Status.GetType() != typeof(QA))
            {
                task.Status.ChangeStatus();
            }
            return base.Handle(task, user);
        }
    }
}
