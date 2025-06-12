using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.classses.status;
using TaskManagement.@enum;

namespace TaskManagement.classses;

//Builder
public class TaskBuilder
{
    private DateTime? CreationDate = null;
    private string? Title = null;
    private string? Description = null;
    public float? EstimationTime = null;
    public float? LoggedTime = null;
    public User? Assignee = null;
    public User? Reporter = null;
    public Priority? Priority = null;
    public List<Task1>? Subtasks = null;

    public TaskBuilder(string title, string description)
    {
        CreationDate = DateTime.Now;
        Title = title;
        Description = description;
        LoggedTime = 0;
        Priority = @enum.Priority.Low;
    }
    public void AddEstimationTime(float time)
    {
        EstimationTime = time;
    }
    public void AddAssignee(User? assignee)
    {
        Assignee = assignee;
    }
    public void AddReporter(User? reporter)
    {
        Reporter = reporter;
    }
    public void AddPriority(Priority? priority)
    {
        Priority = priority;
    }
    public void AddSubtasks(Task1 subtask)
    {
        if (Subtasks == null)
            Subtasks = new();
        Subtasks.Add(subtask);
    }
    public Task1 build()
    {
        if (Assignee == null || Reporter == null || EstimationTime == null)
        {
            throw new InvalidOperationException("can't build task without assignee and reporter");
        }
        return new Task1()
        {
            CreationDate = (DateTime)CreationDate,
            Title = Title,
            Description = Description,
            Subtasks = Subtasks,
            EstimationTime = (float)EstimationTime,
            LoggedTime = (float)LoggedTime,
            Assignee = Assignee,
            Reporter = Reporter,
            Priority = (Priority)Priority
        };
    }
}
