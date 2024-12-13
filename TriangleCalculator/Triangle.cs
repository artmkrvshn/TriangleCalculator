namespace TriangleCalculator;

public class Triangle(double a, double da, double b, double db, double c, double dc)
{
    private readonly double A = a;
    private readonly double dA = da;
    private readonly double B = b;
    private readonly double dB = db;
    private readonly double C = c;
    private readonly double dC = dc;

    public double ComputeArea()
    {
        double p = (A + B + C) / 2.0;
        double area = p * (p - A) * (p - B) * (p - C);
        return area > 0 ? Math.Sqrt(area) : 0;
    }

    public double EstimateAreaError()
    {
        double relErrorA = dA / A;
        double relErrorB = dB / B;
        double relErrorC = dC / C;
        double avgRelError = (relErrorA + relErrorB + relErrorC) / 3.0;
        return ComputeArea() * avgRelError;
    }
}