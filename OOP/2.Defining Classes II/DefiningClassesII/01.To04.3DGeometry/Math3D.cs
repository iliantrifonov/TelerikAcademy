namespace _01.To04._3DGeometry
{
    using System;
    //3.Write a static class with a static method to calculate the distance between two points in the 3D space.
    public static class Math3D
    {
        public static double DistanceBetweenPoints(Point3D first, Point3D second)
        {
            int deltaX = first.X - second.X;
            int deltaY = first.Y - second.Y;
            int deltaZ = first.Z - second.Z;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        }
    }
}
