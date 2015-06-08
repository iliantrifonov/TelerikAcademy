namespace _03.AnimalHierarchy
{
    public class Cat : Animal, ISound
    {
        public Cat(string name, int age, string sex)
            : base(name, age, sex)
        { }

        public override string MakeSound()
        {
            return "Meow Meow";
        }
    }
}