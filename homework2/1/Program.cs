using System;
using System.Collections;

namespace _1
{
    class Program
    {
        public static bool zhishu(int number)  //判断是否为质数
        {
            for(int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;

        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个数：");
            int num = Int32.Parse(Console.ReadLine());
            //ArrayList results=new ArrayList();
            for(int i = 2; i <= num; i++)
            {
                if (num % i == 0&&zhishu(i))   //如果是他的因数且是质数
                {
                    Console.Write(i + " ");
                }
            }



            //for (int i = 2; i < num; i++)
            //{
                //while (num % i == 0 && num != i)
                //{
                    //Console.Write(i + " ");
                   // num /= i;
                //}
           // }
            //Console.Write(num);
        }
    }
}
