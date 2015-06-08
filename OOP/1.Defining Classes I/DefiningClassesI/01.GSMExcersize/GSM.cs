namespace _01.GSMExercise
{
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;
    //1.Define a class that holds information about a mobile phone device: model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk) and display characteristics (size and number of colors). Define 3 separate classes (class GSM holding instances of the classes Battery and Display).
    //2.Define several constructors for the defined classes that take different sets of arguments (the full information for the class or part of it). Assume that model and manufacturer are mandatory (the others are optional). All unknown data fill with null.
    //4.Add a method in the GSM class for displaying all information about it. Try to override ToString().
    //5.Use properties to encapsulate the data fields inside the GSM, Battery and Display classes. Ensure all fields hold correct data at any given time.
    //6.Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.
    //9.Add a property CallHistory in the GSM class to hold a list of the performed calls. Try to use the system class List<Call>.
    //10.Add methods in the GSM class for adding and deleting calls from the calls history. Add a method to clear the call history.
    //11.Add a method that calculates the total price of the calls in the call history. Assume the price per minute is fixed and is provided as a parameter.


    class GSM
    {
        //fields
        
        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private Battery battery;
        private Display display;
        private static GSM iPhone4S;
        private List<Call> callHistory;

        //constructors
        private GSM()
        {
            this.Model = null;
            this.Manufacturer = manufacturer;
            this.Price = null;
            this.Owner = null;
            this.Battery = new Battery();
            this.Display = new Display();
            this.CallHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer) : this()
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
        }

        public GSM(string model, string manufacturer, string owner)
            : this(model, manufacturer)
        {
            this.Owner = owner;
        }

        public GSM(string model, string manufacturer, string owner, decimal price)
            : this(model, manufacturer,owner)
        {
            this.Price = price;
        }

        public GSM(string model, string manufacturer, string owner, decimal price, Battery battery, Display display)
            : this(model, manufacturer, owner, price)
        {
            this.Battery = battery;
            this.Display = display;
        }

        //properties
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

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            private set
            {
                this.manufacturer = value;
            }
        }

        public decimal? Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            private set
            {
                this.owner = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            private set
            {
                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }
            private set
            {
                this.display = value;
            }
        }

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
            set
            {
                iPhone4S = value;
            }

        }

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
            private set
            {
                this.callHistory = value;
            }
        }

        public static decimal pricePerMinute { get; set; }

        //methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.Model != null)
            {
                sb.Append(string.Format("Model : {0}, ", this.Model));
            }
            if (this.Manufacturer != null)
            {
                sb.Append(string.Format("Manufacturer : {0}, ", this.Manufacturer));
            }
            if (this.Price != null)
            {
                sb.Append(string.Format("Price : {0}, ", this.Price));
            }
            if (this.Owner != null)
            {
                sb.Append(string.Format("Owner : {0}, ", this.Owner));
            }
            if (this.Battery == new Battery())
            {
                sb.Append(string.Format("Battery : {0}, ", this.Battery));
            }
            if (this.Display == new Display())
            {
                sb.Append(string.Format("Display : {0}", this.Display));
            }
            return sb.ToString();
            
        }

        public void AddCall(Call call)
        {
            if (callHistory == null)
            {
                CallHistory = new List<Call>();
            }
            CallHistory.Add(call);
        }

        public void DeleteCall(int index)
        {
            this.CallHistory.RemoveAt(index);
        }

        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }

        public decimal CalculatePriceOfCalls()
        {
            BigInteger seconds = 0;
            foreach (var item in CallHistory)
            {
                seconds += item.duration;
            }
            return (decimal)(seconds / 60) * pricePerMinute;
        }
    }
}
