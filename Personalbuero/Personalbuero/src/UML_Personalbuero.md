```mermaid
---
title: Personalbuero UML-Diagramm
---

classDiagram
class Staff {
    <<Abstract>>
    +Id: Guid
    +Role: Type
    +FirstName: string
    +LastName: string
    -Gender: char
    -BirthYear: DateOnly
    -EntryYear: DateOnly
    +Address: Address
    +Staff(name: string, gender: char, birthYear: DateOnly, entryYear: DateOnly, address: Address)
    +CalculateInflationCompensation()* decimal
    +CalculateSalary() decimal
    +CalculateAge() int
    +CalculateServiceYears() int
    +CompareTo(other: Staff) int
    +ToString() string
}

class Employee {
    +Employee(name: string, gender: char, birthYear: DateOnly, entryYear: DateOnly, address: Address)
    +CalculateInflationCompensation() decimal
    +ToString() string
}

class Freelancer {
    -Hours : int
    -HourlyRate : decimal
    +Freelancer(name: string, gender: char, birthYear: DateOnly, entryYear: DateOnly, address: Address, hours: int, hourlyRate: decimal)
    +CalculateInflationCompensation() decimal
    +CalculateSalary() decimal
    +ToString() string
}

class Doctor {
    -WeeklyHours : int
    -FixedSalary : decimal
    +Doctor(name: string, gender: char, birthYear: DateOnly, entryYear: DateOnly, address: Address, weeklyHours: int, fixedSalary: decimal)
    +CalculateInflationCompensation() decimal 
    +CalculateSalary() decimal
    +CalculateHourlyRate() decimal
    +ToString() string
}

class Projectmanager {
    -BonusPerProject: decimal
    +Projects: List<Project>
    +Projectmanager(name: string, gender: char, birthYear: DateOnly, entryYear: DateOnly, address: Address)
    +CalculateInflationCompensation() decimal
    +CalculateSalary() decimal
    +AddProject(project: Project) void
    +CompleteProject(project: Project) bool
    +CountTotalProjects() int
    +CountCompletedProjects() int
    +ToString() string
}

class Office {
    <<Aggregate>>
    +Id: Guid
    +Name: string
    +DepartmentType: Type
    +Address: Address
    +Staff: List<Staff>
    +Office(name: string, address: Address)
    +Enroll(staff: Staff) void
    +CalculateTotalSalary() decimal
    +CalculateAverageAge() double
    +TerminateStaff(staff: Staff) bool
    +TerminateStaffByIndex(employeeIndex: int) bool
    +TerminateAll() int
    +SortBySalary(order: char) void
    +SortStaff() void
    +SortByNames() void
    +SortByAge() void
    +CountStaff() int
    +SalaryList() string
    +CountEmployees() int
    +CalculateAverageSalaryEmployees() decimal
    +ToString() string
}

class Address {
    <<Record>>
    +Address(street: string, zip: string, city: string)
}

class Task {
    -Description : string
    +Task(description: string)
}

class Project {
    -Name : string
    -StartDate : DateOnly
    -EndDate : DateOnly
    +TaskList : List<Task>
    +Completed : bool
    +Project(name: string, startDate: DateOnly, endDate: DateOnly, completed: bool)
    +AddTask(task: Task) void
    +CountTasks() int
}

class SalesOffice {
    +SalesOffice()
}

class AdministrationOffice {
    +AdministrationOffice() 
}

Employee --|> Staff : Inheritance
Freelancer --|> Staff : Inheritance
Doctor --|> Staff : Inheritance
Projectmanager --|> Staff : Inheritance
SalesOffice --|> Office : Inheritance
AdministrationOffice --|> Office : Inheritance
Office o-- Staff : Aggregation
Address *-- Staff : Composition
Task *-- Project : Composition
Project *-- Projectmanager : Composition




