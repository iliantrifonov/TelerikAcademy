using _12.Refactoring;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _11.RefactoringTest
{
    [TestClass]
    public class WalkInMatrixTest
    {
        //[TestMethod]
        //public void GetNextDirectionTestDiagonalRightDown()
        //{
        //    var walkInMatrix = new WalkInMatrix(5);
        //    ICoordinate expectedDirection = new Coordinate(1, 0);
        //    ICoordinate direction = walkInMatrix.GetNextDirection(1, 1);
        //    Assert.IsTrue(direction.Row == expectedDirection.Row && direction.Col == expectedDirection.Col);
        //}

        //[TestMethod]
        //public void GetNextDirectionTestDown()
        //{
        //    var walkInMatrix = new WalkInMatrix(5);
        //    ICoordinate expectedDirection = new Coordinate(1, -1);
        //    ICoordinate direction = walkInMatrix.GetNextDirection(1, 0);
        //    Assert.IsTrue(direction.Row == expectedDirection.Row && direction.Col == expectedDirection.Col);
        //}

        //[TestMethod]
        //public void GetNextDirectionTestDiagonalLeftDown()
        //{
        //    var walkInMatrix = new WalkInMatrix(5);
        //    ICoordinate expectedDirection = new Coordinate(0, -1);
        //    ICoordinate direction = walkInMatrix.GetNextDirection(1, -1);
        //    Assert.IsTrue(direction.Row == expectedDirection.Row && direction.Col == expectedDirection.Col);
        //}

        //[TestMethod]
        //public void GetNextDirectionTestLeft()
        //{
        //    var walkInMatrix = new WalkInMatrix(5);
        //    ICoordinate expectedDirection = new Coordinate(-1, -1);
        //    ICoordinate direction = walkInMatrix.GetNextDirection(0, -1);
        //    Assert.IsTrue(direction.Row == expectedDirection.Row && direction.Col == expectedDirection.Col);
        //}

        //[TestMethod]
        //public void GetNextDirectionTestDiagonalLeftUp()
        //{
        //    var walkInMatrix = new WalkInMatrix(5);
        //    ICoordinate expectedDirection = new Coordinate(-1, 0);
        //    ICoordinate direction = walkInMatrix.GetNextDirection(-1, -1);
        //    Assert.IsTrue(direction.Row == expectedDirection.Row && direction.Col == expectedDirection.Col);
        //}

        //[TestMethod]
        //public void GetNextDirectionTestUp()
        //{
        //    var walkInMatrix = new WalkInMatrix(5);
        //    ICoordinate expectedDirection = new Coordinate(-1, 1);
        //    ICoordinate direction = walkInMatrix.GetNextDirection(-1, 0);
        //    Assert.IsTrue(direction.Row == expectedDirection.Row && direction.Col == expectedDirection.Col);
        //}

        //[TestMethod]
        //public void GetNextDirectionTestDiagonalRightUp()
        //{
        //    var walkInMatrix = new WalkInMatrix(5);
        //    ICoordinate expectedDirection = new Coordinate(0, 1);
        //    ICoordinate direction = walkInMatrix.GetNextDirection(-1, 1);
        //    Assert.IsTrue(direction.Row == expectedDirection.Row && direction.Col == expectedDirection.Col);
        //}

        //[TestMethod]
        //public void GetNextDirectionTestRight()
        //{
        //    var walkInMatrix = new WalkInMatrix(5);
        //    ICoordinate expectedDirection = new Coordinate(1, 1);
        //    ICoordinate direction = walkInMatrix.GetNextDirection(0, 1);
        //    Assert.IsTrue(direction.Row == expectedDirection.Row && direction.Col == expectedDirection.Col);
        //}

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateMatrixWithZeroElementsTest()
        {
            var matrix = new WalkInMatrix(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateMatrixWithNegativeElementsTest()
        {
            var matrix = new WalkInMatrix(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateMatrixWith101Elements()
        {
            var matrix = new WalkInMatrix(101);
        }

        [TestMethod]
        public void OneDimentionTest()
        {
            var matrix = new WalkInMatrix(1);
            
            Assert.IsTrue(matrix.ToString() == string.Format(" 1\r\n"));
        }

        [TestMethod]
        public void TwoDimentionTest()
        {
            var matrix = new WalkInMatrix(2);
            
            Assert.IsTrue(matrix.ToString() == string.Format(" 1 4\r\n 3 2\r\n"));
        }

        [TestMethod]
        public void ThreeDimentionTest()
        {
            var matrix = new WalkInMatrix(3);
            
            Assert.IsTrue(matrix.ToString() == string.Format(" 1 7 8\r\n 6 2 9\r\n 5 4 3\r\n"));
        }

        [TestMethod]
        public void SixDimentionTest()
        {
            var matrix = new WalkInMatrix(6);
            
            Assert.IsTrue(matrix.ToString() == string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}\r\n{5}\r\n",
                                                            " 11617181920",
                                                            "15 227282921",
                                                            "1431 3263022",
                                                            "133632 42523",
                                                            "12353433 524",
                                                            "1110 9 8 7 6"));
        }
    }
}