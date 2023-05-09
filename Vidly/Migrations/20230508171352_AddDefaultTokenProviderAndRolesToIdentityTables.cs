using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultTokenProviderAndRolesToIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE [dbo].[AspNetUserTokens] DROP CONSTRAINT [PK_AspNetUserTokens] WITH ( ONLINE = OFF )");

            migrationBuilder.Sql(@"ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [PK_AspNetUserLogins] WITH ( ONLINE = OFF )");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.Sql(
                @"ALTER TABLE [dbo].[AspNetUserTokens] ADD  CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
                (
	                [UserId] ASC,
	                [LoginProvider] ASC,
	                [Name] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            migrationBuilder.Sql(
                @"ALTER TABLE [dbo].[AspNetUserLogins] ADD  CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
                (
	                [LoginProvider] ASC,
	                [ProviderKey] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE [dbo].[AspNetUserTokens] DROP CONSTRAINT [PK_AspNetUserTokens] WITH ( ONLINE = OFF )");

            migrationBuilder.Sql(@"ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [PK_AspNetUserLogins] WITH ( ONLINE = OFF )");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.Sql(
                @"ALTER TABLE [dbo].[AspNetUserTokens] ADD  CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
                (
	                [UserId] ASC,
	                [LoginProvider] ASC,
	                [Name] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");

            migrationBuilder.Sql(
                @"ALTER TABLE [dbo].[AspNetUserLogins] ADD  CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
                (
	                [LoginProvider] ASC,
	                [ProviderKey] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]");
        }
    }
}
