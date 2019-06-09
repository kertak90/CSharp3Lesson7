namespace MailSenderLib.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MailLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MailMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false, maxLength: 256),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipientsLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Senders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Servers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false),
                        Port = c.Int(nullable: false),
                        UseSSL = c.Boolean(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SchedulerTask",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(),
                        Messages_Id = c.Int(nullable: false),
                        Recipients_Id = c.Int(nullable: false),
                        Sender_Id = c.Int(nullable: false),
                        Server_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MailLists", t => t.Messages_Id, cascadeDelete: true)
                .ForeignKey("dbo.RecipientsLists", t => t.Recipients_Id, cascadeDelete: true)
                .ForeignKey("dbo.Senders", t => t.Sender_Id, cascadeDelete: true)
                .ForeignKey("dbo.Servers", t => t.Server_Id, cascadeDelete: true)
                .Index(t => t.Messages_Id)
                .Index(t => t.Recipients_Id)
                .Index(t => t.Sender_Id)
                .Index(t => t.Server_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchedulerTask", "Server_Id", "dbo.Servers");
            DropForeignKey("dbo.SchedulerTask", "Sender_Id", "dbo.Senders");
            DropForeignKey("dbo.SchedulerTask", "Recipients_Id", "dbo.RecipientsLists");
            DropForeignKey("dbo.SchedulerTask", "Messages_Id", "dbo.MailLists");
            DropIndex("dbo.SchedulerTask", new[] { "Server_Id" });
            DropIndex("dbo.SchedulerTask", new[] { "Sender_Id" });
            DropIndex("dbo.SchedulerTask", new[] { "Recipients_Id" });
            DropIndex("dbo.SchedulerTask", new[] { "Messages_Id" });
            DropTable("dbo.SchedulerTask");
            DropTable("dbo.Servers");
            DropTable("dbo.Senders");
            DropTable("dbo.RecipientsLists");
            DropTable("dbo.Recipients");
            DropTable("dbo.MailMessages");
            DropTable("dbo.MailLists");
        }
    }
}
