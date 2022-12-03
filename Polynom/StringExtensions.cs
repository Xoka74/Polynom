using System;
using System.Collections.Generic;
using System.Text;

namespace polynomialRootSolve;

public static class StringExtensions
{
    public static string DeleteSymbols(this string str, params string[] symbols)
    {
        var sb = new StringBuilder(str);
        foreach (var symbol in symbols)
        {
            sb.Replace(symbol, "");
        }

        return sb.ToString();
    }
    public static string[] SplitWithSeparators(this string str, char[] separators)
    {
        if (str == null || separators == null)
            throw new ArgumentNullException();

        var parts = new List<string>();

        var token = new StringBuilder();
        for (var i = 0; i < str.Length; i++)
        {
            if (separators.ContainsAll(str[i]))
            {
                if (token.Length > 0)
                {
                    parts.Add(token.ToString());
                    token.Clear();
                }

                parts.Add(str[i].ToString());
            }
            else
            {
                token.Append(str[i]);
            }
        }

        if (token.Length > 0)
        {
            parts.Add(token.ToString());
        }

        return parts.ToArray();
    }
}