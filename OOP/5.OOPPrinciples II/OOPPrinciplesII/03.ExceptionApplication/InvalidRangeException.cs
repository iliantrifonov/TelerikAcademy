namespace _03.ExceptionApplication
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
    {
        public InvalidRangeException(string message, T MinValue, T MaxValue)
            : this(message, default(T), MinValue, MaxValue)
        {
        }

        public InvalidRangeException(T MinValue, T MaxValue)
            : this(null, default(T), MinValue, MaxValue)
        {
        }

        public InvalidRangeException(string message, T outOfRangeValue, Exception innerException = null)
            : this(message, outOfRangeValue, default(T), default(T), innerException)
        { }

        public InvalidRangeException(string message, T outOfRangeValue, T minValue, T maxValue, Exception innerException = null)
            : base(string.Format("{0} Must be between {1} and {2}", message, minValue, maxValue), innerException)
        {
            OutOfRangeValue = outOfRangeValue;
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public T MaxValue { get; private set; }

        public T MinValue { get; private set; }

        public T OutOfRangeValue { get; private set; }
    }
}