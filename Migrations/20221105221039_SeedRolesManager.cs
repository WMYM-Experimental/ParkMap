using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkMap.Migrations
{
    public partial class SeedRolesManager : Migration
    {
        private string AdminRoleId = Guid.NewGuid().ToString();
        private string UserRoleId = Guid.NewGuid().ToString();

        private string User1Id = Guid.NewGuid().ToString();
        private string User2Id = Guid.NewGuid().ToString();

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);

            SeedUser(migrationBuilder);

            SeedUserRoles(migrationBuilder);
        }

        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{AdminRoleId}', 'Administrator', 'ADMINISTRATOR', null);");

            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{UserRoleId}', 'User', 'USER', null);");
        }

        private void SeedUser(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @$"INSERT [dbo].[AspNetUsers] ([Id], [NickName], [UserName], [NormalizedUserName], 
[Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], 
[PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
VALUES 
(N'{User1Id}', N'Admin', N'admin@test.com', N'ADMIN@TEST.COM', 
N'admin@test.com', N'ADMIN@TEST.COM', 0, 
N'AQAAAAEAACcQAAAAEBYoExzp3IK+w7yVYihrs4yPNHipZIYREXTVz0z7VN7pIDZQmAiCJ3onqBqQHMgfqw==', 
N'YUPAFWNGZI2UC5FOITC7PX5J7XZTAZAA', N'8e150555-a20d-4610-93ff-49c5af44f749', NULL, 0, 0, NULL, 1, 0)");

            migrationBuilder.Sql(
                @$"INSERT [dbo].[AspNetUsers] ([Id], [NickName], [UserName], [NormalizedUserName], 
[Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], 
[PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
VALUES 
(N'{User2Id}', N'User', N'user@test.com', N'USER@TEST.COM', 
N'user@test.com', N'USER@TEST.COM', 0, 
N'AQAAAAEAACcQAAAAEBYoExzp3IK+w7yVYihrs4yPNHipZIYREXTVz0z7VN7pIDZQmAiCJ3onqBqQHMgfqw==', 
N'YUPAFWNGZI2UC5FOITC7PX5J7XZTAZAA', N'8e150555-a20d-4610-93ff-49c5af44f749', NULL, 0, 0, NULL, 1, 0)");
        }

        private void SeedUserRoles(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User1Id}', '{AdminRoleId}');
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User1Id}', '{UserRoleId}');");

            migrationBuilder.Sql(@$"
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User2Id}', '{UserRoleId}');"
           );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
