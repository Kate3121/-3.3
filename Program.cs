using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лр3._3
{
    class Transport
    {
        //поля
        protected double l;//пробіг
        protected bool spravka;//наявність технічного огляду
        //конструктор з параметрами
        public Transport(double x, bool y)
        {
            this.l = x; this.spravka = y;
        }
        //dL дистанція,яку потрібно проїхати
        //повертає true та  збільшує загальний пробіг,
        //якщо є длвідка  про техогляд
        //чи false, якщо немає довідки
        public bool Move(double dL)
        {
            bool f = false;
            if (spravka) { l += dL; f = true; }
            return f;
        }
        public string ToStr()
        {
            string s = "Загальний пробiг = " + l;
            return s;
        }
        class Car : Transport
        {
            double RT;//витрати бензину в л/км;
            double VB;//обсяг бензину в баку (в літрах);
            //конструктор з параметрами
            //перші два параметри з конструктора базового класу
            public Car(double x, bool y, double rt, double vb) : base(x, y)
            {
                this.RT = rt; this.VB = vb;
            }
            public bool Change(double x)
            {
                bool p = false;
                double b = x * RT;
                if (VB - b >= 0) { VB = VB - b; p = true; }
                return p;
            }
            //перевизначуваний метод,
            //повертає інформацію про стан об'єкту пясня подорожі
            new public string ToStr()
            {
                string s = "Загальний пробiг = " + l + "; залишились бензину = " + VB + ";";
                return s;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Random o = new Random();
            Console.WriteLine("Для транспортного середовища");
            double rast = o.Next(100, 500);
            Console.WriteLine("Вiдстань = {0}", rast);
            double pr = o.Next(1000, 2000);
            Console.WriteLine("Початковий пробiг = {0}", pr);
            double v = o.Next(40, 120);
            Console.WriteLine("Швидкiсть = {0}", v);
            bool sp = true;
            int p = o.Next(0, 2);
            if (p == 0) sp = false;
            Transport t = new Transport(pr, sp);
            bool x;
            if (sp)
            { do
                {
                    x = t.Move(v);
                    rast = rast - v;
                    Console.WriteLine(t.ToStr());
                }
                while (rast - v >= 0);
                x = t.Move(rast);
                Console.WriteLine(t.ToStr());}
            else Console.WriteLine("Потрiбно пройти техосмотр");           
        }     
    }    
}
