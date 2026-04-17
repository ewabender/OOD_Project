using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OOD_Project;

namespace BirdTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateBird()
        {
            Bird bird = new Bird();
            //Test
            bird.userBird = true;
            bird.sciName = "Testicus Unitus";
            bird.comName = "Test Birb";
            bird.howMany = 1;
            bird.locName = " Tesco";
            //Setup

            //Assert
            Assert.IsNotNull(bird);

        }
    }
}
