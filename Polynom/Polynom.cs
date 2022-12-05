using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace polynomialRootSolve;

public partial class Polynom
{
    private Polynom(double[] members) => Members = members;
    public Polynom Copy() => new Polynom(Members);
    public bool Equals(Polynom pol) => Equals(this, pol);
    private double[] _members;

    public double[] Members
    {
        get => _members;
        private set => _members = value;
    }

    public double this[int i]
    {
        get => _members[i];
    }

    private int _maxPow { get; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int i = Members.Length - 1; i > 1; i--)
        {
            if (Members[i] == 0) continue;
            if (Members[i] > 0)
                sb.Append($"{Members[i]}*x^{i} + ");
            else
                sb.Append($"({Members[i]})*x^{i} + ");
        }

        if (Members[1] != 0)
        {
            if (Members[1] > 0)
                sb.Append($"{Members[1]}*x + ");
            else
                sb.Append($"({Members[1]})*x + ");
        }

        if (Members[0] != 0)
        {
            if (Members[0] > 0)
                sb.Append($"{Members[0]} + ");
            else
                sb.Append($"({Members[0]}) + ");
        }

        return sb.ToString().TrimEnd('+', ' ');
    }

    public double GetValue(double x)
    {
        double total = 0;
        for (var i = 0; i < Members.Length; i++)
            total += Members[i] * Math.Pow(x, i);

        return total;
    }

    public Polynom GetDerivative()
    {
        var derivativeMembers = new double[_maxPow];
        for (int i = derivativeMembers.Length - 2; i >= 0; i--)
            derivativeMembers[i] = Members[i + 1] * (i + 1);
        return new Polynom(derivativeMembers);
    }

    public static bool Equals(Polynom pol1, Polynom pol2)
    {
        var pol1Length = pol1.Members.Length;
        var pol2Length = pol1.Members.Length;
        if (pol1Length != pol2Length) return false;
        for (int i = 0; i < pol1Length; i++)
            if (!(pol1[i] == pol2[i]))
                return false;
        
        return true;
    }
}