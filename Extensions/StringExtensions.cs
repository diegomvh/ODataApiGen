static class StringExtensions
{
    public static string Dasherize(this string str)
    {
        if (str.Length > 3) {
            // Replace _ by -
            str = str.Replace("_", "-");
            // Replace Uppercase by -<Uppercase>
            str = string.Concat(str.Select((x, i) => char.IsUpper(x) && i != 0 ? $"-{x}" : x.ToString()));
            // Remove extra -
            str = string.Join("-", str.Split("-", StringSplitOptions.RemoveEmptyEntries));
        }
        return str.ToLower();
    }
}