using System.Text;

namespace polynomialRootSolve;

public static class Extensions
{
    public static void PrintList<T>(this List<T> list)
    {
        var sb = new StringBuilder("{   ");
        foreach (var item in list)
        {
            sb.Append($"{item}   ");
        }

        sb.Append("}");
        Console.WriteLine(sb);
    }

    public static void PrintArray<T>(this T[] array)
    {
        var sb = new StringBuilder("{   ");
        foreach (var item in array)
        {
            sb.Append($"{item}   ");
        }

        sb.Append("}");
        Console.WriteLine(sb);
    }

    public static bool ContainsAll(this IEnumerable<char> array, params char[] symbols)
    {
        foreach (var symbol in symbols)
            if (!array.Contains(symbol))
                return false;

        return true;
    }
}