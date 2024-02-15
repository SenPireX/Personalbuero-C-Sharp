using Microsoft.EntityFrameworkCore;
using Personalverwaltung.Office.Core.Models;
using Task = Personalverwaltung.Office.Core.Models.Task;
using OfficeClass = Personalverwaltung.Office.Core.Models.Office;

namespace Personalverwaltung.Office.Infrastructure;

public class OfficeContext : DbContext
{
    public OfficeContext(DbContextOptions opt) : base(opt){}
    public DbSet<Staff> Staff => Set<Staff>();
    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Freelancer> Freelancers => Set<Freelancer>();
    public DbSet<Projectmanager> Projectmanagers => Set<Projectmanager>();
    public DbSet<OfficeClass> Offices => Set<OfficeClass>();
    public DbSet<AdministrationOffice> AdministrationOffices => Set<AdministrationOffice>();
    public DbSet<SalesOffice> SalesOffices => Set<SalesOffice>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Task> Tasks => Set<Task>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Staff>().HasAlternateKey(staff => staff.Id);
    }
    
}