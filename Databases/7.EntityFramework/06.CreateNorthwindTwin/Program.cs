namespace _06.CreateNorthwindTwin
{
    using System.Text;
    using System.Data.Entity.Infrastructure;
    using _01.CreateContextForNorthwind;

    /// <summary>
    /// Create a database called NorthwindTwin with the same structure as Northwind
    /// using the features from DbContext. Find for the API for schema generation in MSDN or in Google
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // using http://blogs.msdn.com/b/adonet/archive/2011/09/28/ef-4-2-model-amp-database-first-walkthrough.aspx I generated a model.
            // You can generate the script directly by right clicking on the diagram.
            StringBuilder dbScript = new StringBuilder();
            dbScript.Append("USE NorthwindTwin ");
            using (var objectContext = new NorthwindEntities())
            {
                string generatedScript =
                    ((IObjectContextAdapter)objectContext).ObjectContext.CreateDatabaseScript();
                dbScript.Append(generatedScript);
                objectContext.Database.ExecuteSqlCommand("CREATE DATABASE NorthwindTwin");
                objectContext.Database.ExecuteSqlCommand(dbScript.ToString());
            }
        }
    }
}
