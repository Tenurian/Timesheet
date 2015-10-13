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
        public void TimesheetGeneratorTest()
        {
            //aaa (Arrange Act Assert)
            //Arrange
            TimesheetGenerator tg1 = new TimesheetGenerator();      //DEFAULT 2 weeks, 40 Hours max
            TimesheetGenerator tg2 = new TimesheetGenerator(1);     //1 week, default max
            TimesheetGenerator tg3 = new TimesheetGenerator(1, 36);  //1 week, 36 hours max
            //Act
            //Assert
            Assert.Fail();
        }
    }
}