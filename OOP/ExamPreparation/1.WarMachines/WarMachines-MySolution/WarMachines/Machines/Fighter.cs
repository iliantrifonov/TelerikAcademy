namespace WarMachines.Machines
{
    using System.Text;
    using WarMachines.Interfaces;
    public class Fighter : Machine , IFighter
    {
        private const double HealthPoints = 200;
        public Fighter(string name, double attackPoints, double defPoints, bool stealthMode) : base(name, attackPoints, defPoints, HealthPoints)
        {
            this.StealthMode = stealthMode;
        }

        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.Append(string.Format(" *Stealth: {0}", this.StealthMode ? "ON" : "OFF"));
            return sb.ToString();
        }
    }
}
