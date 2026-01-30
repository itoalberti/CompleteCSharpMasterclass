public class Company
{
    private Dictionary<int, Employee> _allEmployees = new();
    public int Count => _allEmployees.Count;

    // ------------------------ADD EMPLOYEE------------------------
    public void AddEmployee(Employee employee)
    {
        if (employee is null)
            throw new ArgumentException(nameof(employee));
        _allEmployees.Add(employee.Id, employee);
    }

    // ------------------------REMOVE EMPLOYEE------------------------
    public bool RemoveEmployee(int id) => _allEmployees.Remove(id);

    // ------------------------GET EMPLOYEE BY ID------------------------
    public Employee GetEmployeeByID(int id)
    {
        _allEmployees.TryGetValue(id, out var employee);
        return employee;
    }

    // ------------------------GET ALL EMPLOYEES------------------------
    public IReadOnlyCollection<Employee> ListEmployees() =>
        _allEmployees.Values.ToList().AsReadOnly();

    // ------------------------ORDER EMPLOYEES ALPHABETICALLY------------------------
    public IEnumerable<Employee> ListEmployeesAlphabetically() =>
        _allEmployees.Values.OrderBy(e => e.Name);

    // FILTER EMPLOYEES
    // public IEnumerable<Employee> FilterEmployees(Func<Employee, bool> predicate)
    // {
    //     return _allEmployees.Values.Where(predicate);
    // }
}
