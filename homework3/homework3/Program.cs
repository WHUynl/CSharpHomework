using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{

    public class Foruser
    {
        SimpleFactory sf;
        public Foruser(SimpleFactory sf)
        {
            this.sf = sf;
        }
        public void makePainting()
        {
            try
            {
                Console.WriteLine("Please input the type you want: circle,square,rectangle or triangle: ");
                String type = Console.ReadLine();
                Paint pp;
                pp = sf.createPaint(type);
                pp.Setlines();
                pp.getS();
            }
            catch (Exception e) { Console.WriteLine("input error: " + e.Message); }
        }


    }
    public class SimpleFactory
    {

        public Paint createPaint(String type)
        {
            Paint painting = null;
            if (type.Equals("circle"))
            {
                painting = new Circle();

            }
            else if (type.Equals("square"))
            {
                painting = new Square();
            }
            else if (type.Equals("rectangle"))
            {
                painting = new Rectangle();
            }
            else if (type.Equals("triangle"))
            {
                painting = new Triangle();
            }

            return painting;

        }



    }
    public class Paint
    {
        public double r;
        public double oneline;
        public double twoline;
        public double threeline;
        public virtual void Setlines()
        {

        }
        public virtual void SetS()
        {

        }
        public virtual void getS()
        {

        }
        public Paint()
        {
            this.r = 0;
            this.oneline = 0;
            this.twoline = 0;
            this.threeline = 0;
        }





    }

    public class Circle : Paint
    {
        double S;
        public override void Setlines()
        {
            Console.Write("Please input a number to make sure the radius of the circle: ");
            try
            {
                String a = Console.ReadLine();
                this.r = double.Parse(a);
            }
            catch (Exception e) { Console.WriteLine("input error: " + e.Message); }
        }
        public override void SetS()
        {
            this.S = r * r * 3.14;

        }
        public override void getS()
        {
            SetS();
            Console.WriteLine("The area of circle is: " + S);
        }

    }
    public class Square : Paint
    {
        double S;
        public override void Setlines()
        {
            Console.Write("Please input a number to make sure the oneline of the square: ");
            try
            {
                String a = Console.ReadLine();
                this.oneline = double.Parse(a);
            }
            catch (Exception e) { Console.WriteLine("input error: " + e.Message); }
        }
        public override void SetS()
        {
            this.S = oneline * oneline;

        }
        public override void getS()
        {
            SetS();
            Console.WriteLine("The area of square is: " + S);
        }

    }
    public class Rectangle : Paint
    {
        double S;
        public override void Setlines()
        {
            Console.WriteLine("Please input a number to make sure the oneline of the rectangle: ");
            try
            {
                String a = Console.ReadLine();
                this.oneline = double.Parse(a);
                Console.WriteLine("Please input a number to make sure the twoline of the rectangle");
                String b = Console.ReadLine();
                this.twoline = double.Parse(b);
            }
            catch (Exception e) { Console.WriteLine("input error: " + e.Message); }
        }
        public override void SetS()
        {
            this.S = oneline * twoline;

        }
        public override void getS()
        {
            SetS();
            Console.WriteLine("The area of rectangle is: " + S);
        }

    }
    public class Triangle : Paint
    {
        double S;
        double l;
        public override void Setlines()
        {
            Console.WriteLine("Please input a number to make sure the oneline of the triangle: ");
            try
            {
                String a = Console.ReadLine();
                this.oneline = double.Parse(a);
                Console.WriteLine("Please input a number to make sure the twoline of the triangle: ");
                String b = Console.ReadLine();
                this.twoline = double.Parse(b);
                Console.WriteLine("Please input a number to make sure the threeline of the triangle: ");
                String c = Console.ReadLine();
                this.threeline = double.Parse(c);
            }
            catch (Exception e) { Console.WriteLine("input error: " + e.Message); }
        }
        public override void SetS()
        {
            if (oneline + threeline > twoline && oneline + twoline > threeline && twoline + threeline > oneline)
            {
                l = (oneline + threeline + twoline) / 2;
                this.S = Math.Sqrt(l * (l - oneline) * (l - twoline) * (l - threeline));
            }
            else
            {
                Console.WriteLine("Please make sure the three lines can make a triangle!!");
                this.oneline = 0;
                this.twoline = 0;
                this.threeline = 0;
                Setlines();
                SetS();
            }

        }
        public override void getS()
        {
            SetS();
            Console.WriteLine("The area of triangle is: " + S);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SimpleFactory s = new SimpleFactory();
            Foruser f = new Foruser(s);
            f.makePainting();



        }
    }
}

