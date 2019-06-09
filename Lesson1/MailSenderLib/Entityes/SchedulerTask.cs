using MailSenderLib.Entityes.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailSenderLib.Entityes
{
    [Table("SchedulerTask")]
    public class SchedulerTask : BaseEntity
    {
        
        public DateTime? Time { get; set; }
        [Required]
        public virtual Sender Sender { get; set; }
        [Required]
        public virtual RecipientsList Recipients { get; set; }
        [Required]
        public virtual MailList Messages { get; set; }
        [Required]
        public virtual Server Server { get; set; }
    }
}
