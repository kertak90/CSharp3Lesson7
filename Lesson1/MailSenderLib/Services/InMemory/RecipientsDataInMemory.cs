﻿using MailSenderLib.Entityes;

using MailSenderLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Services.InMemory
{
    public class RecipientsDataInMemory : DataInMemory<Recipient>, IRecepientsData
    {
        public RecipientsDataInMemory()
        {
            _Items.AddRange(TestData.Senders.Select((s, i) => new Recipient { Id = i+1, Name = s.Name, Email = s.Email}));
        }

        public override void Edit(Recipient item)
        {
            var db_item = GetById(item.Id);
            if (db_item is null || ReferenceEquals(db_item, item))
                return;
            db_item.Name = item.Name;
            db_item.Email = item.Email;
        }
    }

}
