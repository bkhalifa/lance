using System.Text;

namespace Wego.Identity.Helpers
{
    public static class IdentityHelpers
    {
        public static string GetRandomId()
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
        .Select(e => ((char)e).ToString())
        .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
        .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
        .OrderBy(e => Guid.NewGuid())
        .Take(11)
        .ToList().ForEach(e => builder.Append(e));
            string id = builder.ToString();

            return id.ToLower();
        }
        public static string SplitMail(this string adressMail)
        {
            var mail = adressMail.Split('@');
            var result = string.Empty;
            // Split authors separated by a comma followed by space  
            string[] multiArray = mail[0].Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });

            foreach (var item in multiArray)
            {
                if (item.Trim() != "")
                    result += item + "-";
            }
            return result;
        }
        public static string GetInitials(this string value)
               => string.Concat(value
                  .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                  .Where(x => x.Length >= 1 && char.IsLetter(x[0]))
                  .Select(x => char.ToUpper(x[0])));
    }
}
