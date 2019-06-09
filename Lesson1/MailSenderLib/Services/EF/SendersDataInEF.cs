using MailSenderLib.Data.EF;
using MailSenderLib.Entityes;
using MailSenderLib.Services.Interfaces;

namespace MailSenderLib.Services.EF
{
    public class SendersDataInEF : DataInEF<Sender>, ISendersData
    {
        public SendersDataInEF(MailSenderDBContext db) : base(db)
        {
        }

        public override void Edit(Sender item)
        {
            var db_item = GetById(item.Id);
            if (db_item is null) return;
            db_item.Name = item.Name;
            db_item.Email = item.Email;
        }
    }

}
