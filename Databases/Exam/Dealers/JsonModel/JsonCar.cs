namespace JsonModel
{
    public class JsonCar
    {
        public int Year { get; set; }

        public int TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }

        public JsonDealer Dealer { get; set; }
    }
}
