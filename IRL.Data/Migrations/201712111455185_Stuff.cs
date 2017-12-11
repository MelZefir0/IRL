namespace IRL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stuff : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ContactEntity", newName: "Contact");
            RenameTable(name: "dbo.InterestEntity", newName: "Interest");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Interest", newName: "InterestEntity");
            RenameTable(name: "dbo.Contact", newName: "ContactEntity");
        }
    }
}
