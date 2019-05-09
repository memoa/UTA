namespace UTA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArrangementsTransportationTypesAndArrangementsServices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArrangementServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArrangementId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Arrangements", t => t.ArrangementId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ArrangementId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.ArrangementTransportationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArrangementId = c.Int(nullable: false),
                        TransportationTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Arrangements", t => t.ArrangementId, cascadeDelete: true)
                .ForeignKey("dbo.TransportationTypes", t => t.TransportationTypeId, cascadeDelete: true)
                .Index(t => t.ArrangementId)
                .Index(t => t.TransportationTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArrangementTransportationTypes", "TransportationTypeId", "dbo.TransportationTypes");
            DropForeignKey("dbo.ArrangementTransportationTypes", "ArrangementId", "dbo.Arrangements");
            DropForeignKey("dbo.ArrangementServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.ArrangementServices", "ArrangementId", "dbo.Arrangements");
            DropIndex("dbo.ArrangementTransportationTypes", new[] { "TransportationTypeId" });
            DropIndex("dbo.ArrangementTransportationTypes", new[] { "ArrangementId" });
            DropIndex("dbo.ArrangementServices", new[] { "ServiceId" });
            DropIndex("dbo.ArrangementServices", new[] { "ArrangementId" });
            DropTable("dbo.ArrangementTransportationTypes");
            DropTable("dbo.ArrangementServices");
        }
    }
}
