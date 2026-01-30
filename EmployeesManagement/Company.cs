public class Company
{
    private Dictionary<int, Employee> _allEmployees = new();
    public int Count => _allEmployees.Count;

    public void AddEmployee(Employee employee)
    {
        if (employee is null)
            throw new ArgumentException(nameof(employee));
        _allEmployees.Add(employee.Id, employee);
    }

    public bool RemoveEmployee(int id) => _allEmployees.Remove(id);

    public bool RenameEmployee(int id, string newName)
    {
        if (!_allEmployees.TryGetValue(id, out var employee))
            return false;
        employee.UpdateName(newName);
        return true;
    }

    public Employee GetEmployeeByID(int id)
    {
        _allEmployees.TryGetValue(id, out var employee);
        return employee;
    }

    public IReadOnlyCollection<Employee> ListEmployees() =>
        _allEmployees.Values.ToList().AsReadOnly();

    public IEnumerable<Employee> ListEmployeesAlphabetically() =>
        _allEmployees.Values.OrderBy(e => e.Name);
}
