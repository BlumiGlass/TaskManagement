using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagement.classses;
using TaskManagement.interfaces;

namespace TaskManagement.classses.status
{
    public class Done : IStatus
    {
        public Done(Task1 task):base(task)
        {
            
        }
        public override void ChangeStatus()
        {
            Console.WriteLine("Your task was completed");
        }
    }
}
