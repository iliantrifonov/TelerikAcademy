namespace _02.Salaries
{
    using System;
    using System.Linq;

    /// <summary>
    /// downloads.academy.telerik.com/svn/intro-algorithms/2014/11.%20Graphs%20and%20Graph%20Algorithms/Graphs-and-Graph-Algorithms-Homework.rar
    /// </summary>
    public class Program
    {
        private static long[] cachedSalaryResults;
        public static void Main(string[] args)
        {
            // Input is in the following format, where each Y shows that the current employee[row], 
            // the employee on the col as a subordinate.
            // 6
            // NNNNNN
            // YNYNNY
            // YNNNNY
            // NNNNNN
            // YNYNNN
            // YNNYNN

            var employeesCount = int.Parse(Console.ReadLine());
            cachedSalaryResults = new long[employeesCount];
            string[] adjacencyMatrix = new string[employeesCount];

            for (int i = 0; i < employeesCount; i++)
            {
                adjacencyMatrix[i] = Console.ReadLine().Trim();
            }

            long result = 0;
            for (int employeeMatrix = 0; employeeMatrix < adjacencyMatrix.Length; employeeMatrix++)
            {
                result += FindEmployeeSalary(adjacencyMatrix, employeeMatrix);
            }

            Console.WriteLine(result);
        }

        private static long FindEmployeeSalary(string[] adjacencyMatrix, int employeeIndex)
        {
            if (cachedSalaryResults[employeeIndex] != 0)
            {
                return cachedSalaryResults[employeeIndex];
            }

            long salary = 0;
            for (int i = 0; i < adjacencyMatrix[employeeIndex].Length; i++)
            {
                if (adjacencyMatrix[employeeIndex][i] == 'Y')
                {
                    salary += FindEmployeeSalary(adjacencyMatrix, i);
                }
            }

            if (salary == 0)
            {
                salary = 1;
            }

            cachedSalaryResults[employeeIndex] = salary;

            return salary;
        }
    }
}
