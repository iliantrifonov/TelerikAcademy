namespace _01.GSMExercise
{
    using System;

    //8.Create a class Call to hold a call performed through a GSM. It should contain date, time, dialed phone number and duration (in seconds).

    class Call
    {
        //constructors
        public Call(DateTime datetime, long duration, string dialedNum)
        {
            this.dateAndTime = datetime;
            this.duration = duration;
            this.dialedNumber = dialedNum;
        }

        //properties
        public DateTime dateAndTime { get; private set; }

        public long duration { get; private set; }

        public string dialedNumber { get; private set; }

        //methods
        public override string ToString()
        {
            return string.Format("Date : {0}, Time : {1}, Duration of the call : {2}", this.dateAndTime.ToShortDateString(), this.dateAndTime.ToShortTimeString(), this.duration);
        }
    }
}
