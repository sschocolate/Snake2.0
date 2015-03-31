using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake2._0;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSnakeEat()
        {
            Player player = new Player();
            int i = Player.snake.Count;
            Assert.AreEqual(i, 3);
        }
    }
}
