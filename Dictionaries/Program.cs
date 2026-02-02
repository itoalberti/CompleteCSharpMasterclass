namespace Dictionaries;

internal class Program
{
    static void Main(string[] args)
    {
        // key - value
        // Dictionary<int, string> employees = new Dictionary<int, string>
        // {
        //     { 90, "Shaniqua" },
        //     { 91, "Thomas" },
        //     { 92, "LeRoy" },
        //     { 93, "Barnard" },
        //     { 94, "Josephine" },
        // };

        // Console.WriteLine(employees[91]);
        // employees[91] = "Norah";
        // Console.WriteLine(employees[91]);
        // employees.Remove(91);

        // if (!employees.ContainsKey(99))
        //     employees.Add(99, "Malone");
        // if (!employees.ContainsValue("Donald Duck"))
        //     employees.Add(112, "Donald Duck");

        // foreach (KeyValuePair<int, string> employee in employees)
        //     Console.WriteLine($"ID: {employee.Key} - Name: {employee.Value}");

        // ===================== ALTERNATIVE FORM =====================
        Dictionary<int, Employee> employees = new Dictionary<int, Employee>()
        {
            { 101, new Employee("Jeremiah", 43, 6500) },
            { 102, new Employee("Tony", 35, 4200) },
            { 103, new Employee("Sasquatch", 215, 800) },
            { 104, new Employee("Barry", 61, 12300) },
            { 105, new Employee("Earl", 18, 1100) },
        };

        foreach (var item in employees)
            Console.WriteLine(
                $"ID: {item.Key}  Name: {item.Value.Name.PadRight(15)} Age: {item.Value.Age.ToString().PadRight(4)} Salary: $ {item.Value.Salary}"
            );

        var codes = new Dictionary<string, string>
        {
            ["NY"] = "New York",
            ["MA"] = "Massachussetts",
            ["WI"] = "Wisconsin",
            ["MS"] = "Mississippi",
        };

        if (codes.TryGetValue("WIN", out string state))
            Console.WriteLine($"The state with code \"WI\" is {state}");

        foreach (var item in codes)
            Console.WriteLine($"Code: {item.Key} | State: {item.Value}");
    }
}

class Employee
{
    internal string Name { get; set; }
    internal int Age { get; set; }
    internal int Salary { get; set; }

    public Employee(string name, int age, int salary)
    {
        Name = name;
        Age = age;
        Salary = salary;
    }
};
