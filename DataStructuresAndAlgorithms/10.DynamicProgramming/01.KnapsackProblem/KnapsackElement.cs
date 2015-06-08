namespace _01.KnapsackProblem
{
    public class KnapsackElement
    {
        public KnapsackElement(string name,  int weight,int price)
        {
            this.Price = price;
            this.Weight = weight;
            this.Name = name;
        }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return string.Format("{0} -> weight: {1}, price {2}", this.Name, this.Weight, this.Price);
        }
    }
}
