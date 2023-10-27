using System;

class DateModifier
{
    private int dayDifference;

    public int DayDifference
    {
        get { return dayDifference; }
    }

    public void CalculateDifference(string firstDate, string secondDate)
    {
        DateTime date1 = DateTime.Parse(firstDate);
        DateTime date2 = DateTime.Parse(secondDate);

        // Обчислення різниці в днях і збереження результату
        dayDifference = (int)(date2 - date1).TotalDays;
    }
}

class Program
{
    static void Main()
    {
        // Введення дат від користувача
        Console.Write("Введіть першу дату (рік-місяць-день): ");
        string firstDate = Console.ReadLine();

        Console.Write("Введіть другу дату (рік-місяць-день): ");
        string secondDate = Console.ReadLine();

        // Створення та використання класу DateModifier
        DateModifier dateModifier = new DateModifier();
        dateModifier.CalculateDifference(firstDate, secondDate);

        Console.WriteLine($"Різниця в днях: {dateModifier.DayDifference}");
    }
}
