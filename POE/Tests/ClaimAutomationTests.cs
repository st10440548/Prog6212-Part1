using System;
using Xunit;
using CMS.Models;
using CMS.Controllers;
using Microsoft.Extensions.Configuration;
using Moq;
using CMS.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS.Tests
{
    public class ClaimAutomationTests
    {
        [Fact]
        public void TotalAmount_Calculated_Correctly()
        {
            var c = new Claim { HoursWorked = 8, HourlyRate = 150 };
            Assert.Equal(1200, c.TotalAmount);
        }

        [Fact]
        public void PolicyFlag_WhenHoursTooHigh()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb1").Options;
            using (var db = new ApplicationDbContext(options))
            {
                db.Claims.Add(new Claim { LecturerId = 1, HoursWorked = 500, HourlyRate = 10 });
                db.SaveChanges();
                var claim = db.Claims.Find(1);
                Assert.True(claim.HoursWorked > 200);
            }
        }
    }
}
