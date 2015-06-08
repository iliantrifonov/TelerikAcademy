namespace _03.AnimalHierarchy
{
    public class Kitten : Cat, ISound
    {
        private const string DEF_SEX = "female";

        public Kitten(string name, int age)
            : base(name, age, DEF_SEX)
        { }

        public override string MakeSound()
        {
            return "Meeeowz Meeowz";
        }
    }
}