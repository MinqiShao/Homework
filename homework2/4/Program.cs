using System;

namespace _4
{
    class Program
    {
        //用“埃氏筛法”求2~ 100以内的素数。
        //2~ 100以内的数，先去掉2的倍数，再去掉3的倍数，再去掉4的倍数，以此类推...最后剩下的就是素数
        static void Main(string[] args)
        {
            Console.WriteLine("2~100中的素数");
            bool[] flag = new bool[99];
            for(int i = 0; i < 99; i++)
            {
                flag[i] = true;
            }
            for(int i = 2; i < 51; i++)
            {
                for(int j = 2*i; j <101; j+=i)
                {
                    flag[j-2] = false;
                }
            }
            for(int i = 2; i < 101; i++)
            {
                if (flag[i - 2])
                    Console.Write(i + " ");
            }
        }
    }
}
