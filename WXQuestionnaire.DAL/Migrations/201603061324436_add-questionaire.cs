namespace WXQuestionnaire.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addquestionaire : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questionaires",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CustomerType = c.String(),
                        Position = c.String(),
                        QuestionaireType = c.Int(nullable: false),
                        QuestionaireDetail = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Questionaires");
        }
    }
}
