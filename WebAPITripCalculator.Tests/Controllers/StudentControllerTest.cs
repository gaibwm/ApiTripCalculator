using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPITripCalculator;
using WebAPITripCalculator.api;
using TripCalculator;

namespace WebAPITripCalculator.Tests.Controllers
{
    [TestClass]
    public class StudentControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            StudentController controller = new StudentController();

            // Act
            IEnumerable<Student> result = controller.GetStudents();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            StudentController controller = new StudentController();
            // Act
            List<string> result = controller.GetStudent("0");

            // Assert
            Assert.AreEqual("value", result[0]);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            StudentController controller = new StudentController();

            // Act
            IEnumerable<Student> result = controller.PostStudent(new Expense { ID = "0", Amount = 10.0, StudentID = "1" });

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }

        
    }
}
