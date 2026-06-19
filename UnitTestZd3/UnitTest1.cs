using Microsoft.VisualStudio.TestTools.UnitTesting;
using zd3_PavlovMaksim;
using System;

namespace UnitTestZd3
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void ProvKachBazCl()
        {
           
            RoadWork road = new RoadWork("Тест", 10, 20, 500, "Асфальт", 2020);

        
            double result = road.Quality();

            Assert.AreEqual(100, result, 0.001, "Ошибка: неправильный расчет Q");
        }

       
        [TestMethod]
        public void ProvKachPotP5()
        {
            
            ChildRoadWork road = new ChildRoadWork("Тест", 10, 20, 500, "Асфальт", 2020, 5, "Солнце");

    
            double result = road.Quality();

            Assert.AreEqual(110, result, 0.001, "Ошибка: неправильный расчет Qp для P=5");
        }

      
        [TestMethod]
        public void ProvKachPotP3()
        {
     
            ChildRoadWork road = new ChildRoadWork("Тест", 10, 20, 500, "Асфальт", 2020, 3, "Дождь");

   
            double result = road.Quality();

            Assert.AreEqual(160, result, 0.001, "Ошибочка: неправильный расчет Qp для P=3");
        }

     
        [TestMethod]
        public void ProvKachPotP2()
        {
          
            ChildRoadWork road = new ChildRoadWork("Тест", 10, 20, 500, "Асфальт", 2020, 2, "Снег");

        
            double result = road.Quality();

            Assert.AreEqual(190, result, 0.001, "Ошибка: неправильный расчет Qp для P=2");
        }

        
        [TestMethod]
        public void ProvKonstrBazCl()
        {
           
            RoadWork road = new RoadWork("М-5", 15.5, 25.5, 600, "Бетон", 2021);

          
            Assert.AreEqual("М-5", road.Name, "Ошибка: неправильное имя");
            Assert.AreEqual(15.5, road.Width, 0.001, "Ошибка: неправильная ширина");
            Assert.AreEqual(25.5, road.Length, 0.001, "Ошибка: неправильная длина");
            Assert.AreEqual(600, road.MassPerSqM, 0.001, "Ошибка: неправильная масса");
            Assert.AreEqual("Бетон", road.SurfaceType, "Ошибка: неправильный тип покрытия");
            Assert.AreEqual(2021, road.Year, "Ошибка: неправильный год");
        }

       
        [TestMethod]
        public void ProvKonstrPot()
        {
            
            ChildRoadWork road = new ChildRoadWork("М-5", 15.5, 25.5, 600, "Бетон", 2021, 7, "Облачно");

            Assert.AreEqual(7, road.P, "Ошибка: неправильный P");
            Assert.AreEqual("Облачно", road.Weather, "Ошибка: неправильная погода");
        }

       
        [TestMethod]
        public void ProvMetodGetInfoBaz()
        {
            RoadWork road = new RoadWork("Дорога", 10, 20, 500, "Асфальт", 2020);

            string info = road.GetInfo();

            Assert.IsTrue(info.Contains("Дорога"), "Ошибка: нет названия");
            Assert.IsTrue(info.Contains("10"), "Ошибка: нет ширины");
            Assert.IsTrue(info.Contains("20"), "Ошибка: нет длины");
            Assert.IsTrue(info.Contains("500"), "Ошибка: нет массы");
            Assert.IsTrue(info.Contains("Q="), "Ошибка: нет качества");
       
        }
    }
}