using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Wego.Application.Models.Authentification
{
    public class JwtTokenModel
    {
        public string? AccessToken { get; set; }

        public string? TokenType { get; set; }

        public int ExpiresIn { get; set; }

        public string? RefreshToken { get; set; }
    }
}
