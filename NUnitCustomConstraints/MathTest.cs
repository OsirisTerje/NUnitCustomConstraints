using NUnit.Framework;
using NUnit.Framework.Constraints;

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

namespace NUnitCustomConstraints
    {
        /// <summary>
        /// Generic way of extending by using the inherent constraints
        /// </summary>
        public class DoubleVerification : Constraint
    {
        private const double DefaultPrecision = 0.0001;

        public DoubleVerification(double expected) : base(expected)
        {
        }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            return NUnit.Framework.Is.EqualTo(Arguments[0]).Within(DefaultPrecision).ApplyTo(actual);
        }

    }

    /// <summary>
    /// Option 2, which matches this case and similar
    /// </summary>
    public class DoubleVerification2 : EqualConstraint
    {
        private const double DefaultPrecision = 0.0001;

        public DoubleVerification2(double expected) : base(expected)
        {
            Within(DefaultPrecision);
        }


    }

    



/// <summary>
    /// This extends the Is functionality
    /// </summary>
    public class Is : NUnit.Framework.Is
    {
        public static DoubleVerification Approx(double expected)
        {
            return new DoubleVerification(expected);
        }

        public static DoubleVerification2 Approx2(double expected)
        {
            return new DoubleVerification2(expected);
        }
    }


    /// <summary>
    /// This allows for chaining
    /// </summary>
    public static class SimVerifications
    {
        public static DoubleVerification Approx(this ConstraintExpression expression, double expected)
        {
            var constraint = new DoubleVerification(expected);
            expression.Append(constraint);
            return constraint;
        }
    }





}
