using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorBike.Migrations
{
    public partial class login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "categoria",
            //    columns: table => new
            //    {
            //        id_categoria = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        nombre_categoria = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__categori__CD54BC5AE74B909F", x => x.id_categoria);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "clientes",
            //    columns: table => new
            //    {
            //        id_cliente = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        nombre_cliente = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
            //        email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
            //        telefono_cliente = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
            //        direccion_cliente = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__clientes__677F38F59C6AC395", x => x.id_cliente);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "compras",
            //    columns: table => new
            //    {
            //        id_compra = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        precio_final = table.Column<int>(type: "int", nullable: false),
            //        fecha_compra = table.Column<DateTime>(type: "date", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__compras__C4BAA604D5948067", x => x.id_compra);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "mecanicos",
            //    columns: table => new
            //    {
            //        id_mecanico = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        nombre_mecanico = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
            //        cedula = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
            //        telefono_mecanico = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
            //        direccion_mecanico = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__mecanico__3228572C1E6045AF", x => x.id_mecanico);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "servicios",
            //    columns: table => new
            //    {
            //        id_servicio = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        nombre_servicio = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__servicio__6FD07FDC3784A3AE", x => x.id_servicio);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ventas",
            //    columns: table => new
            //    {
            //        id_venta = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        precio_final = table.Column<int>(type: "int", nullable: false),
            //        fecha_venta = table.Column<DateTime>(type: "date", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__venta__459533BF5899F3F6", x => x.id_venta);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "repuestos",
            //    columns: table => new
            //    {
            //        id_repuesto = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        fk_categoria = table.Column<int>(type: "int", nullable: false),
            //        nombre_repuesto = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        cantidad = table.Column<int>(type: "int", nullable: false),
            //        precio = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__repuesto__9D97D13F91737E28", x => x.id_repuesto);
            //        table.ForeignKey(
            //            name: "FK__repuesto__precio__68487DD7",
            //            column: x => x.fk_categoria,
            //            principalTable: "categoria",
            //            principalColumn: "id_categoria");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "compra_x_repuesto",
            //    columns: table => new
            //    {
            //        id_compra_x_repuesto = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        fk_compra = table.Column<int>(type: "int", nullable: false),
            //        fk_categoria = table.Column<int>(type: "int", nullable: false),
            //        fk_repuesto = table.Column<int>(type: "int", nullable: false),
            //        cantidad = table.Column<int>(type: "int", nullable: false),
            //        precio_unitario = table.Column<int>(type: "int", nullable: false),
            //        subtotal = table.Column<int>(type: "int", nullable: false),
            //        precio_final = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__compra_x__9AE7DA60D74DA705", x => x.id_compra_x_repuesto);
            //        table.ForeignKey(
            //            name: "FK__compra_x___fk_ca__6C190EBB",
            //            column: x => x.fk_categoria,
            //            principalTable: "categoria",
            //            principalColumn: "id_categoria");
            //        table.ForeignKey(
            //            name: "FK__compra_x___fk_co__6B24EA82",
            //            column: x => x.fk_compra,
            //            principalTable: "compras",
            //            principalColumn: "id_compra");
            //        table.ForeignKey(
            //            name: "FK__compra_x___fk_re__6D0D32F4",
            //            column: x => x.fk_repuesto,
            //            principalTable: "repuestos",
            //            principalColumn: "id_repuesto");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "venta_x_repuestos",
            //    columns: table => new
            //    {
            //        id_venta_x_repuesto = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        fk_venta = table.Column<int>(type: "int", nullable: false),
            //        fk_categoria = table.Column<int>(type: "int", nullable: false),
            //        fk_repuesto = table.Column<int>(type: "int", nullable: false),
            //        fk_mecanico = table.Column<int>(type: "int", nullable: false),
            //        fk_servicio = table.Column<int>(type: "int", nullable: false),
            //        fk_cliente = table.Column<int>(type: "int", nullable: false),
            //        precio_mano_obra = table.Column<int>(type: "int", nullable: false),
            //        cantidad = table.Column<int>(type: "int", nullable: false),
            //        precio_unitario = table.Column<int>(type: "int", nullable: false),
            //        subtotal = table.Column<int>(type: "int", nullable: false),
            //        precio_final = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__venta_x___AA09E4D69E25184C", x => x.id_venta_x_repuesto);
            //        table.ForeignKey(
            //            name: "FK__venta_x_r__fk_ca__70DDC3D8",
            //            column: x => x.fk_categoria,
            //            principalTable: "categoria",
            //            principalColumn: "id_categoria");
            //        table.ForeignKey(
            //            name: "FK__venta_x_r__fk_cl__74AE54BC",
            //            column: x => x.fk_cliente,
            //            principalTable: "clientes",
            //            principalColumn: "id_cliente");
            //        table.ForeignKey(
            //            name: "FK__venta_x_r__fk_me__72C60C4A",
            //            column: x => x.fk_mecanico,
            //            principalTable: "mecanicos",
            //            principalColumn: "id_mecanico");
            //        table.ForeignKey(
            //            name: "FK__venta_x_r__fk_re__71D1E811",
            //            column: x => x.fk_repuesto,
            //            principalTable: "repuestos",
            //            principalColumn: "id_repuesto");
            //        table.ForeignKey(
            //            name: "FK__venta_x_r__fk_se__73BA3083",
            //            column: x => x.fk_servicio,
            //            principalTable: "servicios",
            //            principalColumn: "id_servicio");
            //        table.ForeignKey(
            //            name: "FK__venta_x_r__fk_ve__6FE99F9F",
            //            column: x => x.fk_venta,
            //            principalTable: "ventas",
            //            principalColumn: "id_venta");
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_compra_x_repuesto_fk_categoria",
                table: "compra_x_repuesto",
                column: "fk_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_compra_x_repuesto_fk_compra",
                table: "compra_x_repuesto",
                column: "fk_compra");

            migrationBuilder.CreateIndex(
                name: "IX_compra_x_repuesto_fk_repuesto",
                table: "compra_x_repuesto",
                column: "fk_repuesto");

            migrationBuilder.CreateIndex(
                name: "IX_repuestos_fk_categoria",
                table: "repuestos",
                column: "fk_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_venta_x_repuestos_fk_categoria",
                table: "venta_x_repuestos",
                column: "fk_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_venta_x_repuestos_fk_cliente",
                table: "venta_x_repuestos",
                column: "fk_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_venta_x_repuestos_fk_mecanico",
                table: "venta_x_repuestos",
                column: "fk_mecanico");

            migrationBuilder.CreateIndex(
                name: "IX_venta_x_repuestos_fk_repuesto",
                table: "venta_x_repuestos",
                column: "fk_repuesto");

            migrationBuilder.CreateIndex(
                name: "IX_venta_x_repuestos_fk_servicio",
                table: "venta_x_repuestos",
                column: "fk_servicio");

            migrationBuilder.CreateIndex(
                name: "IX_venta_x_repuestos_fk_venta",
                table: "venta_x_repuestos",
                column: "fk_venta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "compra_x_repuesto");

            migrationBuilder.DropTable(
                name: "venta_x_repuestos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "compras");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "mecanicos");

            migrationBuilder.DropTable(
                name: "repuestos");

            migrationBuilder.DropTable(
                name: "servicios");

            migrationBuilder.DropTable(
                name: "ventas");

            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
