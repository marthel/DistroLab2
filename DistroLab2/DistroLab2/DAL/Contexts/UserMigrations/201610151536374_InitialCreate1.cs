namespace DistroLab2.DAL.Contexts.UserMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserGroups", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserGroups", "Group_GroupId", "dbo.Groups");
            DropForeignKey("dbo.ApplicationUserMessages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserMessages", "Message_MessageId", "dbo.Messages");
            DropIndex("dbo.ApplicationUserGroups", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserGroups", new[] { "Group_GroupId" });
            DropIndex("dbo.ApplicationUserMessages", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserMessages", new[] { "Message_MessageId" });
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        SomeOtherColumn = c.String(nullable: false, maxLength: 128),
                        Message_MessageId = c.Int(),
                        Group_GroupId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Messages", t => t.Message_MessageId)
                .ForeignKey("dbo.Groups", t => t.Group_GroupId)
                .Index(t => t.Message_MessageId)
                .Index(t => t.Group_GroupId);
            
            AddColumn("dbo.Groups", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Messages", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Groups", "ApplicationUser_Id");
            CreateIndex("dbo.Messages", "ApplicationUser_Id");
            AddForeignKey("dbo.Groups", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Messages", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropTable("dbo.ApplicationUserGroups");
            DropTable("dbo.ApplicationUserMessages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserMessages",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Message_MessageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Message_MessageId });
            
            CreateTable(
                "dbo.ApplicationUserGroups",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Group_GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Group_GroupId });
            
            DropForeignKey("dbo.Messages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Groups", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Users", "Group_GroupId", "dbo.Groups");
            DropForeignKey("dbo.Users", "Message_MessageId", "dbo.Messages");
            DropIndex("dbo.Users", new[] { "Group_GroupId" });
            DropIndex("dbo.Users", new[] { "Message_MessageId" });
            DropIndex("dbo.Messages", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Groups", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Messages", "ApplicationUser_Id");
            DropColumn("dbo.Groups", "ApplicationUser_Id");
            DropTable("dbo.Users");
            CreateIndex("dbo.ApplicationUserMessages", "Message_MessageId");
            CreateIndex("dbo.ApplicationUserMessages", "ApplicationUser_Id");
            CreateIndex("dbo.ApplicationUserGroups", "Group_GroupId");
            CreateIndex("dbo.ApplicationUserGroups", "ApplicationUser_Id");
            AddForeignKey("dbo.ApplicationUserMessages", "Message_MessageId", "dbo.Messages", "MessageId", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserMessages", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserGroups", "Group_GroupId", "dbo.Groups", "GroupId", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserGroups", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
