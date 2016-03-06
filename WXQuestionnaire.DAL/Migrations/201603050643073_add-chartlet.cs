namespace WXQuestionnaire.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addchartlet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chartlets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OriginalImgPath = c.String(),
                        MsgText = c.String(),
                        SignName = c.String(),
                        CreateDate = c.DateTime(defaultValueSql: "getdate()"),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Chartlets");
        }
    }
}
