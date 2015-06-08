namespace _03.AnimalHierarchy
{
    public class Dog : Animal, ISound
    {
        public Dog(string name, int age, string sex)
            : base(name, age, sex)
        { }

        public override string MakeSound()
        {
            return "Baw Baw";
        }
    }
}