using System.Drawing;
using System.Runtime.ConstrainedExecution;

int option = -1;
Company company = new Company();

static void ShowMenu()
{
    PrintColoredMessage(
        ConsoleColor.Blue,
        "============💼 MAXIMUM OVERBUSINESS LTD. 💼============"
    );
    Console.WriteLine("1) Add a new employee");
    Console.WriteLine("2) List all employees");
    Console.WriteLine("3) Fire an employee");
    Console.WriteLine("4) Change the name of an employee");
    Console.WriteLine($"0) EXIT");
    Console.Write($"CHOOSE AN OPTION: ");
}

do
{
    ShowMenu();
    string input = Console.ReadLine();
    if (!int.TryParse(input, out int parsedInput) || parsedInput > 4 || parsedInput < 0)
    {
        PrintColoredMessage(ConsoleColor.Red, "\n===== ⛔️ INVALID OPTION. TRY AGAIN ⛔️ =====\n");
        continue;
    }
    option = parsedInput;

    switch (option)
    {
        case 1: //OK
            Console.WriteLine($"Type in the CPF of the employee:");
            string cpf = Console.ReadLine();
            Console.WriteLine($"Type in the name of the employee:");
            string name = Console.ReadLine();
            Console.WriteLine($"Type in the employee's date of birth (yyyy-mm-dd):");
            DateOnly birthdate = DateOnly.Parse(Console.ReadLine());
            Employee newEmployee = new Employee(cpf, name, birthdate);
            company.AddEmployee(newEmployee);
            PrintColoredMessage(ConsoleColor.Green, "\nEMPLOYEE ADDED SUCCESSFULLY!\n");
            break;
        case 2:
            // LIST ALL EMPLOYEES
            if (company.Count == 0)
            {
                PrintColoredMessage(ConsoleColor.Red, "\nTHERE ARE NO EMPLOYEES IN THE COMPANY\n");
                break;
            }
            PrintColoredMessage(
                ConsoleColor.DarkYellow,
                "\n===== MAXIMUM OVERBUSINESS' EMPLOYEES =====\n"
            );
            foreach (var employee in company.ListEmployeesAlphabetically())
                Console.WriteLine(employee);
            break;
        case 3:
            // FIRE EMPLOYEE
            Console.WriteLine($"Type in the ID of the employee you want to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                PrintColoredMessage(ConsoleColor.Red, "INVALID ID!");
                break;
            }
            if (company.RemoveEmployee(id))
                PrintColoredMessage(ConsoleColor.Green, "\nEMPLOYEE REMOVED SUCCESSFULLY\n");
            else
                PrintColoredMessage(ConsoleColor.Red, "THE COMPANY HAS NO EMPLOYEES");
            break;
        case 4:
            // EDIT EMPLOYEE
            break;
        case 0:
            PrintColoredMessage(
                ConsoleColor.DarkRed,
                "= = = = = = = = = = = SYSTEM CLOSED = = = = = = = = = = ="
            );
            return;
    }
} while (option != 0);

static void PrintColoredMessage(ConsoleColor color, string message)
{
    Console.ForegroundColor = color;
    Console.WriteLine(message);
    Console.ResetColor();
}
