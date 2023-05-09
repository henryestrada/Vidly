using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'23c7703f-6bb9-4808-b240-bd6b03e18d2d', N'admin@vidly.com', N'ADMIN@VIDLY.COM', N'admin@vidly.com', N'ADMIN@VIDLY.COM', 0, N'AQAAAAIAAYagAAAAECuNtt54ntrbgCDBp2NrEOPJG+oqw74Hf00vp4xyBYMnxV4w+Mpx4nVZ2rJ5Go/Aeg==', N'4EWOORQ6HDUYAAG53EFTZQ6XMMYVNZPO', N'f5975d49-5895-42d9-b556-6826e1c9644d', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'978991b7-2631-4a91-a25b-18e6fc0a9300', N'guest@vidly.com', N'GUEST@VIDLY.COM', N'guest@vidly.com', N'GUEST@VIDLY.COM', 0, N'AQAAAAIAAYagAAAAENCZkMYlJoQfk11r7rLZYiLVJd/RiOAEKYD4BTLhJV3sZ/GseEpEqtnU37o+C8L8UA==', N'EYXVVC5UMDVVJD2CFQUJQCLLTHWCLVBZ', N'e808ca17-7753-4aca-bc96-704336564c8a', NULL, 0, 0, NULL, 1, 0)

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'e408a4a3-de3e-4235-b5a0-c70e089af1b4', N'CanManageMovies', N'CANMANAGEMOVIES', NULL)

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'23c7703f-6bb9-4808-b240-bd6b03e18d2d', N'e408a4a3-de3e-4235-b5a0-c70e089af1b4')
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DELETE FROM [dbo].[AspNetUsers]

DELETE FROM [dbo].[AspNetRoles]

DELETE FROM [dbo].[AspNetUserRoles]
            ");
        }
    }
}
