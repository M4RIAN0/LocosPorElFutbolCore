using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarroCompras",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarroCompras", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Envios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrdenCompras",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenCompras", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NombreNormalizado = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreUsuario = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NombreUsuarioNormalizado = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailNormalizado = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmado = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CelularConfirmado = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonasClientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonasClientes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonasClientes_Personas_ID",
                        column: x => x.ID,
                        principalTable: "Personas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CP = table.Column<int>(type: "int", nullable: false),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Localidades_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincias",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UsuarioRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRoles_Usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductosVariantes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Talle = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CodigoBarra = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosVariantes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductosVariantes_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonaClienteID = table.Column<int>(type: "int", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Facturas_PersonasClientes_PersonaClienteID",
                        column: x => x.PersonaClienteID,
                        principalTable: "PersonasClientes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DetalleCarroCompras",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarroComprasId = table.Column<int>(type: "int", nullable: false),
                    ProductoVarianteId = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCarroCompras", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DetalleCarroCompras_CarroCompras_CarroComprasId",
                        column: x => x.CarroComprasId,
                        principalTable: "CarroCompras",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleCarroCompras_ProductosVariantes_ProductoVarianteId",
                        column: x => x.ProductoVarianteId,
                        principalTable: "ProductosVariantes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrdenCompras",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrdenComprasId = table.Column<int>(type: "int", nullable: false),
                    ProductoVarianteId = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrdenCompras", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenCompras_OrdenCompras_OrdenComprasId",
                        column: x => x.OrdenComprasId,
                        principalTable: "OrdenCompras",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenCompras_ProductosVariantes_ProductoVarianteId",
                        column: x => x.ProductoVarianteId,
                        principalTable: "ProductosVariantes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comprobantes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    EnvioId = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobantes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comprobantes_Envios_EnvioId",
                        column: x => x.EnvioId,
                        principalTable: "Envios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comprobantes_Facturas_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Facturas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comprobantes_PersonasClientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "PersonasClientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleComprobantes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CodigoBarra = table.Column<int>(type: "int", nullable: false),
                    ProductoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Talle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    ComprobanteId = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleComprobantes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DetalleComprobantes_Comprobantes_ComprobanteId",
                        column: x => x.ComprobanteId,
                        principalTable: "Comprobantes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleComprobantes_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "ID", "Descripcion", "IsDeleted", "IsEnabled" },
                values: new object[,]
                {
                    { 1, "Camisetas Futbol", false, false },
                    { 2, "Shorts", false, false },
                    { 3, "Pantalones", false, false },
                    { 4, "Camperas", false, false },
                    { 5, "Zapatillas", false, false }
                });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "ID", "Descripcion", "IsDeleted", "IsEnabled" },
                values: new object[,]
                {
                    { 1, "Nike", false, false },
                    { 2, "Adidas", false, false },
                    { 3, "Puma", false, false },
                    { 4, "Reebok", false, false },
                    { 5, "Dc", false, false },
                    { 6, "Vans", false, false },
                    { 7, "Adidas-Classic", false, false },
                    { 8, "Under-Armour", false, false }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "ID", "Apellido", "Celular", "Direccion", "Dni", "Email", "FechaNacimiento", "IsDeleted", "IsEnabled", "Nombre", "Sexo" },
                values: new object[] { 1, "Martinez Melek", "3814498305", "Matienzo 1870, Planta baja B, San Miguel de Tucumán, Tucumán", "39140888", "admin@gmail.com", new DateOnly(1995, 8, 12), false, false, "Maria Lourdes", "Femenino" });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ID", "IsDeleted", "IsEnabled", "Nombre" },
                values: new object[,]
                {
                    { 1, false, false, "Buenos Aires" },
                    { 2, false, false, "Catamarca	" },
                    { 3, false, false, "Chaco" },
                    { 4, false, false, "Chubut" },
                    { 5, false, false, "Cordoba" },
                    { 6, false, false, "Corrientes" },
                    { 7, false, false, "Entre Ríos" },
                    { 8, false, false, "Formosa" },
                    { 9, false, false, "Jujuy" },
                    { 10, false, false, "La Pampa" },
                    { 11, false, false, "La Rioja" },
                    { 12, false, false, "Mendoza" },
                    { 13, false, false, "Misiones" },
                    { 14, false, false, "Neuquén" },
                    { 15, false, false, "Río Negro" },
                    { 16, false, false, "Salta" },
                    { 17, false, false, "San Juan" },
                    { 18, false, false, "San Luis" },
                    { 19, false, false, "Santa Cruz" },
                    { 20, false, false, "Santa Fe" },
                    { 21, false, false, "Santiago del Estero" },
                    { 22, false, false, "Tierra del Fuego" },
                    { 23, false, false, "Tucumán" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Nombre", "NombreNormalizado" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", "11111111-1111-1111-1111-111111111111", "Administrador", "ADMINISTRADOR" },
                    { "22222222-2222-2222-2222-222222222222", "22222222-2222-2222-2222-222222222222", "Cliente", "CLIENTE" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmado", "LockoutEnabled", "LockoutEnd", "Nombre", "EmailNormalizado", "NombreUsuarioNormalizado", "PasswordHash", "Celular", "CelularConfirmado", "SecurityStamp", "TwoFactorEnabled", "NombreUsuario" },
                values: new object[] { "33333333-3333-3333-3333-333333333333", 0, "250d3bc5-e689-4905-9a49-6979443b1453", "admin@gmail.com", true, false, null, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEC6ep+zmlAjaAL91xwG+eLsyucN/PRaqE1XCduWffqSQxclbcGFj3kf9xoIr9XyTTw==", "3814498305", true, "33333333-3333-3333-3333-333333333333", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "Localidades",
                columns: new[] { "ID", "CP", "IsDeleted", "IsEnabled", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 1, 6430, false, false, "Adolfo Alsina", 1 },
                    { 2, 1870, false, false, "Avellaneda", 1 },
                    { 3, 4751, false, false, "San Fernando del Valle de Catamarca", 2 },
                    { 4, 4139, false, false, "Santa Maria", 2 },
                    { 5, 3500, false, false, "Resistencia", 3 },
                    { 6, 3503, false, false, "Barranqueras", 3 },
                    { 7, 9100, false, false, "Trelew", 4 },
                    { 8, 9120, false, false, "Puerto Madryn", 4 },
                    { 9, 5152, false, false, "Carlos Paz", 5 },
                    { 10, 5223, false, false, "Jesus Maria", 5 },
                    { 11, 3409, false, false, "Paso de la Patria", 6 },
                    { 12, 3302, false, false, "Ituzaingo", 6 },
                    { 13, 3100, false, false, "Parana", 7 },
                    { 14, 3200, false, false, "Concordia", 7 },
                    { 15, 3630, false, false, "Las Lomitas", 8 },
                    { 16, 3610, false, false, "Clorinda", 8 },
                    { 17, 4600, false, false, "San Salvador de Jujuy", 9 },
                    { 18, 4500, false, false, "San Pedro", 9 },
                    { 19, 6300, false, false, "Santa Rosa", 10 },
                    { 20, 6360, false, false, "General Pico", 10 },
                    { 21, 5360, false, false, "Chalecito", 11 },
                    { 22, 26540, false, false, "Alfaro", 11 },
                    { 23, 5501, false, false, "Godoy Cruz", 12 },
                    { 24, 5507, false, false, "Lujan de Cuyo", 12 },
                    { 25, 3300, false, false, "Posadas", 13 },
                    { 26, 3370, false, false, "Puerto Iguazu", 13 },
                    { 27, 8300, false, false, "Neuquen", 14 },
                    { 28, 8316, false, false, "Plottier", 14 },
                    { 29, 8332, false, false, "General Roca", 15 },
                    { 30, 8324, false, false, "Cipolletti", 15 },
                    { 31, 4440, false, false, "Metan", 16 },
                    { 32, 4430, false, false, "Guemes", 16 },
                    { 33, 5400, false, false, "Rivadavia", 17 },
                    { 34, 5411, false, false, "Santa Lucia", 17 },
                    { 35, 5700, false, false, "Juan Martín de Pueyrredón", 18 },
                    { 36, 5705, false, false, "San Francisco del Monte de Oro", 18 },
                    { 37, 9400, false, false, "Río Gallegos", 19 },
                    { 38, 9405, false, false, "El Calafate", 19 },
                    { 39, 2000, false, false, "Rosario", 20 },
                    { 40, 3560, false, false, "Reconquista", 20 },
                    { 41, 4200, false, false, "Santiago del Estero", 21 },
                    { 42, 4202, false, false, "La Banda", 21 },
                    { 43, 9410, false, false, "Ushuaia ", 22 },
                    { 44, 9420, false, false, "Rio Grande", 22 },
                    { 45, 4000, false, false, "San Miguel de Tucuman", 23 },
                    { 46, 4001, false, false, "Yerba Buena", 23 }
                });

            migrationBuilder.InsertData(
                table: "PersonasClientes",
                column: "ID",
                value: 1);

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ID", "CategoriaId", "Descripcion", "Genero", "ImagenUrl", "IsDeleted", "IsEnabled", "MarcaId", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, 1, "Un clásico renovado. La nueva colección de Nike destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Hombre", "/images/Productos/Prod-Name-camiseta-futbol-nike-inter-milan-titular.jpg", false, false, 1, "Camiseta Futbol Nike Inter Milan Titular", 98000m },
                    { 2, 1, "Increíble diseño en camiseta futbol Nike Ultra. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para mujer.", "Mujer", "/images/Productos/Prod-Name-camiseta-futbol-nike-barcelona-alternativa.jpg", false, false, 1, "Camiseta Futbol Nike Barcelona Alternativa", 83000m },
                    { 3, 1, "Increíble diseño en camiseta futbol Nike Elite. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para unisex.", "Unisex", "/images/Productos/Prod-Name-camiseta-futbol-nike-barcelona-titular.jpg", false, false, 1, "Camiseta Futbol Nike Barcelona Titular", 16000m },
                    { 4, 1, "Supera tus límites con lo nuevo en camiseta futbol Adidas. Pensado especialmente para hombre, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Tech.", "Hombre", "/images/Productos/Prod-Name-camiseta-futbol-adidas-river-plate-titular.jpg", false, false, 2, "Camiseta Futbol Adidas River Plate Titular", 68000m },
                    { 5, 1, "Increíble diseño en camiseta futbol Adidas Sport. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para mujer.", "Mujer", "/images/Productos/Prod-Name-camiseta-futbol-adidas-river-plate-alternativa.jpg", false, false, 2, "Camiseta Futbol Adidas River Plate Alternativa", 31000m },
                    { 6, 1, "Descubre el confort absoluto con este modelo de Adidas. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Unisex", "/images/Productos/Prod-Name-camiseta-futbol-adidas-boca-juniors-titular.jpg", false, false, 2, "Camiseta Futbol Adidas Boca Juniors Titular", 86000m },
                    { 7, 1, "Increíble diseño en camiseta futbol Puma Tech. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para hombre.", "Hombre", "/images/Productos/Prod-Name-camiseta-futbol-puma-stade-rennais-titular.jpg", false, false, 3, "Camiseta Futbol Puma Stade Rennais Titular", 15000m },
                    { 8, 1, "Increíble diseño en camiseta futbol Puma Ultra. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para mujer.", "Mujer", "/images/Productos/Prod-Name-camiseta-futbol-puma-manchester-city-titular.jpg", false, false, 3, "Camiseta Futbol Puma Manchester City Titular", 17000m },
                    { 9, 1, "Un clásico renovado. La nueva colección de Puma destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Unisex", "/images/Productos/Prod-Name-camiseta-futbol-puma-paraguay-titular.jpg", false, false, 3, "Camiseta Futbol Puma Paraguay Titular", 79000m },
                    { 10, 1, "Increíble diseño en camiseta futbol Reebok Essential. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para hombre.", "Hombre", "/images/Productos/Prod-Name-camiseta-futbol-reebok-botafogo-titular.jpg", false, false, 4, "Camiseta Futbol Reebok Botafogo Titular", 91000m },
                    { 11, 1, "Un clásico renovado. La nueva colección de Reebok destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Mujer", "/images/Productos/Prod-Name-camiseta-futbol-reebok-botafogo-suplente.jpg", false, false, 4, "Camiseta Futbol Reebok Botafogo Suplente", 65000m },
                    { 12, 1, "Increíble diseño en camiseta futbol Reebok Essential. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para unisex.", "Unisex", "/images/Productos/Prod-Name-camiseta-futbol-reebok-essential-serie-3.jpg", false, false, 4, "Camiseta Futbol Reebok Essential Serie 3", 21000m },
                    { 13, 1, "Supera tus límites con lo nuevo en camiseta futbol Dc. Pensado especialmente para hombre, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Classic.", "Hombre", "/images/Productos/Prod-Name-camiseta-futbol-dc-classic-serie-1.jpg", false, false, 5, "Camiseta Futbol Dc Classic Serie 1", 92000m },
                    { 15, 1, "Un clásico renovado. La nueva colección de Dc destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Unisex", "/images/Productos/Prod-Name-camiseta-futbol-dc-elite-serie-3.jpg", false, false, 5, "Camiseta Futbol Dc Elite Serie 3", 56000m },
                    { 19, 1, "Increíble diseño en camiseta futbol Adidas-Classic Tech. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para hombre.", "Hombre", "/images/Productos/Prod-Name-camiseta-futbol-adidas-classic-argentina-suplente.jpg", false, false, 7, "Camiseta Futbol Adidas Classic Argentina Suplente", 84000m },
                    { 20, 1, "Increíble diseño en camiseta futbol Adidas-Classic Pro. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para mujer.", "Mujer", "/images/Productos/Prod-Name-camiseta-futbol-adidas-classic-españa-suplente.jpg", false, false, 7, "Camiseta Futbol Adidas Classic España Suplente", 78000m },
                    { 21, 1, "Un clásico renovado. La nueva colección de Adidas-Classic destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Unisex", "/images/Productos/Prod-Name-camiseta-futbol-adidas-classic-elite-serie-3.jpg", false, false, 7, "Camiseta Futbol Adidas-Classic Elite Serie 3", 45000m },
                    { 22, 1, "Increíble diseño en camiseta futbol Under-Armour Pro. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para hombre.", "Hombre", "/images/Productos/Prod-Name-camiseta-futbol-under-armour-estudiantes-de-la-plata-titular.jpg", false, false, 8, "Camiseta Futbol Under Armour Estudiantes de la Plata Titular", 19000m },
                    { 23, 1, "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de Elite una pieza indispensable en tu guardarropa.", "Mujer", "/images/Productos/Prod-Name-camiseta-futbol-under-armour-sydney-fc-titular.jpg", false, false, 8, "Camiseta Futbol Under Armour Sydney FC Titular", 77000m },
                    { 24, 1, "Descubre el confort absoluto con este modelo de Under-Armour. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Unisex", "/images/Productos/Prod-Name-camiseta-futbol-under-armour-tech-serie-3.jpg", false, false, 8, "Camiseta Futbol Under-Armour Tech Serie 3", 98000m },
                    { 25, 2, "Increíble diseño en short Nike Classic. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para hombre.", "Hombre", "/images/Productos/Prod-Name-short-nike-classic-serie-1.jpg", false, false, 1, "Short Nike Classic Serie 1", 87000m },
                    { 26, 2, "Supera tus límites con lo nuevo en short Nike. Pensado especialmente para mujer, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Essential.", "Mujer", "/images/Productos/Prod-Name-short-nike-essential-serie-2.jpg", false, false, 1, "Short Nike Essential Serie 2", 38000m },
                    { 27, 2, "Supera tus límites con lo nuevo en short Nike. Pensado especialmente para unisex, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Max.", "Unisex", "/images/Productos/Prod-Name-short-nike-max-serie-3.jpg", false, false, 1, "Short Nike Max Serie 3", 35000m },
                    { 28, 2, "Increíble diseño en short Adidas Ultra. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para hombre.", "Hombre", "/images/Productos/Prod-Name-short-adidas-ultra-serie-1.jpg", false, false, 2, "Short Adidas Ultra Serie 1", 40000m },
                    { 29, 2, "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de Sport una pieza indispensable en tu guardarropa.", "Mujer", "/images/Productos/Prod-Name-short-adidas-sport-serie-2.jpg", false, false, 2, "Short Adidas Sport Serie 2", 52000m },
                    { 30, 2, "Un clásico renovado. La nueva colección de Adidas destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Unisex", "/images/Productos/Prod-Name-short-adidas-classic-serie-3.jpg", false, false, 2, "Short Adidas Classic Serie 3", 33000m },
                    { 31, 2, "Increíble diseño en short Puma Elite. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para hombre.", "Hombre", "/images/Productos/Prod-Name-short-puma-elite-serie-1.jpg", false, false, 3, "Short Puma Elite Serie 1", 97000m },
                    { 32, 2, "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de Sport una pieza indispensable en tu guardarropa.", "Mujer", "/images/Productos/Prod-Name-short-puma-sport-serie-2.jpg", false, false, 3, "Short Puma Sport Serie 2", 41000m },
                    { 33, 2, "Increíble diseño en short Puma Sport. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para unisex.", "Unisex", "/images/Productos/Prod-Name-short-puma-sport-serie-3.jpg", false, false, 3, "Short Puma Sport Serie 3", 37000m },
                    { 34, 2, "Increíble diseño en short Reebok Urban. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para hombre.", "Hombre", "/images/Productos/Prod-Name-short-reebok-urban-serie-1.jpg", false, false, 4, "Short Reebok Urban Serie 1", 74000m },
                    { 35, 2, "Supera tus límites con lo nuevo en short Reebok. Pensado especialmente para mujer, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Elite.", "Mujer", "/images/Productos/Prod-Name-short-reebok-elite-serie-2.jpg", false, false, 4, "Short Reebok Elite Serie 2", 58000m },
                    { 36, 2, "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de Urban una pieza indispensable en tu guardarropa.", "Unisex", "/images/Productos/Prod-Name-short-reebok-urban-serie-3.jpg", false, false, 4, "Short Reebok Urban Serie 3", 43000m },
                    { 37, 2, "Supera tus límites con lo nuevo en short Dc. Pensado especialmente para hombre, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Essential.", "Hombre", "/images/Productos/Prod-Name-short-dc-essential-serie-1.jpg", false, false, 5, "Short Dc Essential Serie 1", 60000m },
                    { 38, 2, "Supera tus límites con lo nuevo en short Dc. Pensado especialmente para mujer, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Sport.", "Mujer", "/images/Productos/Prod-Name-short-dc-sport-serie-2.jpg", false, false, 5, "Short Dc Sport Serie 2", 61000m },
                    { 39, 2, "Descubre el confort absoluto con este modelo de Dc. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Unisex", "/images/Productos/Prod-Name-short-dc-pro-serie-3.jpg", false, false, 5, "Short Dc Pro Serie 3", 70000m },
                    { 40, 2, "Supera tus límites con lo nuevo en short Vans. Pensado especialmente para hombre, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Max.", "Hombre", "/images/Productos/Prod-Name-short-vans-max-serie-1.jpg", false, false, 6, "Short Vans Max Serie 1", 64000m },
                    { 42, 2, "Un clásico renovado. La nueva colección de Vans destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Unisex", "/images/Productos/Prod-Name-short-vans-pro-serie-3.jpg", false, false, 6, "Short Vans Pro Serie 3", 35000m },
                    { 43, 2, "Un clásico renovado. La nueva colección de Adidas-Classic destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Hombre", "/images/Productos/Prod-Name-short-adidas-classic-essential-serie-1.jpg", false, false, 7, "Short Adidas-Classic Essential Serie 1", 33000m },
                    { 44, 2, "Increíble diseño en short Adidas-Classic Pro. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para mujer.", "Mujer", "/images/Productos/Prod-Name-short-adidas-classic-pro-serie-2.jpg", false, false, 7, "Short Adidas-Classic Pro Serie 2", 31000m },
                    { 45, 2, "Descubre el confort absoluto con este modelo de Adidas-Classic. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Unisex", "/images/Productos/Prod-Name-short-adidas-classic-essential-serie-3.jpg", false, false, 7, "Short Adidas-Classic Essential Serie 3", 51000m },
                    { 46, 2, "Supera tus límites con lo nuevo en short Under-Armour. Pensado especialmente para hombre, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Ultra.", "Hombre", "/images/Productos/Prod-Name-short-under-armour-ultra-serie-1.jpg", false, false, 8, "Short Under-Armour Ultra Serie 1", 47000m },
                    { 47, 2, "Increíble diseño en short Under-Armour Elite. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para mujer.", "Mujer", "/images/Productos/Prod-Name-short-under-armour-elite-serie-2.jpg", false, false, 8, "Short Under-Armour Elite Serie 2", 56000m },
                    { 48, 2, "Un clásico renovado. La nueva colección de Under-Armour destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Unisex", "/images/Productos/Prod-Name-short-under-armour-max-serie-3.jpg", false, false, 8, "Short Under-Armour Max Serie 3", 18000m },
                    { 49, 3, "Un clásico renovado. La nueva colección de Nike destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Hombre", "/images/Productos/Prod-Name-pantalon-nike-sport-serie-1.jpg", false, false, 1, "Pantalon Nike Sport Serie 1", 32000m },
                    { 50, 3, "Descubre el confort absoluto con este modelo de Nike. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Mujer", "/images/Productos/Prod-Name-pantalon-nike-max-serie-2.jpg", false, false, 1, "Pantalon Nike Max Serie 2", 77000m },
                    { 51, 3, "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de Max una pieza indispensable en tu guardarropa.", "Unisex", "/images/Productos/Prod-Name-pantalon-nike-max-serie-3.jpg", false, false, 1, "Pantalon Nike Max Serie 3", 51000m },
                    { 52, 3, "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de Sport una pieza indispensable en tu guardarropa.", "Hombre", "/images/Productos/Prod-Name-pantalon-adidas-sport-serie-1.jpg", false, false, 2, "Pantalon Adidas Sport Serie 1", 63000m },
                    { 53, 3, "Increíble diseño en pantalon Adidas Classic. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para mujer.", "Mujer", "/images/Productos/Prod-Name-pantalon-adidas-classic-serie-2.jpg", false, false, 2, "Pantalon Adidas Classic Serie 2", 31000m },
                    { 54, 3, "Un clásico renovado. La nueva colección de Adidas destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Unisex", "/images/Productos/Prod-Name-pantalon-adidas-elite-serie-3.jpg", false, false, 2, "Pantalon Adidas Elite Serie 3", 82000m },
                    { 55, 3, "Supera tus límites con lo nuevo en pantalon Puma. Pensado especialmente para hombre, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Urban.", "Hombre", "/images/Productos/Prod-Name-pantalon-puma-urban-serie-1.jpg", false, false, 3, "Pantalon Puma Urban Serie 1", 17000m },
                    { 56, 3, "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de Elite una pieza indispensable en tu guardarropa.", "Mujer", "/images/Productos/Prod-Name-pantalon-puma-elite-serie-2.jpg", false, false, 3, "Pantalon Puma Elite Serie 2", 43000m },
                    { 57, 3, "Descubre el confort absoluto con este modelo de Puma. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Unisex", "/images/Productos/Prod-Name-pantalon-puma-classic-serie-3.jpg", false, false, 3, "Pantalon Puma Classic Serie 3", 27000m },
                    { 58, 3, "Supera tus límites con lo nuevo en pantalon Reebok. Pensado especialmente para hombre, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Pro.", "Hombre", "/images/Productos/Prod-Name-pantalon-reebok-pro-serie-1.jpg", false, false, 4, "Pantalon Reebok Pro Serie 1", 84000m },
                    { 59, 3, "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de Elite una pieza indispensable en tu guardarropa.", "Mujer", "/images/Productos/Prod-Name-pantalon-reebok-elite-serie-2.jpg", false, false, 4, "Pantalon Reebok Elite Serie 2", 53000m },
                    { 60, 3, "Supera tus límites con lo nuevo en pantalon Reebok. Pensado especialmente para unisex, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Pro.", "Unisex", "/images/Productos/Prod-Name-pantalon-reebok-pro-serie-3.jpg", false, false, 4, "Pantalon Reebok Pro Serie 3", 29000m },
                    { 61, 3, "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de Sport una pieza indispensable en tu guardarropa.", "Hombre", "/images/Productos/Prod-Name-pantalon-dc-sport-serie-1.jpg", false, false, 5, "Pantalon Dc Sport Serie 1", 21000m },
                    { 62, 3, "Descubre el confort absoluto con este modelo de Dc. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Mujer", "/images/Productos/Prod-Name-pantalon-dc-ultra-serie-2.jpg", false, false, 5, "Pantalon Dc Ultra Serie 2", 49000m },
                    { 63, 3, "Increíble diseño en pantalon Dc Retro. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para unisex.", "Unisex", "/images/Productos/Prod-Name-pantalon-dc-retro-serie-3.jpg", false, false, 5, "Pantalon Dc Retro Serie 3", 37000m },
                    { 64, 3, "Supera tus límites con lo nuevo en pantalon Vans. Pensado especialmente para hombre, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Elite.", "Hombre", "/images/Productos/Prod-Name-pantalon-vans-elite-serie-1.jpg", false, false, 6, "Pantalon Vans Elite Serie 1", 50000m },
                    { 65, 3, "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de Max una pieza indispensable en tu guardarropa.", "Mujer", "/images/Productos/Prod-Name-pantalon-vans-max-serie-2.jpg", false, false, 6, "Pantalon Vans Max Serie 2", 49000m },
                    { 66, 3, "Descubre el confort absoluto con este modelo de Vans. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Unisex", "/images/Productos/Prod-Name-pantalon-vans-pro-serie-3.jpg", false, false, 6, "Pantalon Vans Pro Serie 3", 46000m },
                    { 67, 3, "Descubre el confort absoluto con este modelo de Adidas-Classic. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Hombre", "/images/Productos/Prod-Name-pantalon-adidas-classic-retro-serie-1.jpg", false, false, 7, "Pantalon Adidas-Classic Retro Serie 1", 28000m },
                    { 68, 3, "Descubre el confort absoluto con este modelo de Adidas-Classic. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Mujer", "/images/Productos/Prod-Name-pantalon-adidas-classic-essential-serie-2.jpg", false, false, 7, "Pantalon Adidas-Classic Essential Serie 2", 76000m },
                    { 69, 3, "Supera tus límites con lo nuevo en pantalon Adidas-Classic. Pensado especialmente para unisex, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Max.", "Unisex", "/images/Productos/Prod-Name-pantalon-adidas-classic-max-serie-3.jpg", false, false, 7, "Pantalon Adidas-Classic Max Serie 3", 23000m },
                    { 70, 3, "Descubre el confort absoluto con este modelo de Under-Armour. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Hombre", "/images/Productos/Prod-Name-pantalon-under-armour-elite-serie-1.jpg", false, false, 8, "Pantalon Under-Armour Elite Serie 1", 41000m },
                    { 71, 3, "Descubre el confort absoluto con este modelo de Under-Armour. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Mujer", "/images/Productos/Prod-Name-pantalon-under-armour-pro-serie-2.jpg", false, false, 8, "Pantalon Under-Armour Pro Serie 2", 15000m },
                    { 72, 3, "Un clásico renovado. La nueva colección de Under-Armour destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Unisex", "/images/Productos/Prod-Name-pantalon-under-armour-ultra-serie-3.jpg", false, false, 8, "Pantalon Under-Armour Ultra Serie 3", 62000m },
                    { 73, 4, "Supera tus límites con lo nuevo en campera Nike. Pensado especialmente para hombre, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Max.", "Hombre", "/images/Productos/Prod-Name-campera-nike-max-serie-1.jpg", false, false, 1, "Campera Nike Max Serie 1", 89000m },
                    { 74, 4, "Descubre el confort absoluto con este modelo de Nike. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Mujer", "/images/Productos/Prod-Name-campera-nike-pro-serie-2.jpg", false, false, 1, "Campera Nike Pro Serie 2", 32000m },
                    { 75, 4, "Increíble diseño en campera Nike Ultra. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para unisex.", "Unisex", "/images/Productos/Prod-Name-campera-nike-ultra-serie-3.jpg", false, false, 1, "Campera Nike Ultra Serie 3", 90000m },
                    { 76, 4, "Descubre el confort absoluto con este modelo de Adidas. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Hombre", "/images/Productos/Prod-Name-campera-adidas-sport-serie-1.jpg", false, false, 2, "Campera Adidas Sport Serie 1", 80000m },
                    { 77, 4, "Increíble diseño en campera Adidas Pro. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para mujer.", "Mujer", "/images/Productos/Prod-Name-campera-adidas-pro-serie-2.jpg", false, false, 2, "Campera Adidas Pro Serie 2", 60000m },
                    { 78, 4, "Increíble diseño en campera Adidas Pro. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para unisex.", "Unisex", "/images/Productos/Prod-Name-campera-adidas-pro-serie-3.jpg", false, false, 2, "Campera Adidas Pro Serie 3", 59000m },
                    { 79, 4, "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de Urban una pieza indispensable en tu guardarropa.", "Hombre", "/images/Productos/Prod-Name-campera-puma-urban-serie-1.jpg", false, false, 3, "Campera Puma Urban Serie 1", 39000m },
                    { 80, 4, "Increíble diseño en campera Puma Urban. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para mujer.", "Mujer", "/images/Productos/Prod-Name-campera-puma-urban-serie-2.jpg", false, false, 3, "Campera Puma Urban Serie 2", 56000m },
                    { 81, 4, "Un clásico renovado. La nueva colección de Puma destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Unisex", "/images/Productos/Prod-Name-campera-puma-tech-serie-3.jpg", false, false, 3, "Campera Puma Tech Serie 3", 79000m },
                    { 82, 4, "Increíble diseño en campera Reebok Sport. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para hombre.", "Hombre", "/images/Productos/Prod-Name-campera-reebok-sport-serie-1.jpg", false, false, 4, "Campera Reebok Sport Serie 1", 79000m },
                    { 83, 4, "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de Retro una pieza indispensable en tu guardarropa.", "Mujer", "/images/Productos/Prod-Name-campera-reebok-retro-serie-2.jpg", false, false, 4, "Campera Reebok Retro Serie 2", 37000m },
                    { 84, 4, "Descubre el confort absoluto con este modelo de Reebok. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Unisex", "/images/Productos/Prod-Name-campera-reebok-sport-serie-3.jpg", false, false, 4, "Campera Reebok Sport Serie 3", 42000m },
                    { 85, 4, "Un clásico renovado. La nueva colección de Dc destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Hombre", "/images/Productos/Prod-Name-campera-dc-tech-serie-1.jpg", false, false, 5, "Campera Dc Tech Serie 1", 78000m },
                    { 86, 4, "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de Retro una pieza indispensable en tu guardarropa.", "Mujer", "/images/Productos/Prod-Name-campera-dc-retro-serie-2.jpg", false, false, 5, "Campera Dc Retro Serie 2", 20000m },
                    { 87, 4, "Increíble diseño en campera Dc Urban. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para unisex.", "Unisex", "/images/Productos/Prod-Name-campera-dc-urban-serie-3.jpg", false, false, 5, "Campera Dc Urban Serie 3", 42000m },
                    { 88, 4, "Increíble diseño en campera Vans Ultra. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para hombre.", "Hombre", "/images/Productos/Prod-Name-campera-vans-ultra-serie-1.jpg", false, false, 6, "Campera Vans Ultra Serie 1", 31000m },
                    { 89, 4, "Increíble diseño en campera Vans Sport. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para mujer.", "Mujer", "/images/Productos/Prod-Name-campera-vans-sport-serie-2.jpg", false, false, 6, "Campera Vans Sport Serie 2", 27000m },
                    { 90, 4, "Descubre el confort absoluto con este modelo de Vans. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Unisex", "/images/Productos/Prod-Name-campera-vans-classic-serie-3.jpg", false, false, 6, "Campera Vans Classic Serie 3", 21000m },
                    { 91, 4, "Descubre el confort absoluto con este modelo de Adidas-Classic. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Hombre", "/images/Productos/Prod-Name-campera-adidas-classic-urban-serie-1.jpg", false, false, 7, "Campera Adidas-Classic Urban Serie 1", 78000m },
                    { 92, 4, "Increíble diseño en campera Adidas-Classic Sport. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para mujer.", "Mujer", "/images/Productos/Prod-Name-campera-adidas-classic-sport-serie-2.jpg", false, false, 7, "Campera Adidas-Classic Sport Serie 2", 51000m },
                    { 93, 4, "Descubre el confort absoluto con este modelo de Adidas-Classic. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Unisex", "/images/Productos/Prod-Name-campera-adidas-classic-elite-serie-3.jpg", false, false, 7, "Campera Adidas-Classic Elite Serie 3", 57000m },
                    { 94, 4, "Supera tus límites con lo nuevo en campera Under-Armour. Pensado especialmente para hombre, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Essential.", "Hombre", "/images/Productos/Prod-Name-campera-under-armour-essential-serie-1.jpg", false, false, 8, "Campera Under-Armour Essential Serie 1", 93000m },
                    { 95, 4, "Un clásico renovado. La nueva colección de Under-Armour destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Mujer", "/images/Productos/Prod-Name-campera-under-armour-classic-serie-2.jpg", false, false, 8, "Campera Under-Armour Classic Serie 2", 50000m },
                    { 96, 4, "Increíble diseño en campera Under-Armour Ultra. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para unisex.", "Unisex", "/images/Productos/Prod-Name-campera-under-armour-ultra-serie-3.jpg", false, false, 8, "Campera Under-Armour Ultra Serie 3", 80000m },
                    { 97, 5, "Supera tus límites con lo nuevo en zapatilla Nike. Pensado especialmente para hombre, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Classic.", "Hombre", "/images/Productos/Prod-Name-zapatilla-nike-classic-serie-1.jpg", false, false, 1, "Zapatilla Nike Classic Serie 1", 46000m },
                    { 98, 5, "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de Elite una pieza indispensable en tu guardarropa.", "Mujer", "/images/Productos/Prod-Name-zapatilla-nike-elite-serie-2.jpg", false, false, 1, "Zapatilla Nike Elite Serie 2", 19000m },
                    { 99, 5, "Increíble diseño en zapatilla Nike Essential. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para unisex.", "Unisex", "/images/Productos/Prod-Name-zapatilla-nike-essential-serie-3.jpg", false, false, 1, "Zapatilla Nike Essential Serie 3", 97000m },
                    { 100, 5, "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de Max una pieza indispensable en tu guardarropa.", "Hombre", "/images/Productos/Prod-Name-zapatilla-adidas-max-serie-1.jpg", false, false, 2, "Zapatilla Adidas Max Serie 1", 77000m },
                    { 101, 5, "Supera tus límites con lo nuevo en zapatilla Adidas. Pensado especialmente para mujer, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Elite.", "Mujer", "/images/Productos/Prod-Name-zapatilla-adidas-elite-serie-2.jpg", false, false, 2, "Zapatilla Adidas Elite Serie 2", 26000m },
                    { 102, 5, "Increíble diseño en zapatilla Adidas Essential. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para unisex.", "Unisex", "/images/Productos/Prod-Name-zapatilla-adidas-essential-serie-3.jpg", false, false, 2, "Zapatilla Adidas Essential Serie 3", 65000m },
                    { 103, 5, "Supera tus límites con lo nuevo en zapatilla Puma. Pensado especialmente para hombre, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Urban.", "Hombre", "/images/Productos/Prod-Name-zapatilla-puma-urban-serie-1.jpg", false, false, 3, "Zapatilla Puma Urban Serie 1", 21000m },
                    { 104, 5, "Un clásico renovado. La nueva colección de Puma destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Mujer", "/images/Productos/Prod-Name-zapatilla-puma-essential-serie-2.jpg", false, false, 3, "Zapatilla Puma Essential Serie 2", 73000m },
                    { 105, 5, "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de Sport una pieza indispensable en tu guardarropa.", "Unisex", "/images/Productos/Prod-Name-zapatilla-puma-sport-serie-3.jpg", false, false, 3, "Zapatilla Puma Sport Serie 3", 58000m },
                    { 106, 5, "Supera tus límites con lo nuevo en zapatilla Reebok. Pensado especialmente para hombre, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Ultra.", "Hombre", "/images/Productos/Prod-Name-zapatilla-reebok-ultra-serie-1.jpg", false, false, 4, "Zapatilla Reebok Ultra Serie 1", 66000m },
                    { 107, 5, "Un clásico renovado. La nueva colección de Reebok destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Mujer", "/images/Productos/Prod-Name-zapatilla-reebok-urban-serie-2.jpg", false, false, 4, "Zapatilla Reebok Urban Serie 2", 50000m },
                    { 108, 5, "Increíble diseño en zapatilla Reebok Ultra. Una elección perfecta para quienes buscan estilo y rendimiento. Fabricación de alta calidad pensada para unisex.", "Unisex", "/images/Productos/Prod-Name-zapatilla-reebok-ultra-serie-3.jpg", false, false, 4, "Zapatilla Reebok Ultra Serie 3", 96000m },
                    { 109, 5, "Descubre el confort absoluto con este modelo de Dc. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Hombre", "/images/Productos/Prod-Name-zapatilla-dc-max-serie-1.jpg", false, false, 5, "Zapatilla Dc Max Serie 1", 89000m },
                    { 110, 5, "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de Sport una pieza indispensable en tu guardarropa.", "Mujer", "/images/Productos/Prod-Name-zapatilla-dc-sport-serie-2.jpg", false, false, 5, "Zapatilla Dc Sport Serie 2", 43000m },
                    { 111, 5, "Supera tus límites con lo nuevo en zapatilla Dc. Pensado especialmente para unisex, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Ultra.", "Unisex", "/images/Productos/Prod-Name-zapatilla-dc-ultra-serie-3.jpg", false, false, 5, "Zapatilla Dc Ultra Serie 3", 93000m },
                    { 112, 5, "Descubre el confort absoluto con este modelo de Vans. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Hombre", "/images/Productos/Prod-Name-zapatilla-vans-ultra-serie-1.jpg", false, false, 6, "Zapatilla Vans Ultra Serie 1", 49000m },
                    { 113, 5, "Un clásico renovado. La nueva colección de Vans destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Mujer", "/images/Productos/Prod-Name-zapatilla-vans-retro-serie-2.jpg", false, false, 6, "Zapatilla Vans Retro Serie 2", 16000m },
                    { 114, 5, "Supera tus límites con lo nuevo en zapatilla Vans. Pensado especialmente para unisex, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Max.", "Unisex", "/images/Productos/Prod-Name-zapatilla-vans-max-serie-3.jpg", false, false, 6, "Zapatilla Vans Max Serie 3", 58000m },
                    { 115, 5, "Un clásico renovado. La nueva colección de Adidas-Classic destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Hombre", "/images/Productos/Prod-Name-zapatilla-adidas-classic-max-serie-1.jpg", false, false, 7, "Zapatilla Adidas-Classic Max Serie 1", 61000m },
                    { 116, 5, "Un clásico renovado. La nueva colección de Adidas-Classic destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Mujer", "/images/Productos/Prod-Name-zapatilla-adidas-classic-essential-serie-2.jpg", false, false, 7, "Zapatilla Adidas-Classic Essential Serie 2", 83000m },
                    { 117, 5, "Un clásico renovado. La nueva colección de Adidas-Classic destaca por su corte ergonómico y tecnología de punta, brindando un ajuste perfecto.", "Unisex", "/images/Productos/Prod-Name-zapatilla-adidas-classic-urban-serie-3.jpg", false, false, 7, "Zapatilla Adidas-Classic Urban Serie 3", 27000m },
                    { 118, 5, "Descubre el confort absoluto con este modelo de Under-Armour. Su diseño exclusivo aporta frescura y libertad de movimiento, ideal para el día a día.", "Hombre", "/images/Productos/Prod-Name-zapatilla-under-armour-urban-serie-1.jpg", false, false, 8, "Zapatilla Under-Armour Urban Serie 1", 67000m },
                    { 119, 5, "Supera tus límites con lo nuevo en zapatilla Under-Armour. Pensado especialmente para mujer, ofrece una durabilidad excepcional en cada uso gracias a su tecnología Elite.", "Mujer", "/images/Productos/Prod-Name-zapatilla-under-armour-elite-serie-2.jpg", false, false, 8, "Zapatilla Under-Armour Elite Serie 2", 32000m },
                    { 120, 5, "Lleva tu estilo urbano al siguiente nivel. Confección premium y detalles únicos hacen de este modelo de Ultra una pieza indispensable en tu guardarropa.", "Unisex", "/images/Productos/Prod-Name-zapatilla-under-armour-ultra-serie-3.jpg", false, false, 8, "Zapatilla Under-Armour Ultra Serie 3", 58000m }
                });

            migrationBuilder.InsertData(
                table: "UsuarioRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "11111111-1111-1111-1111-111111111111", "33333333-3333-3333-3333-333333333333" });

            migrationBuilder.InsertData(
                table: "ProductosVariantes",
                columns: new[] { "ID", "CodigoBarra", "IsDeleted", "IsEnabled", "ProductoId", "Stock", "Talle" },
                values: new object[,]
                {
                    { 1, "100001", false, false, 1, 0, "XL" },
                    { 2, "100002", false, false, 1, 0, "L" },
                    { 3, "100003", false, false, 1, 21, "S" },
                    { 4, "100004", false, false, 2, 36, "S" },
                    { 5, "100005", false, false, 3, 41, "L" },
                    { 6, "100006", false, false, 4, 21, "XS" },
                    { 7, "100007", false, false, 4, 26, "M" },
                    { 8, "100008", false, false, 4, 8, "S" },
                    { 9, "100009", false, false, 5, 18, "L" },
                    { 10, "100010", false, false, 5, 30, "M" },
                    { 11, "100011", false, false, 6, 12, "L" },
                    { 12, "100012", false, false, 6, 9, "M" },
                    { 13, "100013", false, false, 6, 14, "XL" },
                    { 14, "100014", false, false, 7, 34, "M" },
                    { 15, "100015", false, false, 8, 1, "S" },
                    { 16, "100016", false, false, 8, 9, "XL" },
                    { 17, "100017", false, false, 8, 0, "L" },
                    { 18, "100018", false, false, 9, 27, "L" },
                    { 19, "100019", false, false, 10, 0, "L" },
                    { 20, "100020", false, false, 11, 39, "XS" },
                    { 21, "100021", false, false, 11, 3, "XL" },
                    { 22, "100022", false, false, 11, 49, "S" },
                    { 23, "100023", false, false, 12, 0, "S" },
                    { 24, "100024", false, false, 12, 46, "XL" },
                    { 25, "100025", false, false, 12, 23, "M" },
                    { 26, "100026", false, false, 13, 0, "M" },
                    { 27, "100027", false, false, 13, 23, "XS" },
                    { 28, "100028", false, false, 13, 6, "L" },
                    { 29, "100029", false, false, 15, 28, "L" },
                    { 30, "100030", false, false, 15, 24, "S" },
                    { 31, "100031", false, false, 19, 0, "L" },
                    { 32, "100032", false, false, 19, 21, "S" },
                    { 33, "100033", false, false, 20, 26, "S" },
                    { 34, "100034", false, false, 21, 27, "XS" },
                    { 35, "100035", false, false, 22, 3, "XL" },
                    { 36, "100036", false, false, 22, 7, "M" },
                    { 37, "100037", false, false, 23, 0, "XL" },
                    { 38, "100038", false, false, 24, 40, "M" },
                    { 39, "100039", false, false, 25, 25, "M" },
                    { 40, "100040", false, false, 25, 0, "L" },
                    { 41, "100041", false, false, 25, 12, "XS" },
                    { 42, "100042", false, false, 26, 0, "XL" },
                    { 43, "100043", false, false, 26, 32, "M" },
                    { 44, "100044", false, false, 27, 32, "XS" },
                    { 45, "100045", false, false, 28, 29, "XS" },
                    { 46, "100046", false, false, 28, 1, "XL" },
                    { 47, "100047", false, false, 28, 26, "S" },
                    { 48, "100048", false, false, 29, 22, "L" },
                    { 49, "100049", false, false, 29, 1, "S" },
                    { 50, "100050", false, false, 30, 42, "M" },
                    { 51, "100051", false, false, 31, 0, "M" },
                    { 52, "100052", false, false, 31, 25, "L" },
                    { 53, "100053", false, false, 32, 9, "M" },
                    { 54, "100054", false, false, 33, 12, "S" },
                    { 55, "100055", false, false, 33, 9, "M" },
                    { 56, "100056", false, false, 34, 21, "L" },
                    { 57, "100057", false, false, 35, 13, "M" },
                    { 58, "100058", false, false, 36, 0, "L" },
                    { 59, "100059", false, false, 36, 0, "XL" },
                    { 60, "100060", false, false, 37, 0, "XS" },
                    { 61, "100061", false, false, 38, 21, "XS" },
                    { 62, "100062", false, false, 38, 2, "S" },
                    { 63, "100063", false, false, 38, 12, "M" },
                    { 64, "100064", false, false, 39, 49, "S" },
                    { 65, "100065", false, false, 39, 20, "M" },
                    { 66, "100066", false, false, 40, 0, "XS" },
                    { 67, "100067", false, false, 40, 35, "S" },
                    { 68, "100068", false, false, 40, 42, "M" },
                    { 69, "100069", false, false, 42, 13, "XS" },
                    { 70, "100070", false, false, 42, 4, "L" },
                    { 71, "100071", false, false, 43, 38, "XL" },
                    { 72, "100072", false, false, 43, 20, "L" },
                    { 73, "100073", false, false, 43, 0, "XS" },
                    { 74, "100074", false, false, 44, 1, "XS" },
                    { 75, "100075", false, false, 44, 0, "S" },
                    { 76, "100076", false, false, 45, 18, "S" },
                    { 77, "100077", false, false, 45, 0, "XL" },
                    { 78, "100078", false, false, 46, 12, "XL" },
                    { 79, "100079", false, false, 47, 0, "XS" },
                    { 80, "100080", false, false, 47, 6, "S" },
                    { 81, "100081", false, false, 47, 0, "XL" },
                    { 82, "100082", false, false, 48, 0, "S" },
                    { 83, "100083", false, false, 49, 22, "XL" },
                    { 84, "100084", false, false, 49, 23, "S" },
                    { 85, "100085", false, false, 50, 46, "M" },
                    { 86, "100086", false, false, 51, 38, "L" },
                    { 87, "100087", false, false, 51, 0, "S" },
                    { 88, "100088", false, false, 52, 0, "S" },
                    { 89, "100089", false, false, 53, 48, "XL" },
                    { 90, "100090", false, false, 53, 38, "S" },
                    { 91, "100091", false, false, 53, 6, "XS" },
                    { 92, "100092", false, false, 54, 18, "XS" },
                    { 93, "100093", false, false, 54, 35, "XL" },
                    { 94, "100094", false, false, 54, 20, "M" },
                    { 95, "100095", false, false, 55, 45, "L" },
                    { 96, "100096", false, false, 55, 0, "M" },
                    { 97, "100097", false, false, 55, 0, "XL" },
                    { 98, "100098", false, false, 56, 44, "XS" },
                    { 99, "100099", false, false, 56, 0, "XL" },
                    { 100, "100100", false, false, 57, 15, "XS" },
                    { 101, "100101", false, false, 57, 46, "L" },
                    { 102, "100102", false, false, 58, 5, "S" },
                    { 103, "100103", false, false, 59, 32, "XL" },
                    { 104, "100104", false, false, 59, 33, "M" },
                    { 105, "100105", false, false, 59, 0, "S" },
                    { 106, "100106", false, false, 60, 3, "XS" },
                    { 107, "100107", false, false, 61, 45, "XL" },
                    { 108, "100108", false, false, 62, 40, "S" },
                    { 109, "100109", false, false, 63, 5, "XL" },
                    { 110, "100110", false, false, 64, 39, "XS" },
                    { 111, "100111", false, false, 65, 8, "XL" },
                    { 112, "100112", false, false, 65, 0, "M" },
                    { 113, "100113", false, false, 66, 41, "S" },
                    { 114, "100114", false, false, 67, 0, "XS" },
                    { 115, "100115", false, false, 67, 40, "L" },
                    { 116, "100116", false, false, 67, 7, "XL" },
                    { 117, "100117", false, false, 68, 0, "L" },
                    { 118, "100118", false, false, 68, 4, "XS" },
                    { 119, "100119", false, false, 68, 0, "XL" },
                    { 120, "100120", false, false, 69, 9, "M" },
                    { 121, "100121", false, false, 69, 10, "L" },
                    { 122, "100122", false, false, 69, 49, "XS" },
                    { 123, "100123", false, false, 70, 42, "XL" },
                    { 124, "100124", false, false, 71, 40, "XS" },
                    { 125, "100125", false, false, 71, 0, "L" },
                    { 126, "100126", false, false, 71, 0, "S" },
                    { 127, "100127", false, false, 72, 0, "L" },
                    { 128, "100128", false, false, 72, 13, "S" },
                    { 129, "100129", false, false, 72, 0, "M" },
                    { 130, "100130", false, false, 73, 0, "S" },
                    { 131, "100131", false, false, 73, 0, "XS" },
                    { 132, "100132", false, false, 74, 45, "L" },
                    { 133, "100133", false, false, 74, 1, "XL" },
                    { 134, "100134", false, false, 75, 41, "XS" },
                    { 135, "100135", false, false, 75, 12, "XL" },
                    { 136, "100136", false, false, 76, 0, "L" },
                    { 137, "100137", false, false, 77, 15, "S" },
                    { 138, "100138", false, false, 77, 25, "M" },
                    { 139, "100139", false, false, 78, 0, "S" },
                    { 140, "100140", false, false, 78, 6, "XL" },
                    { 141, "100141", false, false, 78, 46, "L" },
                    { 142, "100142", false, false, 79, 6, "XS" },
                    { 143, "100143", false, false, 80, 31, "XL" },
                    { 144, "100144", false, false, 80, 39, "XS" },
                    { 145, "100145", false, false, 81, 0, "L" },
                    { 146, "100146", false, false, 81, 35, "S" },
                    { 147, "100147", false, false, 82, 14, "S" },
                    { 148, "100148", false, false, 83, 0, "XS" },
                    { 149, "100149", false, false, 83, 0, "XL" },
                    { 150, "100150", false, false, 84, 24, "M" },
                    { 151, "100151", false, false, 84, 37, "XL" },
                    { 152, "100152", false, false, 84, 28, "XS" },
                    { 153, "100153", false, false, 85, 42, "S" },
                    { 154, "100154", false, false, 85, 0, "XL" },
                    { 155, "100155", false, false, 85, 1, "L" },
                    { 156, "100156", false, false, 86, 24, "L" },
                    { 157, "100157", false, false, 86, 10, "S" },
                    { 158, "100158", false, false, 86, 0, "M" },
                    { 159, "100159", false, false, 87, 35, "XL" },
                    { 160, "100160", false, false, 87, 9, "S" },
                    { 161, "100161", false, false, 88, 35, "M" },
                    { 162, "100162", false, false, 89, 18, "XS" },
                    { 163, "100163", false, false, 89, 10, "M" },
                    { 164, "100164", false, false, 89, 33, "L" },
                    { 165, "100165", false, false, 90, 0, "L" },
                    { 166, "100166", false, false, 91, 41, "M" },
                    { 167, "100167", false, false, 91, 3, "XS" },
                    { 168, "100168", false, false, 92, 11, "XS" },
                    { 169, "100169", false, false, 92, 10, "XL" },
                    { 170, "100170", false, false, 93, 0, "XL" },
                    { 171, "100171", false, false, 93, 47, "XS" },
                    { 172, "100172", false, false, 94, 49, "S" },
                    { 173, "100173", false, false, 94, 24, "L" },
                    { 174, "100174", false, false, 95, 0, "XL" },
                    { 175, "100175", false, false, 95, 10, "S" },
                    { 176, "100176", false, false, 95, 43, "L" },
                    { 177, "100177", false, false, 96, 15, "S" },
                    { 178, "100178", false, false, 96, 19, "XL" },
                    { 179, "100179", false, false, 97, 11, "43" },
                    { 180, "100180", false, false, 97, 11, "37" },
                    { 181, "100181", false, false, 97, 21, "42" },
                    { 182, "100182", false, false, 97, 0, "40" },
                    { 183, "100183", false, false, 97, 21, "38" },
                    { 184, "100184", false, false, 98, 1, "45" },
                    { 185, "100185", false, false, 98, 21, "43" },
                    { 186, "100186", false, false, 98, 29, "46" },
                    { 187, "100187", false, false, 99, 34, "43" },
                    { 188, "100188", false, false, 99, 0, "44" },
                    { 189, "100189", false, false, 99, 17, "37" },
                    { 190, "100190", false, false, 100, 16, "34" },
                    { 191, "100191", false, false, 100, 49, "43" },
                    { 192, "100192", false, false, 100, 32, "40" },
                    { 193, "100193", false, false, 100, 48, "39" },
                    { 194, "100194", false, false, 100, 5, "36" },
                    { 195, "100195", false, false, 100, 36, "44" },
                    { 196, "100196", false, false, 100, 5, "46" },
                    { 197, "100197", false, false, 101, 31, "36" },
                    { 198, "100198", false, false, 101, 18, "44" },
                    { 199, "100199", false, false, 101, 0, "38" },
                    { 200, "100200", false, false, 101, 6, "43" },
                    { 201, "100201", false, false, 101, 0, "42" },
                    { 202, "100202", false, false, 102, 10, "42" },
                    { 203, "100203", false, false, 102, 45, "39" },
                    { 204, "100204", false, false, 102, 0, "44" },
                    { 205, "100205", false, false, 102, 46, "35" },
                    { 206, "100206", false, false, 103, 30, "46" },
                    { 207, "100207", false, false, 103, 0, "45" },
                    { 208, "100208", false, false, 103, 33, "39" },
                    { 209, "100209", false, false, 103, 0, "41" },
                    { 210, "100210", false, false, 104, 40, "39" },
                    { 211, "100211", false, false, 104, 10, "41" },
                    { 212, "100212", false, false, 104, 0, "43" },
                    { 213, "100213", false, false, 104, 45, "45" },
                    { 214, "100214", false, false, 104, 25, "34" },
                    { 215, "100215", false, false, 104, 19, "46" },
                    { 216, "100216", false, false, 105, 20, "43" },
                    { 217, "100217", false, false, 105, 28, "45" },
                    { 218, "100218", false, false, 105, 24, "42" },
                    { 219, "100219", false, false, 105, 37, "38" },
                    { 220, "100220", false, false, 106, 32, "37" },
                    { 221, "100221", false, false, 106, 33, "46" },
                    { 222, "100222", false, false, 106, 9, "34" },
                    { 223, "100223", false, false, 106, 4, "39" },
                    { 224, "100224", false, false, 106, 44, "40" },
                    { 225, "100225", false, false, 106, 11, "45" },
                    { 226, "100226", false, false, 106, 0, "43" },
                    { 227, "100227", false, false, 107, 21, "36" },
                    { 228, "100228", false, false, 107, 17, "44" },
                    { 229, "100229", false, false, 107, 0, "46" },
                    { 230, "100230", false, false, 108, 1, "37" },
                    { 231, "100231", false, false, 108, 22, "45" },
                    { 232, "100232", false, false, 108, 31, "41" },
                    { 233, "100233", false, false, 108, 46, "43" },
                    { 234, "100234", false, false, 108, 21, "40" },
                    { 235, "100235", false, false, 109, 15, "36" },
                    { 236, "100236", false, false, 109, 47, "38" },
                    { 237, "100237", false, false, 109, 27, "44" },
                    { 238, "100238", false, false, 110, 16, "45" },
                    { 239, "100239", false, false, 110, 30, "38" },
                    { 240, "100240", false, false, 110, 44, "46" },
                    { 241, "100241", false, false, 111, 17, "41" },
                    { 242, "100242", false, false, 111, 7, "46" },
                    { 243, "100243", false, false, 111, 37, "38" },
                    { 244, "100244", false, false, 111, 33, "37" },
                    { 245, "100245", false, false, 112, 6, "40" },
                    { 246, "100246", false, false, 112, 0, "36" },
                    { 247, "100247", false, false, 112, 0, "38" },
                    { 248, "100248", false, false, 112, 12, "37" },
                    { 249, "100249", false, false, 112, 13, "45" },
                    { 250, "100250", false, false, 112, 21, "43" },
                    { 251, "100251", false, false, 112, 0, "46" },
                    { 252, "100252", false, false, 113, 11, "40" },
                    { 253, "100253", false, false, 113, 0, "44" },
                    { 254, "100254", false, false, 113, 32, "45" },
                    { 255, "100255", false, false, 114, 0, "36" },
                    { 256, "100256", false, false, 114, 0, "34" },
                    { 257, "100257", false, false, 114, 0, "46" },
                    { 258, "100258", false, false, 115, 42, "42" },
                    { 259, "100259", false, false, 115, 13, "46" },
                    { 260, "100260", false, false, 115, 7, "43" },
                    { 261, "100261", false, false, 115, 26, "41" },
                    { 262, "100262", false, false, 115, 9, "45" },
                    { 263, "100263", false, false, 115, 37, "44" },
                    { 264, "100264", false, false, 116, 0, "36" },
                    { 265, "100265", false, false, 116, 39, "38" },
                    { 266, "100266", false, false, 116, 47, "35" },
                    { 267, "100267", false, false, 116, 5, "40" },
                    { 268, "100268", false, false, 116, 47, "42" },
                    { 269, "100269", false, false, 117, 0, "40" },
                    { 270, "100270", false, false, 117, 0, "37" },
                    { 271, "100271", false, false, 117, 29, "39" },
                    { 272, "100272", false, false, 117, 23, "36" },
                    { 273, "100273", false, false, 117, 14, "38" },
                    { 274, "100274", false, false, 117, 23, "46" },
                    { 275, "100275", false, false, 118, 43, "39" },
                    { 276, "100276", false, false, 118, 19, "45" },
                    { 277, "100277", false, false, 118, 14, "38" },
                    { 278, "100278", false, false, 119, 9, "39" },
                    { 279, "100279", false, false, 119, 0, "42" },
                    { 280, "100280", false, false, 119, 11, "41" },
                    { 281, "100281", false, false, 120, 14, "40" },
                    { 282, "100282", false, false, 120, 23, "45" },
                    { 283, "100283", false, false, 120, 1, "38" },
                    { 284, "100284", false, false, 120, 0, "36" },
                    { 285, "100285", false, false, 120, 0, "46" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_Descripcion",
                table: "Categorias",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comprobantes_ClienteId",
                table: "Comprobantes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobantes_EnvioId",
                table: "Comprobantes",
                column: "EnvioId");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobantes_FacturaId",
                table: "Comprobantes",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCarroCompras_CarroComprasId",
                table: "DetalleCarroCompras",
                column: "CarroComprasId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCarroCompras_ProductoVarianteId",
                table: "DetalleCarroCompras",
                column: "ProductoVarianteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleComprobantes_ComprobanteId",
                table: "DetalleComprobantes",
                column: "ComprobanteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleComprobantes_ProductoId",
                table: "DetalleComprobantes",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenCompras_OrdenComprasId",
                table: "DetalleOrdenCompras",
                column: "OrdenComprasId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenCompras_ProductoVarianteId",
                table: "DetalleOrdenCompras",
                column: "ProductoVarianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_PersonaClienteID",
                table: "Facturas",
                column: "PersonaClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_ProvinciaId",
                table: "Localidades",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Marca_Descripcion",
                table: "Marcas",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Nombre",
                table: "Productos",
                column: "Nombre",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MarcaId",
                table: "Productos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoVariante_CodigoBarra",
                table: "ProductosVariantes",
                column: "CodigoBarra",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoVariante_ProductoId_Talle",
                table: "ProductosVariantes",
                columns: new[] { "ProductoId", "Talle" },
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NombreNormalizado",
                unique: true,
                filter: "[NombreNormalizado] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRoles_RoleId",
                table: "UsuarioRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Usuarios",
                column: "EmailNormalizado");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Usuarios",
                column: "NombreUsuarioNormalizado",
                unique: true,
                filter: "[NombreUsuarioNormalizado] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleCarroCompras");

            migrationBuilder.DropTable(
                name: "DetalleComprobantes");

            migrationBuilder.DropTable(
                name: "DetalleOrdenCompras");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "UsuarioRoles");

            migrationBuilder.DropTable(
                name: "CarroCompras");

            migrationBuilder.DropTable(
                name: "Comprobantes");

            migrationBuilder.DropTable(
                name: "OrdenCompras");

            migrationBuilder.DropTable(
                name: "ProductosVariantes");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Envios");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "PersonasClientes");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
