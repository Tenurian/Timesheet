using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timesheet
{
    class Program
    {
        public static int N_WEEKS = 2;
        public static int WEEK_HOURS = 40;
        private enum DayType { Regular, Sick, Vacation }
        private enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }
        private String name;
        private int total, overtime;
        //private int weekNumber = 1;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.start();
        }

        public Program()
        {
            name = "";
            total = 0;
            overtime = 0;
        }

        private void start()
        {
            Console.WriteLine("Please Enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine("Welcome, {0}", name);

            total = CalculateTotalTimeWorked();
            Console.WriteLine("Total hours worked: {0}", total);

            overtime = CalculateOvertime(total);
            Console.WriteLine("You had {0} hours of overtime.", overtime);

        }

        private int CalculateTotalTimeWorked()
        {
            int timeWorked = 0;
            for (int week = 1; week <= N_WEEKS; week++)
            {
                foreach (Day day in Enum.GetValues(typeof(Day)))
                {
                choice:
                    Console.WriteLine("What type of day was {1} of week {0}?\n1) Regular\n2) Sick\n3) Vacation", week, day);
                    int choice = Int32.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("How many hours did you work on {1} of week {0}?", week, day);
                            timeWorked += Int32.Parse(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("SICK DAY : 8 Hr");
                            timeWorked += 8;
                            break;
                        case 3:
                            Console.WriteLine("PAID VACATION : 8 Hr");
                            timeWorked += 8;
                            break;
                        default:
                            Console.WriteLine("Invalid day type, try again.");
                            goto choice;
                    }


                }
            }
            return timeWorked;
        }

        private int CalculateOvertime(int worked)
        {
            if(worked > (N_WEEKS * WEEK_HOURS))
            {
                return worked - (N_WEEKS * WEEK_HOURS);
            }
            else
            {
                return 0;
            }
        }
    }
}
