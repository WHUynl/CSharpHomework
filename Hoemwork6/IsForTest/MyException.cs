using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsForTest
{
    class MyException : ApplicationException
    {
        private string idnumber = "输入类型错误或输入数值不正确";
        public MyException()
        {

        }
        public void outputerror()
        {
            Console.WriteLine(idnumber);
        }

    }
}
