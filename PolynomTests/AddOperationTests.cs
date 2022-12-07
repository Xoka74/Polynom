namespace PolynomTests;

[TestFixture]
public class PolynomTests
{
    [TestCase("5*x^6 + 10*x^3 + 7*x^2 + 15*x + 20",
        "36*x^2 + 80*x^7 + 20*x^20 + 10", 
        "20*x^20 + 80*x^7 + 5*x^6 + 10*x^3 + 43*x^2 + 15*x + 30")]
    [TestCase("x","x", "2*x")]
    [TestCase("1", "0", "1")]
    [TestCase("1", "-1", "")]
    [TestCase("x", "1", "x + 1")]
    [TestCase("x + 10", "300*x + 300", "301*x + 310")]
    public void TestAddOperation(string polynom1, string polynom2, string expectedResult)
    {
        var result = Polynom.BuildPolynomByString(polynom1) + Polynom.BuildPolynomByString(polynom2);
        Assert.AreEqual(expectedResult, result.ToString());
    }
}