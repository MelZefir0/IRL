namespace IRL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hm : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UserInterest");
        }
        
        public override void Down()
        {
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
            
        }
    }
}
