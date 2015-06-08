namespace _03.SupermarketQueue
{
    using System;
    using System.Text;
    using Wintellect.PowerCollections;

    /// <summary>
    /// bgcoder.com/Contests/Practice/DownloadResource/431
    /// </summary>
    public class Program
    {
        public static BigList<string> queue = new BigList<string>();
        public static Bag<string> names = new Bag<string>();
        public static StringBuilder sb = new StringBuilder(300);
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != null && input != "End")
            {
                var split = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (split[0])
                {
                    case "Append":
                        Append(split[1]);
                        break;
                    case "Insert":
                        Insert(int.Parse(split[1]), split[2]);
                        break;
                    case "Find":
                        Find(split[1]);
                        break;
                    case "Serve":
                        Serve(int.Parse(split[1]));
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(sb);
        }

        private static void Serve(int count)
        {
            if (count > queue.Count)
            {
                sb.AppendLine("Error");
                return;
            }

            var removedItems = queue.GetRange(0, count).ToArray();

            sb.AppendLine(string.Join(" ", removedItems));

            names.RemoveMany(removedItems);

            queue.RemoveRange(0, count);
        }

        private static void Find(string name)
        {
            var itemsCount = names.NumberOfCopies(name);
            sb.AppendLine(itemsCount.ToString());
        }

        private static void Insert(int position, string name)
        {
            if (position > queue.Count || position < 0)
            {
                sb.AppendLine("Error");
                return;
            }

            if (position == queue.Count)
            {
                queue.Add(name);
                names.Add(name);
            }
            else
            {
                queue.Insert(position, name);
                names.Add(name);
            }

            sb.AppendLine("OK");
        }

        private static void Append(string name)
        {
            queue.Add(name);
            names.Add(name);
            sb.AppendLine("OK");
        }
    }
}
