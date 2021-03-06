using System;
using System.Collections;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入一个数组：");
            //ArrayList nums = new ArrayList();
            string[] sarry = Console.ReadLine().Split(" ");
            int[] iarry=Array.ConvertAll<string, int>(sarry, int.Parse);
            int sum = 0, max=iarry[0], min= iarry[0], ave;
            for(int i = 0; i < iarry.Length; i++)
            {
                sum += iarry[i];
            }
            ave = sum / iarry.Length;
            for(int i = 1; i < iarry.Length; i++)
            {
                if (iarry[i]> max)
                    max = iarry[i];
                if (iarry[i] < min)
                    min = iarry[i];
            }
            Console.WriteLine("总和为" + sum + ",平均值为" + ave + ",最大值为" + max + ",最小值为" + min);
        }
    }
}
