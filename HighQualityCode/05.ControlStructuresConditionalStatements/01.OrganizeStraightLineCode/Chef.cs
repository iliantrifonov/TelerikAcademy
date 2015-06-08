namespace _01.OrganizeStraightLineCode
{
    public class Chef
    {
        public void Cook()
        {
            Bowl bowl = this.GetBowl();
            Potato potato = this.GetPotato();
            this.Peel(potato);
            this.Cut(potato);
            bowl.Add(potato);

            Carrot carrot = this.GetCarrot();
            this.Peel(carrot);
            this.Cut(carrot);
            bowl.Add(carrot);
        }

        public void Cook(Vegetable vegetable)
        {
            // ...
        }

        private Bowl GetBowl()
        {
            var bowl = new Bowl();

            // ...
            return bowl;
        }

        private Carrot GetCarrot()
        {
            var carrot = new Carrot();

            // ...
            return carrot;
        }

        private Potato GetPotato()
        {
            var potato = new Potato();

            // ...
            return potato;
        }

        private void Cut(Vegetable vegetable)
        {
            // ...
        }

        private void Peel(Vegetable vegetable)
        {
            // ...
        }
    }
}