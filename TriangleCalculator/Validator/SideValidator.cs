namespace TriangleCalculator.Validator;

public class SideValidator : IInputValidator
{
    public bool Validate(double value)
    {
        double minVal = Math.Pow(10, -16);
        double maxVal = Math.Pow(10, 16);
        return value >= minVal && value <= maxVal && value > 0;
    }
}