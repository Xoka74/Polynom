using System.Text;
using System.Threading.Channels;

namespace polynomialRootSolve;

public static class Program
{
    public static void Main()
    {
        var x = new Polynom("x^5 + (-48.800000000000004)*x^4 + 47.300000000000004*x^3 + 38.6*x + x + 22");
    }
}