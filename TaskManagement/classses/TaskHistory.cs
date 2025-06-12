using TaskManagement.classses.Handler;
using TaskManagement.interfaces;

namespace TaskManagement.classses
{
    public class TaskHistory //Memento
    {
        private Task1 _originator;
        private Stack<ITask> historyStack;

        public TaskHistory(Task1 originator)
        {
            _originator = originator;
            historyStack = new Stack<ITask>();
        }

        public void ChangeStatus(StatusHandler handler)
        {
            historyStack.Push(_originator.CreateBackup());
            bool reporterHandle = handler.Handle(_originator, _originator.Reporter);
            if (!reporterHandle)
            {
                handler.Handle(_originator, _originator.Assignee);
            }
        }

        public void ChangeAssignee(User assignee)
        {
            historyStack.Push(_originator.CreateBackup());
            _originator.ChangeAssignee(assignee);
        }

        public void ChangeReporter(User reporter)
        {
            historyStack.Push(_originator.CreateBackup());
            _originator.ChangeReporter(reporter);
        }

        public void UpdateLoggedTime(float time)
        {
            historyStack.Push(_originator.CreateBackup());
            _originator.LoggedTime += time;
        }

        public void Undo()
        {
            if (historyStack.Count == 0)
                throw new OutOfMemoryException("you don't have previous state");

            var memento = historyStack.Pop();
            _originator.Restore(memento);
        }
    }
}
