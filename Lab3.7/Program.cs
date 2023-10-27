using System;
using System.Collections.Generic;

class Car
{
    public string Model { get; }
    public double FuelAmount { get; set; }
    public double FuelConsumption { get; }
    public double DistanceTraveled { get; set; }

    public Car(string model, double fuelAmount, double fuelConsumption)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumption = fuelConsumption;
        DistanceTraveled = 0;
    }

    public void Drive(double distance)
    {
        double fuelNeeded = distance * FuelConsumption;
        if (FuelAmount >= fuelNeeded)
        {
            FuelAmount -= fuelNeeded;
            DistanceTraveled += distance;
        }
        else
        {
            Console.WriteLine("Недостатньо палива для подорожі");
        }
    }

    public override string ToString()
    {
        return $"{Model} {FuelAmount:F2} {DistanceTraveled:F2}";
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть кількість автомобілів:");
        int n = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        Console.WriteLine("Введіть інформацію про автомобілі у форматі <Модель> <Кількість палива> <Витрата палива на 1 км>:");
        for (int i = 0; i < n; i++)
        {
            string[] carInfo = Console.ReadLine().Split();
            string model = carInfo[0];
            double fuelAmount = double.Parse(carInfo[1]);
            double fuelConsumption = double.Parse(carInfo[2]);

            Car car = new Car(model, fuelAmount, fuelConsumption);
            cars.Add(car);
        }

        string command;
        Console.WriteLine("Введіть команду у форматі 'Drive <CarModel> <amountOfKm>' або 'Кінець' для завершення:");
        while ((command = Console.ReadLine()) != "Кінець")
        {
            string[] commandArgs = command.Split();
            string carModel = commandArgs[1];
            double distance = double.Parse(commandArgs[2]);

            Car car = cars.Find(c => c.Model == carModel);
            car.Drive(distance);

            Console.WriteLine($"Введіть команду у форматі 'Drive <CarModel> <amountOfKm>' або 'Кінець' для завершення:");
        }

        Console.WriteLine("Результати:");
        foreach (Car car in cars)
        {
            Console.WriteLine(car);
        }
    }
}
