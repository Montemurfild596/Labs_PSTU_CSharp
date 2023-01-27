using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    public class Toy : Item
    {
        #region Поля

        private static readonly string[] names = { "Машинка", "Солдатик", "Белочка", "Лошадка", "Кукла", "Кошка", "Рогатка", "Вертолёт" };

        private string name;

        #endregion

        #region Свойства

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        #endregion

        #region Конструкторы

        public Toy()
        {
            this.RandomInit();
        }

        public Toy(int weight, int cost, string name) : base(weight, cost)
        {
            this.Name = name;
        }

        public Toy(MilkProduct temp)
        {
            this.Weight = temp.Weight;
            this.Cost = temp.Cost;
            this.Name = temp.Name;
        }

        #endregion

        #region Методы

        public override void RandomInit()
        {
            this.Weight = rnd.Next(MIN_WEIGHT, MAX_WEIGHT) * 50;
            this.Cost = rnd.Next(MIN_VALUE, MAX_VALUE);
            this.Name = names[rnd.Next(0, names.Length)];
        }

        public override string ToString()
        {
            return $"Toy({Weight} {Cost} {Name})";
        }

        public new string NoVirtualToString()
        {
            return $"Toy({Weight} {Cost} {Name})";
        }

        public override object Clone()
        {
            return new Toy(this.Weight, this.Cost, this.Name);
        }

        #endregion
    }
}
