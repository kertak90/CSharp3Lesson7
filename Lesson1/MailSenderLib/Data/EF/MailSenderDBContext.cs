using MailSenderLib.Data.EF.Migrations;
using MailSenderLib.Entityes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MailSenderLib.Data.EF
{
    //Активировать миграции
    //Enable-Migrations -StartUpProjectName MailSenderLib -MigrationsDirectory Data\EF\Migrations
    //Добавить миграцию
    //Add-Migration Initial -StartUpProjectName Lesson2
    //Применить миграцию и обновить базу данных
    //Update-Database -StartUpProjectName Lesson2 -v
    //Применить конкретную миграцию, можно использовать для отката изменений
    //Update-Database -StartUpProjectName Lesson2 -v -TargetMigration RecipientAddDescription

    public class MailSenderDBContext : DbContext
    {
        //static MailSenderDBContext() => System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseAlways<MailSenderDBContext>());
        //static MailSenderDBContext() => System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<MailSenderDBContext>());
        //static MailSenderDBContext() => System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MailSenderDBContext>());
        static MailSenderDBContext() => System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<MailSenderDBContext, Migrations.Configuration>());

        public void MigrateTolatestVersion()
        {
            var migrator = new DbMigrator(new Configuration());
            foreach(var pending_migration in migrator.GetPendingMigrations())
            {
                Debug.WriteLine($"migration{pending_migration}");
            }
            //migrator.Update("Имя миграции");
            migrator.Update();
        }

        public DbSet<Sender> Senders { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<RecipientsList> RecipientsLists { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<SchedulerTask> ShedulerTasks { get; set; }
        public DbSet<MailMessage> MailMessages { get; set; }
        public DbSet<MailList> MailLists { get; set; }



        public MailSenderDBContext() : this("name=MailSenderDBContext") { }
        public MailSenderDBContext(string ConnectionString) : base(ConnectionString) { }
    }
}
