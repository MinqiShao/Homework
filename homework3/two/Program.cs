using System;

//随机创建10个形状对象，计算这些对象的面积之和。 尝试使用简单工厂设计模式来创建对象。

namespace two
{
    class Program
    {
        public interface Shape
        {
            public double getArea();
            public bool isLegal();
            public string Info { get; }
        }
        public class Rectangle : Shape  //矩形
        {
            private double width;
            private double length;
            public Rectangle(double l, double w)
            {
                this.length = l;
                this.width = w;
            }
            public double getArea()
            {
                return width * length;
            }
            public bool isLegal()
            {
                if (width <= 0 || length <= 0)
                    return false;
                return true;
            }
            public string Info
            {
                get
                {
                    return "长" + length + "宽" + width;
                }
            }
        }
        public class Square : Rectangle  //正方形
        {
            public Square(double w) : base(w, w) { }

        }

        public class Circle : Shape   //圆
        {
            private double radius;
            const double PI = 3.14;
            public Circle(double r)
            {
                radius = r;
            }
            public double getArea()
            {
                return PI * radius * radius;
            }
            public bool isLegal()
            {
                if (radius <= 0)
                    return false;
                return true;
            }
            public string Info
            {
                get
                {
                    return "半径：" + radius;
                }
            }
        }

        public class Triangle : Shape   //三角形
        {
            private double l1;
            private double l2;
            private double l3;
            public Triangle(double a, double b, double c)
            {
                this.l1 = a;
                this.l2 = b;
                this.l3 = c;
            }
            public double getArea()
            {
                double p = (l1 + l2 + l3) / 2;
                return Math.Sqrt(p * (p - l1) * (p - l2) * (p - l3));
            }
            public bool isLegal()
            {
                if (l1 + l2 <= l3 || l1 + l3 <= l2 || l2 + l3 <= l1)
                    return false;
                return true;
            }
            public string Info
            {
                get
                {
                    return "三边长为:" + l1 +" "+ l2 +" "+ l3;
                }
            }
        }

        public class ShapeFactory
        {
            public Shape getShape(String shape)
            {
                if (shape == null)
                    return null;
                Random rd = new Random();
                if (shape.Equals("Rectangle"))
                {
                    /*Console.WriteLine("输入长：");
                    double length = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("输入宽：");
                    double width = Convert.ToDouble(Console.ReadLine());*/
                    double length = rd.NextDouble() * (10 - 0) + 0;
                    double width = rd.NextDouble() * (10 - 0) + 0;
                    return new Rectangle(length, width);
                }
                else if (shape.Equals("Square"))
                {
                    /*Console.WriteLine("输入边长：");
                    double length = Convert.ToDouble(Console.ReadLine());*/
                    double length = rd.NextDouble() * (10 - 0) + 0;
                    return new Square(length);
                }
                else if (shape.Equals("Circle"))
                {
                    /*Console.WriteLine("输入半径：");
                    double radius= Convert.ToDouble(Console.ReadLine());*/
                    double radius = rd.NextDouble() * (10 - 0) + 0;
                    return new Circle(radius);
                }
                else if (shape.Equals("Triangle"))
                {
                    /*Console.WriteLine("输入第一条边长：");
                    double l1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("输入第二条边长：");
                    double l2 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("输入第三条边长：");
                    double l3 = Convert.ToDouble(Console.ReadLine());*/
                    double l1 = rd.NextDouble() * (10 - 0) + 0;
                    double l2 = rd.NextDouble() * (10 - 0) + 0;
                    double l3 = rd.NextDouble() * (10 - 0) + 0;
                    return new Triangle(l1,l2,l3);
                }
                return null;
            }
        }
        public class Demo
        {
            public static string randomPick(string[] strings)
            {
                Random random = new Random();
                return strings[random.Next(strings.Length)];
            }
            static void Main(string[] args)
            {
                ShapeFactory shapeFactory = new ShapeFactory();
                double sum = 0.0;
                string[] shapes = { "Rectangle", "Square", "Circle", "Triangle" };
                for(int i = 0; i < 5; i++)
                {
                    string shapename = randomPick(shapes);
                    Console.WriteLine(shapename);
                    Shape shape = shapeFactory.getShape(shapename);
                    Console.WriteLine(shape.Info);
                    if (shape.isLegal())
                        sum += shape.getArea();
                    else
                        Console.WriteLine("该形状不合法！不计入总面积");
                }
                Console.WriteLine("面积之和为：" + sum);
            }
        }
    }
}
