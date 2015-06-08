namespace DataGenerator
{
    using System;
    using System.Linq;

    public interface IRandomDataGenerator
    {
        int GetRandomNumber(int min, int max);

        double GetRandomDoubleNumber(double min, double max);

        string GetRandomString(int length);

        string GetRandomStringWithRandomLength(int min, int max);
    }
}
