using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_rename_comment_properties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Comments",
                newName: "CommentUser");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Comments",
                newName: "CommentState");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Comments",
                newName: "CommentDate");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comments",
                newName: "CommentContent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentUser",
                table: "Comments",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "CommentState",
                table: "Comments",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "CommentDate",
                table: "Comments",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "CommentContent",
                table: "Comments",
                newName: "Content");
        }
    }
}
