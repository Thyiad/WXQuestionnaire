namespace WXQuestionnaire.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAdmin2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "LoginTime2", c => c.DateTime(nullable:true,defaultValueSql:"getdate()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "LoginTime2");
        }
    }
}
