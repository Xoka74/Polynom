using System.Text;
using System.Linq;

namespace polynomialRootSolve;

public class Polynom
{
    public Polynom(string polynom) => BuildPolynom(polynom);
    public double[] _values { get; set; }
    public Polynom Copy() => new Polynom(ToString());
    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int i = _values.Length - 1; i > 0; i--)
            if (_values[i] != 0)
                sb.Append($"({_values[i]})*x^{i} + ");
        return sb.ToString().TrimEnd('+', ' ');
    }

    public static Polynom operator *(Polynom pol, double mult)
    {
        var newPol = pol.Copy();
        for (var i = 0; i < newPol._values.Length; i++)
        {
            newPol._values[i] = newPol._values[i] * mult;
        }
    
        return newPol;
    }
    public static Polynom operator *(Polynom pol1, Polynom mult2)
    {
        // TODO: multiply polynoms
        throw new NotImplementedException();
    }

    public double GetValue(double x)
    {
        double total = 0;
        for (var i = 0; i < _values.Length; i++)
        {
            total += _values[i] * Math.Pow(x, i);
        }

        return total;
    }

    public double GetRootFromWolfram()
    {
        // TODO: Just funny thing in future to write http query 
        throw new NotImplementedException();
    }

    // public string GetRoot(double delta = 1e-6)
    // {
    //     var derivative = GetDerivative();
    //     double x = 10;
    //     for (int i = 0; i < 10_000; i++)
    //     {
    //         var calcValue = GetValue(x);
    //         x = x - (calcValue / derivative.GetValue(x));
    //         if (x == 0)
    //             x = 1e-9;
    //     }
    //
    //     if (Math.Abs(GetValue(x)) < delta)
    //         return x.ToString().Replace(",", ".");
    //     return "no roots";
    // }

    // public string GetRootsLaguerreMethod(int iterationsCount)
    // {
    //     var derivative = GetDerivative();
    //     var secondDerivative = derivative.GetDerivative();
    //     var x = 1.0;
    //     for (int k = 0; k < iterationsCount; k++)
    //     {
    //         var calcValue = GetValue(x);
    //         if (calcValue == 0)
    //             calcValue = 1e-3;
    //         var g = derivative.GetValue(x) / calcValue;
    //         var h = g * g - secondDerivative.GetValue(x) / calcValue;
    //         var n = GetMaxPow();
    //         var partOfFormula = Math.Sqrt((n - 1) * (n * h - g * g));
    //         var denominator = Math.Max(g - partOfFormula, g + partOfFormula);
    //         var a = n / denominator;
    //         x = x - a;
    //         if (a < 1e-9) break;
    //     }
    //
    //     return x.ToString();
    // }

    public Polynom GetDerivative()
    {
        var derivative = Copy();

        for (int i = 0; i < _values.Length; i++)
        {
            //     if (Pows[i] == 0)
            //         derivative.Pows.Remove(Pows[i]);
            //     derivative.Coefficients.Remove(Coefficients[i]);
            //     break;
            //
            //
            //     derivative.Pows[i] = Pows[i] - 1;
            //     derivative.Coefficients[i] = Coefficients[i] * Pows[i];
            // }
        }

        return derivative;
    }

    public int GetMaxPow() => _values.Length - 1;

    private void BuildPolynom(string polynom)
    {
        var elements = PreformatPolynom(polynom);
        var maxPow = FindMaxPow(elements);
        _values = new double[maxPow + 1];
        foreach (var element in elements)
        {
            var parts = element.Split('*', '^');
            if (element.ContainsAll('*', '^'))
            {
                var pow = int.Parse(parts[2]);
                _values[pow] += double.Parse(parts[0]);
            }
            else if (element.Contains('*'))
                _values[1] += double.Parse(parts[0]);
            else if (element.Contains('^'))
            {
                var pow = int.Parse(parts[1]);
                _values[pow] += 1.0;
            }
            else if (element == "x")
                _values[1] += 1;
            else
                _values[0] += double.Parse(parts[0]);
        }

        foreach (var val in _values)
        {
            Console.WriteLine(val);
        }
    }

    private int FindMaxPow(List<string> elements)
    {
        var maxPow = 0;
        var currentPow = "0";
        foreach (var elem in elements)
        {
            if (elem.Contains('x'))
            {
                if (elem.Contains('^'))
                    currentPow = elem.Split('^')[^1];
                else
                    currentPow = "1";
            }

            var curPowNumber = int.Parse(currentPow);
            if (maxPow < curPowNumber)
                maxPow = curPowNumber;
        }

        return maxPow;
    }
    private List<string> PreformatPolynom(string polynom)
    {
        var elements = polynom.Split(' ').Where(x => x is not "+" or "-").ToList();
        for (int i = 0; i < elements.Count; i++)
            elements[i] = elements[i].DeleteSymbols(")", "(").Replace('.', ',');

        return elements;
    }
}