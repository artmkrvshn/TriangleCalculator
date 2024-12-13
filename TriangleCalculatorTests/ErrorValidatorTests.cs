using TriangleCalculator.Validator;

namespace TriangleCalculatorTests;

[TestFixture]
public class ErrorValidatorTests
{
    [Test]
    public void Validate_ValidError_ReturnsTrue()
    {
        var validator = new ErrorValidator(10);
        Assert.That(validator.Validate(1), Is.True);
    }

    [Test]
    public void Validate_InvalidError_ReturnsFalse()
    {
        var validator = new ErrorValidator(10);
        Assert.That(validator.Validate(11), Is.False);
        Assert.That(validator.Validate(0), Is.False);
    }
}
