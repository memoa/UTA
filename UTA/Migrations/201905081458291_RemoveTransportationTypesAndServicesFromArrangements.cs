namespace UTA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTransportationTypesAndServicesFromArrangements : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Arrangements", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Arrangements", "TransportationTypeId", "dbo.TransportationTypes");
            DropIndex("dbo.Arrangements", new[] { "TransportationTypeId" });
            DropIndex("dbo.Arrangements", new[] { "ServiceId" });
            DropColumn("dbo.Arrangements", "TransportationTypeId");
            DropColumn("dbo.Arrangements", "ServiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Arrangements", "ServiceId", c => c.Int(nullable: false));
            AddColumn("dbo.Arrangements", "TransportationTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Arrangements", "ServiceId");
            CreateIndex("dbo.Arrangements", "TransportationTypeId");
            AddForeignKey("dbo.Arrangements", "TransportationTypeId", "dbo.TransportationTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Arrangements", "ServiceId", "dbo.Services", "Id", cascadeDelete: true);
        }
    }
}
