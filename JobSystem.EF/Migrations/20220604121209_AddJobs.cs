using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSystem.EF.Migrations
{
    public partial class AddJobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantJob",
                columns: table => new
                {
                    ApplicantsID = table.Column<int>(type: "int", nullable: false),
                    JobsJobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantJob", x => new { x.ApplicantsID, x.JobsJobId });
                    table.ForeignKey(
                        name: "FK_ApplicantJob_Applicants_ApplicantsID",
                        column: x => x.ApplicantsID,
                        principalTable: "Applicants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantJob_Job_JobsJobId",
                        column: x => x.JobsJobId,
                        principalTable: "Job",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantJob_JobsJobId",
                table: "ApplicantJob",
                column: "JobsJobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantJob");

            migrationBuilder.DropTable(
                name: "Job");
        }
    }
}
