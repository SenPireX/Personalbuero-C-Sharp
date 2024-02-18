using Microsoft.EntityFrameworkCore;
using Personalverwaltung.Office.Core.Models;
using Task = Personalverwaltung.Office.Core.Models.Task;
using OfficeClass = Personalverwaltung.Office.Core.Models.Office;

namespace Personalverwaltung.Office.Infrastructure;

public class OfficeContext : DbContext
{
    public OfficeContext(DbContextOptions opt) : base(opt)
    {
    }

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
        // Relationships:
        // Ein Office kann mehrere Mitarbeiter haben, und ein Mitarbeiter kann in einem Office sein                     one-to many 1:m
        // Ein Projekt kann mehrere Tasks haben, und ein Task kann in mehreren Projekten sein                           many-to-many m:m
        // Ein Projektmanager kann mehrere Projekte haben, und ein Projekt kann einem Projektmanager zugeteilt werden   one-to-many 1:m
        // Eine Adresse kann einem Mitarbeiter bzw. Office gehören, und diese können nur eine Adresse haben.            one-to-one 1:1

        //Staff
        modelBuilder.Entity<Staff>().HasAlternateKey(staff => staff.Id);
        modelBuilder.Entity<Staff>().OwnsOne(staff => staff.Address);
        //modelBuilder.Entity<Staff>().HasDiscriminator(staff => staff.Role);
        
        //Office
        modelBuilder.Entity<OfficeClass>().HasAlternateKey(o => o.Id);
        modelBuilder.Entity<OfficeClass>().OwnsOne(o => o.Address);

        modelBuilder.Entity<OfficeClass>()
            .HasMany(o => o.Staff)
            .WithOne()
            .HasForeignKey(staff => staff.Id)
            .IsRequired();
        //modelBuilder.Entity<OfficeClass>().HasDiscriminator(office => office.DepartmentType);

        
        //Projectmanager
        modelBuilder.Entity<Projectmanager>()
            .HasMany(p => p.Projects)
            .WithOne()
            .HasForeignKey(p => p.Id)
            .IsRequired();
        
        //Project
        modelBuilder.Entity<Project>().HasAlternateKey(p => p.Id);
        
        //Task
        modelBuilder.Entity<Task>().HasAlternateKey(t => t.Id);
        
        //...
        modelBuilder.Entity<Employee>().HasBaseType<Staff>();
        modelBuilder.Entity<Freelancer>().HasBaseType<Staff>();
        modelBuilder.Entity<Doctor>().HasBaseType<Staff>();
        modelBuilder.Entity<Projectmanager>().HasBaseType<Staff>();
        modelBuilder.Entity<SalesOffice>().HasBaseType<OfficeClass>();
        modelBuilder.Entity<AdministrationOffice>().HasBaseType<OfficeClass>();
    }
}