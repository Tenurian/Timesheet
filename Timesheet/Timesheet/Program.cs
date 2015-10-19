using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timesheet
{
    class Gooey
    {
        //this is where the GUI code will be
        public Gooey()
        {
            
        }
    }

    public class TimesheetGenerator
    {
        //Creating new branch
        public readonly int NumberOfWeeks;
        public readonly int MaxHoursPerWeek;
        private enum DayType { Regular, Sick, Vacation }
        private enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }
        private String _name;
        private int _total, _overtime;
        private int[] _log;

        //[ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            TimesheetGenerator p = new TimesheetGenerator();
            p.start();
        }

        public TimesheetGenerator()
        {
            _name = "";
            _total = 0;
            _overtime = 0;
            NumberOfWeeks = 2;
            MaxHoursPerWeek = 40;
            _log = new int[NumberOfWeeks * 7];
        }

        public TimesheetGenerator(int Weeks)
        {
            _name = "";
            _total = 0;
            _overtime = 0;
            NumberOfWeeks = Weeks;
            MaxHoursPerWeek = 40;
            _log = new int[NumberOfWeeks * 7];
        }

        public TimesheetGenerator(int Weeks, int hours)
        {
            _name = "";
            _total = 0;
            _overtime = 0;
            NumberOfWeeks = Weeks;
            MaxHoursPerWeek = hours;
            _log = new int[NumberOfWeeks * 7];
        }

        //[ExcludeFromCodeCoverage]
        public void start()
        {
            Console.WriteLine("Please Enter your _name: ");
            _name = Console.ReadLine();
            Console.WriteLine("Welcome, {0}", _name);

            _log = MainLoop();
            _total = CalculateTotalTimeWorked(_log);
            Console.WriteLine("Total hours worked: {0}", _total);

            _overtime = CalculateOvertime(_total);
            Console.WriteLine("\n\nYou had {0} hours of _overtime.", _overtime);

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
            int[] data = new int[NumberOfWeeks * 7];
            for (int week = 0; week < NumberOfWeeks; week++)
            {
                for (int d = 1; d <= 7; d++)
                {
                    Console.WriteLine("How many hours did you work on the {0}{1} {2}?", (week + 1), numSuffixes[week], days[d - 1], week);
                Input:
                    String temp = Console.ReadLine();
                    int number;
                    if (Int32.TryParse(temp, out number))
                    {
                        if (ValidateInput(number))
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

        public int CalculateTotalTimeWorked(int[] w)
        {
            foreach (int h in w)
            {
                _total += h;
            }
            return _total;
        }

        public int GetTotal()
        {
            return _total;
        }

        public int CalculateOvertime(int worked)
        {
            if (worked > (NumberOfWeeks * MaxHoursPerWeek))
            {
                return worked - (NumberOfWeeks * MaxHoursPerWeek);
            }
            else
            {
                return 0;
            }
        }

        public bool ValidateInput(int userInput)/*SHOULD return TRUE if their input is between 0 and 24, and FALSE if input is < 0 or > 24*/
        {
            //Boolean inputValidated = true;
            //if(userInput > 24 || userInput < 0)
            //{                                             //all of this
            //    inputValidated = false;
            //}
            //return inputValidated;
            return (userInput <= 24 && userInput >= 0);     //can be simplified to one line. :)
        }
    }
}
