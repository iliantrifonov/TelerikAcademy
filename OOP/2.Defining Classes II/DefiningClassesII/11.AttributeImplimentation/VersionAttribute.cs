namespace _11.AttributeImplimentation
{
    using System;
    //11.Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a version in the format major.minor (e.g. 2.11). Apply the version attribute to a sample class and display its version at runtime.


    [AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct | System.AttributeTargets.Enum | System.AttributeTargets.Interface | System.AttributeTargets.Method)]
    public class VersionAttribute : Attribute
    {
        private const double DEF_VERSION = 1.0;
        private double version;
        public VersionAttribute()
        {
            this.Ver = DEF_VERSION;
        }

        public VersionAttribute(double version)
        {
            this.Ver = version;
        }

        public double Ver
        {
            get
            {
                return this.version;
            }
            private set
            {
                this.version = value;
            }
        }
    }
}
