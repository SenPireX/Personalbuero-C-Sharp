using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Personalverwaltung.Office.Core.Models;

[Table("Office")]
public class Office
{
    //----------------------------------Attributes---------------------------------

    public int Id { get; }
    public Guid AlternateId { get; }

    public string? Name
    {
        get => _name;
        set => _name = (!string.IsNullOrWhiteSpace(value)
            ? value
            : throw new ArgumentException("Name darf nicht null oder leer sein!"));
    }

    private string? _name;
    
    public Type DepartmentType { get; }
    public Address Address { get; set; }

    private readonly List<Staff> _staff = new();

    public virtual IReadOnlyCollection<Staff> Staff => _staff;

    //----------------------------------Constructor----------------------------------

    public Office(string name, Address address)
    {
        AlternateId = Guid.NewGuid();
        DepartmentType = GetType();
        Name = name;
        Address = address;
    }

#pragma warning disable CS8618
    protected Office()
    {
    }

    //----------------------------------Methods----------------------------------

    public void Enroll(Staff staff)
    {
        _staff.Add(staff);
    }

    public decimal CalculateTotalSalary()
    {
        return _staff.Sum(staff => staff.CalculateSalary());
    }

    public double CalculateAverageAge()
    {
        return _staff.Average(staff => staff.CalculateAge());
    }

    public bool TerminateStaff(Staff staff)
    {
        if (_staff.Count > 0 && _staff.Contains(staff))
        {
            _staff.Remove(staff);
            return true;
        }
        else
        {
            throw new ArgumentException("Liste existiert nicht oder Mitarbeiter existiert nicht in dem Buero");
            return false;
        }
    }

    public bool TerminateStaffByIndex(int employeeIndex)
    {
        if (_staff.Count > 0)
        {
            if (employeeIndex >= 0)
            {
                _staff.RemoveAt(employeeIndex);
                return true;
            }
            else
            {
                throw new ArgumentException("Parameterzahl war negativ!");
                return false;
            }
        }
        else
        {
            throw new ArgumentException("Liste existiert nicht!");
            return false;
        }
    }

    public int TerminateAll()
    {
        var terminatedCount = 0;
        if (_staff.Count <= 0) return terminatedCount;
        terminatedCount = _staff.Count;
        _staff.Clear();

        return terminatedCount;
    }

    public void SortBySalary(char order)
    {
        if (order is '+' or '-')
        {
            _staff.Sort((ma1, ma2) => order == '-'
                ? ma2.CalculateSalary().CompareTo(ma1.CalculateSalary())
                : ma1.CalculateSalary().CompareTo(ma2.CalculateSalary())); // absteigend '-'
        }
    }

    public void SortStaff()
    {
        _staff.Sort();
    }

    public void SortByNames()
    {
        _staff.Sort((x, y) => string.CompareOrdinal(x.FirstName + x.LastName, y.FirstName + y.LastName));
    }

    public void SortByAge()
    {
        _staff.Sort((x, y) => x.CalculateAge().CompareTo(y.CalculateAge()));
    }

    public int CountStaff()
    {
        return _staff.Count;
    }

    public string SalaryList()
    {
        if (_staff.Count <= 0) return "No staff in the office.";

        var sb = new StringBuilder();
        sb.AppendLine("Salary List:");
        sb.AppendLine("------------");

        foreach (var staff in _staff)
        {
            sb.AppendLine($"Name: {staff.FirstName} {staff.LastName}, Salary: {staff.CalculateSalary()}");
        }

        sb.AppendLine("Gehalts-Summe: " + CalculateTotalSalary());

        return sb.ToString();
    }

    public int CountEmployees()
    {
        var count = 0;
        if (_staff.Count > 0)
        {
            count += _staff.OfType<Employee>().Count();
        }

        return count;
    }

    public decimal CalculateAverageSalaryEmployees()
    {
        if (CountEmployees() > 0)
        {
            return CalculateSalaryEmployee() / CountEmployees();
        }
        else
        {
            return 0m;
        }
    }

    //-------------Helper-Method--------------
    private decimal CalculateSalaryEmployee()
    {
        var sum = 0m;
        var employees = _staff.OfType<Employee>();

        if (_staff.Count > 0)
        {
            sum += employees.Sum(employee => employee.CalculateSalary());
            return sum;
        }
        else
        {
            return 0m;
        }
    }

    //----------------------------------ToString()----------------------------------

    public new string ToString()
    {
        var sb = new StringBuilder(2000);
        if (_staff.Count > 0)
        {
            _staff.ForEach(staff => sb.Append(staff.ToString()).Append('\n'));
        }
        else
        {
            sb.Append("Keine Mitarbeiter im Personalbuero");
        }

        return sb.ToString();
    }
}