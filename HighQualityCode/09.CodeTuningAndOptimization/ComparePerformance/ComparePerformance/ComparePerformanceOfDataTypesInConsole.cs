namespace ComparePerformance
{
    using System;
    using System.Diagnostics;

    public static class ComparePerformanceOfDataTypesInConsole
    {
        public static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        // 2.Write a program to compare the performance of add, subtract, increment, multiply, divide for int, long, float, double and decimal values.
        public static void CompareAddSubtractIncrementMultyplyDivideAndPrint()
        {
            Console.WriteLine("Compare add");
            CompareAdd();
            Console.WriteLine();

            Console.WriteLine("Compare subtract");
            CompareSubtract();
            Console.WriteLine();

            Console.WriteLine("Compare increment");
            CompareIncrement();
            Console.WriteLine();

            Console.WriteLine("Compare multiply");
            CompareMultiply();
            Console.WriteLine();

            Console.WriteLine("Compare divide");
            CompareDivide();
        }

        private static void CompareAdd()
        {
            Console.WriteLine("Test for int");
            DisplayExecutionTime(() =>
            {
                int sum = 0;
                for (int i = 0; i < 10000; i++)
                {
                    sum += i;
                }
            }
            );

            Console.WriteLine("Test for long");
            DisplayExecutionTime(() =>
            {
                long sum = 0;
                for (int i = 0; i < 10000; i++)
                {
                    sum += i;
                }
            }
            );

            Console.WriteLine("Test for float");
            DisplayExecutionTime(() =>
            {
                float sum = 0;
                for (int i = 0; i < 10000; i++)
                {
                    sum += i;
                }
            }
            );

            Console.WriteLine("Test for double");
            DisplayExecutionTime(() =>
            {
                double sum = 0;
                for (int i = 0; i < 10000; i++)
                {
                    sum += i;
                }
            }
            );

            Console.WriteLine("Test for decimal");
            DisplayExecutionTime(() =>
            {
                decimal sum = 0;
                for (int i = 0; i < 10000; i++)
                {
                    sum += i;
                }
            }
            );
        }

        private static void CompareSubtract()
        {
            Console.WriteLine("Test for int");
            DisplayExecutionTime(() =>
            {
                int sum = 0;
                for (int i = 0; i < 10000; i++)
                {
                    sum -= i;
                }
            }
            );

            Console.WriteLine("Test for long");
            DisplayExecutionTime(() =>
            {
                long sum = 0;
                for (int i = 0; i < 10000; i++)
                {
                    sum -= i;
                }
            }
            );

            Console.WriteLine("Test for float");
            DisplayExecutionTime(() =>
            {
                float sum = 0;
                for (int i = 0; i < 10000; i++)
                {
                    sum -= i;
                }
            }
            );

            Console.WriteLine("Test for double");
            DisplayExecutionTime(() =>
            {
                double sum = 0;
                for (int i = 0; i < 10000; i++)
                {
                    sum -= i;
                }
            }
            );

            Console.WriteLine("Test for decimal");
            DisplayExecutionTime(() =>
            {
                decimal sum = 0;
                for (int i = 0; i < 10000; i++)
                {
                    sum -= i;
                }
            }
            );
        }

        private static void CompareMultiply()
        {
            Console.WriteLine("Test for int");
            DisplayExecutionTime(() =>
            {
                int product = 0;
                for (int i = 0; i < 10000; i++)
                {
                    product *= i;
                }
            }
            );

            Console.WriteLine("Test for long");
            DisplayExecutionTime(() =>
            {
                long product = 0;
                for (int i = 0; i < 10000; i++)
                {
                    product *= i;
                }
            }
            );

            Console.WriteLine("Test for float");
            DisplayExecutionTime(() =>
            {
                float product = 0;
                for (int i = 0; i < 10000; i++)
                {
                    product *= i;
                }
            }
            );

            Console.WriteLine("Test for double");
            DisplayExecutionTime(() =>
            {
                double product = 0;
                for (int i = 0; i < 10000; i++)
                {
                    product *= i;
                }
            }
            );

            Console.WriteLine("Test for decimal");
            DisplayExecutionTime(() =>
            {
                decimal product = 0;
                for (int i = 0; i < 10000; i++)
                {
                    product *= i;
                }
            }
            );
        }

        private static void CompareDivide()
        {
            Console.WriteLine("Test for int");
            DisplayExecutionTime(() =>
            {
                int div = 0;
                for (int i = 1; i < 10000; i++)
                {
                    div /= i;
                }
            }
            );

            Console.WriteLine("Test for long");
            DisplayExecutionTime(() =>
            {
                long div = 0;
                for (int i = 1; i < 10000; i++)
                {
                    div /= i;
                }
            }
            );

            Console.WriteLine("Test for float");
            DisplayExecutionTime(() =>
            {
                float div = 0;
                for (int i = 1; i < 10000; i++)
                {
                    div /= i;
                }
            }
            );

            Console.WriteLine("Test for double");
            DisplayExecutionTime(() =>
            {
                double div = 0;
                for (int i = 1; i < 10000; i++)
                {
                    div /= i;
                }
            }
            );

            Console.WriteLine("Test for decimal");
            DisplayExecutionTime(() =>
            {
                decimal div = 0;
                for (int i = 1; i < 10000; i++)
                {
                    div /= i;
                }
            }
            );
        }

        private static void CompareIncrement()
        {
            Console.WriteLine("Test for int");
            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                }
            }
            );

            Console.WriteLine("Test for long");
            DisplayExecutionTime(() =>
            {
                for (long i = 0; i < 100000; i++)
                {
                }
            }
            );

            Console.WriteLine("Test for float");
            DisplayExecutionTime(() =>
            {
                for (float i = 0; i < 100000; i++)
                {
                }
            }
            );

            Console.WriteLine("Test for double");
            DisplayExecutionTime(() =>
            {
                for (double i = 0; i < 100000; i++)
                {
                }
            }
            );

            Console.WriteLine("Test for decimal");
            DisplayExecutionTime(() =>
            {
                for (decimal i = 0; i < 100000; i++)
                {
                }
            }
            );
        }

        // 3.Write a program to compare the performance of square root, natural logarithm, sinus for float, double and decimal values.
        public static void CompareSqrtLog10SinAndPrint()
        {
            Console.WriteLine("Compare square root");
            CompareSquareRoot();
            Console.WriteLine();

            Console.WriteLine("Compare natural logarithm");
            CompareNaturalLogarithm();
            Console.WriteLine();

            Console.WriteLine("Compare sinus");
            CompareSin();
            Console.WriteLine();
        }

        private static void CompareSquareRoot()
        {
            Console.WriteLine("For float");
            DisplayExecutionTime(() =>
            {
                for (float i = 4f; i < 100000; i += 3.4f)
                {
                    Math.Sqrt(i);
                }
            }
            );

            Console.WriteLine("For double");
            DisplayExecutionTime(() =>
            {
                for (double i = 4d; i < 100000; i += 3.4d)
                {
                    Math.Sqrt(i);
                }
            }
            );

            Console.WriteLine("For decimal");
            DisplayExecutionTime(() =>
            {
                for (decimal i = 4m; i < 100000; i += 3.4m)
                {
                    Math.Sqrt((double)i);
                }
            }
            );
        }

        private static void CompareNaturalLogarithm()
        {
            Console.WriteLine("For float");
            DisplayExecutionTime(() =>
            {
                for (float i = 4f; i < 100000; i += 3.4f)
                {
                    Math.Log10(i);
                }
            }
            );

            Console.WriteLine("For double");
            DisplayExecutionTime(() =>
            {
                for (double i = 4d; i < 100000; i += 3.4d)
                {
                    Math.Log10(i);
                }
            }
            );

            Console.WriteLine("For decimal");
            DisplayExecutionTime(() =>
            {
                for (decimal i = 4m; i < 100000; i += 3.4m)
                {
                    Math.Log10((double)i);
                }
            }
            );
        }

        private static void CompareSin()
        {
            Console.WriteLine("For float");
            DisplayExecutionTime(() =>
            {
                for (float i = 4f; i < 100000; i += 3.4f)
                {
                    Math.Sin(i);
                }
            }
            );

            Console.WriteLine("For double");
            DisplayExecutionTime(() =>
            {
                for (double i = 4d; i < 100000; i += 3.4d)
                {
                    Math.Sin(i);
                }
            }
            );

            Console.WriteLine("For decimal");
            DisplayExecutionTime(() =>
            {
                for (decimal i = 4m; i < 100000; i += 3.4m)
                {
                    Math.Sin((double)i);
                }
            }
            );
        }
    }
}
