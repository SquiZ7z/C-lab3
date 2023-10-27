using System;

class Rectangle
{
    public string Id { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public Rectangle(string id, int width, int height, int x, int y)
    {
        Id = id;
        Width = width;
        Height = height;
        X = x;
        Y = y;
    }

    public bool IntersectsWith(Rectangle other)
    {
        return X < other.X + other.Width &&
               X + Width > other.X &&
               Y < other.Y + other.Height &&
               Y + Height > other.Y;
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine()); // Кількість прямокутників
        int m = int.Parse(Console.ReadLine()); // Кількість перевірок перетину

        Rectangle[] rectangles = new Rectangle[n];

        // Читаємо вхідні дані та створюємо об'єкти Rectangle
        for (int i = 0; i < n; i++)
        {
            string[] rectData = Console.ReadLine().Split();
            rectangles[i] = new Rectangle(rectData[0], int.Parse(rectData[1]), int.Parse(rectData[2]), int.Parse(rectData[3]), int.Parse(rectData[4]));
        }

        // Перевіряємо перетин для кожної пари прямокутників
        for (int i = 0; i < m; i++)
        {
            string[] pair = Console.ReadLine().Split();
            string id1 = pair[0];
            string id2 = pair[1];

            Rectangle rect1 = Array.Find(rectangles, r => r.Id == id1);
            Rectangle rect2 = Array.Find(rectangles, r => r.Id == id2);

            bool intersect = rect1.IntersectsWith(rect2);
            Console.WriteLine(intersect);
        }
    }
}
