using TaskManagement.classses;
using TaskManagement.classses.Handler;
using TaskManagement.classses.status;
using TaskManagement.@enum;

User[] users = {
new User() { Name="Sara", Email="sara@gmail.com", Role=Role.developer },
new User() { Name = "Moshe", Email = "moshe@gmail.com", Role = Role.manager },
new User() { Name = "Gal", Email = "gal@gmail.com", Role = Role.QA },
new User(){ Name="Shir", Email="shir@gmail.com", Role=Role.developer },
new User(){ Name="Dan", Email="dan@gmail.com", Role=Role.QA }
};

List<Task1> tasks = new List<Task1>();

//1
TaskBuilder taskBuilder1 = new("Implement Feature X", "Detailed description of Feature X implementation.");
taskBuilder1.AddAssignee(users[1]);
taskBuilder1.AddReporter(users[0]);
taskBuilder1.AddEstimationTime(30);
taskBuilder1.AddPriority(Priority.Medium);
Task1 task = taskBuilder1.build();
tasks.Add(task);

//2
TaskBuilder taskBuilder2 = new("Implement Feature X", "Detailed description of Feature X implementation.");
taskBuilder2.AddAssignee(users[2]);
taskBuilder2.AddReporter(users[3]);
taskBuilder2.AddEstimationTime(26);
taskBuilder2.AddPriority(Priority.High);
Task1 task1 = taskBuilder2.build();
tasks.Add(task1);

//3
TaskBuilder taskBuilder3 = new("Develop New Feature", "Develop a new feature in the system");
taskBuilder3.AddAssignee(users[3]);
taskBuilder3.AddReporter(users[4]);
taskBuilder3.AddEstimationTime(26);
taskBuilder3.AddPriority(Priority.Low);

TaskBuilder taskBuilder4 = new("Design User Interface", "Design the UI for the new feature");
taskBuilder4.AddAssignee(users[4]);
taskBuilder4.AddReporter(users[2]);
taskBuilder4.AddEstimationTime(10);
Task1 subTask1 = taskBuilder4.build();
taskBuilder3.AddSubtasks(subTask1);

TaskBuilder taskBuilder5 = new("Develop Business Logic", "Develop the business logic for the feature");
taskBuilder5.AddAssignee(users[4]);
taskBuilder5.AddReporter(users[2]);
taskBuilder5.AddEstimationTime(5);
Task1 subTask2 = taskBuilder5.build();
taskBuilder3.AddSubtasks(subTask2);

Task1 task2 = taskBuilder3.build();
tasks.Add(task2);


QAHandler qaHandler = new QAHandler();
DeveloperHandler developerHandler = new DeveloperHandler();
ManagerHandler managerHandler = new ManagerHandler();
managerHandler.SetNext(developerHandler);
developerHandler.SetNext(qaHandler);

Console.WriteLine(tasks[0]);
TaskHistory history = new(tasks[0]); 
history.ChangeAssignee(users[3]);
Console.WriteLine(tasks[0]);
history.Undo();
Console.WriteLine(tasks[0]);
history.ChangeReporter(users[2]);
Console.WriteLine(tasks[0]);

for (int i = 0; i < 5; i++)
{
    history.UpdateLoggedTime(3);
    history.ChangeStatus(managerHandler);
    Console.WriteLine(tasks[0]);
}