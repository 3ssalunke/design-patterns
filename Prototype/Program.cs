using Prototype;

Console.Title = "Prototype";

var manager = new Manager("Badru");
var managerClone = (Manager)manager.Clone();
Console.WriteLine($"Manager was cloned: {managerClone.Name}");

var employee = new Employee("Dhaval", managerClone);
var employeeClone = (Employee)employee.Clone(true);
Console.WriteLine($"Employee was cloned: {employeeClone.Name} {employeeClone.Manager.Name}");

managerClone.Name = "Paul";
Console.WriteLine($"Employee was cloned: {employeeClone.Name} {employeeClone.Manager.Name}");
