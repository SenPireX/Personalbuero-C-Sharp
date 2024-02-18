/*using System;
using Personalverwaltung.Personalbuero.Core.Models;

namespace Personalverwaltung.Personalbuero.Core.Tests;

public class TestMitarbeiter
{
    public static void MitarbeiterTest()
    {
        var staffGenerator = new StaffGenerator();

        // Generate staff
        var staff1 = staffGenerator.GenerateStaff();
        var staff2 = staffGenerator.GenerateStaff();
        var staff3 = staffGenerator.GenerateStaff();

        Console.WriteLine(staff1.ToString());
        Console.WriteLine();

        Console.WriteLine(staff2.ToString());
        Console.WriteLine();

        Console.WriteLine(staff3.ToString());
        Console.WriteLine();
    }

    private static char RandomGender()
    {
        char[] genders = { 'm', 'w' };
        var random = new Random();
        return genders[random.Next(genders.Length)];
    }

    private static DateOnly RandomBirthDate()
    {
        var random = new Random();
        var year = random.Next(1970, 2003);
        var month = random.Next(1, 13);
        var day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
        return new DateOnly(year, month, day);
    }

    private static DateOnly RandomEntryDate()
    {
        var random = new Random();
        var year = random.Next(2005, DateTime.Now.Year);
        var month = random.Next(1, 13);
        var day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
        return new DateOnly(year, month, day);
    }

    private class StaffGenerator
    {
        private readonly Random _random = new();

        private readonly string[] _femaleNames =
        {
            "Emma", "Mia", "Hannah", "Anna", "Lea", "Sophie", "Lena", "Sarah", "Laura", "Julia", "Lisa", "Emily",
            "Elena", "Clara", "Nora"
        };

        private readonly string[] _maleNames =
        {
            "Lukas", "Max", "Paul", "Jonas", "Finn", "Leon", "Ben", "Noah", "Elias", "David", "Julian", "Felix",
            "Simon", "Alexander", "Niklas"
        };

        private readonly string[] _lastNames =
        {
            "Müller", "Schmidt", "Schneider", "Fischer", "Weber", "Meyer", "Wagner", "Becker", "Hoffmann", "Schulz",
            "Koch", "Bauer", "Richter", "Klein", "Wolf"
        };

        public Staff GenerateStaff()
        {
            string firstName;
            var gender = RandomGender();

            if (gender is 'w' or 'm')
            {
                firstName = gender == 'w'
                    ? _femaleNames[_random.Next(_femaleNames.Length)]
                    : _maleNames[_random.Next(_maleNames.Length)];
            }
            else
            {
                gender = RandomGender();
                firstName = gender == 'w'
                    ? _femaleNames[_random.Next(_femaleNames.Length)]
                    : _maleNames[_random.Next(_maleNames.Length)];
            }

            var lastName = _lastNames[_random.Next(_lastNames.Length)];

            //int birthYear = _random.Next(1970, 2001);
            //int birthMonth = _random.Next(1, 13);
            //int birthDay = _random.Next(1, DateTime.DaysInMonth(birthYear, birthMonth) + 1);
            //int entryYear = _random.Next(birthYear, DateTime.Now.Year);
            //int entryMonth = _random.Next(1, 13);
            //int entryDay = _random.Next(1, DateTime.DaysInMonth(entryYear, entryMonth) + 1);

            return new Staff(firstName, lastName, gender, RandomBirthDate(), RandomEntryDate());
        }
    }
}*/

