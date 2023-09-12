namespace Wego.Identity.Helpers
{
    public static class IdentityHelpers
    {

        public static string GetInitials(this string value)
              => string.Concat(value
                 .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Where(x => x.Length >= 1 && char.IsLetter(x[0]))
                 .Select(x => char.ToUpper(x[0])));
        public static string Base64Encode(string text)
        {
            var textBytes = System.Text.Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(textBytes);
        }
        public static string Base64Decode(string base64)
        {
            var base64Bytes = System.Convert.FromBase64String(base64);
            return System.Text.Encoding.UTF8.GetString(base64Bytes);
        }
    }
}
