using System;

namespace FiguresTask
{
    public abstract class Figure
    {
        public abstract double Area();
        public virtual void DisplayProperties()
        {
            Console.WriteLine($"Фигура {GetType().Name}");
        }
        ~Figure()
        {
            Console.WriteLine($"[Деструктор] Объект {GetType().Name} уничтожен");
        }
    }

    public class Circle : Figure
    {
        public double Radius { get; set; }
        public Circle(double radius) => Radius = radius;
        public override double Area() => Math.PI * Radius * Radius;
        public override void DisplayProperties()
        {
            Console.WriteLine($"Круг: радиус = {Radius:F2}");
        }
    }

    public abstract class Quadrilateral : Figure { }

    public class Rectangle : Quadrilateral
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public override double Area() => Width * Height;
        public override void DisplayProperties()
        {
            Console.WriteLine($"Прямоугольник: ширина = {Width:F2}, высота = {Height:F2}");
        }
    }

    public class Square : Rectangle
    {
        public Square(double side) : base(side, side) { }
        public override void DisplayProperties()
        {
            Console.WriteLine($"Квадрат: сторона = {Width:F2}");
        }
    }

    public class Rhombus : Quadrilateral
    {
        public double Side { get; set; }
        public double AngleDegrees { get; set; }
        public Rhombus(double side, double angleDegrees)
        {
            Side = side;
            AngleDegrees = angleDegrees;
        }
        public override double Area() => Side * Side * Math.Sin(AngleDegrees * Math.PI / 180.0);
        public override void DisplayProperties()
        {
            Console.WriteLine($"Ромб: сторона = {Side:F2}, угол = {AngleDegrees:F1}°");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 3. Полиморфизм (Фигуры) ===\n");
            try
            {
                Console.Write("Введите радиус круга: ");
                double r = double.Parse(Console.ReadLine());
                Circle circle = new Circle(r);

                Console.Write("Введите ширину прямоугольника: ");
                double w = double.Parse(Console.ReadLine());
                Console.Write("Введите высоту прямоугольника: ");
                double h = double.Parse(Console.ReadLine());
                Rectangle rect = new Rectangle(w, h);

                Console.Write("Введите сторону квадрата: ");
                double s = double.Parse(Console.ReadLine());
                Square square = new Square(s);

                Console.Write("Введите сторону ромба: ");
                double side = double.Parse(Console.ReadLine());
                Console.Write("Введите угол ромба (градусы): ");
                double angle = double.Parse(Console.ReadLine());
                Rhombus rhombus = new Rhombus(side, angle);

                Figure[] figures = { circle, rect, square, rhombus };

                Console.WriteLine("\n--- Демонстрация полиморфизма ---");
                foreach (var fig in figures)
                {
                    // 1. Вывод всех свойств объекта
                    fig.DisplayProperties();
                    // 2. Явный вызов метода Area и вывод результата
                    Console.WriteLine($"Площадь: {fig.Area():F2}\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
}