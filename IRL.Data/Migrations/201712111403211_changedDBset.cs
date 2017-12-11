namespace IRL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDBset : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Contact", newName: "ContactEntity");
            CreateTable(
                "dbo.InterestEntity",
                c => new
                    {
                        InterestId = c.Int(nullable: false, identity: true),
                        Item = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.InterestId);
            
            DropTable("dbo.Interest");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Interest",
                c => new
                    {
                        InterestId = c.Int(nullable: false, identity: true),
                        Item = c.String(nullable: false),
                        IsChecked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InterestId);
            
            DropTable("dbo.InterestEntity");
            RenameTable(name: "dbo.ContactEntity", newName: "Contact");
        }
    }
}
