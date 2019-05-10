namespace UTA.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class SeedTables : DbMigration
  {
    public override void Up()
    {
      SqlFile("../UTASeed.sql");
    }

    public override void Down()
    {
    }
  }
}
