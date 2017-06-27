namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedSuperUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [EmployeeNumber], [Phone]) VALUES (N'fd82ad9e-19e2-4ba3-a40a-fa8230025807', N'admin@vidly.com', 0, N'AN0288oiaAmZXxzU1HjTfp4jA4Y3BEK39JUU9b6F7aIIBURTC+U8haveXQe2cQ68Ww==', N'37954e0a-e600-4315-820b-886414491ff6', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com', 9999, N'91524584')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c96df0ae-f523-43d9-a8b2-d2ca8a601a74', N'CustomerManager')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'35300768-5e1e-4167-a782-ef1b04144e05', N'MovieManager')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fd82ad9e-19e2-4ba3-a40a-fa8230025807', N'35300768-5e1e-4167-a782-ef1b04144e05')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fd82ad9e-19e2-4ba3-a40a-fa8230025807', N'c96df0ae-f523-43d9-a8b2-d2ca8a601a74')
            ");
        }
        
        public override void Down()
        {

        }
    }
}
