namespace _07.ConcurrentChanges
{
    using System.Linq;
    using _01.CreateContextForNorthwind;
    using System;

    /// <summary>
    /// Try to open two different data contexts and perform concurrent changes
    /// on the same records. What will happen at SaveChanges()? How to deal with it?
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var northwindEntities1 = new NorthwindEntities())
            {
                using (var northwindEntities2 = new NorthwindEntities())
                {
                    var one = northwindEntities1.Categories.First();
                    var two = northwindEntities2.Categories.First();

                    one.Description = "Description One";
                    two.Description = "Description two";
                    northwindEntities1.SaveChanges();
                    northwindEntities2.SaveChanges();
                }
            }

            // the second one is now in the data base
            using (var entities = new NorthwindEntities())
            {
                Console.WriteLine(entities.Categories.First().Description);
            }
        }
    }
}
