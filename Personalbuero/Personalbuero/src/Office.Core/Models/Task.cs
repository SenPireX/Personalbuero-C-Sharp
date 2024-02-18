namespace Personalverwaltung.Office.Core.Models;

public class Task
{
    public int TaskId;
    private string Description { get; }

    public Task(string description)
    {
        Description = description;
    }

#pragma warning disable CS8618
    protected Task()
    {
    }
}