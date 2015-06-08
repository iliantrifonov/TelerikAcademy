using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolePhonebook
{
    public class PhonebookEntry : IComparable<PhonebookEntry>
    {
        private string name;
        private string nameForComparison;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name must be non empty");
                }
                if (value.Length > 200)
                {
                    throw new ArgumentException("The maximal lenght of the name is 200 simbols");
                }

                this.name = value;

                this.nameForComparison = value.ToLowerInvariant();
            }
        }

        public SortedSet<string> PhoneNumbers { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append('[');

            result.Append(this.Name);
            result.Append(": ");
            bool isFirstIteration = true;
            foreach (var phone in this.PhoneNumbers)
            {
                if (isFirstIteration)
                {
                    isFirstIteration = false;
                }
                else
                {
                    result.Append(", ");
                }

                result.Append(phone);
            }

            result.Append(']');
            return result.ToString();
        }

        public int CompareTo(PhonebookEntry other)
        {
            return this.nameForComparison.CompareTo(other.nameForComparison);
        }
    }
}