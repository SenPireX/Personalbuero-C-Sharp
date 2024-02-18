using System.ComponentModel.DataAnnotations.Schema;

namespace Personalverwaltung.Office.Core.Models;

[Table("Office")]
public class AdministrationOffice : Office
{
    public AdministrationOffice(string name, Address address) : base(name, address)
    {
    }

#pragma warning disable CS8618
    protected AdministrationOffice()
    {
    }
}