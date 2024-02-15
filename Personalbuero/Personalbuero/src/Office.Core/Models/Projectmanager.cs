﻿using System.Text;

namespace Personalverwaltung.Office.Core.Models;

public class Projectmanager : Staff
{
    private decimal BonusPerProject { get; }
    public List<Project> Projects { get; }

    public Projectmanager(string firstName, string lastName, char geschlecht, DateOnly gebJahr, DateOnly eintrJahr)
        : base(firstName, lastName, geschlecht, gebJahr, eintrJahr)
    {
        Projects = new List<Project>();
        BonusPerProject = 100m;
    }

    public override decimal CalculateInflationCompensation()
    {
        return CalculateSalary() * 1.15m;
    }

    public override decimal CalculateSalary()
    {
        return base.CalculateSalary() + (CountCompletedProjects() * BonusPerProject);
    }

    public void AddProject(Project project)
    {
        Projects.Add(project);
    }

    public bool CompleteProject(Project project)
    {
        if (!project.Completed)
        {
            project.Completed = true;
            Projects.Remove(project);
            return true;
        }
        else
        {
            return false;
        }
    }

    public int CountTotalProjects()
    {
        return Projects.Count;
    }

    public int CountCompletedProjects()
    {
        return Projects.Count(project => project.Completed);
    }

    public new string ToString()
    {
        var sb = new StringBuilder(2000).Append(base.ToString());
        return sb.ToString();
    }
}