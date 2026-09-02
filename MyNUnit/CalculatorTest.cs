using calculator;
using NUnit.Framework.Legacy; 
namespace MyNUnit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Calculator calc = new Calculator();
            int res = calc.Add(10, 10);

            //ClassicAssert.AreEqual(res, 30);
            //Assert.That(res, Is.EqualTo(200));

            Assert.Multiple(() =>
            {
                Assert.That(res, Is.EqualTo(20));
                //Assert.That(res, Is.EqualTo(200));
                Assert.That(res, Is.EqualTo(20));
            });
        }
    }
}
