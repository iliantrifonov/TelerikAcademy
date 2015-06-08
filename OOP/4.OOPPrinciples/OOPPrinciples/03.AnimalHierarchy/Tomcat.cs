namespace _03.AnimalHierarchy
{
    public class Tomcat : Cat, ISound
    {
        private const string DEF_SEX = "male";

        public Tomcat(string name, int age)
            : base(name, age, DEF_SEX)
        { }

        public override string MakeSound()
        {
            return "Rawr Rawr";
        }
    }
}