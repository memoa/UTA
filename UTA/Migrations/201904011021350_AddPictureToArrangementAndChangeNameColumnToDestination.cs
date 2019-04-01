namespace UTA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPictureToArrangementAndChangeNameColumnToDestination : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arrangements", "Destination", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Arrangements", "Picture", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Arrangements", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Arrangements", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Arrangements", "Picture");
            DropColumn("dbo.Arrangements", "Destination");
        }
    }
}
