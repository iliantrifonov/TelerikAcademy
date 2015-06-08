namespace WarMachines.Machines
{
    using System.Text;
    using WarMachines.Interfaces;

    public class Tank : Machine, ITank
    {
        private const double HealthPoints = 100;
        public Tank(string name, double attackPoints, double defPoints)
            : base(name, attackPoints, defPoints, HealthPoints)
        {
            this.DefenseMode = false;
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
            }
            else
            {
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }
            this.DefenseMode = !this.DefenseMode;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine(string.Format(" *Defense: {0}", this.DefenseMode ? "ON" : "OFF"));
            return sb.ToString();
        }
    }
}
