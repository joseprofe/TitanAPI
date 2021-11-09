using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace Titan.DAL.Migrations
{
    public partial class InsertarProvincias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = @"../Titan.DAL/Scripts/20211109_InsertarProvincias.sql";
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from provincias;");
        }   
    }
}
