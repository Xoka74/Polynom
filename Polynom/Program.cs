using System.Text;
using System.Threading.Channels;
namespace polynomialRootSolve;

public static class Program
{
    public static void Main()
    {
        var a = Polynom.BuildPolynomByString("0");
        var b = Polynom.BuildPolynomByString("1");
        Console.WriteLine(a + b);
    }
}