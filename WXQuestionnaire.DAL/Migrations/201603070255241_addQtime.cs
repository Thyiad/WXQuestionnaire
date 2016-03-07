namespace WXQuestionnaire.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addQtime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questionaires", "QTime", c => c.DateTime(defaultValueSql:"getdate()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questionaires", "QTime");
        }
    }
}
