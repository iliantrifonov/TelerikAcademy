using System;
namespace _01.To04._3DGeometry
{
    using System.IO;
    //4.Create a class Path to hold a sequence of points in the 3D space. Create a static class PathStorage with static methods to save and load paths from a text file. Use a file format of your choice.
    public static class PathStorage
    {
        public static void SavePath(Path path)
        {
            using (StreamWriter writer = new StreamWriter(@"../../paths.txt"))
            {
                foreach (var item in path.Paths)
                {
                    writer.Write(item.ToString());
                    writer.Write("   ");
                }
            }
        }

        public static Path ReadPath()
        {
            Path returnPath = new Path();
            try
            {
                using (StreamReader reader = new StreamReader(@"../../paths.txt"))
                {
                    string[] points = reader.ReadToEnd().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int index = 0;
                    while (index < points.Length)
                    {
                        Point3D point = new Point3D(int.Parse(points[index]), int.Parse(points[index + 1]), int.Parse(points[index + 2]));
                        index += 3;
                        returnPath.AddPoint(point);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found, try adding a new file");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return returnPath;
        }
    }
}
