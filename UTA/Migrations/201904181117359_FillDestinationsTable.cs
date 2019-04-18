namespace UTA.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class FillDestinationsTable : DbMigration
  {
    public override void Up()
    {
      Sql("INSERT INTO Destinations VALUES ('Tunguzija', 'Rusija', 'brown-circle-and-chocolate-coffee.png')");
      Sql("INSERT INTO Destinations VALUES ('Dembelija', 'Srbija', 'brown-circle-and-chocolate-coffee.png')");
    }

    public override void Down()
    {
    }
  }
}
