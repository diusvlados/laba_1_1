using System;

namespace варіант6
{
    internal class TTriangle
    {
        private double x1, y1, x2, y2, x3, y3;

        // Конструктор за замовчуванням це трикутник
        public TTriangle()
        {
            x1 = 0; y1 = 0;
            x2 = 1; y2 = 0;
            x3 = 0; y3 = 1;
        }

        // Конструктор з координатами трьох вершин
        public TTriangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Check(x1, y1, x2, y2, x3, y3);
            this.x1 = x1; this.y1 = y1;
            this.x2 = x2; this.y2 = y2;
            this.x3 = x3; this.y3 = y3;
        }

        // Сторони тільки для читання: вони рахуються з вершин
        public double A 
        { 
            get 
            { 
                return Distance(x1, y1, x2, y2); 
            } 
        }
        public double B 
        {
            get
            { 
                return Distance(x2, y2, x3, y3); } }
        public double C
        {
            get
            {
                return Distance(x3, y3, x1, y1); 
            } 
        }

        // Індексатор (індексатор тільки для читання
        public double this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: 
                        return A;
                    case 1:
                        return B;
                    case 2:
                        return C;
                    default:
                        throw new IndexOutOfRangeException("Індекс має бути 0, 1 або 2");
                }
            }
        }

        public void Input()
        {
            double nx1 = Read("x1"), ny1 = Read("y1");
            double nx2 = Read("x2"), ny2 = Read("y2");
            double nx3 = Read("x3"), ny3 = Read("y3");

            Check(nx1, ny1, nx2, ny2, nx3, ny3);
            x1 = nx1;
            y1 = ny1;
            x2 = nx2;
            y2 = ny2;
            x3 = nx3;
            y3 = ny3;
        }

        public void Output()
        {
            Console.WriteLine("Вершини: ({0}; {1}), ({2}; {3}), ({4}; {5})", x1, y1, x2, y2, x3, y3);
            Console.WriteLine("Сторони: a = {0:F2}, b = {1:F2}, c = {2:F2}", this[0], this[1], this[2]);
        }

        public double Perimeter()
        {
            return this[0] + this[1] + this[2];
        }

        public double Area()
        {
            return CalcArea(x1, y1, x2, y2, x3, y3);
        }

        // Відстань між двома точками
        private static double Distance(double xa, double ya, double xb, double yb)
        {
            double dx = xb - xa;
            double dy = yb - ya;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        // Площа за координатами вершин
        private static double CalcArea(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            return Math.Abs(x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2;
        }

        // Площа 0 означає, що точки лежать на одній прямій
        private static void Check(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            if (CalcArea(x1, y1, x2, y2, x3, y3) == 0)
                throw new ArgumentException("Точки лежать на одній прямій, трикутник не існує");
        }

        private static double Read(string name)
        {
            Console.Write(name + " = ");
            return double.Parse(Console.ReadLine());
        }
    }
}