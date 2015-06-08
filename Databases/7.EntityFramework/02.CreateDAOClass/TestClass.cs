namespace _02.CreateDAOClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using _01.CreateContextForNorthwind;

    /// <summary>
    /// Create a DAO class with static methods which provide functionality 
    /// for inserting, modifying and deleting customers. Write a testing class.
    /// </summary>
    public class TestClass
    {
        public static void Main(string[] args)
        {
            using (var northwindEntities = new NorthwindEntities())
            {
                var newCustomer = new Customer() { CompanyName = "Some company", CustomerID = "IIIII" };
                Dao.AddCustomer(northwindEntities, newCustomer);
                Dao.SaveChanges(northwindEntities);
                Console.WriteLine(northwindEntities.Customers.Where(c => c.CompanyName == "Some company").First().CustomerID);

                Dao.ModifyCustomer(northwindEntities, "IIIII", new Customer() { CompanyName = "Some company2", CustomerID = "IIIII" });
                Dao.SaveChanges(northwindEntities);

                Console.WriteLine(northwindEntities.Customers.Where(c => c.CustomerID == "IIIII").First().CompanyName);

                Dao.DeleteCustomer(northwindEntities, newCustomer.CustomerID);
                Dao.SaveChanges(northwindEntities);

                //This should print an empty row.
                Console.WriteLine(northwindEntities.Customers.Where(c => c.CompanyName == "Some company").FirstOrDefault());
            }
        }
    }
}
