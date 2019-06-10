using MailSenderLib.Entityes.Base;
using MailSenderLib.Linq2SQL;
using System.Collections.Generic;

namespace MailSenderLib.Entityes
{
    public class RecipientsList : NamedEntity
    {
        public virtual IEnumerable<Recipient> Recipients { get; set; }
    }
}
