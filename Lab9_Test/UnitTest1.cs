using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_9;

namespace Lab9_Test
{
	[TestClass]
	public class UnitTest1
	{
        #region Тесты класса Point

        [TestMethod]
		public void TestPointsAreNotEqual()
		{
			Point expectedPoint = new Point(23.4, 125.8);
			Point pointWithoutParams = new Point();
			Assert.AreNotEqual(pointWithoutParams, expectedPoint);
			Point point1 = new Point(3234, 4352.0);
			Assert.AreNotEqual(point1, expectedPoint);
			Point point2 = new Point(-123.4, 521.8);
			Assert.AreNotEqual(point2, expectedPoint);
			Point pointCopy1 = new Point(point1);
			Assert.AreNotEqual(pointCopy1, expectedPoint);
            double temp1 = 3254.5;
            Assert.IsFalse(expectedPoint.Equals(temp1));
        }

		[TestMethod]
		public void TestPointsAreEqual()
		{
			Point expectedPoint = new Point(23.4, 125.8);
			Point point1 = new Point(expectedPoint);
			Assert.AreEqual(expectedPoint, point1);
			Point point2 = new Point(point1.X, point1.Y);
			Assert.AreEqual(expectedPoint, point2);
		}

		[TestMethod]
		public void TestPointsCorrectOperatorIncrement()
		{
			Point expectedPoint = new Point(-24.9, 0.42);
			Point point1 = new Point(expectedPoint.X - 1, expectedPoint.Y - 1);
			expectedPoint--;
			Assert.AreEqual(expectedPoint, point1);
		}

		[TestMethod]
		public void TestPointsCorrectOperatorComparison()
		{
			Point expectedPoint = new Point(23.4, 125.8);
			Point point1 = new Point(expectedPoint);
			Assert.IsTrue(expectedPoint == point1);
			Point point2 = new Point();
			Assert.IsFalse(expectedPoint == point2);
		}

		[TestMethod]
		public void TestPointsCorrectOperatorNotComparison()
		{
            Point expectedPoint = new Point(23.4, 125.8);
            Point point1 = new Point(expectedPoint);
            Assert.IsFalse(expectedPoint != point1);
            Point point2 = new Point();
            Assert.IsTrue(expectedPoint != point2);
        }

		[TestMethod]
		public void TestPointCorrectOperatorSubstraction1()
		{
			Point expectedPoint = new Point(123.0, 256.5);
			expectedPoint = expectedPoint - 3;
			Point point1 = new Point(120.0, 256.5);
			Assert.IsTrue(expectedPoint == point1);
		}

		[TestMethod]
        public void TestPointCorrectOperatorSubstraction2()
        {
            Point expectedPoint = new Point(123.0, 256.5);
            expectedPoint = 3 - expectedPoint;
            Point point1 = new Point(123.0, 253.5);
            Assert.IsTrue(expectedPoint == point1);
        }

		[TestMethod]
        public void TestPointCorrectOperatorSubstraction3()
        {
            Point expectedPoint = new Point(123.0, 256.5);
            Point point1 = new Point(1.0, 4.2);
			double length1 = Math.Sqrt((123.0 - 1.0) * (123.0 - 1.0) - (256.5 - 4.2) * (256.5 - 4.2)),
				   length2 = expectedPoint - point1;
			Assert.AreEqual(length1, length2);
        }

        [TestMethod]
        public void TestCorrectLength()
        {
            Point expectedPoint = new Point(45.1, -754.0);
            double expectedPointLength = expectedPoint.GetLength(), length = Math.Sqrt((45.1 * 45.1) + ((-754.0) * (-754.0)));
            Assert.AreEqual(expectedPointLength, length);
        }

		[TestMethod]
		public void TestPointCorrectOperatorMinus()
		{
			Point expectedPoint = new Point(325.5, 489.0);
			Point point1 = new Point(expectedPoint.Y, expectedPoint.X);
			expectedPoint = -expectedPoint;
			Assert.AreEqual(expectedPoint, point1);
		}

		[TestMethod]
		public void TestPointCorrectImplicitInt()
		{
			Point expectedPoint = new Point(432.52, 4356.6);
			int temp1 = Convert.ToInt32(expectedPoint.X), temp2 = expectedPoint;
			Assert.AreEqual(temp1, temp2);
			int temp3 = 433;
			Assert.AreEqual(temp2, temp3);
		}

		[TestMethod]
		public void TestPointCorrectExplicitDouble()
		{
			Point expectedPoint = new Point(524.4536, 2878.2309);
			double temp1 = 2878.2309;
			double temp2 = (double)expectedPoint;
			Assert.AreEqual(temp1, temp2);
		}

		#endregion

		#region Тесты класса PointArray

		[TestMethod]
		public void TestPointArrayAreEqual()
		{
			PointArray pointArray = new PointArray(5, 235.4, -641.043);
			PointArray temp1 = new PointArray(pointArray);
			Assert.AreEqual(pointArray, temp1);
            (double, double)[] tempList = new (double, double)[5] { (pointArray[0].X, pointArray[0].Y), (pointArray[1].X, pointArray[1].Y), (pointArray[2].X, pointArray[2].Y), (pointArray[3].X, pointArray[3].Y), (pointArray[4].X, pointArray[4].Y) };
			PointArray temp2 = new PointArray(tempList.Length, tempList);
			Assert.AreEqual(pointArray, temp2);
		}

		[TestMethod]
		public void TestPointArrayAreNotEqual()
		{
			PointArray pointArray = new PointArray(5, 235.4, -641.043);
			(double, double)[] tempList = new (double, double)[5] { (12.5, 425.0), (534.65, -250.453), (234.54, 9082), (2145.640, 0.251), (6452.54, 9734.0) };
			PointArray temp1 = new PointArray(tempList.Length, tempList);
			Assert.AreNotEqual(pointArray, temp1);
			PointArray temp2 = new PointArray();
			Assert.AreNotEqual(pointArray, temp2);
			PointArray temp3 = new PointArray(3, 324.52, 34.5490);
			Assert.AreNotEqual(pointArray, temp3);
		}

		[TestMethod]
		public void TestPointArrayCorrectIndexator()
		{
			PointArray pointArray = new PointArray(5, -100, 100);
			Assert.IsInstanceOfType(pointArray[0], typeof(Point));
            Assert.IsInstanceOfType(pointArray[4], typeof(Point));
			Assert.IsNotInstanceOfType(pointArray[5], typeof(Point));
            Assert.IsNotInstanceOfType(pointArray[-1], typeof(Point));
        }

		[TestMethod]
		public void TestPointArrayCorrectOperatorNotEqual()
		{
			PointArray pointArray = new PointArray(5, -100, 100);
			PointArray array1 = new PointArray(pointArray.Length);
			for (int i = 0; i < array1.Length; ++i)
			{
				array1[i] = pointArray[i];
				array1[i].X += i;
			}
			Assert.IsTrue(pointArray != array1);
		}

        #endregion
    }
}
