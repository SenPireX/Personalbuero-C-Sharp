using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Personalverwaltung.Office.Core.Models;

[Table("Staff")]
public class Doctor : Staff
{
    private int WeeklyHours { get; }
    private decimal FixedSalary { get; }

    public Doctor(string firstName, string lastName, char gender, DateOnly birthYear, DateOnly entryYear,
        Address address,
        int weeklyHours, decimal fixedSalary)
        : base(firstName, lastName, gender, birthYear, entryYear, address)
    {
        WeeklyHours = weeklyHours;
        FixedSalary = fixedSalary;
    }

#pragma warning disable CS8618
    protected Doctor()
    {
    }

    public override decimal CalculateInflationCompensation()
    {
        return CalculateSalary() * 1.15m;
    }

    public override decimal CalculateSalary()
    {
        return FixedSalary;
    }

    public decimal CalculateHourlyRate()
    {
        return FixedSalary / WeeklyHours;
    }

    public new string ToString()
    {
        var sb = new StringBuilder(2000).Append(base.ToString());
        sb.Append("\nWeeklyHours: ").Append(WeeklyHours)
            .Append("\nFixedSalary: ").Append(FixedSalary);

        return sb.ToString();
    }
}