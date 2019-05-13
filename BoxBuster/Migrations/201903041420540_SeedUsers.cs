namespace BoxBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ba51c7f7-0625-4cf0-84fe-93673e4e04c8', N'manage@buxbuster.com', 0, N'AJu41hfV+8brNoOblu9aomn6vfnfWxyZR3U8p1apU/uWMYKenNPqCyloJsA/QDN0UA==', N'a0cbb716-8951-4784-8b5e-2f25b98544ea', NULL, 0, 0, NULL, 1, 0, N'manage@buxbuster.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fe50873f-f6e2-4046-81ec-ac5a2b9409de', N'user@boxbuster.com', 0, N'AOyJg23D7vpOTFuxrzMfeKsxk9b6wTWMp9QXI4zVOdmm+XDXkk1YcPoe1kdGQw4r7Q==', N'6bbbe695-47b4-419a-a667-4413056123d8', NULL, 0, 0, NULL, 1, 0, N'user@boxbuster.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1d54d580-f71e-49f3-8b00-eefd79d87a82', N'ManageDb')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ba51c7f7-0625-4cf0-84fe-93673e4e04c8', N'1d54d580-f71e-49f3-8b00-eefd79d87a82')


");
        }
        
        public override void Down()
        {
        }
    }
}
