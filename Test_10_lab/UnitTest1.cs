using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Lab_10;
namespace Test_10_lab
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //Тесты для класса Item
        public void TestItemEqual1()
        {
            Item p = new Item(50, 50);
            Item p1 = new Item();

            Assert.AreNotEqual(p, p1);
        }
        [TestMethod]
        public void TestItemEqual2()
        {
            Item p = new Item(50, 50);
            Item p1 = new Item(p);
            Assert.AreEqual(p, p1);
        }
        [TestMethod]
        public void TestItemEqual3()
        {
            Item p = new Item(50, 50);
            Item p1 = (Item)p.Clone();
            Assert.AreEqual(p, p1);
        }
        [TestMethod]
        public void TestItemEqual4()
        {
            Item p = new Item(50, 50);
            int p1 = 4;
            Assert.AreNotEqual(p, p1);
        }
        [TestMethod]
        public void TestItemIsInstanseOfType1()
        {
            Item p = new Item(50, 50);
            Item p1 = new Item();
            Assert.IsInstanceOfType(p, typeof(Item));
        }
        [TestMethod]
        public void TestItemIsInstanseOfType2()
        {
            Item p = new Item(50, 50);
            Item p1 = new Item();
            Assert.IsInstanceOfType(p.ToString(), typeof(string));
        }
        [TestMethod]
        public void TestItemIsInstanseOfType3()
        {
            Item p = new Item(50, 50);
            Item p1 = new Item();
            Assert.IsInstanceOfType(p.NoVirtualToString(), typeof(string));
        }
        [TestMethod]
        public void TestItemClone1()
        {
            Item p = new Item(50, 50);
            Assert.AreNotSame(p, p.Clone());
        }
        [TestMethod]
        public void TestItemClone2()
        {
            Item p = new Item(50, 50);
            Assert.AreEqual(p, p.Clone());
        }
        [TestMethod]
        //Тесты для класса Item
        public void TestProductEqual1()
        {
            Product p = new Product(50, 50, 5);
            Product p1 = new Product();

            Assert.AreNotEqual(p, p1);
        }
        [TestMethod]
        public void TestProductEqual2()
        {
            Product p = new Product(50, 50, 5);
            Product p1 = new Product(p);
            Assert.AreEqual(p, p1);
        }
        [TestMethod]
        public void TestProductEqual3()
        {
            Product p = new Product(50, 50, 5);
            Product p1 = (Product)p.Clone();
            Assert.AreEqual(p, p1);
        }
        [TestMethod]
        public void TestProductEqual4()
        {
            Product p = new Product(50, 50, 5);
            int p1 = 4;
            Assert.AreNotEqual(p, p1);
        }
        [TestMethod]
        public void TestProductIsInstanseOfType1()
        {
            Product p = new Product(50, 50, 5);
            Product p1 = new Product();
            Assert.IsInstanceOfType(p, typeof(Product));
        }
        [TestMethod]
        public void TestProductIsInstanseOfType2()
        {
            Product p = new Product(50, 50, 5);
            Product p1 = new Product();
            Assert.IsInstanceOfType(p.ToString(), typeof(string));
        }
        [TestMethod]
        public void TestProductIsInstanseOfType3()
        {
            Product p = new Product(50, 50, 5);
            Product p1 = new Product();
            Assert.IsInstanceOfType(p.NoVirtualToString(), typeof(string));
        }
        [TestMethod]
        public void TestProductClone1()
        {
            Product p = new Product(50, 50, 5);
            Assert.AreNotSame(p, p.Clone());
        }
        [TestMethod]
        public void TestProductClone2()
        {
            Product p = new Product(50, 50, 5);
            Assert.AreEqual(p, p.Clone());
        }

        [TestMethod]
        //Тесты для класса Item
        public void TestMilkProductEqual1()
        {
            MilkProduct p = new MilkProduct(50, 50, 5, "Молоко");
            MilkProduct p1 = new MilkProduct();

            Assert.AreNotEqual(p, p1);
        }
        [TestMethod]
        public void TestMilkProductEqual2()
        {
            MilkProduct p = new MilkProduct(50, 50, 5, "Молоко");
            MilkProduct p1 = new MilkProduct(p);
            Assert.AreEqual(p, p1);
        }
        [TestMethod]
        public void TestMilkProductEqual3()
        {
            MilkProduct p = new MilkProduct(50, 50, 5, "Молоко");
            MilkProduct p1 = (MilkProduct)p.Clone();
            Assert.AreEqual(p, p1);
        }
        [TestMethod]
        public void TestMilkProductEqual4()
        {
            MilkProduct p = new MilkProduct(50, 50, 5, "Молоко");
            int p1 = 4;
            Assert.AreNotEqual(p, p1);
        }
        [TestMethod]
        public void TestMilkProductIsInstanseOfType1()
        {
            MilkProduct p = new MilkProduct(50, 50, 5, "Молоко");
            MilkProduct p1 = new MilkProduct();
            Assert.IsInstanceOfType(p, typeof(MilkProduct));
        }
        [TestMethod]
        public void TestMilkProductIsInstanseOfType2()
        {
            MilkProduct p = new MilkProduct(50, 50, 5, "Молоко");
            MilkProduct p1 = new MilkProduct();
            Assert.IsInstanceOfType(p.ToString(), typeof(string));
        }
        [TestMethod]
        public void TestMilkProductIsInstanseOfType3()
        {
            MilkProduct p = new MilkProduct(50, 50, 5, "Молоко");
            MilkProduct p1 = new MilkProduct();
            Assert.IsInstanceOfType(p.NoVirtualToString(), typeof(string));
        }
        [TestMethod]
        public void TestMilkProductClone1()
        {
            MilkProduct p = new MilkProduct(50, 50, 5, "Молоко");
            Assert.AreNotSame(p, p.Clone());
        }
        [TestMethod]
        public void TestMilkProductClone2()
        {
            MilkProduct p = new MilkProduct(50, 50, 5, "Молоко");
            Assert.AreEqual(p, p.Clone());
        }

        [TestMethod]
        public void TestToyEqual1()
        {
            Toy p = new Toy(50, 50, "Солдатик");
            Toy p1 = new Toy();

            Assert.AreNotEqual(p, p1);
        }
        
        [TestMethod]
        public void TestToyEqual3()
        {
            Toy p = new Toy(50, 50, "Солдатик");
            Toy p1 = (Toy)p.Clone();
            Assert.AreEqual(p, p1);
        }
        [TestMethod]
        public void TestToyEqual4()
        {
            Toy p = new Toy(50, 50, "Солдатик");
            int p1 = 4;
            Assert.AreNotEqual(p, p1);
        }
        [TestMethod]
        public void TestToyIsInstanseOfType1()
        {
            Toy p = new Toy(50, 50, "Солдатик");
            Toy p1 = new Toy();
            Assert.IsInstanceOfType(p, typeof(Toy));
        }
        [TestMethod]
        public void TestToyIsInstanseOfType2()
        {
            Toy p = new Toy(50, 50, "Солдатик");
            Toy p1 = new Toy();
            Assert.IsInstanceOfType(p.ToString(), typeof(string));
        }
        [TestMethod]
        public void TestToyIsInstanseOfType3()
        {
            Toy p = new Toy(50, 50, "Солдатик");
            Toy p1 = new Toy();
            Assert.IsInstanceOfType(p.NoVirtualToString(), typeof(string));
        }
        [TestMethod]
        public void TestToyClone1()
        {
            Toy p = new Toy(50, 50, "Солдатик");
            Assert.AreNotSame(p, p.Clone());
        }

        [TestMethod]
        public void TestToyClone2()
        {
            Toy p = new Toy(50, 50, "Солдатик");
            Assert.AreEqual(p, p.Clone());
        }

        [TestMethod]
        public void TestMagazineIsInstanseOfType1()
        {
            Magazine p = new Magazine();
            Assert.IsInstanceOfType(p, typeof(Magazine));
        }
        [TestMethod]
        public void TestMagazineIsInstanseOfType2()
        {
            Magazine p = new Magazine();
            Magazine p1 = (Magazine)p.Clone();
            Assert.IsInstanceOfType(p1, typeof(Magazine));
        }
        [TestMethod]
        public void TestMagazineIsInstanseOfType3()
        {
            Magazine p = new Magazine();
            Assert.IsInstanceOfType(p.ToString(), typeof(string));
        }
        [TestMethod]
        public void TestMagazineIsInstanseOfType4()
        {
            Magazine p = new Magazine();
            Assert.IsInstanceOfType(p.ShallowCopy(), typeof(Magazine));
        }
        //[TestMethod]
        ////Тесты для класса Product
        //public void ProductTest()
        //{
        //    Product em = new Product();
        //    Product em1 = new Product("Денис", "Мельников", "Вячеславович", 1500, 15);
        //    Product em_clone = (Product)em.Clone();

        //    //проверка соответствия типам данных
        //    Assert.IsInstanceOfType(em, typeof(Item));
        //    Assert.IsInstanceOfType(em1, typeof(Item));
        //    Assert.IsInstanceOfType(em.ToString(), typeof(string));
        //    //проверка правильности глубокого клонирования
        //    Assert.AreNotSame(em, em_clone);
        //    Assert.AreEqual(em, em_clone);
        //}
        //[TestMethod]
        ////Тесты для класса MilkProduct
        //public void MilkProductTest()
        //{
        //    MilkProduct ad = new MilkProduct("Денис", "Мельников", "Вячеславович", 1500, 15, "Отдел продаж");
        //    MilkProduct ad1 = new MilkProduct();
        //    MilkProduct ad_clone = (MilkProduct)ad.Clone();
        //    //проверка соответствия типам данных
        //    Assert.IsInstanceOfType(ad, typeof(Item));
        //    Assert.IsInstanceOfType(ad1, typeof(Item));
        //    Assert.IsInstanceOfType(ad.ToString(), typeof(string));
        //    //проверка правильности глубокого клонирования
        //    Assert.AreNotSame(ad, ad_clone);
        //    Assert.AreEqual(ad, ad_clone);
        //}
        //[TestMethod]
        ////Тесты для класса Toy
        //public void ToyTest()
        //{
        //    Toy eng = new Toy("Денис", "Мельников", "Вячеславович", 1500, 15, "Отдел продаж");
        //    Toy eng1 = new Toy();
        //    Toy eng_clone = (Toy)eng.Clone();
        //    //проверка соответствия типам данных
        //    Assert.IsInstanceOfType(eng, typeof(Item));
        //    Assert.IsInstanceOfType(eng1, typeof(Item));
        //    Assert.IsInstanceOfType(eng.ToString(), typeof(string));
        //    //проверка правильности глубокого клонирования
        //    Assert.AreNotSame(eng, eng_clone);
        //    Assert.AreEqual(eng, eng_clone);
        //}
        //[TestMethod]
        ////Тесты для класса Magazine
        //public void MagazineTest()
        //{
        //    Magazine c = new Magazine();
        //    Magazine c_deep_clone = (Magazine)c.Clone();
        //    Magazine c_memberwise_clone = c.ShallowCopy();
        //    //првоерка соответсвия типам
        //    Assert.IsInstanceOfType(c.getAdminWithDepartment("Отдел продаж"), typeof(List<Item>));
        //    Assert.IsInstanceOfType(c.getEmpWithMoreThanYearsOfExp(5), typeof(List<Item>));
        //    Assert.IsInstanceOfType(c.getToyWithSpeciality("Инженер-технолог"), typeof(List<Item>));
        //    Assert.IsInstanceOfType(c.ToString(), typeof(string));
        //    //проверка правильности глубокого и поверхностного копирования
        //    Assert.AreNotSame(c, c_deep_clone);
        //    Assert.AreNotSame(c, c_memberwise_clone);
        //    Assert.AreNotSame(c.Items, c_deep_clone.Items);
        //    Assert.AreSame(c.Items, c_memberwise_clone.Items);
        //}
    }
}