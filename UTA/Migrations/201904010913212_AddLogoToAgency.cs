namespace UTA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogoToAgency : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agencies", "Logo", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agencies", "Logo");
        }
    }
}
