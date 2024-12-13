namespace TriangleCalculator;

public class Triangle(double a, double da, double b, double db, double c, double dc)
{
    public double ComputeArea()
    {
        double p = (a + b + c) / 2.0;
        double area = p * (p - a) * (p - b) * (p - c);
        return area > 0 ? Math.Sqrt(area) : 0;
    }

    public double EstimateAreaError()
    {
        double relErrorA = da / a;
        double relErrorB = db / b;
        double relErrorC = dc / c;
        double avgRelError = (relErrorA + relErrorB + relErrorC) / 3.0;
        return ComputeArea() * avgRelError;
    }
}