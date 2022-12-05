namespace polynomialRootSolve;

public partial class Polynom
{
    public static Polynom operator *(Polynom pol, double mult)
    {
        var members = (double[])pol.Members.Clone();
        for (var i = 0; i < members.Length; i++)
            members[i] = pol.Members[i] * mult;

        return new Polynom(members);
    }
    public static Polynom operator *(Polynom pol1, Polynom pol2)
    {
        var pol1Length = pol1.Members.Length;
        var pol2Length = pol2.Members.Length;
        var members = new double[pol1Length + pol2Length];
        for (int i = 0; i < pol1Length; i++)
        for (int j = 0; j < pol2Length; j++)
            members[i + j] += pol1.Members[i] * pol2.Members[j];

        return new Polynom(members);
    }

    public static Polynom operator +(Polynom pol1, Polynom pol2)
    {
        var pol1Length = pol1.Members.Length;
        var pol2Length = pol2.Members.Length;
        var members = new double[Math.Max(pol1Length, pol2Length)];
        for (int i = 0; i < pol1Length; i++)
            members[i] += pol1.Members[i];
        for (int j = 0; j < pol2Length; j++)
            members[j] += pol2.Members[j];
        
        return new Polynom(members);
    }
    public static Polynom operator -(Polynom pol1, Polynom pol2)
    {
        // TODO: substracting polynoms
        throw new NotImplementedException();
    }

    public static bool operator ==(Polynom pol1, Polynom pol2) => Equals(pol1, pol2);
    public static bool operator !=(Polynom pol1, Polynom pol2) => !(pol1 == pol2);
}