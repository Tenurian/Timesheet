using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheet;

namespace TimesheetConsole
{
    public class TimesheetEngine
    {
        private string _name;
        private int[] _log;
        private int _total;
        private int _overtime;
        private TimesheetGenerator tg;

        public static void Main(string[] args)
        {
            new TimesheetEngine();
        }

        public TimesheetEngine()
        {
            tg = new TimesheetGenerator();
            this.Start();
        }

        //[ExcludeFromCodeCoverage]
        public void Start()
        {
            Console.WriteLine("Please Enter your name: ");
            _name = Console.ReadLine();
            Console.WriteLine("Welcome, {0}", _name);

            _log = MainLoop();
            _total = tg.CalculateTotalTimeWorked(_log);
            Console.WriteLine("Total hours worked: {0}", _total);

            _overtime = tg.CalculateOvertime(_total);
            Console.WriteLine("\n\nYou had {0} hours of overtime.", _overtime);

            Console.ReadLine();
        }

        //[ExcludeFromCodeCoverage]
        public int[] MainLoop()
        {
            DayOfWeek[] days = new[]
            {
                DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday,
                DayOfWeek.Saturday, DayOfWeek.Sunday
            };
            String[] numSuffixes = new[] { "st", "nd", "rd", "th" };
            int[] data = new int[tg.NumberOfWeeks * 7];
            for (int week = 0; week < tg.NumberOfWeeks; week++)
            {
                for (int d = 1; d <= 7; d++)
                {
                    Console.WriteLine("How many hours did you work on the {0}{1} {2}?", (week + 1), numSuffixes[week], days[d - 1], week);
                Input:
                    String temp = Console.ReadLine();
                    int number;
                    if (Int32.TryParse(temp, out number))
                    {
                        if (tg.ValidateInput(number))
                        {
                            data[((week * 7) + (d - 1))] = number;
                        }
                        else
                        {
                            Console.WriteLine("Please enter the number of hours you worked.");
                            goto Input;
                        }
                    }
                    else if (temp.ToLower().Equals("exit") || temp.ToLower().Equals("stop"))
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Please enter the number of hours you worked.");
                        goto Input;
                    }
                    //Console.WriteLine("{0}", ((week * 7) + d));
                    Console.WriteLine("\n");
                }
            }
            return data;
        }
    }
}
