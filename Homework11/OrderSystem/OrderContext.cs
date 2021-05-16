using System;
using System.Data.Entity;
using System.Linq;


namespace OrderSystem
{
    public class OrderContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“OrderContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“OrderSystem.OrderContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“OrderContext”
        //连接字符串。
        public OrderContext()
            : base("name=OrderContext")
        {
            Database.SetInitializer(
            new DropCreateDatabaseIfModelChanges<OrderContext>());
        }

        public DbSet<Order> Orders { get; set; } 
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Client> Clients { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}