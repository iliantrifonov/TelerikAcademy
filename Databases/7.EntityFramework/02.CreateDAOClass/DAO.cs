namespace _02.CreateDAOClass
{
    using System.Linq;
    using _01.CreateContextForNorthwind;

    public static class Dao
    {
        public static void AddCustomer(NorthwindEntities entities, Customer customer)
        {
            entities.Customers.Add(customer);   
        }

        public static void DeleteCustomer(NorthwindEntities entities, Customer customer)
        {
            entities.Customers.Remove(customer);
        }

        public static void DeleteCustomer(NorthwindEntities entities, string customerId)
        {
            entities.Customers.Remove(entities.Customers.Where(c => c.CustomerID == customerId).First());
        }

        public static void ModifyCustomer(NorthwindEntities entities, string customerId, Customer modifiedCustomer)
        {
            var customerToModify = entities.Customers.Where(c => c.CustomerID == customerId).First();
            customerToModify.Address = modifiedCustomer.Address;
            customerToModify.City = modifiedCustomer.City;
            customerToModify.CompanyName = modifiedCustomer.CompanyName;
            customerToModify.ContactName = modifiedCustomer.ContactName;
            customerToModify.ContactTitle = modifiedCustomer.ContactTitle;
            customerToModify.Country = modifiedCustomer.Country;
            customerToModify.CustomerDemographics = modifiedCustomer.CustomerDemographics;
            customerToModify.Fax = modifiedCustomer.Fax;
            customerToModify.Orders = modifiedCustomer.Orders;
            customerToModify.Phone = modifiedCustomer.Phone;
            customerToModify.PostalCode = modifiedCustomer.PostalCode;
            customerToModify.Region = modifiedCustomer.Region;
        }

        public static void SaveChanges(NorthwindEntities entities)
        {
            entities.SaveChanges();
        }
    }
}
