namespace IRL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInterestModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        InterestId = c.Int(nullable: false),
                        Item = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            DropTable("dbo.UserInterestModel");

        }
        
        public override void Down()
        {
            DropTable("dbo.UserInterestModel");
        }
    }
}
