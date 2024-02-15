using System.Text;

namespace Personalverwaltung.Office.Core.Models;

public class Employee : Staff
{
    public Employee(string firstName, string lastName, char gender, DateOnly birthYear, DateOnly entryYear)
        : base(firstName, lastName, gender, birthYear, entryYear)
    {
    }

    public override decimal CalculateInflationCompensation()
    {
        return CalculateSalary() * 1.25m;
    }

    public new string ToString()
    {
        var sb = new StringBuilder(2000).Append(base.ToString());
        return sb.ToString();
    }
}