namespace WXQuestionnaire.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatechartlet2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chartlets", "ServerIDWX", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chartlets", "ServerIDWX");
        }
    }
}
