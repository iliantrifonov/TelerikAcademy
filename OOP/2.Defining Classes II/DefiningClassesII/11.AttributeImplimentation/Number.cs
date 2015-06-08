namespace _11.AttributeImplimentation
{
    using System;
    //11.Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a version in the format major.minor (e.g. 2.11). Apply the version attribute to a sample class and display its version at runtime.

    [Version(2.11)]
    public class Number
    {
        public int number { get; private set; }

        public Number(int number)
        {
            this.number = number;
        }
    }
}
