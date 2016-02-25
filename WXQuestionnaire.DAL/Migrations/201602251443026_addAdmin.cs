namespace WXQuestionnaire.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAdmin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Account = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        LoginTime = c.DateTime(nullable: false),
                        LoginIP = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
