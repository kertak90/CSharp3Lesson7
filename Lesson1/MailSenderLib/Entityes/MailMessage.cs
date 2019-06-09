using MailSenderLib.Entityes.Base;
using System.ComponentModel.DataAnnotations;

namespace MailSenderLib.Entityes
{
    public class MailMessage : BaseEntity
    {
        [Required, MaxLength(256)]
        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
