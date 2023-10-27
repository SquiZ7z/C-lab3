using System;
using System.Collections.Generic;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть кількість осіб:");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            List<Person> people = new List<Person>();

            // Зчитуємо інформацію про осіб з консолі
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введіть ім'я для особи #{i + 1}:");
                string name = Console.ReadLine();

                Console.WriteLine($"Введіть вік для особи #{i + 1}:");
                if (int.TryParse(Console.ReadLine(), out int age))
                {
                    people.Add(new Person { Name = name, Age = age });
                }
                else
                {
                    Console.WriteLine("Неправильний формат віку. Спробуйте ще раз.");
                    i--;
                }
            }

            // Фільтрація та сортування
            var filteredPeople = people.FindAll(person => person.Age > 30);
            filteredPeople.Sort((person1, person2) => string.Compare(person1.Name, person2.Name, StringComparison.Ordinal));

            // Вивід результатів
            Console.WriteLine("\nОсоби старше 30 років, відсортовані за ім'ям:");
            foreach (var person in filteredPeople)
            {
                Console.WriteLine($"Ім'я: {person.Name}, Вік: {person.Age} років");
            }
        }
        else
        {
            Console.WriteLine("Неправильне введення. Будь ласка, введіть додатнє ціле число.");
        }
    }
}
