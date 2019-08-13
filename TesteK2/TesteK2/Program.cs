using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteK2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("**************************       Teste Pratico K2        **************************");
            Console.WriteLine();
            Console.WriteLine("**************************Desenvolvido por: Fábio Firmino**************************");
            Console.WriteLine();
            Console.WriteLine();

            //Alguns dados de testes efetuados.
            p.Test("01/03/2010 23:00", '+', 4000);
            //p.Test("01/03/2010 23:00", '-', 30);
            //p.Test("01/03/2010 23:00", '-', 70);
            //p.Test("26/02/2010 23:00", '+', 4020);
            //p.Test("01/03/2010 01:20", '-', 100);
            //p.Test("30/12/2010 23:00", '+', 4000);
            //p.Test("01/01/2011 02:12", '-', 140);
            //p.Test("01/03/2010 23:00", '+', 4000);
            Console.ReadKey();
        }

        private void Test(string date, char op, long value)
        {
            Console.WriteLine("Resultado: " + date + " " + op + " " + value + "min => " + ChangeDate(date, op, value));
        }

        public string ChangeDate(string date, char op, long value)
        {
            /*
            Conforme solicitado dentro da Regra
            ChangeDate("01/03/2010 23:00", '+', 4000) = "04/03/2010 17:40"
            */
            string result = date;

            if (op != '-' && op != '+')
                throw new Exception("Operador Inválido");
            if (value < 0)
                value = value * (-1);
            bool add = (op == '+');
            long day = Convert.ToInt32(date.Substring(0, 2));
            int month = Convert.ToInt32(date.Substring(3, 2));
            int year = Convert.ToInt32(date.Substring(6, 4));
            long hour = Convert.ToInt32(date.Substring(11, 2));
            long min = Convert.ToInt32(date.Substring(14, 2));

            if (add)
            {
                min = min + value;
                hour = hour + (min / 60);
                day = day + (hour / 24);
            }
            else
            {
                min = min + value;
                hour = hour + (min / 60);
                day = day + (hour / 24);
            }

            int[] m30 = { 4, 6, 9, 11 };
            int[] m31 = { 1, 3, 5, 7, 8, 10, 12 };
            bool monthOK = false;
            while (!monthOK)
            {
                bool is30 = m30.Contains(month);
                bool is31 = m31.Contains(month);
                monthOK = (day <= 28 && month == 2) || (day <= 30 && is30) || (day <= 31 && is31);
                if (!monthOK)
                {
                }
            }
            result = day.ToString("00") + "/" + month.ToString("00") + "/" + year + " " + (hour % 24).ToString("00") + ":" + (min % 60).ToString("00");
            return result;
        }
    }
}

