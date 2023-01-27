using System;

namespace Lab_3
{
	class Program
	{
		static void Main(string[] args)
		{
			double diapazonBegin = -2, diapazonEnd = -0.1;
			int k = 10;
			for (double x = diapazonBegin; x <= diapazonEnd; x += (diapazonEnd - diapazonBegin) / k)
			{
				double summaSteps = 0, summaAccuracy = 0;
				
				// для n шагов
				int nSteps = 40;
				double divisibleSteps = (-1) * (1 + x) * (1 + x), dividerSteps = 1;
				for (int i = 1; i <= nSteps; ++i)
				{
					if (i != 1)
                    {
						divisibleSteps *= ((-1) * (1 + x) * (1 + x));
						dividerSteps += 1;
                    }
					summaSteps += (divisibleSteps / dividerSteps);
				}

				// для заданной точности
				double accuracy = 0.0001;
				double divisibleAccuracy = (-1) * (1 + x) * (1 + x), dividerAccuracy = 1;
				double summaTerm = divisibleAccuracy / dividerAccuracy;
				bool isFirstSummaTerm = true;
				while (Math.Abs(summaTerm) >= accuracy)
                {
					if (!isFirstSummaTerm)
                    {
						divisibleAccuracy *= ((-1) * (1 + x) * (1 + x));
						dividerAccuracy += 1;
						summaTerm = divisibleAccuracy / dividerAccuracy;
                    } 
					else
                    {
						isFirstSummaTerm = false;
                    }
					summaAccuracy += summaTerm;
                }
				double y = Math.Log(1 / (2 + 2 * x + Math.Pow(x, 2)));
				Console.WriteLine("X = " + Math.Round(x, 2) + " SN = " + Math.Round(summaSteps, 5) + " SE = " + Math.Round(summaAccuracy, 5) + " Y = " + Math.Round(y, 5));
			}
		}
	}
}
