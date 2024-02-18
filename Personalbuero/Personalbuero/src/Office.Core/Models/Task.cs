namespace Personalverwaltung.Office.Core.Models;

public class Task
{
    public Guid Id { get; }
    private string Description { get; }

    public Task(string description)
    {
        Id = Guid.NewGuid();
        Description = description;
    }

#pragma warning disable CS8618
    protected Task()
    {
    }
}