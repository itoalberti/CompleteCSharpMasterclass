// Choose a pivot element
// Split the other elements in two groups:
//      > pivot
//      < pivot
// Apply this logic recursively
// Bind everything together in the end
static int[] QuickSort(int[] arr)
{
    if (arr.Length <= 1)
        return arr;
    int pivot = arr[0];
    List<int> left = new List<int>();
    List<int> right = new List<int>();
    List<int> equal = new List<int>();

    foreach (int n in arr)
    {
        if (n < pivot)
            left.Add(n);
        if (n > pivot)
            right.Add(n);
        if (n == pivot)
            equal.Add(n);
    }

    return QuickSort(left.ToArray()).Concat(equal).Concat(QuickSort(right.ToArray())).ToArray();
}

static int[] BubbleSort(int[] arr)
{
    int length = arr.Length;
    for (int i = 0; i < length - 1; i++)
    {
        bool swapped = false;
        for (int j = 0; j < length - i - 1; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                int temp = arr[j + 1];
                arr[j + 1] = arr[j];
                arr[j] = temp;
                swapped = true;
            }
        }
        if (!swapped)
            break;
    }
    return arr;
}

int[] arr = { 10, 7, 8, 9, 1, 4, 57, 10, 120, 8745, 0, 5, 10000 };

int[] quickSorted = QuickSort(arr);
int[] bubbleSorted = BubbleSort(arr);

Console.WriteLine($"Quick Sort:  {string.Join(", ", quickSorted)}");
Console.WriteLine($"Bubble Sort: {string.Join(", ", bubbleSorted)}");

static void PrintIntArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
        Console.WriteLine($"Item {i + 1}: {arr[i]}");
}

static void PrintStringArray(string[] arr)
{
    int i = 0;
    foreach (string s in arr)
    {
        i++;
        Console.WriteLine($"Item {i + 1}: {s}");
    }
}

// merges together the PrintIntArray and PrintStringArray functions
static void PrintArray<T>(T[] arr)
{
    for (int i = 0; i < arr.Length; i++)
        Console.WriteLine($"{typeof(T)} - Item {i + 1}: {arr[i]}");
}

int[] numbers = { 11, 22, 33, 44, 55, 66 };
string s = "Who can it be now?";
string[] s2 = { "I've", "become", "comfortably", "numb" };

PrintArray(numbers);
PrintArray(s.Split(' '));
PrintArray(s2);

Person[] people =
{
    new Person { Name = "Anne", Age = 40 },
    new Person { Name = "Bernie", Age = 35 },
    new Person { Name = "Coraline", Age = 30 },
};

PersonSorter sorter = new();

static int CompareByAge(Person x, Person y) => x.Age.CompareTo(y.Age);
static int CompareByName(Person x, Person y) => x.Name.CompareTo(y.Name);

Console.WriteLine($"\nCOMPARISON BY NAME:");
sorter.Sort(people, CompareByName);
foreach (Person person in people)
    Console.WriteLine($"{person.Name}, {person.Age}");

Console.WriteLine($"\nCOMPARISON BY AGE:");
sorter.Sort(people, CompareByAge);
foreach (Person person in people)
    Console.WriteLine($"{person.Name}, {person.Age}");

// DECLARATION OF TYPES
public delegate int Comparison<T>(T t1, T t2);

public class Person
{
    public int Age { get; set; }
    public string Name { get; set; }
}

public class PersonSorter
{
    public void Sort(Person[] people, Comparison<Person> comparison)
    {
        for (int i = 0; i < people.Length - 1; i++)
        {
            for (int j = i + 1; j < people.Length; j++)
            {
                if (comparison(people[i], people[j]) > 0)
                {
                    Person temp = people[i];
                    people[i] = people[j];
                    people[j] = temp;
                }
            }
        }
    }
}
