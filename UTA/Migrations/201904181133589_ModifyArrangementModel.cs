namespace UTA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyArrangementModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arrangements", "DestinationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Arrangements", "DestinationId");
            AddForeignKey("dbo.Arrangements", "DestinationId", "dbo.Destinations", "Id", cascadeDelete: true);
            DropColumn("dbo.Arrangements", "Destination");
            DropColumn("dbo.Arrangements", "Picture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Arrangements", "Picture", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Arrangements", "Destination", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.Arrangements", "DestinationId", "dbo.Destinations");
            DropIndex("dbo.Arrangements", new[] { "DestinationId" });
            DropColumn("dbo.Arrangements", "DestinationId");
        }
    }
}
