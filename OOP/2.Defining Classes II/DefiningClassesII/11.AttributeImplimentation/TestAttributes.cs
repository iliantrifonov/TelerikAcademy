namespace _11.AttributeImplimentation
{
    using System;
    //11.Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a version in the format major.minor (e.g. 2.11). Apply the version attribute to a sample class and display its version at runtime.

    public class TestAttributes
    {
        public static void Main(string[] args)
        {
            Number stuff = new Number(12);
            Type type = typeof(Number);

            object[] allAttributes = type.GetCustomAttributes(false);

            foreach (VersionAttribute attr in allAttributes)
            {
                Console.WriteLine("{0}: {1}", attr, attr.Ver);
            }
        }
    }
}
