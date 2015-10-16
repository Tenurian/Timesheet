using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timesheet
{
    public class TimesheetGenerator
    {
        //Creating new branch
        public readonly int NUMBER_OF_WEEKS;
        public readonly int MAX_HOURS_PER_WEEK;
        private enum DayType { Regular, Sick, Vacation }
        private enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }
        private String name;
        private int total, overtime;
        private int[] log;

        //[ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            TimesheetGenerator p = new TimesheetGenerator();
            p.start();
        }

        public TimesheetGenerator()
        {
            name = "";
            total = 0;
            overtime = 0;
            NUMBER_OF_WEEKS = 2;
            MAX_HOURS_PER_WEEK = 40;
            log = new int[NUMBER_OF_WEEKS * 7];
        }

        public TimesheetGenerator(int Weeks)
        {
            name = "";
            total = 0;
            overtime = 0;
            NUMBER_OF_WEEKS = Weeks;
            MAX_HOURS_PER_WEEK = 40;
            log = new int[NUMBER_OF_WEEKS * 7];
        }

        public TimesheetGenerator(int Weeks, int hours)
        {
            name = "";
            total = 0;
            overtime = 0;
            NUMBER_OF_WEEKS = Weeks;
            MAX_HOURS_PER_WEEK = hours;
            log = new int[NUMBER_OF_WEEKS * 7];
        }

        //[ExcludeFromCodeCoverage]
        public void start()
        {
            Console.WriteLine("Please Enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine("Welcome, {0}", name);

            log = MainLoop();
            total = CalculateTotalTimeWorked(log);
            Console.WriteLine("Total hours worked: {0}", total);

            overtime = CalculateOvertime(total);
            Console.WriteLine("\n\nYou had {0} hours of overtime.", overtime);

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
            int[] data = new int[NUMBER_OF_WEEKS * 7];
            for (int week = 0; week < NUMBER_OF_WEEKS; week++)
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
                total += h;
            }
            return total;
        }

        public int GetTotal()
        {
            return total;
        }

        public int CalculateOvertime(int worked)
        {
            if (worked > (NUMBER_OF_WEEKS * MAX_HOURS_PER_WEEK))
            {
                return worked - (NUMBER_OF_WEEKS * MAX_HOURS_PER_WEEK);
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
