using System.Reflection;
using TaskManagement.classses.status;
using TaskManagement.@enum;
using TaskManagement.interfaces;

namespace TaskManagement.classses;

public class Task1 : ITask
{
    public Task1()
    {
        Status = new ToDo(this);
    }
    public DateTime CreationDate { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    //Composite
    private float estimationTime;
    public float EstimationTime
    {
        get { return estimationTime; }
        set
        {
            if (Subtasks == null)
                estimationTime = value;
            else
            {
                float sum = 0;
                foreach (var task in Subtasks)
                    sum += task.EstimationTime;
                estimationTime = sum;
            }
        }
    }
    private float loggedTime;
    public float LoggedTime
    {
        get { return loggedTime; }
        set
        {
            if (Subtasks == null)
                loggedTime = value;
            else
            {
                float sum = 0;
                foreach (var task in Subtasks)
                    sum += task.loggedTime;
                loggedTime = sum;
            }
        }
    }
    private User assignee;
    public User Assignee
    {
        get { return assignee; }
        set {
            if(_subscribers.Count > 0 && _subscribers.Find(s => s == assignee) != null)
                _subscribers.Remove(assignee);
            assignee = value;
            AddSubscribe(assignee);
        }
    }
    private User reporter;
    public User Reporter
    {
        get { return reporter; }
        set
        {
            if (_subscribers.Count > 0 && _subscribers.Find(s => s == reporter) != null)
                _subscribers.Remove(reporter);
            reporter = value;
            AddSubscribe(reporter);
        }
    }
    public IStatus Status { get; set; }
    public Priority Priority { get; set; }
    public List<Task1> Subtasks { get; set; }

    public override string ToString()
    {
        return $"CreationDate:{CreationDate}, Title:{Title}, " +
            $"Description:{Description}, EstimationTime:{estimationTime}, LoggedTime:{loggedTime}, " +
            $"Assignee:{Assignee}, Reporter:{Reporter}, Status:{Status}, " +
            $"Priority:{Priority}, Subtasks:{Subtasks}";
    }


    //Memento - Originator
    public void ChangeAssignee(User assignee)
    {
        Assignee = assignee;
        Emit("Assignee");
    }

    public void ChangeReporter(User reporter)
    {
        Reporter = reporter;
        Emit("Reporter");
    }

    public ITask CreateBackup()
    {
        List<Task1> subtasks;
        if (Subtasks == null)
            subtasks = null;
        else subtasks = Subtasks.Select(x => x).ToList();

        User assignee = new User()
        {
            Name = Assignee.Name,
            Email = Assignee.Email,
            Role = Assignee.Role
        };
        User reporter = new User()
        {
            Name = Reporter.Name,
            Email = Reporter.Email,
            Role = Reporter.Role
        };

        return new Task1()
        {
            CreationDate = CreationDate,
            Title = Title,
            Description = Description,
            EstimationTime = EstimationTime,
            LoggedTime = LoggedTime,
            Assignee = assignee,
            Reporter = reporter,
            Status = Status,
            Priority = Priority,
            Subtasks = subtasks
        };
    }

    public void Restore(ITask task)
    {
        CreationDate = ((Task1)task).CreationDate;
        Title = ((Task1)task).Title;
        Description = ((Task1)task).Description;
        EstimationTime = ((Task1)task).EstimationTime;
        LoggedTime = ((Task1)task).LoggedTime;
        Assignee = ((Task1)task).Assignee;
        Reporter = ((Task1)task).Reporter;
        Status = ((Task1)task).Status;
        Priority = ((Task1)task).Priority;
        Subtasks = ((Task1)task).Subtasks;
    }
    //Observer - Publisher
    private List<ITaskSubscriber> _subscribers = new List<ITaskSubscriber>();
    public void AddSubscribe(ITaskSubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }
    public void Emit(string changeType)
    {
        foreach (ITaskSubscriber subscriber in _subscribers)
        {
            subscriber.GetTaskChange(Title,changeType);
        }
    }

    //State - Context
    public void ChangeStatus(IStatus status)
    {
        Status = status;   
        Emit("Status");
    }
}

