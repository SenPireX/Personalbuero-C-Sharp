using System.Text;

namespace Personalverwaltung.Office.Core.Models;

public class Freelancer : Staff
{
    private int Hours { get; }
    private decimal HourlyRate { get; }

    public Freelancer(string firstName, string lastName, char geschlecht, DateOnly gebJahr, DateOnly eintrJahr,
        int hours, decimal hourlyRate)
        : base(firstName, lastName, geschlecht, gebJahr, eintrJahr)
    {
        Hours = hours;
        HourlyRate = hourlyRate;
    }

    public override decimal CalculateInflationCompensation()
    {
        return CalculateSalary() * 1.25m;
    }

    public override decimal CalculateSalary()
    {
        return HourlyRate * Hours;
    }

    public new string ToString()
    {
        var sb = new StringBuilder(2000).Append(base.ToString());
        sb.Append("\nHours: ").Append(Hours)
            .Append("\nHourlyRate: ").Append(HourlyRate);

        return sb.ToString();
    }
}