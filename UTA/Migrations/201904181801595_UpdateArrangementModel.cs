namespace UTA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateArrangementModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arrangements", "Description", c => c.String(nullable: false, maxLength: 1000));
            AddColumn("dbo.Arrangements", "ArrangementTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Arrangements", "TransportationTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Arrangements", "ServiceId", c => c.Int(nullable: false));
            AddColumn("dbo.Arrangements", "StayDays", c => c.Int(nullable: false));
            AddColumn("dbo.Arrangements", "StayNights", c => c.Int(nullable: false));
            AddColumn("dbo.Arrangements", "Price", c => c.Int(nullable: false));
            CreateIndex("dbo.Arrangements", "ArrangementTypeId");
            CreateIndex("dbo.Arrangements", "TransportationTypeId");
            CreateIndex("dbo.Arrangements", "ServiceId");
            AddForeignKey("dbo.Arrangements", "ArrangementTypeId", "dbo.ArrangementTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Arrangements", "ServiceId", "dbo.Services", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Arrangements", "TransportationTypeId", "dbo.TransportationTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Arrangements", "TransportationTypeId", "dbo.TransportationTypes");
            DropForeignKey("dbo.Arrangements", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Arrangements", "ArrangementTypeId", "dbo.ArrangementTypes");
            DropIndex("dbo.Arrangements", new[] { "ServiceId" });
            DropIndex("dbo.Arrangements", new[] { "TransportationTypeId" });
            DropIndex("dbo.Arrangements", new[] { "ArrangementTypeId" });
            DropColumn("dbo.Arrangements", "Price");
            DropColumn("dbo.Arrangements", "StayNights");
            DropColumn("dbo.Arrangements", "StayDays");
            DropColumn("dbo.Arrangements", "ServiceId");
            DropColumn("dbo.Arrangements", "TransportationTypeId");
            DropColumn("dbo.Arrangements", "ArrangementTypeId");
            DropColumn("dbo.Arrangements", "Description");
        }
    }
}
