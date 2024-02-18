namespace Personalverwaltung.Office.Core.Models;

public class SalesOffice : Office
{
    public SalesOffice(string name, Address address) : base(name, address)
    {
    }

#pragma warning disable CS8618
    protected SalesOffice()
    {
    }
}