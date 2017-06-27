namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedAndAddedPropertiesToMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AmountInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "AmountAvailable", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "Stock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "AmountAvailable");
            DropColumn("dbo.Movies", "AmountInStock");
        }
    }
}
