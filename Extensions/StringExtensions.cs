static class StringExtensions
{
    public static string Dasherize(this string str)
    {
        return string
           .Concat(str
           .Select((x, i) => char.IsUpper(x) && i != 0 ? $"-{x}" : x.ToString()))
           .ToLower();
    }
}