namespace TaskManagement.interfaces;

public interface ITaskSubscriber
{
    public void GetTaskChange(string taskTitle, string changeType);
}
