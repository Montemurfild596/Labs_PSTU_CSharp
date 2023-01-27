using LabClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Lab_12
{
	
	public class DeList
	{
		public class Node
		{
			private Item data;
			private Node? prev, next;
			public Item Data
			{
				get => data;
				set => data = value;
			}
			public Node? Prev
			{
				get => prev;
				set => prev = value;
			}
			public Node? Next
			{
				get => next;
				set => next = value;
			}

			public Node()
			{
				Data = new Item();
				Prev = null;
				Next = null;
			}
			public Node(Item data)
			{
				Data = data;
				Prev = null;
				Next = null;
			}
			public override string ToString()
			{
				return Data.ToString();
			}
		}
		
		private Node? begin = null, end = null;
		private int count = 0;
		public Node Begin
		{
			get => begin;
			set => begin = value;
		}
		public Node End
		{
			get => end;
			set => end = value;
		}
		public int Count
		{
			get => count;
			private set => count = value;
		}

		public DeList()
		{
			Begin = null;
			End = null;
		}
		public DeList(Item temp)
		{
			Node node = new Node(temp);
			Begin = node.Prev!;
			End = node.Next!;
		}
		public DeList(int size)
		{
			if (size <= 0)
			{
				Console.WriteLine("Ёмкость неположительная; создаётся пустой список");
				Begin = null;
				End = null;
			}
			else
			{
				Random rnd = new Random();
				for (int i = 0; i < size; ++i)
				{
					Add();
				}
			}
		}
		static public Item RandomItem()
		{
			Random rnd = new Random();
			Item item = new Item();
			switch (rnd.Next(0, 4))
			{
				case 0:
					item =  new Item();
					break;
				case 1:
					item = new Product();
					break;
				case 2:
					item = new Toy();
					break;
				case 3:
					item = new MilkProduct();
					break;
			}
			return item;
		}

        public void Add()
        {
            Node temp = new Node(RandomItem());
            if (Begin == null)
            {
                Begin = temp;
                End = temp;
            }
            else
            {
                End.Next = temp;
                temp.Prev = End;
                End = temp;
            }
            ++Count;
        }

        public void Add(Item item)
		{
			Node temp = new Node(item);
			if (Begin == null)
			{
				Begin = temp;
				End = temp;
			}
			else
			{
				End.Next = temp;
				temp.Prev = End;
				End = temp;
			}
			++Count;
		}

        public bool Contains(Item item)
        {
            Node node = Begin;
            while (node != null)
            {
                if (node.Data == item)
                {
                    return true;
                }
                node = node.Next!;
            }
            return false;
        }

        public void Insert(int index, Item item)
		{
			if (index < 0 && index > Count)
			{
                throw new ArgumentOutOfRangeException("Невозможно обратиться к заданному индексу");
            }
			Node temp = new Node(item);
			if (index == Count && Begin == null)
			{
				Add(item);
				return;
			}
			if (index == 0)
			{
				Begin.Prev = temp;
				temp.Next = Begin;
				Begin = temp;
				return;
			}
			Node node = Begin;
			for (int i = 0; i < index && node != null; ++i)
			{
				node = node.Next;
			}
			Node node1 = node.Prev;
			node1.Next = temp;
			temp.Prev = node1;
			temp.Next = node;
			node.Prev = temp;
			++Count;
		}

		public int IndexOf(Item item)
		{
			int index = -1;
			Node node = Begin;
			for (int i = 0; node != null && index == -1; ++i) {
				if (node.Data == item)
				{
					index = i;
				}
				node = node.Next!;
			}
			return index;
		}

		public int LastIndexOf(Item item)
		{
			int index = -1;
			Node node = Begin;
			for (int i = 0; node != null; ++i)
			{
				if (node.Data == item)
				{
					index = i;
				}
				node = node.Next!;
			}
			return index;
		}

		public bool Remove(Item item)
		{
			if (!Contains(item))
			{
				return false;
			}
			bool isDeleted = false;
			Node node = Begin;
			for (int i = 0; !isDeleted; ++i)
			{
				if (node.Data == item)
				{
					isDeleted = true;
					node.Prev.Next = node.Next;
					node.Next.Prev = node.Prev;
				}
			}
			return isDeleted;
		}
		
		public void Print() 
		{
			Node node = Begin;
			if (node == null)
			{
				Console.WriteLine("Список пуст");
			}
			else
			{
				while (node != null)
				{
					Console.WriteLine(node.ToString());
					node = node.Next!;
				}
			}
		}
	}
}
