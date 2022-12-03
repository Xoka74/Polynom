using System.Text;
using System.Linq;

namespace polynomialRootSolve;

public class Polynom
{
    public Polynom(string polynom = null)
    {
        if (polynom != null)
            BuildPolynomByString(polynom);
    }

    public double[] _members { get; set; }

    public Polynom Copy()
    {
        var newPolynom = new Polynom();
        newPolynom._members = this._members;
        return newPolynom;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int i = _members.Length - 1; i >= 0; i--)
            if (_members[i] != 0)
                sb.Append($"({_members[i]})*x^{i} + ");

        return sb.ToString().TrimEnd('+', ' ');
    }

    public int GetMaxPow() => _members.Length - 1;

    public static Polynom operator *(Polynom pol, double mult)
    {
        var newPol = pol.Copy();
        for (var i = 0; i < newPol._members.Length; i++)
        {
            newPol._members[i] = newPol._members[i] * mult;
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
        for (var i = 0; i < _members.Length; i++)
        {
            total += _members[i] * Math.Pow(x, i);
        }

        return total;
    }

    public double GetRootFromWolfram()
    {
        // TODO: Just funny thing in future to write http query 
        throw new NotImplementedException();
    }

    public string GetRoot(double delta = 1e-6)
    {
        var derivative = GetDerivative();
        double x = 10;
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
        var derivative = GetDerivative();
        var secondDerivative = derivative.GetDerivative();
        var x = 1.0;
        for (int k = 0; k < iterationsCount; k++)
        {
            var calcValue = GetValue(x);
            if (calcValue == 0)
                calcValue = 1e-3;
            var g = derivative.GetValue(x) / calcValue;
            var h = g * g - secondDerivative.GetValue(x) / calcValue;
            var n = GetMaxPow();
            var partOfFormula = Math.Sqrt((n - 1) * (n * h - g * g));
            var denominator = Math.Max(g - partOfFormula, g + partOfFormula);
            var a = n / denominator;
            x = x - a;
            if (a < 1e-9) break;
        }

        return x.ToString();
    }

    public Polynom GetDerivative()
    {
        var derivative = new Polynom();
        derivative._members = new double[GetMaxPow()];
        for (int i = _members.Length - 2; i >= 0; i--)
            derivative._members[i] = _members[i + 1] * (i + 1);
        return derivative;
    }

    private void BuildPolynomByString(string polynom)
    {
        var elements = PreformatPolynom(polynom);
        var maxPow = FindMaxPow(elements);
        _members = new double[maxPow + 1];
        foreach (var element in elements)
        {
            var parts = element.Split('*', '^');
            if (element.ContainsAll('*', '^'))
            {
                var pow = int.Parse(parts[2]);
                _members[pow] += double.Parse(parts[0]);
            }
            else if (element.Contains('*'))
                _members[1] += double.Parse(parts[0]);
            else if (element.Contains('^'))
            {
                var pow = int.Parse(parts[1]);
                _members[pow] += 1.0;
            }
            else if (element == "x")
                _members[1] += 1;
            else
                _members[0] += double.Parse(parts[0]);
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