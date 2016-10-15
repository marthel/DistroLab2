namespace DistroLab2.DAL.Contexts.GroupMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Read = c.Boolean(nullable: false),
                        SenderId = c.String(),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        SomeOtherColumn = c.String(nullable: false, maxLength: 128),
                        Message_MessageId = c.Int(),
                        Group_GroupId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Message", t => t.Message_MessageId)
                .ForeignKey("dbo.Group", t => t.Group_GroupId)
                .Index(t => t.Message_MessageId)
                .Index(t => t.Group_GroupId);
            
            CreateTable(
                "dbo.MessageGroup",
                c => new
                    {
                        Message_MessageId = c.Int(nullable: false),
                        Group_GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Message_MessageId, t.Group_GroupId })
                .ForeignKey("dbo.Message", t => t.Message_MessageId, cascadeDelete: true)
                .ForeignKey("dbo.Group", t => t.Group_GroupId, cascadeDelete: true)
                .Index(t => t.Message_MessageId)
                .Index(t => t.Group_GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "Group_GroupId", "dbo.Group");
            DropForeignKey("dbo.User", "Message_MessageId", "dbo.Message");
            DropForeignKey("dbo.MessageGroup", "Group_GroupId", "dbo.Group");
            DropForeignKey("dbo.MessageGroup", "Message_MessageId", "dbo.Message");
            DropIndex("dbo.MessageGroup", new[] { "Group_GroupId" });
            DropIndex("dbo.MessageGroup", new[] { "Message_MessageId" });
            DropIndex("dbo.User", new[] { "Group_GroupId" });
            DropIndex("dbo.User", new[] { "Message_MessageId" });
            DropTable("dbo.MessageGroup");
            DropTable("dbo.User");
            DropTable("dbo.Message");
            DropTable("dbo.Group");
        }
    }
}
