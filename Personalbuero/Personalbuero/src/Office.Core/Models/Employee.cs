using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Personalverwaltung.Office.Core.Models;

[Table("Staff")]
public class Employee : Staff
{
    public Employee(string firstName, string lastName, char gender, DateOnly birthYear, DateOnly entryYear,
        Address address)
        : base(firstName, lastName, gender, birthYear, entryYear, address)
    {
    }

#pragma warning disable CS8618
    protected Employee()
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