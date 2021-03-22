using System;
using testmylearning.handlers;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTest()
        {
            Logic a = new Logic();
            float aa = a.Check(100, 100, "deposit");
            Assert.Equal(200,aa);
        }

        [Fact]

        public void falingTest()
        {
            Logic a = new Logic();
            float aa = a.Check(10, 100, "deposit");
            Assert.NotEqual(200, aa);
        }

       
    }
}
