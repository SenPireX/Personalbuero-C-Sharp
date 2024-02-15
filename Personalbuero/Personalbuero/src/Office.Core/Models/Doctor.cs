using System.Text;

namespace Personalverwaltung.Office.Core.Models;

public class Doctor : Staff
{
    private int WeeklyHours { get; }
    private decimal FixedSalary { get; }

    public Doctor(string firstName, string lastName, char geschlecht, DateOnly gebJahr, DateOnly eintrJahr,
        int weeklyHours, decimal fixedSalary)
        : base(firstName, lastName, geschlecht, gebJahr, eintrJahr)
    {
        WeeklyHours = weeklyHours;
        FixedSalary = fixedSalary;
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