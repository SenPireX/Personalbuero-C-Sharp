using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Personalverwaltung.Office.Core.Models;

[Table("Staff")]
public class Freelancer : Staff
{
    private int Hours { get; }
    private decimal HourlyRate { get; }

    public Freelancer(string firstName, string lastName, char geschlecht, DateOnly gebJahr, DateOnly eintrJahr,
        Address address,
        int hours, decimal hourlyRate)
        : base(firstName, lastName, geschlecht, gebJahr, eintrJahr, address)
    {
        Hours = hours;
        HourlyRate = hourlyRate;
    }

#pragma warning disable CS8618
    protected Freelancer()
    {
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