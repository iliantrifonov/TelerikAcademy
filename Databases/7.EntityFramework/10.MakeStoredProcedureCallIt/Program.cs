namespace _10.MakeStoredProcedureCallIt
{
    using System;
    using System.Linq;

    using _01.CreateContextForNorthwind;

    /// <summary>
    /// Create a stored procedures in the Northwind database for finding 
    /// the total incomes for given supplier name and period (start date, 
    /// end date). Implement a C# method that calls the stored procedure 
    /// and returns the retuned record set.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            //--Stored procedure
            //CREATE PROC usp_GetTotalIncome(@supplierName nvarchar, @startDate date, @endDate date)
            //AS
            //SELECT SUM(od.UnitPrice) 
            //FROM [Order Details] od
            //JOIN Orders o ON od.OrderID = o.OrderID
            //JOIN Products p ON od.ProductID = p.ProductID
            //JOIN Suppliers s ON p.SupplierID = s.SupplierID
            //WHERE (o.ShippedDate BETWEEN @startDate AND @endDate) AND s.CompanyName = @supplierName
            //GO

            using (var entities = new NorthwindEntities())
            {
                var totalIncome = GetTotalIncomes(entities, "Exotic Liquids", new DateTime(1980, 1, 1), new DateTime(2014, 1, 1));
                Console.WriteLine(totalIncome);
            }
        }

        public static decimal? GetTotalIncomes(NorthwindEntities entities, string supplierName, DateTime? startDate, DateTime? endDate)
        {
            var income = entities.usp_GetTotalIncome(supplierName, startDate, endDate).First();

            return income;
        }
    }
}
