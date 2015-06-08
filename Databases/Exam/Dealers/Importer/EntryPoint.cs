namespace Importer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using System.Xml.Linq;

    using Newtonsoft.Json;

    using Data;
    using JsonModel;
    using Model;

    public class EntryPoint
    {
        public static DatabaseContext Context { get; set; }

        public static void Main(string[] args)
        {
            Context = new DatabaseContext();

            // context = new DatabaseContext("SQLContextExpress");
            using (Context)
            {
                Context.Manufacturers.Any(m => true);
                string entryDataFilePath = "../../JsonData/";

                DataGenerator.Insert(entryDataFilePath);
                string queryFilePath = "../../../../Queries.xml";

                string outputXmlFilePath = "../../../../";
                PerformQuery(queryFilePath, outputXmlFilePath);
            }
        }

        public static void PerformQuery(string queryFilePath, string outputXmlFilePath)
        {
            var xmlFile = XElement.Load(queryFilePath);

            var allQueries = xmlFile.Elements("Query");
            foreach (var query in allQueries)
            {
                string outputFileName = outputXmlFilePath + query.Attribute("OutputFileName").Value;

                var result = ParseQuery(query);

                CreateXmlResultSet(result, outputFileName);
            }
        }

        private static void CreateXmlResultSet(IQueryable<Car> result, string outputFileName)
        {
            var document = new XDocument();

            var carsXml = new XElement("Cars");

            var necessaryData = result.Select(c => new
            {
                @ManufacturerName = c.Manufacturer.Name,
                @Model = c.Model,
                @Year = c.Year,
                @Price = c.Price,
                Dealer = new
                {
                    @Name = c.Dealer.Name,
                    Cities = c.Dealer.Cities.Select(cit => new
                    {
                        Name = cit.Name
                    })
                }
            }).ToList();

            var obj = JsonConvert.SerializeObject(necessaryData);

            carsXml.Add(JsonConvert.DeserializeXNode(obj));
            document.Add(carsXml);

            document.Save(outputFileName);
        }

        private static IQueryable<Car> ParseQuery(XElement query)
        {
            var whereClausesElement = query.Element("WhereClauses");
            IQueryable<Car> cars = Context.Cars.AsQueryable();
            if (whereClausesElement != null)
            {
                cars = ParseWhereClauses(whereClausesElement, cars);
            }

            var ordeyElement = query.Element("OrderBy");
            if (ordeyElement != null)
            {
                cars = ParseOrderByClause(ordeyElement, cars);
            }

            return cars;
        }

        private static IQueryable<Car> ParseOrderByClause(XElement ordeyElement, IQueryable<Car> cars)
        {
            var orderByProperyName = ordeyElement.Value;

            if (orderByProperyName == "Id")
            {
                return cars.OrderBy(c => c.Id)
                    .AsQueryable();
            }
            else if (orderByProperyName == "Year")
            {
                return cars.OrderBy(c => c.Year)
                    .AsQueryable();
            }
            else if (orderByProperyName == "Model")
            {
                return cars.OrderBy(c => c.Model)
                    .AsQueryable();
            }
            else if (orderByProperyName == "Price")
            {
                return cars.OrderBy(c => c.Price)
                    .AsQueryable();
            }
            else if (orderByProperyName == "Maufacturer ")
            {
                return cars.OrderBy(c => c.Manufacturer.Name)
                    .AsQueryable();
            }
            else if (orderByProperyName == "Dealer")
            {
                return cars.OrderBy(c => c.Dealer.Name)
                    .AsQueryable();
            }

            throw new ArgumentException(string.Format("The property name is not valid : {0}", orderByProperyName));
        }

        private static IQueryable<Car> ParseWhereClauses(XElement whereClausesElement, IQueryable<Car> cars)
        {
            var allWhereClauses = whereClausesElement.Elements("WhereClause");

            foreach (var where in allWhereClauses)
            {
                var propertyName = where.Attribute("PropertyName").Value;
                var type = where.Attribute("Type").Value;

                int val;

                if (int.TryParse(where.Value, out val))
                {
                    
                }
                decimal dec;
                if (decimal.TryParse(where.Value, out dec))
                {
                    
                }
                if (propertyName == "Id")
                {
                    if (type == "Equals")
                    {
                        cars = cars.Where(c => c.Id == val).AsQueryable();
                    }
                    else if (type == "GreaterThan")
                    {
                        cars = cars.Where(c => c.Id > val).AsQueryable();
                    }
                    else if (type == "LessThan")
                    {
                        cars = cars.Where(c => c.Id < val).AsQueryable();
                    }
                }
                else if (propertyName == "Year")
                {
                    if (type == "Equals")
                    {
                        cars = cars.Where(c => c.Year == val).AsQueryable();
                    }
                    else if (type == "GreaterThan")
                    {
                        cars = cars.Where(c => c.Year > val).AsQueryable();
                    }
                    else if (type == "LessThan")
                    {
                        cars = cars.Where(c => c.Year < val).AsQueryable();
                    }
                }
                else if (propertyName == "Price")
                {
                    if (type == "Equals")
                    {
                        cars = cars.Where(c => c.Price == dec)
                            .AsQueryable();
                    }
                    else if (type == "GreaterThan")
                    {
                        cars = cars.Where(c => c.Price > dec)
                            .AsQueryable();
                    }
                    else if (type == "LessThan")
                    {
                        cars = cars.Where(c => c.Price < dec)
                            .AsQueryable();
                    }
                }
                else if (propertyName == "Model")
                {
                    if (type == "Equals")
                    {
                        cars = cars.Where(c => c.Model == where.Value.Trim())
                            .AsQueryable();
                    }
                    else if (type == "Contains")
                    {
                        cars = cars.Where(c => c.Model.Contains(where.Value.Trim()))
                            .AsQueryable();
                    }
                }
                else if (propertyName == "Manufacturer")
                {
                    if (type == "Equals")
                    {
                        cars = cars.Where(c => c.Manufacturer.Name == where.Value.Trim())
                            .AsQueryable();
                    }
                    else if (type == "Contains")
                    {
                        cars = cars.Where(c => c.Manufacturer
                                                .Name
                                                .Contains(where.Value.Trim()))
                                                .AsQueryable();
                    }
                }
                else if (propertyName == "Dealer")
                {
                    if (type == "Equals")
                    {
                        cars = cars.Where(c => c.Dealer.Name == where.Value.Trim())
                            .AsQueryable();
                    }
                    else if (type == "Contains")
                    {
                        cars = cars.Where(c => c.Dealer
                                                .Name
                                                .Contains(where.Value.Trim()))
                                                .AsQueryable();
                    }
                }
                else if (propertyName == "City")
                {
                    if (type == "Equals")
                    {
                        cars = cars.Where(c => c.Dealer
                                                .Cities
                                                .AsQueryable()
                                                .Any(cit => cit.Name == where.Value.Trim()))
                                                .AsQueryable();
                    }
                }
                else
                {
                    throw new ArgumentException(string.Format("The property name is invalid {0}", propertyName));
                }
            }

            return cars.AsQueryable();
        }
    }
}
