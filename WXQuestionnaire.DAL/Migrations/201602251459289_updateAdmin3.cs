namespace WXQuestionnaire.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAdmin3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Admins", "LoginTime2");
            AlterColumn("dbo.Admins", "CreateDate", c => c.DateTime(nullable: true, defaultValueSql: "getdate()"));
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "LoginTime2", c => c.DateTime());
        }
    }
}
