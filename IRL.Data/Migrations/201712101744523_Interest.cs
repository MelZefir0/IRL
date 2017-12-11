namespace IRL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Interest : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Interest");
        }
    }
}
