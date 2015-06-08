namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;
    public abstract class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        private IList<string> targets;

        public Machine(string name, double attackPoints, double defPoints, double health)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defPoints;
            this.HealthPoints = health;
            this.targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name of the machine cannot be null or empty");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The name of the pilot cannot be null or empty");
                }
                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; set; }

        public double DefensePoints { get; set; }

        public IList<string> Targets
        {
            get { return this.targets; } // return new List(targets); if you do not want to return a referance.
        }

        public void Attack(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                throw new ArgumentNullException("Targets cannot be null or empty");   
            }

            this.targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("- {0}", this.Name));
            sb.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            sb.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            sb.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            sb.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));
            sb.AppendLine(string.Format(" *Targets: {0}", this.Targets.Count == 0 ? "None" : string.Join(", ", this.Targets)));
            
            return sb.ToString();
        }
    }
}
