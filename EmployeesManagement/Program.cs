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
    Console.WriteLine($"0) Exit");
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
        case 1:
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
            if (company.Count == 0)
            {
                PrintColoredMessage(ConsoleColor.Red, "\nTHERE ARE NO EMPLOYEES IN THE COMPANY\n");
                break;
            }
            PrintColoredMessage(
                ConsoleColor.Magenta,
                "\n===== MAXIMUM OVERBUSINESS' EMPLOYEES ====="
            );
            foreach (var employee in company.ListEmployeesAlphabetically())
                Console.WriteLine(employee);
            break;

        case 3:
            Console.Write($"Type in the ID of the employee you want to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                PrintColoredMessage(ConsoleColor.Red, "\nINVALID ID!\n");
                break;
            }
            if (company.RemoveEmployee(id))
                PrintColoredMessage(ConsoleColor.Green, "\nEMPLOYEE REMOVED SUCCESSFULLY\n");
            else
                PrintColoredMessage(ConsoleColor.Red, "\nTHE COMPANY HAS NO EMPLOYEES\n");
            break;

        case 4:
        {
            Console.Write($"Type in the ID of the employee you want to rename: ");
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                PrintColoredMessage(ConsoleColor.Red, "\nINVALID ID!\n");
                break;
            }
            var employee = company.GetEmployeeByID(id);
            if (employee is null)
            {
                PrintColoredMessage(ConsoleColor.Red, "\nEMPLOYEE NOT FOUND\n");
                break;
            }
            Console.WriteLine($"Type in the new name:");
            string newName = Console.ReadLine();
            try
            {
                company.RenameEmployee(id, newName);
                PrintColoredMessage(ConsoleColor.Green, "\nEMPLOYEE RENAMED SUCCESSFULLY!\n");
            }
            catch (ArgumentException ex)
            {
                PrintColoredMessage(ConsoleColor.Red, $"\n{ex.Message}\n");
            }
            break;
        }

        case 0:
            PrintColoredMessage(
                ConsoleColor.DarkRed,
                "\n= = = = = = = = = = = SYSTEM CLOSED = = = = = = = = = = =\n"
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
