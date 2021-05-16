using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrderSystem
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public Client() { }
        public Client(int id,string name)
        {
            ClientID = id;
            ClientName = name;
        }
        public override string ToString()
        {
            return "客户ID为"+ClientID+",客户名为：" + ClientName;
        }
    }
}
