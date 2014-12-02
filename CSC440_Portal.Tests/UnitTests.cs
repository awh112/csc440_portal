using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSC440_Project.Controllers;
using CSC440_Project.Modules;
using System.Linq;

namespace CSC440_Portal.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestSyncOfODCData()
        {
            var adminController = new AdminController();
            var context = new AppDbContext();

            adminController.SyncCincyData();

            Assert.IsNotNull(context.DetailedOccupations);
            Assert.IsNotNull(context.OccupationalGroups);
        }

        [TestMethod]
        public void TestSyncOfBLSData()
        {
            var adminController = new AdminController();
            var context = new AppDbContext();

            adminController.SyncBLSData();

            var group = context.OccupationalGroups.FirstOrDefault();

            Assert.IsNotNull(group.BLSCurrent);
            Assert.IsNotNull(group.BLSFuture);
            Assert.IsNotNull(group.BLSMedianWage);
            Assert.IsNotNull(group.BLSNumChange);
            Assert.IsNotNull(group.BLSPercentChange);
        }
    }
}
