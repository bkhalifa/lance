using System.Text;

namespace Wego.Domain.Profile;

public class ProfileModel
{
    public long Id { get; set; }
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string InitialUserName { get; set; }
    public string Email { get; set; }
    public int? PhoneNumber { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string UsId { get; private set; }
    public string Position { get; set; }

    public ProfileModel()
    {
        
    }
    public ProfileModel(string id, string email)
    {
        UserId = id;
        Email = email;
        UsId = SplitMail(email)+ GetRandomId();
        InitialUserName = GetInitials(email);
    }

    public string SetUsId()
    {
        return UsId + GenerateRandomNumber();
    }
    public int GenerateRandomNumber() => Random.Shared.Next(1, 9);
    public static string SplitMail(string adressMail)
    {
        var mail = adressMail.Split('@');
        var result = string.Empty;
        // Split authors separated by a comma followed by space  
        string[] multiArray = mail[0].Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });

        foreach (var item in multiArray)
        {
            if (item.Trim() != "")
                result += item;
        }
        return result;
    }
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
    public static string GetInitials(string value)
       => string.Concat(value
          .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
          .Where(x => x.Length >= 1 && char.IsLetter(x[0]))
          .Select(x => char.ToUpper(x[0])));
}
