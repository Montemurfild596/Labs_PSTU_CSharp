using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11
{
    public class Product : Item
    {
        #region Поля

        protected int MIN_SHELFLIFE = 1;
        protected int MAX_SHELFLIFE = 20;
        protected int shelfLife;

        #endregion

        #region Свойства

        public int ShelfLife
        {
            get { return shelfLife; }
            set { shelfLife = value; }
        }

        public Item BaseItem
        {
            get
            {
                return new Item(Weight, Cost);
            }
        }

        #endregion

        #region Конструкторы

        public Product()
        {
            this.RandomInit();
        }

        public Product(int weight, int cost, int time) : base(weight, cost)
        {
            this.ShelfLife = time;
        }

        public Product(Product temp)
        {
            this.Weight = temp.Weight;
            this.Cost = temp.Cost;
            this.ShelfLife = temp.ShelfLife;
        }

        #endregion

        #region Методы

        public override void RandomInit()
        {
            this.Weight = rnd.Next(MIN_WEIGHT, MAX_WEIGHT) * 50;
            this.Cost = rnd.Next(MIN_VALUE, MAX_VALUE);
            this.ShelfLife = rnd.Next(MIN_SHELFLIFE, MAX_SHELFLIFE);
        }

        public override string ToString()
        {
            return $"Product({Weight} {Cost} {ShelfLife})";
        }

        public new string NoVirtualToString()
        {
            return $"Product({Weight} {Cost} {ShelfLife})";
        }

        public override object Clone()
        {
            return new Product(this.Weight, this.Cost, this.ShelfLife);
        }

        #endregion

    }
}
