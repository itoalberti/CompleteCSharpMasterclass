public class Employee
{
    private static int _nextId = 1;
    public int Id;
    public string Cpf { get; set; }
    public string Name { get; set; }
    public DateOnly Birthdate { get; set; }

    // ============= CONSTRUCTOR =============
    public Employee(string cpf, string name, DateOnly birthdate)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            throw new ArgumentException("⛔️ Invalid CPF! ⛔️");
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("⛔️ Invalid name! ⛔️");

        Id = _nextId++;
        Name = name;
        Cpf = cpf;
        Birthdate = birthdate;
    }

    // ============= METHODS =============
    public void UpdateName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("⛔️ New name is invalid! ⛔️");
    }

    public override string ToString()
    {
        return $"ID: {Id} | Name: {Name} | CPF: {Cpf} | Birthdate: {Birthdate:dd/MM/yyyy}";
    }
}
