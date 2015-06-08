
namespace _01.GSMExercise
{
    using System;
    using System.Text;
    //1.Define a class that holds information about a mobile phone device: model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk) and display characteristics (size and number of colors). Define 3 separate classes (class GSM holding instances of the classes Battery and Display).
    //2.Define several constructors for the defined classes that take different sets of arguments (the full information for the class or part of it). Assume that model and manufacturer are mandatory (the others are optional). All unknown data fill with null.
    //3.Add an enumeration BatteryType (Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries.
    //5.Use properties to encapsulate the data fields inside the GSM, Battery and Display classes. Ensure all fields hold correct data at any given time.

    public enum BatteryType
    {
        LiIon, NiMH, NiCd
    }
    class Battery
    {
        //fields
        private string model;
        private int? hoursIdle;
        private int? hoursTalk;
        
        //constructors
        public Battery()
        {
            this.Model = null;
            this.HoursIdle = null;
            this.HoursTalk = null;
        }

        public Battery(string model) : this()
        {
            this.Model = model;
        }

        public Battery(string model, int? idle) : this(model)
        {
            this.HoursIdle = idle;
        }

        public Battery(string model, int? idle, int? talk) : this(model,idle)
        {
            this.HoursTalk = talk;
        }

        public Battery(string model, int? idle, int? talk, BatteryType batType) : this(model, idle, talk)
        {
            this.type = batType;
        }

        //properties
        public BatteryType type { get; private set; }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                this.model = value;
            }
        }

        public int? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            private set
            {
                this.hoursIdle = value;
            }
        }

        public int? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            private set
            {
                this.hoursTalk = value;
            }
        }

        //methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.Model != null)
            {
                sb.Append(string.Format("Model : {0}, ", this.Model));
            }
            if (this.HoursIdle != null)
            {
                sb.Append(string.Format("Hours idle : {0}, ", this.HoursIdle));
            }
            if (this.HoursTalk != null)
            {
                sb.Append(string.Format("Hours talk : {0}", this.HoursTalk));
            }
            return sb.ToString();
        }
    }
}
