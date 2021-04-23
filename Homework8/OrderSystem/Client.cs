using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSpace
{
    public class Client
    {
        public string ClientName { get; set; }
        public Client() { }
        public Client(string name)
        {
            ClientName = name;
        }
        public override string ToString()
        {
            return "客户名为：" + ClientName;
        }
    }
}
