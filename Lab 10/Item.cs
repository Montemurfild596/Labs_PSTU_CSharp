using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
	public class Item : IRandomInit, IComparable<Item>, ICloneable
	{
		#region Поля

		protected static int MIN_WEIGHT = 1;
		protected static int MAX_WEIGHT = 50;
		protected static int MIN_VALUE = 50;
		protected static int MAX_VALUE = 5000;

		protected Random rnd = new Random();


        protected int weight;
		protected int cost;

		#endregion

		#region Свойства

		public int Weight
		{
			get { return weight; }
			protected set { weight = value; }
		}

		public int Cost
		{
			get { return cost; } 
			protected set { cost = value; }
		}

		#endregion

		#region Конструкторы

		public Item()
		{
			this.RandomInit();
		}

		public Item(int weight, int cost)
		{
			this.Weight = weight;
			this.Cost = cost;
		}

		public Item(Item temp)
		{
			this.Weight = temp.Weight;
			this.Cost = temp.Cost;
		}

		#endregion

		#region Методы

		public virtual void RandomInit()
		{
			this.Weight = rnd.Next(MIN_WEIGHT, MAX_WEIGHT) * 50;
			this.Cost = rnd.Next(MIN_VALUE, MAX_VALUE);
		}

		public override string ToString()
		{
			return $"Item({Weight} {Cost})";
		}

		public string NoVirtualToString()
		{
            return $"Item({Weight} {Cost})";
        }

		public int CompareTo(Item it)
		{
			return Cost - it.Cost;
		}

		public virtual object Clone()
		{
			return new Item(this.Weight, this.Cost);
		}

        public override bool Equals(object? obj)
        {
			if (obj is Item)
			{
                return ((Item)obj).Cost == this.Cost && ((Item)obj).Weight == this.Weight;
			}
            return obj is Item;
			//return (obj is Item && ((Item)obj).Cost == this.Cost && ((Item)obj).Weight == this.Weight);
        }

        #endregion
    }
}
