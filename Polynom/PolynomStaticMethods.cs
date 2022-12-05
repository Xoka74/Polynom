namespace polynomialRootSolve;

public partial class Polynom
{
    public static Polynom BuildPolynomByString(string polynom)
    {
        var elements = PreformatPolynom(polynom);
        var maxPow = FindMaxPow(elements);
        var members = new double[maxPow + 1];
        foreach (var element in elements)
        {
            var parts = element.Split('*', '^');
            if (element.ContainsAll('*', '^'))
            {
                var pow = int.Parse(parts[2]);
                members[pow] += double.Parse(parts[0]);
            }
            else if (element.Contains('*'))
                members[1] += double.Parse(parts[0]);
            else if (element.Contains('^'))
            {
                var pow = int.Parse(parts[1]);
                members[pow] += 1.0;
            }
            else if (element == "x")
                members[1] += 1;
            else
                members[0] += double.Parse(parts[0]);
        }

        return new Polynom(members);
    }

    private static int FindMaxPow(List<string> elements)
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

    private static List<string> PreformatPolynom(string polynom)
    {
        var elements = polynom.Split(' ').ToList();
        elements.RemoveAll(x => x == "+" || x == "-");
        for (int i = 0; i < elements.Count; i++)
            elements[i] = elements[i].DeleteSymbols(")", "(").Replace('.', ',');

        return elements;
    }
}