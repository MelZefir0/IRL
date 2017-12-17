namespace IRL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInterestToContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Interest", "Contact_ContactId", c => c.Int());
            CreateIndex("dbo.Interest", "Contact_ContactId");
            AddForeignKey("dbo.Interest", "Contact_ContactId", "dbo.Contact", "ContactId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interest", "Contact_ContactId", "dbo.Contact");
            DropIndex("dbo.Interest", new[] { "Contact_ContactId" });
            DropColumn("dbo.Interest", "Contact_ContactId");
        }
    }
}
