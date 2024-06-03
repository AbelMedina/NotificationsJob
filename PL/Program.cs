using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            int diaSemana = (int)DateTime.Now.DayOfWeek;
            int dia = (int)DateTime.Now.Day;
            if (Enumerable.Range(1, 5).Contains(diaSemana))
            {
                if (dia == 15)
                {
                    BL.Job.notificacion();
                    System.Environment.Exit(0);
                }
                if (dia == 30)
                {
                    BL.Job.notificacion();
                    System.Environment.Exit(0);
                }
                if (dia == 13 && diaSemana == 5)
                {
                    BL.Job.notificacion();
                    System.Environment.Exit(0);
                }
                if (dia == 14 && diaSemana == 5)
                {
                    BL.Job.notificacion();
                    System.Environment.Exit(0);
                }
                if (dia == 28 && diaSemana == 5)
                {
                    BL.Job.notificacion();
                    System.Environment.Exit(0);
                }
                if (dia == 29 && diaSemana == 5)
                {
                    BL.Job.notificacion();
                    System.Environment.Exit(0);
                }
            }
            else
            {
                System.Environment.Exit(0);
            }
        }
    }
}
