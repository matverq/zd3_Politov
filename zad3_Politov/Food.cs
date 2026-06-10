using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3_Politov
{
    public class Food
    {
        public string Name;
        public double Belok;
        public double Ugl;

        public double Fats { get; set; }
        public string Kat { get; set; }
        //Конструктор
        public Food(string name, double belok, double ugl, double fats,string kat)
        {
            Name = name;
            Belok = belok;
            Ugl = ugl;
            Fats = fats;
            Kat = kat;
        }
        //Расчет качества
        public virtual double Q()
        {
            return Ugl * 4 + Belok * 4;
        }
        //Вывод информации
        public virtual string GetInfo()
        {
            return $"{Name} {Kat}, Белки: {Belok}, Жиры: {Fats}, Углеводы: {Ugl}, Качество: {Q():F2}";
        }
    }
}