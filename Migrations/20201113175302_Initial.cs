using Microsoft.EntityFrameworkCore.Migrations;

namespace Term_Project_Version_1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 40, nullable: false),
                    email = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    ConfirmPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Price = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MembersID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Purchases_Membership_MembersID",
                        column: x => x.MembersID,
                        principalTable: "Membership",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "ID", "Address", "City", "ConfirmPassword", "Country", "Password", "Zipcode", "State", "email", "name" },
                values: new object[,]
                {
                    { 1, "Pastoor Celensstraat 1", "Kalmthout", null, "Belgium", null, "2920", null, "michelle@vanwetteregroup.com", "Michelle Vanwettere" },
                    { 2, "Mohammed Mohammed Amr Allah", "Alexandria", null, "Egypt", null, "21624", null, "tito.nugaily@gmail.com", "Tito Nugauily" },
                    { 3, null, "New York City", null, "United States", null, "10001", null, "david.wood@acts17.com", "David Wood" },
                    { 4, "4138 Huntington Drive", "Traverse City", null, "United States", null, "49686", null, "mgibson@makeitrain.com", "Matthew Gibson" },
                    { 5, "4131 Benedict Canyon Dr", "Los Angeles", null, "United States", null, "91423", null, "mohamedayew@gmail.com", "Mohamed Ayew" },
                    { 6, "1219 Tetreau Street", "Thibodaux", null, "United States", null, "70301", null, "mayadamohamed@gmail.com", "Meda Doyle" }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "ID", "Description", "MembersID", "Price" },
                values: new object[] { "SA", "Seeking Allah Finding Jesus Paperback", 1, "$19.99" });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "ID", "Description", "MembersID", "Price" },
                values: new object[] { "FA", "Full Access including study guide and access to all podcasts and articles", 5, "$109.99" });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "ID", "Description", "MembersID", "Price" },
                values: new object[] { "SG", "Study Guide including hard cover book, study guide and blu-ray", 6, "$79.99" });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_MembersID",
                table: "Purchases",
                column: "MembersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Membership");
        }
    }
}
