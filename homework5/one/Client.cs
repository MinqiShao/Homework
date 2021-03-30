using System;
using System.Collections.Generic;
using System.Text;
//订单、订单明细、客户、货物等类添加ToString方法，用来显示订单信息。
namespace ClientSpace
{
    class Client
    {
        public string ClientName { get; set; }
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
