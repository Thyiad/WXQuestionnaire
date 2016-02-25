namespace WXQuestionnaire.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAdmin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Admins", "LoginTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "LoginTime", c => c.DateTime(nullable: true));
            AlterColumn("dbo.Admins", "CreateDate", c => c.DateTime(nullable: true, defaultValueSql: "getdate()"));
        }
    }
}
