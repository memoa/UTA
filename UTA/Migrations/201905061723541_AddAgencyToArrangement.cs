namespace UTA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgencyToArrangement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arrangements", "AgencyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Arrangements", "AgencyId");
            AddForeignKey("dbo.Arrangements", "AgencyId", "dbo.Agencies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Arrangements", "AgencyId", "dbo.Agencies");
            DropIndex("dbo.Arrangements", new[] { "AgencyId" });
            DropColumn("dbo.Arrangements", "AgencyId");
        }
    }
}
