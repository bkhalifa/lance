using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wego.Application.Models.Chat
{
    public class MessageModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public int ProfileFromId { get; set; }

        public int ProfileToId { get; set; }

        public string MsgContent { get; set; }

        public bool IsOpen { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
