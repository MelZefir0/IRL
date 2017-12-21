namespace IRL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReplacingLostTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactInterest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ContactId = c.Int(nullable: false),
                        InterestId = c.Int(nullable: false),
                        Item = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.UserInterest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        InterestId = c.Int(nullable: false),
                        Item = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Interest", "ContactInterest_Id", c => c.Int());
            AddColumn("dbo.Interest", "UserInterest_Id", c => c.Int());
            AlterColumn("dbo.Contact", "LastName", c => c.String());
            CreateIndex("dbo.Interest", "ContactInterest_Id");
            CreateIndex("dbo.Interest", "UserInterest_Id");
            AddForeignKey("dbo.Interest", "ContactInterest_Id", "dbo.ContactInterest", "Id");
            AddForeignKey("dbo.Interest", "UserInterest_Id", "dbo.UserInterest", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interest", "UserInterest_Id", "dbo.UserInterest");
            DropForeignKey("dbo.ContactInterest", "ContactId", "dbo.Contact");
            DropForeignKey("dbo.Interest", "ContactInterest_Id", "dbo.ContactInterest");
            DropIndex("dbo.Interest", new[] { "UserInterest_Id" });
            DropIndex("dbo.Interest", new[] { "ContactInterest_Id" });
            DropIndex("dbo.ContactInterest", new[] { "ContactId" });
            AlterColumn("dbo.Contact", "LastName", c => c.String(nullable: false));
            DropColumn("dbo.Interest", "UserInterest_Id");
            DropColumn("dbo.Interest", "ContactInterest_Id");
            DropTable("dbo.UserInterest");
            DropTable("dbo.ContactInterest");
        }
    }
}
