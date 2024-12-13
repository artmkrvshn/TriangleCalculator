namespace TriangleCalculator.Validator;

public class ErrorValidator(double side) : IInputValidator
{
    public bool Validate(double value)
    {
        double minVal = Math.Pow(10, -16);
        if (value < minVal || value > side)
        {
            return false;
        }
        double relError = value / side;
        return relError >= Math.Pow(10, -16) && relError < 1;
    }
}