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
        public readonly int NumberOfWeeks;
        public readonly int MaxHoursPerWeek;
        private enum DayType { Regular, Sick, Vacation }
        private enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }
        private int _total;
        private int[] _log;

        public TimesheetGenerator()
        {
            _total = 0;
            NumberOfWeeks = 2;
            MaxHoursPerWeek = 40;
            _log = new int[NumberOfWeeks * 7];
        }

        public TimesheetGenerator(int Weeks)
        {
            _total = 0;
            NumberOfWeeks = Weeks;
            MaxHoursPerWeek = 40;
            _log = new int[NumberOfWeeks * 7];
        }

        public TimesheetGenerator(int Weeks, int hours)
        {
            _total = 0;
            NumberOfWeeks = Weeks;
            MaxHoursPerWeek = hours;
            _log = new int[NumberOfWeeks * 7];
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
<<<<<<< HEAD
            Boolean inputValidated = false;
            if(userInput < 24 && userInput > 0)
            {
                inputValidated = true;
            }
            return inputValidated;
=======
            //Boolean inputValidated = true;
            //if(userInput > 24 || userInput < 0)
            //{                                             //all of this
            //    inputValidated = false;
            //}
            //return inputValidated;
            return (userInput <= 24 && userInput >= 0);     //can be simplified to one line. :)
>>>>>>> 163daeb8b40ebbadfd666f6a64ed6b158bd5b1a3
        }
    }
}
