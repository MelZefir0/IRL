namespace IRL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ok : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactInterestModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        InterestId = c.Int(nullable: false),
                        Item = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            DropTable("dbo.ContactInterestModel");
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactInterestModel");
        }
    }
}
