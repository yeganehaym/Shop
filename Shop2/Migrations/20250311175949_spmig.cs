using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop2.Migrations
{
    /// <inheritdoc />
    public partial class spmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create procedure USP_Cats
@id int
as
select id,[name] from Categories where id=@id or parentId=@id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop USP_Cats");
        }
    }
}
