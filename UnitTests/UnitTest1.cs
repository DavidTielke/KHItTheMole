using System;
using System.Drawing;
using HitTheMole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var length = 2.8284*2;
            var angle = 45.0;
            var vector = new Vector2D(angle, length);

            var point = vector.MovePoint(new Point(0, 0));

            Assert.AreEqual(4, point.X);
            Assert.AreEqual(4, point.Y);
        }
    }
}
