using MailSenderLib.Entityes.Base;
using System.Collections.Generic;

namespace MailSenderLib.Entityes
{
    public class MailList : NamedEntity
    {

        public virtual IEnumerable<MailMessage> Messages { get; set; }
    }
}
