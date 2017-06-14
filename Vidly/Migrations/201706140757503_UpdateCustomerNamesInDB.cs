namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerNamesInDB : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET FirstName = 'Marius', LastName = 'Riis Haugan' WHERE Id = 1");
            Sql("UPDATE Customers SET FirstName = 'Julia', LastName = 'Skjelbred' WHERE Id = 2");
            Sql("UPDATE Customers SET FirstName = 'Fauna', LastName = 'Riis Skjelbred' WHERE Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
