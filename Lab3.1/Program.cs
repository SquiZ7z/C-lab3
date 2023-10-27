﻿using System;

class Людина
{
    public string Ім_я { get; set; } = "Невідомо";
    public int Вік { get; set; } = 0;
}

class Program
{
    static void Main()
    {
        // Створення об'єкта за допомогою вбудованої ініціалізації
        Людина людина1 = new Людина();
        Console.WriteLine($"Ім'я: {людина1.Ім_я}, Вік: {людина1.Вік}");

        // Створення об'єкта за допомогою вбудованої ініціалізації зі значеннями
        Людина людина2 = new Людина { Ім_я = "Іван", Вік = 25 };
        Console.WriteLine($"Ім'я: {людина2.Ім_я}, Вік: {людина2.Вік}");

        // Введення даних з консолі для нового об'єкта
        Console.Write("Введіть ім'я: ");
        string ім_я = Console.ReadLine();

        Console.Write("Введіть вік: ");
        int вік;

        while (!int.TryParse(Console.ReadLine(), out вік) || вік < 0)
        {
            Console.WriteLine("Будь ласка, введіть коректне значення для віку (ціле невід'ємне число).");
            Console.Write("Введіть вік: ");
        }

        // Створення нового об'єкта з введеними даними
        Людина новаЛюдина = new Людина { Ім_я = ім_я, Вік = вік };

        // Виведення інформації про новостворений об'єкт
        Console.WriteLine($"Ім'я нової людини: {новаЛюдина.Ім_я}, Вік: {новаЛюдина.Вік}");
    }
}