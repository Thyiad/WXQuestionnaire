namespace WXQuestionnaire.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PrizeWinnerNum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stats");
        }
    }
}
