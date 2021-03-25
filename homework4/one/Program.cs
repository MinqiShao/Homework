//为示例中的泛型链表类添加类似于List<T>类的ForEach(Action<T> action)方法。通过调用这个方法打印链表元素，求最大值、最小值和求和（使用lambda表达式实现）

using System;

namespace one
{
    public delegate void Func<T>(Node<T> n);
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
                head = tail = n;
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        
        public void ForEach(Func<T> func)
        {
            Node<T> n = this.head;
            while (n != null)
            {
                func(n);
                n = n.Next;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list=new GenericList<int>();
            for(int i = 0; i < 5; i++)
            {
                Random random = new Random();
                list.Add(random.Next(50));
            }
            list.ForEach(m => Console.Write(m.Data+" "));
            int sum = 0;
            list.ForEach(m => sum += m.Data);
            Console.WriteLine($"sum={sum}");
            int max = 0;
            list.ForEach(m => { if (m.Data > max) max = m.Data; });
            Console.WriteLine($"max={max}");
            int min = 123;
            list.ForEach(m => { if (m.Data <min) min = m.Data; });
            Console.WriteLine($"min={min}");
        }
    }
}
