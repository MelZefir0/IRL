namespace IRL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Interest", "ContactInterest_Id", "dbo.ContactInterest");
            DropForeignKey("dbo.Interest", "UserInterest_Id", "dbo.UserInterest");
            DropIndex("dbo.Interest", new[] { "ContactInterest_Id" });
            DropIndex("dbo.Interest", new[] { "UserInterest_Id" });
            CreateTable(
                "dbo.InterestContact",
                c => new
                    {
                        Interest_InterestId = c.Int(nullable: false),
                        Contact_ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Interest_InterestId, t.Contact_ContactId })
                .ForeignKey("dbo.Interest", t => t.Interest_InterestId, cascadeDelete: true)
                .ForeignKey("dbo.Contact", t => t.Contact_ContactId, cascadeDelete: true)
                .Index(t => t.Interest_InterestId)
                .Index(t => t.Contact_ContactId);
            
            AddColumn("dbo.Contact", "HasTalked", c => c.Boolean(nullable: false));
            AddColumn("dbo.ApplicationUser", "Interest_InterestId", c => c.Int());
            CreateIndex("dbo.ContactInterest", "InterestId");
            CreateIndex("dbo.ApplicationUser", "Interest_InterestId");
            CreateIndex("dbo.UserInterest", "InterestId");
            AddForeignKey("dbo.ApplicationUser", "Interest_InterestId", "dbo.Interest", "InterestId");
            AddForeignKey("dbo.ContactInterest", "InterestId", "dbo.Interest", "InterestId", cascadeDelete: true);
            AddForeignKey("dbo.UserInterest", "InterestId", "dbo.Interest", "InterestId", cascadeDelete: true);
            DropColumn("dbo.ContactInterest", "UserId");
            DropColumn("dbo.ContactInterest", "Item");
            DropColumn("dbo.Interest", "ContactInterest_Id");
            DropColumn("dbo.Interest", "UserInterest_Id");
            DropColumn("dbo.UserInterest", "Item");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInterest", "Item", c => c.String());
            AddColumn("dbo.Interest", "UserInterest_Id", c => c.Int());
            AddColumn("dbo.Interest", "ContactInterest_Id", c => c.Int());
            AddColumn("dbo.ContactInterest", "Item", c => c.String());
            AddColumn("dbo.ContactInterest", "UserId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.UserInterest", "InterestId", "dbo.Interest");
            DropForeignKey("dbo.ContactInterest", "InterestId", "dbo.Interest");
            DropForeignKey("dbo.ApplicationUser", "Interest_InterestId", "dbo.Interest");
            DropForeignKey("dbo.InterestContact", "Contact_ContactId", "dbo.Contact");
            DropForeignKey("dbo.InterestContact", "Interest_InterestId", "dbo.Interest");
            DropIndex("dbo.InterestContact", new[] { "Contact_ContactId" });
            DropIndex("dbo.InterestContact", new[] { "Interest_InterestId" });
            DropIndex("dbo.UserInterest", new[] { "InterestId" });
            DropIndex("dbo.ApplicationUser", new[] { "Interest_InterestId" });
            DropIndex("dbo.ContactInterest", new[] { "InterestId" });
            DropColumn("dbo.ApplicationUser", "Interest_InterestId");
            DropColumn("dbo.Contact", "HasTalked");
            DropTable("dbo.InterestContact");
            CreateIndex("dbo.Interest", "UserInterest_Id");
            CreateIndex("dbo.Interest", "ContactInterest_Id");
            AddForeignKey("dbo.Interest", "UserInterest_Id", "dbo.UserInterest", "Id");
            AddForeignKey("dbo.Interest", "ContactInterest_Id", "dbo.ContactInterest", "Id");
        }
    }
}
