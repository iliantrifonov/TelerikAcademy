namespace Importer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    using JsonModel;
    using Model;

    public static class DataGenerator
    {
        public static void Insert(string entryDataFilePath)
        {
            // this will match only the necessary files
            var fileNames = Directory.EnumerateFiles(entryDataFilePath, "data.*.json");
            EntryPoint.Context.Configuration.AutoDetectChangesEnabled = false;
            foreach (var file in fileNames)
            {
                Console.WriteLine();
                Console.WriteLine("Adding " + file);

                InsertFile(file);

                Console.WriteLine("Finised " + file);
            }

            EntryPoint.Context.Configuration.AutoDetectChangesEnabled = true;
        }

        private static void InsertFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            json = json.Trim();

            JavaScriptSerializer js = new JavaScriptSerializer();
            JsonCar[] jsonCars = js.Deserialize<JsonCar[]>(json);
            int count = 0;
            foreach (var jsonCar in jsonCars)
            {
                var city = GetCity(jsonCar.Dealer.City);

                var dealer = new Dealer()
                {
                    Name = jsonCar.Dealer.Name,
                };

                dealer.Cities.Add(city);

                var manufacturer = GetManufacturer(jsonCar.ManufacturerName);

                var car = new Car()
                {
                    Dealer = dealer,
                    Manufacturer = manufacturer,
                    Model = jsonCar.Model,
                    Price = (decimal)jsonCar.Price,
                    TransmissionType = jsonCar.TransmissionType == 0 ? TransmissionType.Manual : TransmissionType.Automatic,
                    Year = jsonCar.Year
                };

                EntryPoint.Context.Cars.Add(car);
                count++;
                if (count % 200 == 0)
                {
                    Console.Write(" . ");
                }

                // this is here and not in the if because of a local bug I had on my machine. Should be in the IF statement for performance!
                EntryPoint.Context.SaveChanges();
            }
        }

        private static Manufacturer GetManufacturer(string name)
        {
            var manufacturer = EntryPoint.Context.Manufacturers.Where(m => m.Name == name).FirstOrDefault();
            if (manufacturer == null)
            {
                manufacturer = new Manufacturer
                {
                    Name = name,
                };
            }

            return manufacturer;
        }

        private static City GetCity(string name)
        {
            var city = EntryPoint.Context.Cities.Where(m => m.Name == name).FirstOrDefault();
            if (city == null)
            {
                city = new City
                {
                    Name = name,
                };
            }

            return city;
        }
    }
}
