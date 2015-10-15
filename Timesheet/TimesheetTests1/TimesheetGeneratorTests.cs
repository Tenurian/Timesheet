using Microsoft.VisualStudio.TestTools.UnitTesting;
using Timesheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timesheet.Tests
{
    [TestClass()]
    public class TimesheetGeneratorTests
    {
        [TestMethod()]
        public void CalculateOvertimeTestNone()
        {
            int hoursWorked = 35;
            int expected = 0;
            TimesheetGenerator tg = new TimesheetGenerator();
           int returnedValue = tg.CalculateOvertime(hoursWorked);
            Assert.AreEqual(returnedValue, expected);
        }
        [TestMethod()]
        public void CalculateOvertimeTestWith()
        {
            int hoursWorked = 90;
            int expected = 10;
            TimesheetGenerator tg = new TimesheetGenerator();
            int returnedValue = tg.CalculateOvertime(hoursWorked);
            Assert.AreEqual(returnedValue, expected);
        }
    }
}