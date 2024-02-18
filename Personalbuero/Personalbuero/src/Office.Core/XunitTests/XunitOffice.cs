using Personalverwaltung.Office.Core.Models;
using Xunit;
using Xunit.Abstractions;

namespace Personalverwaltung.Office.Core.XunitTests;

public class XunitOffice
{
    private readonly ITestOutputHelper _output;

    public XunitOffice(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void Enroll_AddsStaffToList()
    {
        // Arrange
        var office = new Models.Office("C# Programmers", new Address(Street: "Kärtnerstraße 10", "1100", "Wien"));

        var staff = new Employee("John", "Doe", 'M', new DateOnly(1990, 1, 1),
            new DateOnly(2020, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        // Act
        office.Enroll(staff);
        _output.WriteLine("Added " + office.CountStaff() + " Staff to the Office");

        // Assert
        Assert.Contains(staff, office.Staff);
        _output.WriteLine(staff.ToString());
    }

    [Fact]
    public void CalculateTotalSalary_ReturnsCorrectSum()
    {
        // Arrange
        var office = new Models.Office("C# Programmers", new Address(Street: "Kärtnerstraße 10", "1100", "Wien"));

        var staff1 = new Employee("John", "Doe", 'M', new DateOnly(1990, 1, 1),
            new DateOnly(2020, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff2 = new Employee("Jane", "Doe", 'F', new DateOnly(1995, 1, 1),
            new DateOnly(2021, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        office.Enroll(staff1);
        office.Enroll(staff2);

        // Act
        var totalSalary = office.CalculateTotalSalary();

        // Assert
        Assert.Equal(staff1.CalculateSalary() + staff2.CalculateSalary(), totalSalary);
        _output.WriteLine("Gehalts-Summe: " + totalSalary + '€');
    }

    [Fact]
    public void CalculateAverageAge_ReturnsCorrectAverage()
    {
        // Arrange
        var office = new Models.Office("C# Programmers", new Address(Street: "Kärtnerstraße 10", "1100", "Wien"));

        var staff1 = new Employee("John", "Doe", 'M', new DateOnly(1990, 1, 1),
            new DateOnly(2020, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff2 = new Employee("Jane", "Doe", 'F', new DateOnly(1995, 1, 1),
            new DateOnly(2021, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        office.Enroll(staff1);
        office.Enroll(staff2);

        // Act
        var averageAge = office.CalculateAverageAge();

        // Assert
        Assert.Equal(31.5, averageAge);
        _output.WriteLine("Durchschnittsalter: " + averageAge);
    }

    [Fact]
    public void TerminateStaff_TerminatesCorrectStaff()
    {
        // Arrange
        var office = new Models.Office("C# Programmers", new Address(Street: "Kärtnerstraße 10", "1100", "Wien"));

        var staff1 = new Employee("John", "Doe", 'M', new DateOnly(1990, 1, 1),
            new DateOnly(2020, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff2 = new Employee("Jane", "Doe", 'F', new DateOnly(1995, 1, 1),
            new DateOnly(2021, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff3 = new Doctor("Dr. Smith", "Specialty", 'M', new DateOnly(1985, 5, 15),
            new DateOnly(2010, 3, 20), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 12, 1500);

        var staff4 = new Freelancer("Alice", "Johnson", 'F', new DateOnly(1992, 10, 8),
            new DateOnly(2018, 6, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 120, 12);

        var staff5 = new Projectmanager("Jack", "Thompson", 'M', new DateOnly(1988, 3, 25),
            new DateOnly(2015, 8, 10), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        office.Enroll(staff1);
        office.Enroll(staff2);
        office.Enroll(staff3);
        office.Enroll(staff4);
        office.Enroll(staff5);

        // Act
        var termStaff = office.TerminateStaff(staff1);

        // Assert
        Assert.True(termStaff);
        Assert.DoesNotContain(staff1, office.Staff);

        _output.WriteLine(staff1.ToString());
    }

    [Fact]
    public void TerminateStaffByIndex_TerminatesCorrectStaffByIndex()
    {
        // Arrange
        var office = new Models.Office("C# Programmers", new Address(Street: "Kärtnerstraße 10", "1100", "Wien"));

        var staff1 = new Employee("John", "Doe", 'M', new DateOnly(1990, 1, 1),
            new DateOnly(2020, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff2 = new Employee("Jane", "Doe", 'F', new DateOnly(1995, 1, 1),
            new DateOnly(2021, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff3 = new Doctor("Dr. Smith", "Specialty", 'M', new DateOnly(1985, 5, 15),
            new DateOnly(2010, 3, 20), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 12, 1500);

        var staff4 = new Freelancer("Alice", "Johnson", 'F', new DateOnly(1992, 10, 8),
            new DateOnly(2018, 6, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 120, 12);

        var staff5 = new Projectmanager("Jack", "Thompson", 'M', new DateOnly(1988, 3, 25),
            new DateOnly(2015, 8, 10), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        office.Enroll(staff1);
        office.Enroll(staff2);
        office.Enroll(staff3);
        office.Enroll(staff4);
        office.Enroll(staff5);

        // Act
        //_output.WriteLine("Kündige Mitarbeiter... \n" + office.Staff[0].ToString());
        var indexStaff = office.TerminateStaffByIndex(0);

        // Assert
        Assert.True(indexStaff);
        Assert.Equal(staff1, staff1);
        Assert.DoesNotContain(staff1, office.Staff);
    }

    [Fact]
    public void TerminateAll_TerminatesAllStaff()
    {
        // Arrange
        var office = new Models.Office("C# Programmers", new Address(Street: "Kärtnerstraße 10", "1100", "Wien"));

        var staff1 = new Employee("John", "Doe", 'M', new DateOnly(1990, 1, 1),
            new DateOnly(2020, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff2 = new Employee("Jane", "Doe", 'F', new DateOnly(1995, 1, 1),
            new DateOnly(2021, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff3 = new Doctor("Dr. Smith", "Specialty", 'M', new DateOnly(1985, 5, 15),
            new DateOnly(2010, 3, 20), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 12, 1500);

        var staff4 = new Freelancer("Alice", "Johnson", 'F', new DateOnly(1992, 10, 8),
            new DateOnly(2018, 6, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 120, 12);

        var staff5 = new Projectmanager("Jack", "Thompson", 'M', new DateOnly(1988, 3, 25),
            new DateOnly(2015, 8, 10), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        office.Enroll(staff1);
        office.Enroll(staff2);
        office.Enroll(staff3);
        office.Enroll(staff4);
        office.Enroll(staff5);

        // Act
        var count = office.TerminateAll();

        // Assert
        Assert.Equal(5, count);
        Assert.Empty(office.Staff);
        _output.WriteLine(office.ToString());
    }

    [Fact]
    public void SortBySalary_Ascending()
    {
        // Arrange
        var office = new Models.Office("C# Programmers", new Address(Street: "Kärtnerstraße 10", "1100", "Wien"));

        var staff1 = new Employee("John", "Doe", 'M', new DateOnly(1990, 1, 1),
            new DateOnly(2020, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff2 = new Employee("Jane", "Doe", 'F', new DateOnly(1995, 1, 1),
            new DateOnly(2021, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff3 = new Doctor("Dr. Smith", "Specialty", 'M', new DateOnly(1985, 5, 15),
            new DateOnly(2010, 3, 20), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 12, 1500);

        var staff4 = new Freelancer("Alice", "Johnson", 'F', new DateOnly(1992, 10, 8),
            new DateOnly(2018, 6, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 100, 12);

        var staff5 = new Projectmanager("Jack", "Thompson", 'M', new DateOnly(1988, 3, 25),
            new DateOnly(2015, 8, 10), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        office.Enroll(staff1);
        office.Enroll(staff2);
        office.Enroll(staff3);
        office.Enroll(staff4);
        office.Enroll(staff5);

        // Act
        _output.WriteLine("Sortiere AUFsteigend... ");
        office.SortBySalary('+');

        //st3 Doctor = 1500, st4 Freelancer = 1200, st5 ProjectManager = 1950 , st1 Employee1 = 1700 , st2 Employee2 = 1650

        // Assert
        var sortedStaff = office.Staff.ToList();
        Assert.Equal(staff4, sortedStaff[0]);
        Assert.Equal(staff3, sortedStaff[1]);
        Assert.Equal(staff2, sortedStaff[2]);
        Assert.Equal(staff1, sortedStaff[3]);
        Assert.Equal(staff5, sortedStaff[4]);

        _output.WriteLine("Liste wurde Sortiert... ");
        _output.WriteLine(office.SalaryList());
    }

    [Fact]
    public void SortBySalary_Descending()
    {
        // Arrange
        var office = new Models.Office("C# Programmers", new Address(Street: "Kärtnerstraße 10", "1100", "Wien"));

        var staff1 = new Employee("John", "Doe", 'M', new DateOnly(1990, 1, 1),
            new DateOnly(2020, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff2 = new Employee("Jane", "Doe", 'F', new DateOnly(1995, 1, 1),
            new DateOnly(2021, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff3 = new Doctor("Dr. Smith", "Specialty", 'M', new DateOnly(1985, 5, 15),
            new DateOnly(2010, 3, 20), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 12, 1500);

        var staff4 = new Freelancer("Alice", "Johnson", 'F', new DateOnly(1992, 10, 8),
            new DateOnly(2018, 6, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 100, 12);

        var staff5 = new Projectmanager("Jack", "Thompson", 'M', new DateOnly(1988, 3, 25),
            new DateOnly(2015, 8, 10), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        office.Enroll(staff1);
        office.Enroll(staff2);
        office.Enroll(staff3);
        office.Enroll(staff4);
        office.Enroll(staff5);

        // Act
        _output.WriteLine("Sortiere ABsteigend... ");
        office.SortBySalary('-');

        //st3 Doctor = 1500, st4 Freelancer = 1200, st5 ProjectManager = 1950 , st1 Employee1 = 1700 , st2 Employee2 = 1650

        // Assert
        var sortedStaff = office.Staff.ToList();
        Assert.Equal(staff5, sortedStaff[0]);
        Assert.Equal(staff1, sortedStaff[1]);
        Assert.Equal(staff2, sortedStaff[2]);
        Assert.Equal(staff3, sortedStaff[3]);
        Assert.Equal(staff4, sortedStaff[4]);

        _output.WriteLine("Liste wurde Sortiert... ");
        _output.WriteLine(office.SalaryList());
    }

    [Fact]
    public void SortStaff_CorrectlySortedStaff()
    {
        // Arrange
        var office = new Models.Office("C# Programmers", new Address(Street: "Kärtnerstraße 10", "1100", "Wien"));

        var staff1 = new Employee("John", "Doe", 'M', new DateOnly(1990, 1, 1),
            new DateOnly(2020, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff2 = new Employee("Jane", "Doe", 'F', new DateOnly(1995, 1, 1),
            new DateOnly(2021, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff3 = new Doctor("Dr. Smith", "Specialty", 'M', new DateOnly(1985, 5, 15),
            new DateOnly(2010, 3, 20), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 12, 1500);

        var staff4 = new Freelancer("Alice", "Johnson", 'F', new DateOnly(1992, 10, 8),
            new DateOnly(2018, 6, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 100, 12);

        var staff5 = new Projectmanager("Jack", "Thompson", 'M', new DateOnly(1988, 3, 25),
            new DateOnly(2015, 8, 10), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        // Act
        office.Enroll(staff1);
        office.Enroll(staff2);
        office.Enroll(staff3);
        office.Enroll(staff4);
        office.Enroll(staff5);

        office.SortStaff();

        // Assert
        Assert.Collection(office.Staff,
            item => Assert.Equal(staff4, item),
            item => Assert.Equal(staff3, item),
            item => Assert.Equal(staff2, item),
            item => Assert.Equal(staff1, item),
            item => Assert.Equal(staff5, item)
        );

        _output.WriteLine(office.ToString());
    }

    [Fact]
    public void SortByNames_CorrectlySortedByNames()
    {
        // Arrange
        var office = new Models.Office("C# Programmers", new Address(Street: "Kärtnerstraße 10", "1100", "Wien"));

        var staff1 = new Employee("John", "Doe", 'M', new DateOnly(1990, 1, 1),
            new DateOnly(2020, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff2 = new Employee("Jane", "Doe", 'F', new DateOnly(1995, 1, 1),
            new DateOnly(2021, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff3 = new Doctor("Dr. Smith", "Specialty", 'M', new DateOnly(1985, 5, 15),
            new DateOnly(2010, 3, 20), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 12, 1500);

        var staff4 = new Freelancer("Alice", "Johnson", 'F', new DateOnly(1992, 10, 8),
            new DateOnly(2018, 6, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 100, 12);

        var staff5 = new Projectmanager("Jack", "Thompson", 'M', new DateOnly(1988, 3, 25),
            new DateOnly(2015, 8, 10), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        // Act
        office.Enroll(staff1);
        office.Enroll(staff2);
        office.Enroll(staff3);
        office.Enroll(staff4);
        office.Enroll(staff5);

        office.SortByNames();

        // Assert
        Assert.Collection(office.Staff,
            item => Assert.Equal(staff4, item),
            item => Assert.Equal(staff3, item),
            item => Assert.Equal(staff5, item),
            item => Assert.Equal(staff2, item),
            item => Assert.Equal(staff1, item)
        );

        _output.WriteLine(office.ToString());
    }

    [Fact]
    public void SortByAge_CorrectlySortedByAge()
    {
        // Arrange
        var office = new Models.Office("C# Programmers", new Address(Street: "Kärtnerstraße 10", "1100", "Wien"));

        var staff1 = new Employee("John", "Doe", 'M', new DateOnly(1990, 1, 1),
            new DateOnly(2020, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff2 = new Employee("Jane", "Doe", 'F', new DateOnly(1995, 1, 1),
            new DateOnly(2021, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff3 = new Doctor("Dr. Smith", "Specialty", 'M', new DateOnly(1985, 5, 15),
            new DateOnly(2010, 3, 20), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 12, 1500);

        var staff4 = new Freelancer("Alice", "Johnson", 'F', new DateOnly(1992, 10, 8),
            new DateOnly(2018, 6, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 100, 12);

        var staff5 = new Projectmanager("Jack", "Thompson", 'M', new DateOnly(1988, 3, 25),
            new DateOnly(2015, 8, 10), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        // Act
        office.Enroll(staff1); // 34
        office.Enroll(staff2); // 29
        office.Enroll(staff3); // 39
        office.Enroll(staff4); // 32
        office.Enroll(staff5); // 36

        office.SortByAge();

        // Assert
        Assert.Collection(office.Staff,
            item => Assert.Equal(staff2, item),
            item => Assert.Equal(staff4, item),
            item => Assert.Equal(staff1, item),
            item => Assert.Equal(staff5, item),
            item => Assert.Equal(staff3, item)
        );

        _output.WriteLine(office.ToString());
    }


    [Fact]
    public void CountStaff_ReturnsCorrectAmountOfStaff()
    {
        // Arrange
        var office = new Models.Office("C# Programmers", new Address(Street: "Kärtnerstraße 10", "1100", "Wien"));

        var staff1 = new Employee("John", "Doe", 'M', new DateOnly(1990, 1, 1),
            new DateOnly(2020, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff2 = new Employee("Jane", "Doe", 'F', new DateOnly(1995, 1, 1),
            new DateOnly(2021, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff3 = new Doctor("Dr. Smith", "Specialty", 'M', new DateOnly(1985, 5, 15),
            new DateOnly(2010, 3, 20), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 12, 1500);

        // Act
        office.Enroll(staff1);
        office.Enroll(staff2);
        office.Enroll(staff3);

        // Assert
        Assert.Equal(3, office.CountStaff());
        _output.WriteLine("Count: " + office.CountStaff());
        _output.WriteLine(office.ToString());
    }

    [Fact]
    public void SalaryList_ReturnsCompleteSalaryList()
    {
        // Arrange
        var office = new Models.Office("C# Programmers", new Address(Street: "Kärtnerstraße 10", "1100", "Wien"));

        var staff1 = new Employee("John", "Doe", 'M', new DateOnly(1990, 1, 1),
            new DateOnly(2020, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff2 = new Employee("Jane", "Doe", 'F', new DateOnly(1995, 1, 1),
            new DateOnly(2021, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        office.Enroll(staff1);
        office.Enroll(staff2);

        // Act
        var salaryList = office.SalaryList();

        // Assert
        Assert.Contains("Name: John Doe, Salary: 1700", salaryList);
        Assert.Contains("Name: Jane Doe, Salary: 1650", salaryList);

        _output.WriteLine(salaryList);
    }

    [Fact]
    public void CountEmployees_ReturnsCorrectAmountOfEmployees()
    {
        // Arrange
        var office = new Models.Office("C# Programmers", new Address(Street: "Kärtnerstraße 10", "1100", "Wien"));

        var staff1 = new Employee("John", "Doe", 'M', new DateOnly(1990, 1, 1),
            new DateOnly(2020, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff2 = new Employee("Jane", "Doe", 'F', new DateOnly(1995, 1, 1),
            new DateOnly(2021, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff3 = new Doctor("Dr. Smith", "Specialty", 'M', new DateOnly(1985, 5, 15),
            new DateOnly(2010, 3, 20), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 12, 1500);

        var staff4 = new Freelancer("Alice", "Johnson", 'F', new DateOnly(1992, 10, 8),
            new DateOnly(2018, 6, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 100, 12);

        var staff5 = new Projectmanager("Jack", "Thompson", 'M', new DateOnly(1988, 3, 25),
            new DateOnly(2015, 8, 10), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        office.Enroll(staff1);
        office.Enroll(staff2);
        office.Enroll(staff3);
        office.Enroll(staff4);
        office.Enroll(staff5);

        // Act
        var employees = office.CountEmployees();

        // Assert
        Assert.Equal(2, employees);
    }

    [Fact]
    public void CalculateAverageSalaryEmployees_ReturnsCorrectAverageSalaryEmployees()
    {
        // Arrange
        var office = new Models.Office("C# Programmers", new Address(Street: "Kärtnerstraße 10", "1100", "Wien"));

        var staff1 = new Employee("John", "Doe", 'M', new DateOnly(1990, 1, 1),
            new DateOnly(2020, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff2 = new Employee("Jane", "Doe", 'F', new DateOnly(1995, 1, 1),
            new DateOnly(2021, 1, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        var staff3 = new Doctor("Dr. Smith", "Specialty", 'M', new DateOnly(1985, 5, 15),
            new DateOnly(2010, 3, 20), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 12, 1500);

        var staff4 = new Freelancer("Alice", "Johnson", 'F', new DateOnly(1992, 10, 8),
            new DateOnly(2018, 6, 1), new Address(Street: "Quellenstraße 11", "1100", "Wien"), 100, 12);

        var staff5 = new Projectmanager("Jack", "Thompson", 'M', new DateOnly(1988, 3, 25),
            new DateOnly(2015, 8, 10), new Address(Street: "Quellenstraße 11", "1100", "Wien"));

        office.Enroll(staff1);
        office.Enroll(staff2);
        office.Enroll(staff3);
        office.Enroll(staff4);
        office.Enroll(staff5);

        // Act
        var employeesAvgSalary = office.CalculateAverageSalaryEmployees();

        // Assert
        Assert.Equal(1675, employeesAvgSalary);
    }
}