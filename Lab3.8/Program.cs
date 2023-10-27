using System;
using System.Collections.Generic;
using System.Linq;

class Engine
{
    public int Speed { get; set; }
    public int Power { get; set; }

    public Engine(int speed, int power)
    {
        Speed = speed;
        Power = power;
    }
}

class Cargo
{
    public int Weight { get; set; }
    public string Type { get; set; }

    public Cargo(int weight, string type)
    {
        Weight = weight;
        Type = type;
    }
}

class Tire
{
    public double Pressure { get; set; }
    public int Age { get; set; }

    public Tire(double pressure, int age)
    {
        Pressure = pressure;
        Age = age;
    }
}

class Car
{
    public string Model { get; set; }
    public Engine CarEngine { get; set; }
    public Cargo CarCargo { get; set; }
    public List<Tire> Tires { get; set; }

    public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
    {
        Model = model;
        CarEngine = engine;
        CarCargo = cargo;
        Tires = tires;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the number of cars:");
        int n = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter information for car #{i + 1}:");
            string[] carInfo = Console.ReadLine().Split();

            string model = carInfo[0];
            int speed = int.Parse(carInfo[1]);
            int power = int.Parse(carInfo[2]);
            int weight = int.Parse(carInfo[3]);
            string cargoType = carInfo[4];
            double tire1Pressure = double.Parse(carInfo[5]);
            int tire1Age = int.Parse(carInfo[6]);
            double tire2Pressure = double.Parse(carInfo[7]);
            int tire2Age = int.Parse(carInfo[8]);
            double tire3Pressure = double.Parse(carInfo[9]);
            int tire3Age = int.Parse(carInfo[10]);
            double tire4Pressure = double.Parse(carInfo[11]);
            int tire4Age = int.Parse(carInfo[12]);

            Engine engine = new Engine(speed, power);
            Cargo cargo = new Cargo(weight, cargoType);
            List<Tire> tires = new List<Tire>
            {
                new Tire(tire1Pressure, tire1Age),
                new Tire(tire2Pressure, tire2Age),
                new Tire(tire3Pressure, tire3Age),
                new Tire(tire4Pressure, tire4Age)
            };

            Car car = new Car(model, engine, cargo, tires);
            cars.Add(car);
        }

        Console.WriteLine("Enter the command (fragile/flamable):");
        string command = Console.ReadLine();

        if (command == "fragile")
        {
            var fragileCars = cars.Where(car => car.CarCargo.Type == "fragile" &&
                                                car.Tires.Any(tire => tire.Pressure < 1));

            Console.WriteLine("Fragile cars:");
            foreach (var fragileCar in fragileCars)
            {
                Console.WriteLine(fragileCar.Model);
            }
        }
        else if (command == "flamable")
        {
            var flamableCars = cars.Where(car => car.CarCargo.Type == "flamable" &&
                                                 car.CarEngine.Power > 250);

            Console.WriteLine("Flamable cars:");
            foreach (var flamableCar in flamableCars)
            {
                Console.WriteLine(flamableCar.Model);
            }
        }
        else
        {
            Console.WriteLine("Invalid command. Please enter 'fragile' or 'flamable'.");
        }
    }
}
