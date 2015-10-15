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

        [ExcludeFromCodeCoverage]
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
        }

        public TimesheetGenerator(int Weeks)
        {
            name = "";
            total = 0;
            overtime = 0;
            NUMBER_OF_WEEKS = Weeks;
            MAX_HOURS_PER_WEEK = 40;
        }

        public TimesheetGenerator(int Weeks, int hours)
        {
            name = "";
            total = 0;
            overtime = 0;
            NUMBER_OF_WEEKS = Weeks;
            MAX_HOURS_PER_WEEK = hours;
        }

        [ExcludeFromCodeCoverage]
        public void start()
        {
            Console.WriteLine("Please Enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine("Welcome, {0}", name);

            total = CalculateTotalTimeWorked();
            Console.WriteLine("Total hours worked: {0}", total);

            overtime = CalculateOvertime(total);
            Console.WriteLine("\n\nYou had {0} hours of overtime.", overtime);

            Console.ReadLine();

        }

        [ExcludeFromCodeCoverage]
        public int CalculateTotalTimeWorked()
        {
            int timeWorked = 0;
            for (int week = 1; week <= NUMBER_OF_WEEKS; week++)
            {
                foreach (Day day in Enum.GetValues(typeof(Day)))
                {
                MakeChoice:
                    int choice = 0;
                    Console.WriteLine("What type of day was {1} of week {0}?\n1) Regular\n2) Sick\n3) Vacation", week, day);
                    String input = Console.ReadLine();
                    if (input.ToLower().Equals("exit"))
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        try
                        {
                            choice = Int32.Parse(input);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Console.WriteLine("Sorry try again");
                            choice = 0;
                        }
                    }

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("How many hours did you work on {1} of week {0}?", week, day);
                            timeWorked += Int32.Parse(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("SICK DAY : 8 Hr");
                            if (timeWorked < (NUMBER_OF_WEEKS * MAX_HOURS_PER_WEEK))
                            {
                                timeWorked += 8;
                            }
                            break;
                        case 3:
                            Console.WriteLine("PAID VACATION : 8 Hr");
                            if (timeWorked < (NUMBER_OF_WEEKS * MAX_HOURS_PER_WEEK))
                            {
                                timeWorked += 8;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid day type, try again.");
                            goto MakeChoice;
                    }


                }
            }
            return timeWorked;
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
    }
}
