namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAmountAvailableInMovies : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET AmountAvailable = AmountInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AmountAvailable");
        }
    }
}
