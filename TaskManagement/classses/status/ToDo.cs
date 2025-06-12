using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.interfaces;

namespace TaskManagement.classses.status
{
    public class ToDo : IStatus
    {
        public ToDo(Task1 task) : base(task)
        {
        }

        public override void ChangeStatus()
        {
            _task.ChangeStatus(new InProgress(_task));
        }
    }
}
