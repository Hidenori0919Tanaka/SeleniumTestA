namespace UnitTest_Sample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewTable_CollectColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Fa", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Fa", new[] { "UserId" });
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.M_User",
                c => new
                    {
                        M_UserId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        GroupId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.M_UserId)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
            AddColumn("dbo.Fa", "GroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Fa", "GroupId");
            AddForeignKey("dbo.Fa", "GroupId", "dbo.Group", "GroupId", cascadeDelete: true);
            DropColumn("dbo.Fa", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fa", "UserId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.M_User", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.M_User", "GroupId", "dbo.Group");
            DropForeignKey("dbo.Fa", "GroupId", "dbo.Group");
            DropIndex("dbo.M_User", new[] { "GroupId" });
            DropIndex("dbo.M_User", new[] { "UserId" });
            DropIndex("dbo.Fa", new[] { "GroupId" });
            DropColumn("dbo.Fa", "GroupId");
            DropTable("dbo.M_User");
            DropTable("dbo.Group");
            CreateIndex("dbo.Fa", "UserId");
            AddForeignKey("dbo.Fa", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
