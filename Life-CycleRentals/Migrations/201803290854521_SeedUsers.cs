namespace Life_CycleRentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

INSERT INTO[dbo].[AspNetUsers]
([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'785351a5-3d68-43ee-bbc8-8703f0641271', N'admin@admin.com', 0, N'AOhHKgvjjoWHoqL/aD6d/a/WnBAyZMTDnhgKIh0zORA/6hS0o44qAPG0SJEqS8UtQw==', N'50b7a671-a353-4cdb-8ba0-3b5d467af87c', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')
INSERT INTO[dbo].[AspNetUsers]
([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'969832e9-540d-4b2c-81a6-bb5396e6ae11', N'guest@guest.com', 0, N'AH+Z2/GWesrAtHNyZz3UuIQOvEtQjJ5hehTw7GGzxVGnR5doCD1+zLHhYhEeKzE4tw==', N'd6dea082-2809-4eb7-83f2-6c5fdf1ac52f', NULL, 0, 0, NULL, 1, 0, N'guest@guest.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'948ed3d8-b08d-4d26-87a9-c5daa0ca022b', N'CanManageBikes')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'785351a5-3d68-43ee-bbc8-8703f0641271', N'948ed3d8-b08d-4d26-87a9-c5daa0ca022b')

");
        }
        
        public override void Down()
        {
        }
    }
}

