using System;

public class SimpleMathExam : Exam
{
    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0)
        {
            throw new ArgumentException("Cannot solve less than 0 problems");
        }

        if (problemsSolved > 10)
        {
            throw new ArgumentException("Cannot solve more than 10 problems");
        }

        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved { get; private set; }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (this.ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }

        throw new ArgumentException("Cannot solve more than 2 problems");
    }
}