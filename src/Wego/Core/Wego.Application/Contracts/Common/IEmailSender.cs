using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wego.Application.Models.Mail;

namespace Wego.Application.Contracts.Common
{
    public interface IEmailSender
    {
        Task<bool> SendMailAsync(Email mailData, CancellationToken ct = default);
    }
}
