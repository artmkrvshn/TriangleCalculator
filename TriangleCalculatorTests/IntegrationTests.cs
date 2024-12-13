using TriangleCalculator;
using TriangleCalculator.Validator;

namespace TriangleCalculatorTests;

[TestFixture]
public class IntegrationTests
{
    [Test]
    public void FullIntegrationTest_ValidInputs_CalculatesCorrectly()
    {
        var sideValidator = new SideValidator();
        var errorValidator = new ErrorValidator(5);

        Assert.That(sideValidator.Validate(3), Is.True);
        Assert.That(errorValidator.Validate(0.5), Is.True);

        var triangle = new Triangle(3, 0.1, 4, 0.1, 5, 0.1);
        double area = triangle.ComputeArea();
        double error = triangle.EstimateAreaError();

        Assert.That(area, Is.EqualTo(6).Within(1e-5));
        Assert.That(error, Is.GreaterThan(0));
    }
}
