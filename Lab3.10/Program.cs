using System;
using System.Collections.Generic;

class Engine
{
    public string Model { get; set; }
    public int Power { get; set; }
    public double Displacement { get; set; }
    public double Efficiency { get; set; }
}

class Car
{
    public string Model { get; set; }
    public Engine CarEngine { get; set; }
    public double Weight { get; set; }
    public string Color { get; set; }

    public Car(string model, Engine carEngine, double weight, string color)
    {
        Model = model;
        CarEngine = carEngine;
        Weight = weight;
        Color = color;
    }

    public void PrintCarDetails()
    {
        Console.WriteLine($"{Model} : {CarEngine.Model}:");

        Console.WriteLine($"Потужність: {CarEngine.Power}");
        Console.WriteLine($"Об'єм: {CarEngine.Displacement}");
        Console.WriteLine($"ККД: {CarEngine.Efficiency}");

        Console.WriteLine($"Вага: {(Weight > 0 ? Weight.ToString() : "n/a")}");
        Console.WriteLine($"Колір: {(string.IsNullOrEmpty(Color) ? "n/a" : Color)}");

        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, Engine> engines = new Dictionary<string, Engine>();

        for (int i = 0; i < n; i++)
        {
            string[] engineInfo = Console.ReadLine().Split();
            string engineModel = engineInfo[0];
            int enginePower = int.Parse(engineInfo[1]);
            double engineDisplacement = engineInfo.Length > 2 ? double.Parse(engineInfo[2]) : -1;
            double engineEfficiency = engineInfo.Length > 3 ? double.Parse(engineInfo[3]) : -1;

            Engine engine = new Engine
            {
                Model = engineModel,
                Power = enginePower,
                Displacement = engineDisplacement,
                Efficiency = engineEfficiency
            };

            engines.Add(engineModel, engine);
        }

        int m = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < m; i++)
        {
            string[] carInfo = Console.ReadLine().Split();
            string carModel = carInfo[0];
            string engineModel = carInfo[1];
            double carWeight = carInfo.Length > 2 ? double.Parse(carInfo[2]) : -1;
            string carColor = carInfo.Length > 3 ? carInfo[3] : null;

            Engine carEngine = engines[engineModel];
            Car car = new Car(carModel, carEngine, carWeight, carColor);
            cars.Add(car);
        }

        foreach (Car car in cars)
        {
            car.PrintCarDetails();
        }
    }
}
