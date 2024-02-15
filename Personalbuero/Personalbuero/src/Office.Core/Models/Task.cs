namespace Personalverwaltung.Office.Core.Models;

public class Task
{
    private string Description { get; }

    public Task(string description)
    {
        Description = description;
    }
}