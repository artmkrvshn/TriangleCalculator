using TriangleCalculator;

namespace TriangleCalculatorTests;

[TestFixture]
public class TriangleTests
{
    [Test]
    public void ComputeArea_ValidTriangle_ReturnsCorrectArea()
    {
        var triangle = new Triangle(3, 0.1, 4, 0.1, 5, 0.1);
        double area = triangle.ComputeArea();
        Assert.That(area, Is.EqualTo(6).Within(1e-5));
    }

    [Test]
    public void ComputeArea_DegenerateTriangle_ReturnsZero()
    {
        var triangle = new Triangle(1, 0.1, 2, 0.1, 3, 0.1);
        double area = triangle.ComputeArea();
        Assert.That(area, Is.EqualTo(0).Within(1e-5));
    }

    [Test]
    public void EstimateAreaError_ValidTriangle_ReturnsErrorEstimate()
    {
        var triangle = new Triangle(3, 0.1, 4, 0.1, 5, 0.1);
        double error = triangle.EstimateAreaError();
        Assert.That(error, Is.GreaterThan(0));
    }
}