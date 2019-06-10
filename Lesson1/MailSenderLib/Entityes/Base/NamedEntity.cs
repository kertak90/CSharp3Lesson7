using System.ComponentModel.DataAnnotations;

namespace MailSenderLib.Entityes.Base
{
    public abstract class NamedEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
