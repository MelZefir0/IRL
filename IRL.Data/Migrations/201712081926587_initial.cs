namespace IRL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "Nickname", c => c.String());
            AddColumn("dbo.Contact", "Address", c => c.String());
            AddColumn("dbo.Contact", "PhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Contact", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contact", "Notes");
            DropColumn("dbo.Contact", "PhoneNumber");
            DropColumn("dbo.Contact", "Address");
            DropColumn("dbo.Contact", "Nickname");
        }
    }
}
