using System;
using two;

//使用事件机制，模拟实现一个闹钟功能。闹钟可以有嘀嗒（Tick）事件和响铃（Alarm）两个事件。在闹钟走时时或者响铃时，在控制台显示提示信息。
//闹钟：自己设置

namespace A
{
    public class Time
    {
        public int h { get; set; }
        public int m { get; set; }
        public int s { get; set; }
        public string Info
        {
            get
            {
                return (h + ":" + m + ":" + s);
            }
        }
        public Time(int hour,int minute,int second)
        {
            h = hour;  m = minute;  s = second;
        }
        public bool isValid()
        {
            return (h > 0 && h <= 24 && m >= 0 && m < 60 && s >= 0 && s < 60);
        }
    }
}

namespace B
{
    public delegate void EventHandler();   //委托

    public class Clock
    {
        //声明事件
        public event EventHandler Tick;
        public event EventHandler Alarm;

        //public A.Time time;
        public A.Time alarmTime;
        
        public void setAlarm(int hour,int minute,int second)
        {
            alarmTime = new A.Time(hour, minute, second);
            if (alarmTime.isValid())
            {
                Alarm += Clock_Alarm;
            }                           //这里可以写个异常类，也可以直接用Exception
            else
            {
                throw new InValidException(hour, minute, second);
;            }
        }
        public bool IsAlarm()  //若时间到达alarmtime
        {
            if (alarmTime.h== DateTime.Now.Hour&& alarmTime.m == DateTime.Now.Minute&& alarmTime.s == DateTime.Now.Second)
            {
                Alarm();  //调用事件
                return true;
            }
            return false;
        }
        public void Clock_Tick()  //tick的事件处理
        {
            Console.WriteLine("Tick!!");
        }
        public void Clock_Alarm()  //alarm的事件处理
        {
            Console.WriteLine("Alarm!!");
            Console.WriteLine("现在是：" + alarmTime.Info);
        }
        public void start()
        {
            Tick += Clock_Tick;
            while (true)
            {
                Console.WriteLine(DateTime.Now);
                Tick();
                System.Threading.Thread.Sleep(1000);
                if (IsAlarm())
                {
                    return;
                }
                Console.Clear();
            }
        }
    }
    class Program
    {
        //事件处理方法
        
        static void Main(string[] args)
        {
            Clock clock=new Clock();
            Console.WriteLine("输入alarm的时间：(时 分 秒)");
            int hour = Convert.ToInt32(Console.ReadLine());
            int minute = Convert.ToInt32(Console.ReadLine());
            int second = Convert.ToInt32(Console.ReadLine());
            try
            {
                clock.setAlarm(hour, minute, second);
                clock.start();
            }
            catch(InValidException e)
            {
                Console.WriteLine("第"+e.Code + "个数错了！");
            }
        }
    }
}
