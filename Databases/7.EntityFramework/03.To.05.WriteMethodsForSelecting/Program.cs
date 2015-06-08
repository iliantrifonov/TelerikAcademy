namespace _03.To._05.WriteMethodsForSelecting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using _01.CreateContextForNorthwind;

    public class Program
    {
        public static void Main(string[] args)
        {
            using (var entities = new NorthwindEntities())
            {
                var orders = GetOrdersFrom1997ShippedToCanada(entities);

                foreach (var order in orders)
                {
                    Console.WriteLine(order.OrderDate + " - " + order.ShipCountry + " - " + order.ShipRegion);
                }

                orders = GetOrdersFrom1997ShippedToCanadaNative(entities);
                Console.WriteLine();

                foreach (var order in orders)
                {
                    Console.WriteLine(order.OrderDate + " - " + order.ShipCountry + " - " + order.ShipName);
                }

                Console.WriteLine("Sales: ");

                var sales = GetSales(entities, "BC", new DateTime(1996, 10, 11), DateTime.Now);

                foreach (var sale in sales)
                {
                    Console.WriteLine(sale.OrderDate + " - " + sale.ShipCountry + " - " + sale.ShipName);
                }
            }
        }

        /// <summary>
        /// Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
        /// </summary>
        public static IEnumerable<Order> GetOrdersFrom1997ShippedToCanada(NorthwindEntities entities)
        {
            return entities.Orders.Where(o => o.OrderDate.Value.Year == 1997 && o.ShipCountry == "Canada");
        }

        /// <summary>
        /// Implement previous by using native SQL query and executing it through the DbContext.
        /// </summary>
        public static IEnumerable<Order> GetOrdersFrom1997ShippedToCanadaNative(NorthwindEntities entities)
        {
            string sqlQuery = @"SELECT * from Customers c INNER JOIN Orders o ON o.CustomerID = c.CustomerID " +
                             "WHERE (YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1});";

            object[] parameters = { 1997, "Canada" };
            var sqlQueryResult = entities.Database.SqlQuery<Order>(sqlQuery, parameters);
            return sqlQueryResult;
        }

        /// <summary>
        /// Write a method that finds all the sales by specified region and period (start / end dates).
        /// </summary>
        public static IEnumerable<Order> GetSales(NorthwindEntities entities, string region, DateTime startDate, DateTime endDate)
        {
            return entities.Orders.Where(o => o.ShipRegion == region && o.OrderDate >= startDate && o.OrderDate <= endDate);
        }
    }
}
