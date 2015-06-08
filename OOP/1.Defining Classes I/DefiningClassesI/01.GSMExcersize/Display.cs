
namespace _01.GSMExercise
{
    using System.Text;
    //1.Define a class that holds information about a mobile phone device: model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk) and display characteristics (size and number of colors). Define 3 separate classes (class GSM holding instances of the classes Battery and Display).
    //2.Define several constructors for the defined classes that take different sets of arguments (the full information for the class or part of it). Assume that model and manufacturer are mandatory (the others are optional). All unknown data fill with null.
    //5.Use properties to encapsulate the data fields inside the GSM, Battery and Display classes. Ensure all fields hold correct data at any given time.

    class Display
    {
        //fields
        private string size;
        private long? numberOfColors;

        //constructors
        public Display()
        {
            this.Size = null;
            this.NumberOfColors = null;
        }

        public Display(string size) : this()
        {
            this.Size = size;
        }

        public Display(string size, long? numOfColors) : this(size)
        {
            this.NumberOfColors = numOfColors;
        }

        //properties
        public string Size
        {
            get
            {
                return this.size;
            }
            private set
            {
                this.size = value;
            }
        }

        public long? NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
            private set
            {
                this.numberOfColors = value;
            }
        }

        //methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.Size != null)
            {
                sb.Append(string.Format("Size : {0}, ", this.Size));
            }
            if (this.NumberOfColors != null)
            {
                sb.Append(string.Format("Number of colors : {0} ", this.NumberOfColors));
            }
            return sb.ToString();
        }
    }
}
