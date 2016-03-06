namespace WXQuestionnaire.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatechartlet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chartlets", "BuildImgPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chartlets", "BuildImgPath");
        }
    }
}
