namespace _01.School
{
    using System;

    public class Discipline : ICommentable
    {
        private string name;
        private int numberOfExercises;
        private int numberOfLectures;

        public Discipline(string name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
        }

        public string Comment { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length <= 3)
                {
                    throw new ArgumentException("The lenght of the name {0} is too short, null or empty", value);
                }
                this.name = value;
            }
        }

        public int NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format("{0} is not a valid amount of exercises", value));
                }
                this.numberOfExercises = value;
            }
        }

        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format("{0} is not a valid amount of lectures", value));
                }
                this.numberOfLectures = value;
            }
        }
    }
}