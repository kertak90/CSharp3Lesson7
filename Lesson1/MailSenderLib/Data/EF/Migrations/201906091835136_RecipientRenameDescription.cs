namespace MailSenderLib.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecipientRenameDescription : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Recipients","Description","Description2");
            //AddColumn("dbo.Recipients", "Description2", c => c.String());
            //DropColumn("dbo.Recipients", "Description");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Recipients", "Description2", "Description");
            //AddColumn("dbo.Recipients", "Description", c => c.String());
            //DropColumn("dbo.Recipients", "Description2");
        }
    }
}
