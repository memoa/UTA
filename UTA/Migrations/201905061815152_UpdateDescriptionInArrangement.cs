namespace UTA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDescriptionInArrangement : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Arrangements", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Arrangements", "Description", c => c.String(nullable: false, maxLength: 1000));
        }
    }
}
