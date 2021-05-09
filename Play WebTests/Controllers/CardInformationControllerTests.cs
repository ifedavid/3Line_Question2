using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Play_Web.Controllers.Tests
{
    [TestClass()]
    public class WeatherForecastControllerTests
    {
        CardInformationController controller = new CardInformationController();
        AuthenticationData authentData = new AuthenticationData
        {
            AppKey = "test_20191123132233",
            TimeStamp = "1617953042",
            Authorization = "3line 4n+F7tDHDaFCoPkDDCtHMX6fvNIolyzMLFONT5c4XSYBg7VYFg1uMDYW7b3wDOs+rKL4QjaY2A100Jufsg1XFA=="
        };


        [TestMethod()]
        public void VerifyCardTest_WithCorrectData_ToExpectStatusCode200()
        {
            //Arrange

            //Act
            var result = controller.VerifyCard(authentData, "2234");
            var smth = result.Result as OkObjectResult;


            //Test
            Assert.IsNotNull(smth);
            Assert.AreEqual(200, smth.StatusCode);

        }

        [TestMethod()]
        public void VerifyCardTest_WithInCorrectData_ToExpectNotFound()
        {
            //Arrange


            //Act
            var result = controller.VerifyCard(authentData, "2164434");
            var smth = result.Result as NotFoundObjectResult;


            //Test
            Assert.IsNotNull(smth);
            Assert.AreEqual(404, smth.StatusCode);

        }

        [TestMethod()]
        public void VerifyCardTest_WithInCorrectData_ToExpectBadRequest()
        {
            //Arrange


            //Act
            var result = controller.VerifyCard(authentData, null);
            var smth = result.Result as BadRequestObjectResult;


            //Test
            Assert.IsNotNull(smth);
            Assert.AreEqual(400, smth.StatusCode);

        }


        [TestMethod()]
        public void HitCountTest_WithCorrectData_ToExpectOkResult()
        {
            //Arrange


            //Act
            var result = controller.HitCounts(authentData, 3, 3);
            var smth = result.Result as OkObjectResult;


            //Test
            Assert.IsNotNull(smth);
            Assert.AreEqual(200, smth.StatusCode);

        }


        [TestMethod()]
        public void HitCountTest_WithInCorrectData_ToExpectBadRequest()
        {
            //Arrange


            //Act
            var result = controller.HitCounts(authentData, 7, 3);
            var smth = result.Result as BadRequestObjectResult;


            //Test
            Assert.IsNotNull(smth);
            Assert.AreEqual(400, smth.StatusCode);

        }
    }
}