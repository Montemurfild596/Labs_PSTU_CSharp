using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11
{
    public class MilkProduct : Product
    {
        #region Поля

        private static readonly string[] names = { "Молоко", "Кефир", "Творог", "Йогурт", "Сметана", "Сыр", "Сырок", "Ряженка" };

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

        public MilkProduct()
        {
            this.RandomInit();
        }

        public MilkProduct(int weight, int cost, int time, string name) : base(weight, cost, time)
        {
            this.Name = name;
        }

        public MilkProduct(MilkProduct temp)
        {
            this.Weight = temp.Weight;
            this.Cost = temp.Cost;
            this.ShelfLife = temp.ShelfLife;
            this.Name = temp.Name;
        }

        #endregion

        #region Методы

        public override void RandomInit()
        {
            this.Weight = rnd.Next(MIN_WEIGHT, MAX_WEIGHT) * 50;
            this.Cost = rnd.Next(MIN_VALUE, MAX_VALUE);
            this.ShelfLife = rnd.Next(MIN_SHELFLIFE, MAX_SHELFLIFE);
            this.Name = names[rnd.Next(0, names.Length)];
        }

        public override string ToString()
        {
            return $"MilkProduct({Weight} {Cost} {ShelfLife} {Name})";
        }

        public new string NoVirtualToString()
        {
            return $"MilkProduct({Weight} {Cost} {ShelfLife} {Name})";
        }

        public override object Clone()
        {
            return new MilkProduct(this.Weight, this.Cost, this.ShelfLife, this.Name);
        }

        #endregion
    }
}
