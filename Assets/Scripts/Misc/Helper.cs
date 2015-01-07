using System.Collections;
using System.Text.RegularExpressions;

public static class Helper
{
    public static string SplitCamelCase(string str)
    {
        return Regex.Replace(
            Regex.Replace(
                str,
                @"(\P{Ll})(\P{Ll}\p{Ll})",
                "$1 $2"
            ),
            @"(\p{Ll})(\P{Ll})",
            "$1 $2"
        );
    }
}
