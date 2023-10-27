using System;
using System.Collections.Generic;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

class Family
{
    private List<Person> members;

    public Family()
    {
        members = new List<Person>();
    }

    public void AddMember(Person member)
    {
        members.Add(member);
    }

    public Person GetOldestMember()
    {
        if (members.Count == 0)
        {
            return null; // Return null if the family has no members
        }

        Person oldest = members[0];

        foreach (Person member in members)
        {
            if (member.Age > oldest.Age)
            {
                oldest = member;
            }
        }

        return oldest;
    }
}

class Program
{
    static void Main()
    {
        Family family = new Family();

        // Додайте членів сім'ї
        // Приклад введення: "Іван 25", "Марія 30", "Петро 40"
        Console.WriteLine("Введіть ім'я та вік кожного члена сім'ї (наприклад, Ім'я Вік):");
        for (int i = 0; i < 3; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            string name = input[0];
            int age = int.Parse(input[1]);

            Person person = new Person(name, age);
            family.AddMember(person);
        }

        // Отримайте та надрукуйте ім'я та вік найстаршого члена сім'ї
        Person oldestMember = family.GetOldestMember();

        if (oldestMember != null)
        {
            Console.WriteLine($"Найстарший учасник сім'ї: {oldestMember.Name}, Вік: {oldestMember.Age}");
        }
        else
        {
            Console.WriteLine("Сім'я порожня. Додайте членів сім'ї.");
        }
    }
}
