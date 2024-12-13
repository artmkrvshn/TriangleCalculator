using TriangleCalculator.Validator;

namespace TriangleCalculator;

internal static class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Program to calculate the area of a triangle with error margins.");

            IInputValidator sideValidator = new SideValidator();

            double sideA = InputAndValidate("A", sideValidator,
                "Enter the length of side A (from 10^-16 to 10^16, >0): ");
            double dA = InputAndValidate("dA", new ErrorValidator(sideA),
                "Enter the absolute error for A (dA): ");

            double sideB = InputAndValidate("B", sideValidator,
                "Enter the length of side B (from 10^-16 to 10^16, >0): ");
            double dB = InputAndValidate("dB", new ErrorValidator(sideB),
                "Enter the absolute error for B (dB): ");

            double sideC = InputAndValidate("C", sideValidator,
                "Enter the length of side C (from 10^-16 to 10^16, >0): ");
            double dC = InputAndValidate("dC", new ErrorValidator(sideC),
                "Enter the absolute error for C (dC): ");

            Triangle triangle = new(sideA, dA, sideB, dB, sideC, dC);

            double area = triangle.ComputeArea();
            double dS = triangle.EstimateAreaError();

            if (area <= 0)
            {
                Console.WriteLine("The triangle is degenerate (area ≈ 0). ");
            }
            else
            {
                Console.WriteLine($"Triangle area: {area:F5} ± {dS:F5}");
                Console.WriteLine(area - dS <= 0
                    ? "Considering errors, the triangle might be degenerate."
                    : "The triangle is non-degenerate considering errors.");
            }

            Console.WriteLine("Choose an action: (R) Repeat calculation, (Q) Quit");
            string? choice = Console.ReadLine();
            if (choice?.ToUpper() == "Q")
            {
                break;
            }
        }
    }

    private static double InputAndValidate(string paramName, IInputValidator validator, string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (double.TryParse(input, out double value))
            {
                if (validator.Validate(value))
                {
                    return value;
                }

                Console.WriteLine($"Error: Invalid value for {paramName}. Try again.");
            }
            else
            {
                Console.WriteLine($"Format error: {paramName} must be a number.");
            }
        }
    }
}