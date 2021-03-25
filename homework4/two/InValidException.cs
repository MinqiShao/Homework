using System;
using System.Collections.Generic;
using System.Text;

namespace two
{
    class InValidException:Exception
    {
        public string Code { get; set; }
        public InValidException(int hour,int minute,int second)
        {
            if (hour > 24)
                Code = "1";
            if (minute > 60)
                Code = "2";
            if(second>60)
                Code="3";
        }
    }
}
