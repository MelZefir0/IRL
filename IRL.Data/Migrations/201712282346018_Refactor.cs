namespace IRL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactInterestEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        InterestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.InterestEntity", t => t.InterestId, cascadeDelete: true)
                .Index(t => t.ContactId)
                .Index(t => t.InterestId);
            
            CreateTable(
                "dbo.ContactEntity",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Nickname = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Notes = c.String(),
                        HasTalked = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ContactId);

            CreateTable(
                "dbo.InterestEntity",
                c => new
                    {
                        InterestId = c.Int(nullable: false, identity: true),
                        Item = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.InterestId);
            
            
           
            CreateTable(
                "dbo.UserInterestEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        InterestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InterestEntity", t => t.InterestId, cascadeDelete: true)
                .Index(t => t.InterestId);
            
            
            
           
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.UserInterestEntity", "InterestId", "dbo.InterestEntity");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.ContactInterestEntity", "InterestId", "dbo.InterestEntity");
            DropForeignKey("dbo.ContactInterestEntity", "ContactId", "dbo.Contact");
            DropForeignKey("dbo.InterestListItem", "ContactEntity_ContactId", "dbo.Contact");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserInterestEntity", new[] { "InterestId" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.InterestListItem", new[] { "ContactEntity_ContactId" });
            DropIndex("dbo.ContactInterestEntity", new[] { "InterestId" });
            DropIndex("dbo.ContactInterestEntity", new[] { "ContactId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.UserInterestEntity");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.InterestEntity");
            DropTable("dbo.InterestListItem");
            DropTable("dbo.Contact");
            DropTable("dbo.ContactInterestEntity");
        }
    }
}
