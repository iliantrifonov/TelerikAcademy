using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentNullException("The firstName must not be null or whitespace");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentNullException("The lastName must not be null or whitespace");
        }

        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public IList<Exam> Exams { get; private set; }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
            throw new ArgumentNullException("Exams in Student is cannot be null");
        }

        if (this.Exams.Count <= 0)
        {
            throw new ArgumentException("Exams in Student is cannot be less than 1");
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null)
        {
            throw new ArgumentNullException("Exams in Student is cannot be null");
        }

        if (this.Exams.Count <= 0)
        {
            throw new ArgumentException("Exams in Student is cannot be less than 1");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] =
                ((double)examResults[i].Grade - examResults[i].MinGrade) /
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}