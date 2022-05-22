using System;
using Xunit;

namespace BatoaneCiocolata.Tests
{
    public class BatoaneCiocolataTests
    {
        int[] ciocolatePackages = new int[] { 1, 2, 3, 5, 10 };
        [Fact]
        public void Test1()
        {
            int number = 7;
            Assert.Equal(3, Program.GetHighestValueIndex(number, ciocolatePackages));
        }

        [Fact]
        public void Test2()
        {
            int index = 2;
            int[] ciocolate = new int[] { 1, 2, 5, 10 };
            Assert.Equal(ciocolate, Program.RemoveElementFromArrayAtGivenIndex(ciocolatePackages, index));
        }
    }
}
