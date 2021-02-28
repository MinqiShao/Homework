using System;

namespace _1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0, b = 0, c = 0;
            string n;
            Console.WriteLine("请输入第一个数：");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入第二个数：");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入运算符：");
            n = Console.ReadLine();
            if (n == "+")
            {
                c = a + b;
                Console.WriteLine(c);
            }
            else if (n == "-")
            {
                c = a - b;
                Console.WriteLine(c);
            }
            else if (n == "*")
            {
                c = a * b;
                Console.WriteLine(c);
            }
            else if (n == "/")
            {
                c = a / b;
                Console.WriteLine(c);
            }
        }
    }
}
