namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;
    using System.Linq;
    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
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
                    throw new ArgumentNullException("The name of the pilot cannot be null or empty");
                }
                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            string numOfMachines = string.Empty;
            if (this.machines.Count == 0)
            {
                numOfMachines = "no";
            }
            else
            {
                numOfMachines = this.machines.Count.ToString();
            }
            string multiple = string.Empty;
            if (this.machines.Count == 1)
            {
                multiple = "machine";
            }
            else
            {
                multiple = "machines";
            }
            if (machines.Count != 0)
            {
                sb.AppendLine(string.Format("{0} – {1} {2}", this.Name, numOfMachines, multiple));
                var sortedMachines = this.machines.OrderBy(x => x.HealthPoints).ThenBy(y => y.Name);
                foreach (var machine in sortedMachines)
                {
                    sb.Append(machine.ToString());
                }
            }
            else
            {
                sb.Append(string.Format("{0} – {1} {2}", this.Name, numOfMachines, multiple));
            }
            return sb.ToString();
        }
    }
}
