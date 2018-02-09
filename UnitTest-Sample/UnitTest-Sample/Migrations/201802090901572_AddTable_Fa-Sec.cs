namespace UnitTest_Sample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable_FaSec : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fas",
                c => new
                    {
                        FaId = c.Int(nullable: false, identity: true),
                        FaName = c.String(),
                        UserId = c.String(maxLength: 128),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        DeleteFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FaId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Secs",
                c => new
                    {
                        SecId = c.Int(nullable: false, identity: true),
                        FaId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        DeleteFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SecId)
                .ForeignKey("dbo.Fas", t => t.FaId, cascadeDelete: true)
                .Index(t => t.FaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Secs", "FaId", "dbo.Fas");
            DropForeignKey("dbo.Fas", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Secs", new[] { "FaId" });
            DropIndex("dbo.Fas", new[] { "UserId" });
            DropTable("dbo.Secs");
            DropTable("dbo.Fas");
        }
    }
}
