namespace polynomialRootSolve;

public partial class Polynom
{
    public static bool operator ==(Polynom left, Polynom right) => Equals(left, right);
    public static bool operator !=(Polynom left, Polynom right) => !(left == right);
    public static Polynom operator *(Polynom left, double mult)
    {
        var members = (double[])left.Members.Clone();
        for (var i = 0; i < members.Length; i++)
            members[i] = left.Members[i] * mult;

        return new Polynom(members);
    }
    public static Polynom operator *(Polynom left, Polynom right)
    {
        var pol1Length = left.Members.Length;
        var pol2Length = right.Members.Length;
        var members = new double[pol1Length + pol2Length];
        for (int i = 0; i < pol1Length; i++)
        for (int j = 0; j < pol2Length; j++)
            members[i + j] += left.Members[i] * right.Members[j];

        return new Polynom(members);
    }

    public static Polynom operator +(Polynom left, Polynom right)
    {
        var pol1Length = left.Members.Length;
        var pol2Length = right.Members.Length;
        var members = new double[Math.Max(pol1Length, pol2Length)];
        for (int i = 0; i < pol1Length; i++)
            members[i] += left.Members[i];
        for (int j = 0; j < pol2Length; j++)
            members[j] += right.Members[j];
        
        return new Polynom(members);
    }
    public static Polynom operator -(Polynom left, Polynom right)
    {
        // TODO: substracting polynoms
        throw new NotImplementedException();
    }

    public static Polynom operator /(Polynom left, Polynom right)
    {
        // TODO : dividing polynoms
        // Examples:
        // (8t^2 + 10t - 3)
        // (2t + 3)
        throw new NotImplementedException();
    }

}