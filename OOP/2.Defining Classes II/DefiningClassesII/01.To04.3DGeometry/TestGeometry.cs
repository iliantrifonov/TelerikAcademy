namespace _01.To04._3DGeometry
{
    using System;

    public class TestGeometry
    {
        public static void Main(string[] args)
        {
            Point3D point = new Point3D(4, 2, 1);
            Console.WriteLine(point);
            Console.WriteLine(Point3D.ZeroPoint);
            Console.WriteLine(Math3D.DistanceBetweenPoints(Point3D.ZeroPoint, point));
            Point3D secondPoint = new Point3D(10, 7, 1);
            Path path = new Path();
            path.AddPoint(Point3D.ZeroPoint);
            path.AddPoint(point);
            path.AddPoint(secondPoint);
            PathStorage.SavePath(path);
            path.Clear();
            path = PathStorage.ReadPath();
            foreach (var item in path.Paths)
            {
                Console.WriteLine(item);
            }
        }
    }
}
