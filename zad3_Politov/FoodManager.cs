using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3_Politov
{
    public class FoodManager
    {
        public List<Food> FoodList { get; private set; } = new List<Food>();
        public Dictionary<int, Food> FoodDict { get; private set; } = new Dictionary<int, Food>();
        private int idC = 1;
        //Добавление готового объекта
        public void Add(Food item)
        {
            FoodList.Add(item);
            FoodDict.Add(idC++, item);
        }
        //Создание объекта
        public void Add(string name, double belok, double ugl, double fats, string kat)
        {
            var newItem = new Food(name, belok, ugl, fats, kat);
            Add(newItem);
        }
        //Удаление продукта по номеру(индексу)
        public void Remove(int index)
        {
            if(index >= 0 && index < FoodList.Count)
            {
                Food item = FoodList[index];
                FoodList.RemoveAt(index);
                var key = FoodDict.FirstOrDefault(c => c.Value == item).Key;
                if (key != 0) FoodDict.Remove(key);
            }
        }
        //Удаление продукта по названию
        public void Remove(string name)
        {
            Food item = FoodList.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if(item != null)
            {
                FoodList.Remove(item);
                int key = FoodDict.FirstOrDefault(c => c.Value == item).Key;
                if (key != 0) FoodDict.Remove(key);
            }
        }
        public List<string> Filter()
        {
            return FoodList
                .Where(c => c.Belok > 15)
                .Select(c => c.GetInfo())
                .ToList();
        }
        //Вычисление среднего значение качества среди всех продуктов
        public double GetAvgQ()
        {
            if (FoodList.Count == 0) return 0;
            return FoodList.Average(c => c.Q());
        }
    }
}