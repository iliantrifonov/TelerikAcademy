namespace _01.CreateContextForNorthwind
{
    using System.Data.Linq;

    public partial class Employee
    {
        private EntitySet<Territory> entityTerritories;

        public EntitySet<Territory> EntityTerritories
        {
            get
            {
                var employeeTerritories = this.Territories;
                this.entityTerritories = new EntitySet<Territory>();
                this.entityTerritories.AddRange(employeeTerritories);
                return this.entityTerritories;
            }
        }
    }
}
