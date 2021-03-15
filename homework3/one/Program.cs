using System;

//实现长方形、正方形、三角形等形状的类。每个形状类都能计算面积、判断形状是否合法。
namespace one
{
    public abstract class Shape
    {
        public abstract double getArea();
        public abstract double getPerimter();
        public abstract bool isLegal();
    }
    public class Rectangle : Shape   //矩形
    {
        private double width;
        private double length;
        public string Info
        {
            get
            {
                return "长为" + length + "，宽为" + width;
            }
        }
        public Rectangle(double l,double w)
        {
            this.length = l;
            this.width = w;
        }
        public override double getArea()
        {
            return this.width * this.length;
        }
        public override double getPerimter()
        {
            return 2 * (width + length);
        }
        public override bool isLegal()
        {
            if (width <= 0 || length <= 0)
                return false;
            return true;
        }
    }
    public class Square : Rectangle
    {
        public Square(double w) : base(w, w) { }

    }

    public class Triangle : Shape
    {
        private double l1;
        private double l2;
        private double l3;
        public Triangle(double a,double b,double c)
        {
            this.l1=a;
            this.l2 = b;
            this.l3 = c;
        }
        public override double getArea()
        {
            double p = (l1 + l2 + l3) / 2;
            return Math.Sqrt(p*(p - l1)*(p - l2)*(p - l3));
        }
        public override double getPerimter()
        {
            return (l1 + l2 + l3);
        }
        public override bool isLegal()
        {
            if (l1 + l2 <= l3 || l1 + l3 <= l2 || l2 + l3 <= l1)
                return false;
            return true;
        }
    }

    public class ShapeJudge
    {
        public static bool isLegal(object obj)
        {
            if (obj is Shape)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Shape shape = new Rectangle(2, 1);
            Console.WriteLine(shape.isLegal());
            Console.WriteLine(shape.getArea());
            shape = new Triangle(1, 2, 3);
            Console.WriteLine(shape.isLegal());
            Rectangle rec = new Rectangle(3, 2);
            Console.WriteLine(ShapeJudge.isLegal(rec));
            Console.WriteLine(rec.Info);
        }
    }
}
