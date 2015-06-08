namespace _01.To04._3DGeometry
{
    using System.Collections.Generic;
    //4.Create a class Path to hold a sequence of points in the 3D space. Create a static class PathStorage with static methods to save and load paths from a text file. Use a file format of your choice.
    public class Path
    {
        private List<Point3D> path;

        public Path()
        {
            this.Paths = new List<Point3D>();
        }

        public List<Point3D> Paths
        {
            get
            {
                return path;
            }
            private set
            {
                this.path = value;
            }
        }

        public void AddPoint(Point3D point)
        {
            Paths.Add(point);
        }

        public void Clear()
        {
            this.Paths = new List<Point3D>();
        }
    }
}
