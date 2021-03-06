using System;
using System.Collections.Generic;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("输入一个矩阵：");
            //List<List<int>> nums = new List<List<int>>();
            Console.WriteLine("输入矩阵的行数：");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("输入矩阵的列数：");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] nums = new int[m, n];
            Console.WriteLine("输入矩阵：");
            for(int i = 0; i < m; i++)
            {
                string[] sNum= Console.ReadLine().Split(" ");
                int[] iNum = Array.ConvertAll<string, int>(sNum, int.Parse);
                for(int j = 0; j < n; j++)
                {
                    nums[i, j] = iNum[j];
                }
            }

            bool flag = true;
            /*for(int j = 0; j <= n - 2; j++)
            {
                int a =1,b=j+1;
                while (flag&&a<m&&b<n)
                {
                    if (nums[0, j] != nums[a, b])
                    {
                        flag = false;
                    }
                    a++;
                    b++;
                }
                if (!flag)
                {
                    break;
                }
            }
            for (int i = 1; i <= m - 2; i++)
            {
                int a = i+1,b=1;
                while (flag&& a < m && b < n)
                {
                    if (nums[i,0] != nums[a,b])
                    {
                        flag = false;
                    }
                    a++;
                    b++;
                }
                if (!flag)
                {
                    break;
                }
            }*/

            for(int i = 0; i < m - 1; i++)
            {
                for(int j = 0; j < n - 1; j++)
                {
                    if (nums[i, j] != nums[i + 1, j + 1])
                    {
                        flag = false;
                        break;
                    }
                }
                if (!flag)
                    break;
            }
            if (flag)
            {
                Console.WriteLine("是托普利兹矩阵！");
            }
            else
            {
                Console.WriteLine("不是托普利兹矩阵！");
            }
        }
    }
}
