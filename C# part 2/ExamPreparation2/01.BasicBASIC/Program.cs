using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BasicBASIC
{
    class Program
    {
        public static List<List<string>> rows = new List<List<string>>();
        public static int V = 0;
        public static int W = 0;
        public static int X = 0;
        public static int Y = 0;
        public static int Z = 0;
        public static int index = 0;
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            GetRows(line);

        }

        private static void HandleFirstPartOfEquation(string command)
        {
            index = 0;
            switch (command[index])
            {
                case 'V':
                    V = HandleValueAfterEquals(command);
                    break;
                case 'W':
                    W = HandleValueAfterEquals(command);
                    break;
                case 'X':
                    X = HandleValueAfterEquals(command);
                    break;
                case 'Y':
                    Y = HandleValueAfterEquals(command);

                    break;
                case 'Z':
                    Z = HandleValueAfterEquals(command);
                    break;
                case 'I':
                    break;
                default:
                    throw new Exception("Missing operation at HandleFirstPart");
            }
        }

        private static int HandleValueAfterEquals(string command)
        {
            index++;
            if (command[index] != '=')
            {
                throw new DllNotFoundException("no =");
            }
            index++;
            if (command[index] == '-')
            {
                index++;
                return FoundDigit(command) * (-1);
            }
            int number = AfterEquals(command);
            if (index >= command.Length)
            {
                return number;
            }
            char sign = command[index];
            index++;
            int secondNumber = AfterEquals(command);
            if (sign == '+')
            {
                return secondNumber + number;
            }
            else if (sign == '-')
            {
                return secondNumber - number;
            }
            else
            {
                throw new Exception("Missing Sign");
            }
        }

        private static int AfterEquals(string command)
        {
            int number = 0;
            if (char.IsDigit(command[index]))
            {
                number = FoundDigit(command);
            }
            else
            {
                if (command[index] == 'V')
                {
                    number = V;
                }
                else if (command[index] == 'W')
                {
                    number = W;
                }
                else if (command[index] == 'X')
                {
                    number = X;
                }
                else if (command[index] == 'Y')
                {
                    number = Y;
                }
                else if (command[index] == 'Z')
                {
                    number = Z;
                }
                index++;
            }
            return number;
        }

        private static int FoundDigit(string command)
        {
            StringBuilder sb = new StringBuilder();
            while (char.IsDigit(command[index]))
            {
                sb.Append(command[index]);
                index++;
            }
            int num = int.Parse(sb.ToString());
            return num;
        }

        private static void IF(string commads)
        {
            index++;
            if (commads[index] != 'F')
            {
                throw new Exception("Wrong IF");
            }
        }

        private static void GetRows(string line)
        {
            int i = 0;
            while (line.Trim() != "RUN")
            {
                StringBuilder rowNum = new StringBuilder();
                int indexS = 0;
                while (char.IsDigit(line[indexS]))
                {
                    rowNum.Append(line[indexS]);
                    indexS++;
                }
                StringBuilder relevantPart = new StringBuilder();
                while (indexS < line.Length)
                {
                    if (line[i] != ' ')
                    {
                        relevantPart.Append(line[i]);
                    }
                    indexS++;
                }
                List<string> splitRowList = new List<string>();
                splitRowList.Add(rowNum.ToString());
                splitRowList.Add(relevantPart.ToString());
                rows.Add(splitRowList);
                line = Console.ReadLine();
            }
        }
    }
}
