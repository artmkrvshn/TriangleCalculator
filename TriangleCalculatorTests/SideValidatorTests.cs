using TriangleCalculator.Validator;

namespace TriangleCalculatorTests;

[TestFixture]
public class SideValidatorTests
{
    [Test]
    public void Validate_ValidSide_ReturnsTrue()
    {
        var validator = new SideValidator();
        Assert.That(validator.Validate(3), Is.True);
    }

    [Test]
    public void Validate_InvalidSide_ReturnsFalse()
    {
        var validator = new SideValidator();
        Assert.That(validator.Validate(-1), Is.False);
        Assert.That(validator.Validate(Math.Pow(10, 17)), Is.False);
    }
}