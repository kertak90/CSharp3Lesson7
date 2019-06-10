using MailSenderLib.Data.EF;
using MailSenderLib.Entityes.Base;
using MailSenderLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Services.EF
{
    public abstract class DataInEF<T> : IDataService<T> where T : BaseEntity
    {
        private MailSenderDBContext _db;
        private DbSet<T> _DbSet;

        public IEnumerable<T> GetAll() => _DbSet.AsEnumerable();

        protected DataInEF(MailSenderDBContext db)
        {
            _db = db;
            var db_set = db.Set<T>();
        }

        public int Add(T item)
        {
            if (_DbSet.Any(p=>p.Id == item.Id)) return item.Id;
            _DbSet.Add(item);
            return item.Id;
        }

        public abstract void Edit(T recipient);

        public T GetById(int id) => _DbSet.FirstOrDefault(p => p.Id == id);

        public void Remove(int id)
        {
            var db_item = GetById(id);
            if (db_item != null)
                _DbSet.Remove(db_item);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }

}
