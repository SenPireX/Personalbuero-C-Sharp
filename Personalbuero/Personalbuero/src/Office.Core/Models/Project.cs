namespace Personalverwaltung.Office.Core.Models;

public class Project
{
    private string Name { get; }
    private DateOnly StartDate { get; }
    private DateOnly EndDate { get; }
    public List<Task> TaskList { get; }
    public bool Completed { get; set; }


    public Project(string name, DateOnly startDate, DateOnly endDate, bool completed = false)
    {
        TaskList = new List<Task>();
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        Completed = completed;
    }

    public void AddTask(Task task)
    {
        TaskList.Add(task);
    }

    public int CountTasks()
    {
        return TaskList.Count;
    }
}