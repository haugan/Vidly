namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCustomersBirthDate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate = '10-12-1984' WHERE Id = 2");
            Sql("UPDATE Customers SET BirthDate = '05-02-2017' WHERE Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
