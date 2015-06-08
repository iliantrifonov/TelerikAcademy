namespace _09.MakeOrder
{
    using System;
    using System.Linq;
    using System.Transactions;

    using _01.CreateContextForNorthwind;

    /// <summary>
    /// Create a method that places a new order in the Northwind database.
    /// The order should contain several order items. Use transaction to ensure
    /// the data consistency.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (NorthwindEntities entities = new NorthwindEntities())
                {
                    InsertOrder(entities, "Ship name", "Address", "City", "Region", null, null);
                    InsertOrder(entities, "Ship name2", "Address2", "City2", "Region2", null, null);
                }

                scope.Complete();
            }
        }

        static void InsertOrder(NorthwindEntities entities, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry, string customerID = null, int? employeeID = null, DateTime? orderDate = null, DateTime? requiredDate = null, DateTime? shippedDate = null, int? shipVia = null, decimal? freight = null)
        {
            Order newOrder = new Order
            {
                ShipAddress = shipAddress,
                ShipCity = shipCity,
                ShipCountry = shipCountry,
                ShipName = shipName,
                ShippedDate = shippedDate,
                ShipPostalCode = shipPostalCode,
                ShipRegion = shipRegion,
                ShipVia = shipVia,
                EmployeeID = employeeID,
                OrderDate = orderDate,
                RequiredDate = requiredDate,
                Freight = freight,
                CustomerID = customerID
            };

            entities.Orders.Add(newOrder);
            entities.SaveChanges();
        }
    }
}
