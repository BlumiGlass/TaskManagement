using TaskManagement.classses;

namespace TaskManagement.interfaces
{
    //state
    public abstract class IStatus
    {
        protected Task1 _task;
        protected IStatus(Task1 task)
        {
            _task = task;
        }
        public abstract void ChangeStatus();
    }
}
