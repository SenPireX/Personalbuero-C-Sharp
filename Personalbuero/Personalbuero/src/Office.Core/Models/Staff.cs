using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Personalverwaltung.Office.Core.Models;

[Table("Staff")]
public abstract class Staff : IComparable<Staff>
{
    //----------------------------------Attributes----------------------------------
    public int Id { get; }
    public Guid AlternateId { get; }
    public Type Role { get; }

    public string? FirstName
    {
        get => _firstName;
        set => _firstName = (!string.IsNullOrWhiteSpace(value)
            ? value
            : throw new ArgumentException("Vorname darf nicht null oder leer sein!"));
    }

    private string? _firstName;

    public string? LastName
    {
        get => _lastName;
        set => _lastName = (!string.IsNullOrWhiteSpace(value)
            ? value
            : throw new ArgumentException("Nachname darf nicht null oder leer sein!"));
    }

    private string? _lastName;

    private char Gender { get; }
    private DateOnly BirthYear { get; set; }
    private DateOnly EntryYear { get; set; }

    public Address Address { get; set; }

    //----------------------------------Constructor----------------------------------
    public Staff(string firstName, string lastName, char gender, DateOnly birthYear, DateOnly entryYear,
        Address address)
    {
        AlternateId = Guid.NewGuid();
        Role = GetType();
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        BirthYear = birthYear;
        EntryYear = entryYear;
        Address = address;
    }

#pragma warning disable CS8618
    protected Staff()
    {
    }

    public abstract decimal CalculateInflationCompensation();

    public virtual decimal CalculateSalary()
    {
        return 1500m + 50m * CalculateServiceYears();
    }

    public int CalculateAge()
    {
        return DateTime.Now.Year - BirthYear.Year;
    }

    public int CalculateServiceYears()
    {
        return DateTime.Now.Year - EntryYear.Year;
    }

    //----------------------------------CompareTo()----------------------------------

    public int CompareTo(Staff? other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        return decimal.Compare(CalculateSalary(), other.CalculateSalary());
    }

    //----------------------------------ToString()----------------------------------
    public new string ToString()
    {
        var geschlecht = Gender switch
        {
            'm' or 'M' => "maennlich",
            'w' or 'W' or 'f' or 'F' => "weiblich",
            _ => "unbekannt"
        };

        var sb = new StringBuilder(2000);
        sb.Append("\n--- Mitarbeiter-Details: ---")
            .Append('\n').Append(Role.Name + "-Id: ").Append(Id)
            .Append('\n').Append(Role.Name + "-Rolle: ").Append(Role.Name)
            .Append('\n').Append(Role.Name + "-Vorname: ").Append(FirstName)
            .Append('\n').Append(Role.Name + "-Nachname: ").Append(LastName)
            .Append('\n').Append("Geschlecht: ").Append(geschlecht)
            .Append('\n').Append("Alter: ").Append(CalculateAge())
            .Append('\n').Append("Dienstalter: ").Append(CalculateServiceYears());

        return sb.ToString();
    }
}