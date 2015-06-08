namespace ToyStore.DataGenerator
{
    using System;
    using System.Linq;

    public interface IRandomDataGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);

        string GetRandomStringWithRandomLength(int min, int max);
    }
}
