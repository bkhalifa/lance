using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wego.Application.Models.Chat
{
    public class CandidateModel
    {
        public long Id { get; set; }

        public long ProfileId { get; set; }

        public string CandidateName { get; set; }

        public string CandidateEmail { get; set; }

        public bool IsConnected { get; set; }
    }
}
