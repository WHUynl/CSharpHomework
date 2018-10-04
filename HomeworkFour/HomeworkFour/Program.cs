using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeworkFour
{
    class Program
    {

        public class AlarmEventArgs : EventArgs
        {
            public string Time { get; set; }
        }
        public delegate void AlarmEventHandler(object sender, AlarmEventArgs e);

        public class Alarmclock
        {
            public event AlarmEventHandler alarming;
            public void Alarm(string a)
            {

                AlarmEventArgs arg = new AlarmEventArgs();
                arg.Time = a;
                string b = DateTime.Now.ToShortTimeString().ToString();
                Thread.Sleep(1000);
                if (arg.Time.Equals(b))
                {

                    alarming(this, arg);
                }
                else
                {
                    Alarm(a);

                }
            }
        }
        static void Main(string[] args)
        {
            Alarmclock oneclock = new Alarmclock();
            oneclock.alarming += new AlarmEventHandler(Timeup);
            oneclock.Alarm("18:08");//设置提醒的时间
        }
        static void Timeup(object sender, AlarmEventArgs e)
        {
            Console.WriteLine("It's time now!");
        }

    }
}

