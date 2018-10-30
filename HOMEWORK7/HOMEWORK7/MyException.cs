using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace HOMEWORK7
{
    class MyException : ApplicationException
    {
        private string idnumber = "输入类型错误或输入数值不正确";
        public MyException()
        {

        }
        public void outputerror()
        {
            if (MessageBox.Show("输入错误", "错误", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
        }

    }
}
