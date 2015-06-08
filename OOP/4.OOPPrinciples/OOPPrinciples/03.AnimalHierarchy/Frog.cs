namespace _03.AnimalHierarchy
{
    public class Frog : Animal, ISound
    {
        public Frog(string name, int age, string sex)
            : base(name, age, sex)
        { }

        public override string MakeSound()
        {
            return "Ribbit Ribbit";
        }
    }
}