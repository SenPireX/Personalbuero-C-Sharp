/*using System;
using Personalverwaltung.Personalbuero.Core.Models;
using Xunit;

namespace Personalverwaltung.Personalbuero.Core.XunitTests;

public class XunitStaff
{
    [Fact]
    public static void TestCalculateAge()
    {
        //Arrange
        var birthYear = new DateOnly(1990, 1, 1);
        var entryYear = new DateOnly(2010,1,1);
        var staff = new Staff("Max", "Mustermann", 'm', birthYear, entryYear);

        //Act
        var age = staff.CalculateAge();

        //Assert
        Assert.Equal(DateTime.Now.Year - geburtsdatum.Year, alter);
    }

    [Fact]
    public static void TestCalculateServiceYears()
    {
        // Arrange
        var birthYear = new DateOnly(1990, 1, 1);
        var entryYear = new DateOnly(2010,1,1);
        var staff = new Staff("Max", "Mustermann", 'm', birthYear, entryYear);

        // Act
        var serviceYears = staff.CalculateServiceYears();

        // Assert
        Assert.Equal(DateTime.Now.Year - entryYear.Year, serviceYears);
    }

    [Fact]
    public static void TestCalculateSalary()
    {
        // Arrange
        var birthYear = new DateOnly(1990, 1, 1);
        var entryYear = new DateOnly(2010,1,1);
        var staff = new Staff("Max", "Mustermann", 'm', birthYear, entryYear);

        // Act
        var salary = staff.CalculateSalary();

        // Assert
        Assert.Equal(1500m + 50m * (DateTime.Now.Year - entryYear.Year), salary);
    }

    [Fact]
    public static void TestToString()
    {
        // Arrange
        var birthYear = new DateOnly(1990, 1, 1);
        var entryYear = new DateOnly(2010,1,1);
        var staff = new Staff("Max", "Mustermann", 'm', birthYear, entryYear);

        // Act
        var result = staff.ToString();

        // Assert
        Assert.Contains("Max", result);
        Assert.Contains("Mustermann", result);
        Assert.Contains("maennlich", result);
        Assert.Contains("Alter: 34", result);
        Assert.Contains("Dienstalter: 14", result);
    }

}*/

