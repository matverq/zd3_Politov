using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3_Politov
{
    public class DetailFood : Food
    {
        public double Calories;
        public bool IsHealth { get; set; }
        public string Firm { get; set; }
        public DetailFood(string name, double belok, double ugl, double fats, string kat, double calories, string firm) 
            : base(name, belok, ugl, fats, kat)
        {
            Calories = calories;
            Firm = firm;
            IsHealth = calories < 200;
        }
        //Расчет качества с учетом калорий
        public override double Q()
        {
            double qBase = base.Q();
            return qBase * 1.2 + Calories * 7;
        }
        //Вывод информации
        public override string GetInfo()
        {
            string healthStatus = IsHealth ? "Полезный" : "Тяжелый продукт";
            return $"{Name} ({Kat}), Белки: {Belok}г, Жиры: {Fats}г, Углеводы: {Ugl}г, Калорийность P: {Calories}, Производитель: {Firm} ({healthStatus}), Качество Qp: {Q():F2}";
        }
    }
}
