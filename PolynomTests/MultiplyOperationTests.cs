namespace PolynomTests;

public class MultiplyOperationTests
{
    [TestCase("8*x^5 + (-7)*x^4 + 3*x^3 + (-4)*x^2 + 2*x + 1",
        "15*x^8 + (-34)*x^52 + 43*x",
        "(-272)*x^57 + 238*x^56 + (-102)*x^55 + 136*x^54 + (-68)*x^53 + (-34)*x^52 + 120*x^13 + (-105)*x^12 + 45*x^11 + (-60)*x^10 + 30*x^9 + 15*x^8 + 344*x^6 + (-301)*x^5 + 129*x^4 + (-172)*x^3 + 86*x^2 + 43*x")]
    [TestCase("10", "20", "200")]
    [TestCase("300", "x", "300*x")]
    [TestCase("0", "0", "0")]
    [TestCase("0", "x^2", "0")]
    [TestCase("1", "x^3 + 10*x^2 + 50*x + 56", "x^3 + 10*x^2 + 50*x + 56")]
    public void TestMultiplyOperation(string polynom1, string polynom2, string expectedResult)
    {
        var result = Polynom.BuildPolynomByString(polynom1) * Polynom.BuildPolynomByString(polynom2);
        Assert.AreEqual(expectedResult, result.ToString());
    }
}