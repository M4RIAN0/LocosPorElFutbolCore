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
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
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
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
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
                name: "Talles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Letra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talles", x => x.ID);
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
                name: "Productos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CodigoBarra = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    TalleId = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Productos_Talles_TalleId",
                        column: x => x.TalleId,
                        principalTable: "Talles",
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
                name: "Comprobantes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobantes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comprobantes_PersonasClientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "PersonasClientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                    ProductoId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_DetalleCarroCompras_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
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
                    ProductoId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_DetalleOrdenCompras_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
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

            migrationBuilder.CreateTable(
                name: "Envios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persona = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComprobanteId = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Envios_Comprobantes_ComprobanteId",
                        column: x => x.ComprobanteId,
                        principalTable: "Comprobantes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComprobanteId = table.Column<int>(type: "int", nullable: false),
                    PersonaClienteID = table.Column<int>(type: "int", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Facturas_Comprobantes_ComprobanteId",
                        column: x => x.ComprobanteId,
                        principalTable: "Comprobantes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facturas_PersonasClientes_PersonaClienteID",
                        column: x => x.PersonaClienteID,
                        principalTable: "PersonasClientes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Movimientos_Facturas_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Facturas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "ID", "Descripcion", "IsDeleted", "IsEnabled" },
                values: new object[,]
                {
                    { 1, "Camisetas Futbol Masculinas", false, false },
                    { 2, "Camisetas Futbol Femeninas", false, false },
                    { 3, "Remeras", false, false },
                    { 4, "Musculosas", false, false },
                    { 5, "Shorts", false, false },
                    { 6, "Medias", false, false },
                    { 7, "Pantalones", false, false },
                    { 8, "Camperas", false, false }
                });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "ID", "Descripcion", "IsDeleted", "IsEnabled" },
                values: new object[,]
                {
                    { 1, "Nike", false, false },
                    { 2, "Adidas", false, false },
                    { 3, "Fila", false, false },
                    { 4, "Topper", false, false },
                    { 5, "Reebok", false, false },
                    { 6, "Umbro", false, false },
                    { 7, "Puma", false, false }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "ID", "Apellido", "Celular", "Direccion", "Dni", "Email", "FechaNacimiento", "IsDeleted", "IsEnabled", "Nombre", "Sexo" },
                values: new object[,]
                {
                    { 1, "Martinez", "123", "Jujuy 362", "38060619", "marcosmartinezmelek@gmail.com", new DateOnly(1994, 4, 22), false, false, "Marcos", "Masculino" },
                    { 2, "Garcia", "34567", "Heras 1255", "45607656", "juan@gmail.com", new DateOnly(1994, 4, 22), false, false, "Juan Carlos", "Masculino" }
                });

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
                    { "9f1dbdd5-6c6a-4438-975c-d8b0819f152a", null, "Cliente", "CLIENTE" },
                    { "eb4008ef-1a78-4662-a1b1-06c1a7a7df2d", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "Talles",
                columns: new[] { "ID", "IsDeleted", "IsEnabled", "Letra", "Numero" },
                values: new object[,]
                {
                    { 1, false, false, "XS", 36 },
                    { 2, false, false, "S", 38 },
                    { 3, false, false, "M", 40 },
                    { 4, false, false, "L", 42 },
                    { 5, false, false, "XL", 44 },
                    { 6, false, false, "XXL", 46 }
                });

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
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ID", "CategoriaId", "CodigoBarra", "Descripcion", "ImagenUrl", "IsDeleted", "IsEnabled", "MarcaId", "Nombre", "Precio", "Stock", "TalleId" },
                values: new object[,]
                {
                    { 1, 1, 123123, "Camiseta 100 % Poliester, con tecnologia AdiFreeIce, ideal para cual epoca de el año", "https://placehold.co/603x403", false, false, 1, "Camiseta Titular Manchester United 24/25", 150000.00m, 10, 1 },
                    { 2, 1, 323232, "Camiseta 100 % Poliester, con tecnologia AdiFreeIce, ideal para cual epoca de el año", "https://placehold.co/603x403", false, false, 1, "Camiseta Titular Mancheste City 24/25", 175000.00m, 10, 1 },
                    { 3, 8, 976898, "Campera 100 % Algodon, con tecnologia AdiFreeIce, ideal para cualquier epoca de el año", "https://placehold.co/603x403", false, false, 2, "Campera River Plate Retro", 300000.00m, 15, 5 }
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
                name: "IX_DetalleCarroCompras_CarroComprasId",
                table: "DetalleCarroCompras",
                column: "CarroComprasId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCarroCompras_ProductoId",
                table: "DetalleCarroCompras",
                column: "ProductoId");

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
                name: "IX_DetalleOrdenCompras_ProductoId",
                table: "DetalleOrdenCompras",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_ComprobanteId",
                table: "Envios",
                column: "ComprobanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ComprobanteId",
                table: "Facturas",
                column: "ComprobanteId");

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
                name: "IX_Movimientos_FacturaId",
                table: "Movimientos",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Nombre",
                table: "Productos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MarcaId",
                table: "Productos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TalleId",
                table: "Productos",
                column: "TalleId");

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
                name: "Envios");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "UsuarioRoles");

            migrationBuilder.DropTable(
                name: "CarroCompras");

            migrationBuilder.DropTable(
                name: "OrdenCompras");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Talles");

            migrationBuilder.DropTable(
                name: "Comprobantes");

            migrationBuilder.DropTable(
                name: "PersonasClientes");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
