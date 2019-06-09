namespace MailSenderLib.Data.EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MailSenderLib.Data.EF.MailSenderDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"Data\EF\Migrations";
        }

        protected override void Seed(MailSenderDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (!context.MailMessages.Any())
                context.MailMessages.AddRange(Enumerable.Range(1, 20).Select(i => new Entityes.MailMessage
                {
                    Subject = $"Message {i}",
                    Body = $"Message body {i}"              
                }));

            if (!context.Servers.Any())
                context.Servers.AddRange(Enumerable.Range(1, 5).Select(i => new Entityes.Server
                {
                   Name = $"Test server {i}",
                   Address = $"smtp.Server{i}.ru",
                   Port = 25,
                   Login = $"ServerLogin{i}",
                   Password = $"ServerPassword{i}"
                }));
            if (!context.Senders.Any())
                context.Senders.AddRange(Enumerable.Range(1, 5).Select(i => new Entityes.Sender
                {
                   Name = $"Sender {i}",
                   Email = $"sender{i}@server.ru",
                }));
            if (!context.Recipients.Any())
                context.Recipients.AddRange(Enumerable.Range(1, 5).Select(i => new Entityes.Recipient
                {
                    Name = $"Recipient {i}",
                    Email = $"recipient{i}@server.ru",
                }));
            context.SaveChanges();
        }
    }
}
