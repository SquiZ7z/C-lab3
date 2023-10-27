using System;

class Person
{
    private string name;
    private int age;

    public Person()
    {
        name = "Без імені";
        age = 1;
    }

    public Person(int age)
        : this()
    {
        this.age = age;
    }

    public Person(string name, int age)
        : this(age)
    {
        this.name = name;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Ім'я: {name}, Вік: {age}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть дані для персони 1:");

        Console.Write("Ім'я: ");
        string name1 = Console.ReadLine();

        Console.Write("Вік: ");
        int age1 = int.Parse(Console.ReadLine());

        Console.WriteLine("\nВведіть дані для персони 2:");

        Console.Write("Ім'я: ");
        string name2 = Console.ReadLine();

        Console.Write("Вік: ");
        int age2 = int.Parse(Console.ReadLine());

        Console.WriteLine("\nВведіть дані для персони 3:");

        Console.Write("Ім'я: ");
        string name3 = Console.ReadLine();

        Console.Write("Вік: ");
        int age3 = int.Parse(Console.ReadLine());

        Person person1 = new Person(name1, age1);
        Person person2 = new Person(name2, age2);
        Person person3 = new Person(name3, age3);

        Console.WriteLine("\nПерсона 1:");
        person1.DisplayInfo();

        Console.WriteLine("\nПерсона 2:");
        person2.DisplayInfo();

        Console.WriteLine("\nПерсона 3:");
        person3.DisplayInfo();

        Console.ReadLine();
    }
}
