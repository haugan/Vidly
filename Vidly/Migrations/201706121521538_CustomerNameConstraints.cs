namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerNameConstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Firstname", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "Lastname", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Lastname", c => c.String());
            AlterColumn("dbo.Customers", "Firstname", c => c.String());
        }
    }
}
