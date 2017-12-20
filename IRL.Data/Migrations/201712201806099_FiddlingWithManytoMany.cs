namespace IRL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FiddlingWithManytoMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Interest", "Contact_ContactId", "dbo.Contact");
            DropIndex("dbo.Interest", new[] { "Contact_ContactId" });
            
            
            CreateIndex("dbo.ContactInterest", "ContactId");
            AddForeignKey("dbo.ContactInterest", "ContactId", "dbo.Contact", "ContactId", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Interest", "Contact_ContactId", c => c.Int());
            DropForeignKey("dbo.ContactInterest", "ContactId", "dbo.Contact");
            DropIndex("dbo.ContactInterest", new[] { "ContactId" });
            DropColumn("dbo.ContactInterest", "UserId");
            RenameColumn(table: "dbo.ContactInterest", name: "ContactId", newName: "Contact_ContactId");
            AddColumn("dbo.ContactInterest", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Interest", "Contact_ContactId");
            AddForeignKey("dbo.Interest", "Contact_ContactId", "dbo.Contact", "ContactId");
        }
    }
}
