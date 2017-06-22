namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql
            (@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'70ea4a9f-b6eb-4b7a-8f9b-f78d5feec50b', N'admin@vidly.com', 0, N'AOEGheb2jZYETWc0NmEQOLda4qVJ6V8um4mgDzTpQvY2zLzfiLen0GTnL0AqU2J13Q==', N'f0cb1712-301c-4d53-935b-e86dec236432', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'92410bf0-c04f-4ad0-92a8-030e8301eb23', N'guest@vidly.com', 0, N'AKrF/vFWG6ZQGdAc3Ez7iZEgwzHUvzvK3lwAW26D+wo2HTsQKopLPT9c5VSD6lJ0Rg==', N'f46df0ef-18b7-4598-9203-722a66d2ccfb', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'35300768-5e1e-4167-a782-ef1b04144e05', N'MovieManager')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'70ea4a9f-b6eb-4b7a-8f9b-f78d5feec50b', N'35300768-5e1e-4167-a782-ef1b04144e05')
            ");
        }
        
        public override void Down()
        {

        }
    }
}
