namespace WXQuestionnaire.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatestat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stats", "Day1WinnerNum", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "Day2WinnerNum", c => c.Int(nullable: false));
            DropColumn("dbo.Stats", "D1DZPrizeNum");
            DropColumn("dbo.Stats", "D1PPJLDDPrizeNum");
            DropColumn("dbo.Stats", "D1CLPXPrizeNum");
            DropColumn("dbo.Stats", "D1SPPrizeNum");
            DropColumn("dbo.Stats", "D2DZPrizeNum");
            DropColumn("dbo.Stats", "D2PPJLDDPrizeNum");
            DropColumn("dbo.Stats", "D2CLPXPrizeNum");
            DropColumn("dbo.Stats", "D2CLPrizeNum");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stats", "D2CLPrizeNum", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "D2CLPXPrizeNum", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "D2PPJLDDPrizeNum", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "D2DZPrizeNum", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "D1SPPrizeNum", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "D1CLPXPrizeNum", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "D1PPJLDDPrizeNum", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "D1DZPrizeNum", c => c.Int(nullable: false));
            DropColumn("dbo.Stats", "Day2WinnerNum");
            DropColumn("dbo.Stats", "Day1WinnerNum");
        }
    }
}
