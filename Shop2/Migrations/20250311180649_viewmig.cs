using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop2.Migrations
{
    /// <inheritdoc />
    public partial class viewmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view V_Cat as
select Id,name from categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop V_Cat");
        }
    }
}
