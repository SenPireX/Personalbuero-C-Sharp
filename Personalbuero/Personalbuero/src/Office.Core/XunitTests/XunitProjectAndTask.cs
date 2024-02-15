using Personalverwaltung.Office.Core.Models;
using Xunit;
using Xunit.Abstractions;
using Task = Personalverwaltung.Office.Core.Models.Task;

namespace Personalverwaltung.Office.Core.XunitTests;

public class XunitProjectAndTask
{
    
    private readonly ITestOutputHelper _output;

    public XunitProjectAndTask(ITestOutputHelper output)
    {
        _output = output;
    }
    
    [Fact]
    public void AddTask_AddsTasks()
    {
        // Arrange
        var task1 = new Task("Implement Tests");
        var task2 = new Task("Implement new Classes");
        
        var project1 = new Project("Project A", new DateOnly(2024, 1, 1), new DateOnly(2024, 6, 30), true);
        var project2 = new Project("Project B", new DateOnly(2024, 2, 15), new DateOnly(2024, 8, 31), false);
        

        // Act
        project1.AddTask(task1);
        project2.AddTask(task2);

        // Assert
        Assert.Contains(task1, project1.TaskList);
        Assert.Contains(task2, project2.TaskList);
        _output.WriteLine("Added Tasks: " + project1.CountTasks());
        _output.WriteLine("Added Tasks: " + project2.CountTasks());
    }
    
    [Fact]
    public void CountTasks_ReturnsCorrectAmountOfTasks()
    {
        // Arrange
        var task1 = new Task("Implement Tests");
        var task2 = new Task("Implement new Classes");
        var task3 = new Task("Design UI");
        var task4 = new Task("Refactor Code");
        var task5 = new Task("Write Documentation");
        var task6 = new Task("Review Code");
    
        var project1 = new Project("Project A", new DateOnly(2024, 1, 1), new DateOnly(2024, 6, 30), true);
        var project2 = new Project("Project B", new DateOnly(2024, 2, 15), new DateOnly(2024, 8, 31), false);
    

        // Act
        project1.AddTask(task1);
        project2.AddTask(task2);
        project1.AddTask(task3);
        project2.AddTask(task4);
        project1.AddTask(task5);
        project2.AddTask(task6);

        var tasksInProject1 = project1.CountTasks();
        var tasksInProject2 = project2.CountTasks();

        // Assert
        Assert.Equal(3, tasksInProject1);
        Assert.Equal(3, tasksInProject2);
        
        _output.WriteLine("Tasks: " + project1.CountTasks());
        _output.WriteLine("Tasks: " + project2.CountTasks());
    }

    
}