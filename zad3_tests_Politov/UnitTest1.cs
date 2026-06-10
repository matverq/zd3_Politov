using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using zad3_Politov;

namespace zad3_tests_Politov
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class FoodManagerTests
        {
            [TestMethod]
            //Тестирование через передачу объекта
            public void Add1()
            {
                FoodManager manager = new FoodManager();
                Food food = new Food("Яблоко", 0.4, 9.8, 0.4, "Фрукты");
                manager.Add(food);
                Assert.AreEqual(1, manager.FoodList.Count);
                Assert.AreEqual("Яблоко", manager.FoodList[0].Name);
            }

            [TestMethod]
            //Тестирование через передачу полей
            public void Add2()
            {
                FoodManager manager = new FoodManager();
                manager.Add("Творог", 18.0, 3.0, 5.0, "Молочные продукты");

                Assert.AreEqual(1, manager.FoodList.Count);
                Assert.AreEqual("Творог", manager.FoodList[0].Name);
                Assert.AreEqual(18.0, manager.FoodList[0].Belok);
            }

            [TestMethod]
            //Тестирование корректности удаления элемента по индексу
            public void Remove1()
            {
                FoodManager manager = new FoodManager();
                Food food1 = new Food("Яблоко", 0.4, 9.8, 0.4, "Фрукты");
                Food food2 = new Food("Курица", 20.0, 0.0, 2.0, "Мясо");
                manager.Add(food1);
                manager.Add(food2);
                manager.Remove(0);
                Assert.AreEqual(1, manager.FoodList.Count);
                Assert.AreEqual("Курица", manager.FoodList[0].Name);
            }

            [TestMethod]
            //Тестирование корректности удаление элемента по названию
            public void Remove2()
            {
                FoodManager manager = new FoodManager();
                Food food = new Food("Курица", 20.0, 0.0, 2.0, "Мясо");
                manager.Add(food);
                manager.Remove("курица");
                Assert.AreEqual(0, manager.FoodList.Count);
            }
        }
    }
}
