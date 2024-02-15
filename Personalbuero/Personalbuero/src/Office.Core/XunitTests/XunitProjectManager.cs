using Personalverwaltung.Office.Core.Models;
using Xunit;
using Xunit.Abstractions;

namespace Personalverwaltung.Office.Core.XunitTests;

public class XunitProjectManager
{
    private readonly ITestOutputHelper _output;

    public XunitProjectManager(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void AddProject_AddsProjectToList()
    {
        // Arrange
        var office = new Models.Office("C# Programmers", new Address(Street: "Kärtnerstraße 10", "1100", "Wien"));
        var project1 = new Project("Project A", new DateOnly(2024, 1, 1), new DateOnly(2024, 6, 30), true);
        var project2 = new Project("Project B", new DateOnly(2024, 2, 15), new DateOnly(2024, 8, 31), false);

        var staff1 = new Projectmanager("John", "Doe", 'M', new DateOnly(1990, 1, 1), new DateOnly(2020, 1, 1));
        var staff2 = new Projectmanager("Jane", "Doe", 'F', new DateOnly(1995, 1, 1), new DateOnly(2021, 1, 1));

        office.Enroll(staff1);
        office.Enroll(staff2);

        // Act
        staff1.AddProject(project1);
        staff2.AddProject(project2);

        // Assert
        Assert.Contains(staff1, office.Staff);
        Assert.Contains(staff2, office.Staff);
        Assert.Contains(project1, staff1.Projects);
        Assert.Contains(project2, staff2.Projects);
    }

    [Fact]
    public void CountTotalProjects_ReturnsCorrectAmountOfProjects()
    {
        // Arrange
        var project1 = new Project("Project A", new DateOnly(2024, 1, 1), new DateOnly(2024, 6, 30), true);
        var project2 = new Project("Project B", new DateOnly(2024, 2, 15), new DateOnly(2024, 8, 31), false);
        var project3 = new Project("Project C", new DateOnly(2024, 3, 10), new DateOnly(2024, 9, 15), false);

        var staff1 = new Projectmanager("John", "Doe", 'M', new DateOnly(1990, 1, 1), new DateOnly(2020, 1, 1));
        var staff2 = new Projectmanager("Jane", "Doe", 'F', new DateOnly(1995, 1, 1), new DateOnly(2021, 1, 1));


        // Act
        staff1.AddProject(project1);
        staff2.AddProject(project2);
        staff1.AddProject(project3);

        var totalProjects = staff1.CountTotalProjects();
        var totalProjects2 = staff2.CountTotalProjects();

        // Assert
        Assert.Equal(2, totalProjects);
        Assert.Equal(1, totalProjects2);
    }


    [Fact]
    public void CompleteProject_CompletesProjects()
    {
        // Arrange
        var project1 = new Project("Project A", new DateOnly(2024, 1, 1), new DateOnly(2024, 6, 30), false);
        var project2 = new Project("Project B", new DateOnly(2024, 2, 15), new DateOnly(2024, 8, 31), true);

        var staff1 = new Projectmanager("John", "Doe", 'M', new DateOnly(1990, 1, 1), new DateOnly(2020, 1, 1));
        var staff2 = new Projectmanager("Jane", "Doe", 'F', new DateOnly(1995, 1, 1), new DateOnly(2021, 1, 1));

        staff1.AddProject(project1);
        staff2.AddProject(project2);

        // Act
        staff1.CompleteProject(project1);
        staff2.CompleteProject(project2);

        // Assert
        Assert.True(project1.Completed);
        Assert.True(project2.Completed);
    }


    [Fact]
    public void CountCompletedProjects_ReturnsCorrectAmountOfCompletedProjects()
    {
        // Arrange
        var project1 = new Project("Project A", new DateOnly(2024, 1, 1), new DateOnly(2024, 6, 30), true);
        var project2 = new Project("Project B", new DateOnly(2024, 2, 15), new DateOnly(2024, 8, 31), false);
        var project3 = new Project("Project C", new DateOnly(2024, 3, 10), new DateOnly(2024, 9, 15), true);
        var project4 = new Project("Project D", new DateOnly(2024, 4, 20), new DateOnly(2024, 10, 25), false);
        var project5 = new Project("Project E", new DateOnly(2024, 5, 5), new DateOnly(2024, 11, 20), true);

        var staff1 = new Projectmanager("John", "Doe", 'M', new DateOnly(1990, 1, 1), new DateOnly(2020, 1, 1));
        var staff2 = new Projectmanager("Jane", "Doe", 'F', new DateOnly(1995, 1, 1), new DateOnly(2021, 1, 1));

        // Act
        staff1.AddProject(project1);
        staff2.AddProject(project2);
        staff1.AddProject(project3);
        staff2.AddProject(project4);
        staff1.AddProject(project5);

        var complProj1 = staff1.CountCompletedProjects();
        var complProj2 = staff2.CountCompletedProjects();

        // Assert
        Assert.Equal(3, complProj1);
        Assert.Equal(0, complProj2);
    }

    [Fact]
    public void CalculateSalary_ProjectManagerBonusPerProject()
    {
        // Arrange
        var project1 = new Project("Project A", new DateOnly(2024, 1, 1), new DateOnly(2024, 6, 30), true);
        var project2 = new Project("Project B", new DateOnly(2024, 2, 15), new DateOnly(2024, 8, 31), false);
        var project3 = new Project("Project C", new DateOnly(2024, 3, 10), new DateOnly(2024, 9, 15), true);
        var project4 = new Project("Project D", new DateOnly(2024, 4, 20), new DateOnly(2024, 10, 25), false);
        var project5 = new Project("Project E", new DateOnly(2024, 5, 5), new DateOnly(2024, 11, 20), true);

        var staff1 = new Projectmanager("John", "Doe", 'M', new DateOnly(1990, 1, 1), new DateOnly(2020, 1, 1));
        var staff2 = new Projectmanager("Jane", "Doe", 'F', new DateOnly(1995, 1, 1), new DateOnly(2021, 1, 1));
        
        staff1.AddProject(project1);
        staff2.AddProject(project2);
        staff1.AddProject(project4);
        staff2.AddProject(project3);
        staff2.AddProject(project5);
        
        // Act
        var sal1 = staff1.CalculateSalary(); //PM1: 1500+ 50*4 + 1 * 100 = 1800
        var sal2 = staff2.CalculateSalary(); //PM2: 1500+ 50*3 + 2 * 100 = 1850

        // Assert
        Assert.Equal(1800,sal1);
        Assert.Equal(1850,sal2);
    }
    
}