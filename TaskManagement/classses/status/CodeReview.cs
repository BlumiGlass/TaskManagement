using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagement.interfaces;

namespace TaskManagement.classses.status
{
    public class CodeReview : IStatus
    {
        public CodeReview(Task1 task) : base(task)
        {
        }

        public override void ChangeStatus()
        {
            _task.ChangeStatus(new QA(_task));
        }
    }
}
