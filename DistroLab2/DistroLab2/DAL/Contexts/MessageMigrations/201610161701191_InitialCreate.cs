namespace DistroLab2.DAL.Contexts.MessageMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ApplicationUserID = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Read = c.Boolean(nullable: false),
                        SenderId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.ApplicationUsers", t => t.SenderId)
                .Index(t => t.SenderId);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        GroupsID = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MessageGroup",
                c => new
                    {
                        MessageID = c.Int(nullable: false),
                        GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MessageID, t.GroupID })
                .ForeignKey("dbo.Messages", t => t.MessageID, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.MessageID)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.MessageUsers",
                c => new
                    {
                        MessageID = c.Int(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MessageID, t.UserID })
                .ForeignKey("dbo.Messages", t => t.MessageID, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.MessageID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.GroupApplicationUsers",
                c => new
                    {
                        Group_GroupId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Group_GroupId, t.ApplicationUser_Id })
                .ForeignKey("dbo.Groups", t => t.Group_GroupId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Group_GroupId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.GroupApplicationUsers", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.GroupApplicationUsers", "Group_GroupId", "dbo.Groups");
            DropForeignKey("dbo.MessageUsers", "UserID", "dbo.ApplicationUsers");
            DropForeignKey("dbo.MessageUsers", "MessageID", "dbo.Messages");
            DropForeignKey("dbo.Messages", "SenderId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.MessageGroup", "GroupID", "dbo.Groups");
            DropForeignKey("dbo.MessageGroup", "MessageID", "dbo.Messages");
            DropIndex("dbo.GroupApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.GroupApplicationUsers", new[] { "Group_GroupId" });
            DropIndex("dbo.MessageUsers", new[] { "UserID" });
            DropIndex("dbo.MessageUsers", new[] { "MessageID" });
            DropIndex("dbo.MessageGroup", new[] { "GroupID" });
            DropIndex("dbo.MessageGroup", new[] { "MessageID" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropTable("dbo.GroupApplicationUsers");
            DropTable("dbo.MessageUsers");
            DropTable("dbo.MessageGroup");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.Messages");
            DropTable("dbo.Groups");
        }
    }
}
