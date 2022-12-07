namespace polynomialRootSolve;

public partial class Polynom
{
    public double GetRootFromWolfram()
    {
        // TODO: Just funny thing in future to write http query 
        throw new NotImplementedException();
    }

    public string GetRoot(double delta = 1e-3)
    {
        var derivative = GetDerivative();
        double x = 1;
        for (int i = 0; i < 10_000; i++)
        {
            var calcValue = GetValue(x);
            x = x - (calcValue / derivative.GetValue(x));
            if (x == 0)
                x = 1e-9;
        }

        if (Math.Abs(GetValue(x)) < delta)
            return x.ToString().Replace(",", ".");
        return "no roots";
    }

    public string GetRootsLaguerreMethod(int iterationsCount)
    {
        // TODO: Getting roots with Laguerre Method
        // var derivative = GetDerivative();
        // var secondDerivative = derivative.GetDerivative();
        // var x = 1.0;
        // for (int k = 0; k < iterationsCount; k++)
        // {
        //     var calcValue = GetValue(x);
        //     if (calcValue == 0)
        //         calcValue = 1e-3;
        //     var g = derivative.GetValue(x) / calcValue;
        //     var h = g * g - secondDerivative.GetValue(x) / calcValue;
        //     var n = GetMaxPow();
        //     var partOfFormula = Math.Sqrt((n - 1) * (n * h - g * g));
        //     var denominator = Math.Max(g - partOfFormula, g + partOfFormula);
        //     var a = n / denominator;
        //     x = x - a;
        //     if (a < 1e-9) break;
        // }

        // return x.ToString();
        throw new NotImplementedException();
    }
}