using NUnit.Framework;

namespace NUnitCustomConstraintsTests
{
    using NUnitCustomConstraints;

    public class MathTest
    {
        [Test]
        public void TestAddStandard()
        {
            var sut = new Math();

            var res = sut.Add(42, 42);

            Assert.That(res, Is.EqualTo(84).Within(0.001));
        }


        [Test]
        public void TestAddCustom()
        {
            var sut = new Math();

            var res = sut.Add(42, 42);

            Assert.That(res, Is.Approx(84d));
        }

        [Test]
        public void TestAddCustom2()
        {
            var sut = new Math();

            var res = sut.Add(42, 42);

            Assert.That(res, Is.Approx2(84d));
        }


        [Test]
        public void TestAddCustom3()
        {
            var sut = new Math();

            var res = sut.Add(42, 42);

            Assert.That(res, Is.Not.Approx(80d));
        }


    }
}

