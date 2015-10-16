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
<<<<<<< HEAD
           int returnedValue = tg.CalculateOvertime(hoursWorked);
=======
            int returnedValue = tg.CalculateOvertime(hoursWorked);
>>>>>>> 73e7ebf485b87767134061486b05bd2da4d923b9
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
        [TestMethod()]
        public void TimesheetGeneratorTest()
        {
<<<<<<< HEAD
=======
            //testing all constructors, 
            // X_1 = Exactly the max number hours worked
            // X_2 = 1 hour overtime
            // X_3 = 0 hours
>>>>>>> 73e7ebf485b87767134061486b05bd2da4d923b9
            //aaa (Arrange Act Assert)
            //Arrange
            TimesheetGenerator tg1 = new TimesheetGenerator();      //DEFAULT 2 weeks, 40 Hours max
            TimesheetGenerator tg2 = new TimesheetGenerator(1);     //1 week, default max
            TimesheetGenerator tg3 = new TimesheetGenerator(1, 36);  //1 week, 36 hours max
            //Act
<<<<<<< HEAD
            //Assert
            Assert.Fail();
=======
            int expected1_1 = 0;
            int expected1_2 = 1;
            int expected1_3 = 0;
            int actual1_1 = tg1.CalculateOvertime(80);
            int actual1_2 = tg1.CalculateOvertime(81);
            int actual1_3 = tg1.CalculateOvertime(0);


            int expected2_1 = 0;
            int expected2_2 = 1;
            int expected2_3 = 0;
            int actual2_1 = tg2.CalculateOvertime(40);
            int actual2_2 = tg2.CalculateOvertime(41);
            int actual2_3 = tg2.CalculateOvertime(0);


            int expected3_1 = 0;
            int expected3_2 = 1;
            int expected3_3 = 0;
            int actual3_1 = tg3.CalculateOvertime(36);
            int actual3_2 = tg3.CalculateOvertime(37);
            int actual3_3 = tg3.CalculateOvertime(0);
            //Assert
            Assert.AreEqual(expected1_1, actual1_1);
            Assert.AreEqual(expected1_2, actual1_2);
            Assert.AreEqual(expected1_3, actual1_3);


            Assert.AreEqual(expected2_1, actual2_1);
            Assert.AreEqual(expected2_2, actual2_2);
            Assert.AreEqual(expected2_3, actual2_3);


            Assert.AreEqual(expected3_1, actual3_1);
            Assert.AreEqual(expected3_2, actual3_2);
            Assert.AreEqual(expected3_3, actual3_3);
            //Assert.Fail();
>>>>>>> 73e7ebf485b87767134061486b05bd2da4d923b9
        }
    }
}