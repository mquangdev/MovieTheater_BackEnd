using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IdentityCard = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Accounts_InsertedById",
                        column: x => x.InsertedById,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_Accounts_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Accounts_InsertedById",
                        column: x => x.InsertedById,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Accounts_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddScore = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ScheduleShow = table.Column<DateOnly>(type: "date", nullable: false),
                    ScheduleShowTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UseScore = table.Column<int>(type: "int", nullable: false),
                    Seat = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Accounts_InsertedById",
                        column: x => x.InsertedById,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Accounts_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Members_Accounts_InsertedById",
                        column: x => x.InsertedById,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_Accounts_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Actor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieProductionCompany = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieNameEnglish = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MovieNameVN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LargeImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmallImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Accounts_InsertedById",
                        column: x => x.InsertedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movies_Accounts_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DiscountLevel = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotions_Accounts_InsertedById",
                        column: x => x.InsertedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Promotions_Accounts_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Accounts_InsertedById",
                        column: x => x.InsertedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Roles_Accounts_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Accounts_InsertedById",
                        column: x => x.InsertedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedules_Accounts_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShowDates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateShow = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowDates_Accounts_InsertedById",
                        column: x => x.InsertedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShowDates_Accounts_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Types_Accounts_InsertedById",
                        column: x => x.InsertedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Types_Accounts_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TicketType = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Accounts_InsertedById",
                        column: x => x.InsertedById,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Accounts_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CinemaRooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SeatQuantity = table.Column<int>(type: "int", nullable: false),
                    CurrentMovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaRooms_Accounts_InsertedById",
                        column: x => x.InsertedById,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CinemaRooms_Accounts_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CinemaRooms_Movies_CurrentMovieId",
                        column: x => x.CurrentMovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieSchedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieSchedule_Accounts_InsertedById",
                        column: x => x.InsertedById,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieSchedule_Accounts_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovieSchedule_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieSchedule_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieShowDates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShowDateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieShowDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieShowDates_Accounts_InsertedById",
                        column: x => x.InsertedById,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieShowDates_Accounts_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovieShowDates_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieShowDates_ShowDates_ShowDateId",
                        column: x => x.ShowDateId,
                        principalTable: "ShowDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieTypes_Accounts_InsertedById",
                        column: x => x.InsertedById,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieTypes_Accounts_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovieTypes_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieTypes_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CinemaRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatRow = table.Column<int>(type: "int", nullable: false),
                    SeatColumn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeatStatus = table.Column<int>(type: "int", nullable: false),
                    SeatType = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Accounts_InsertedById",
                        column: x => x.InsertedById,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seats_Accounts_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Seats_CinemaRooms_CinemaRoomId",
                        column: x => x.CinemaRoomId,
                        principalTable: "CinemaRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleSeats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatColumn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeatRow = table.Column<int>(type: "int", nullable: false),
                    SeatStatus = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    InsertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleSeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleSeats_Accounts_InsertedById",
                        column: x => x.InsertedById,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleSeats_Accounts_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduleSeats_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleSeats_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleSeats_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CinemaRooms",
                columns: new[] { "Id", "CurrentMovieId", "InsertedAt", "InsertedById", "IsDeleted", "Name", "SeatQuantity", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), null, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2308), null, null, "Room 2", 25, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2309), null },
                    { new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), null, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2226), null, null, "Room 1", 30, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2226), null }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Actor", "Content", "Director", "Duration", "FromDate", "InsertedAt", "InsertedById", "IsDeleted", "LargeImage", "MovieNameEnglish", "MovieNameVN", "MovieProductionCompany", "SmallImage", "ToDate", "UpdatedAt", "UpdatedById", "Version" },
                values: new object[,]
                {
                    { new Guid("54274e99-c5ae-4700-9cb8-d1d688d7d114"), "Actor 2", "Romantic movie.", "Director 2", new TimeSpan(0, 1, 30, 0, 0), new DateTime(2024, 9, 30, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2359), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2361), null, null, "path/to/large/image2.jpg", "Romantic Movie", "Phim Tình Cảm", null, "path/to/small/image2.jpg", new DateTime(2024, 11, 30, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2360), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2362), null, null },
                    { new Guid("baa8ac4c-51f3-4fad-bbab-3209c5e484a3"), "Actor 1", "Action packed movie.", "Director 1", new TimeSpan(0, 2, 0, 0, 0), new DateTime(2024, 9, 30, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2344), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2356), null, null, "path/to/large/image1.jpg", "Action Movie", "Phim Hành Động", null, "path/to/small/image1.jpg", new DateTime(2024, 12, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2354), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2357), null, null }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Detail", "DiscountLevel", "EndTime", "Image", "InsertedAt", "InsertedById", "IsDeleted", "StartTime", "Title", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("3e6d83f4-6d83-48af-80b6-08a36425a5d5"), "Get 20% off for all tickets.", 20.0, new DateTime(2024, 11, 30, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3428), "path/to/promotion/image.jpg", new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3429), null, null, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3428), "New Year Discount", new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3430), null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "InsertedAt", "InsertedById", "IsDeleted", "RoleName", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { new Guid("35317719-3b20-49ca-b754-91ff85562eaa"), null, null, null, "Admin", null, null },
                    { new Guid("72611c8e-2e66-4487-959b-5dc518c63bf0"), null, null, null, "Employee", null, null },
                    { new Guid("dded4e77-fd32-4d63-aede-4161441f583a"), null, null, null, "Member", null, null }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "InsertedAt", "InsertedById", "IsDeleted", "ScheduleTime", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { new Guid("043b1d4c-bd60-4f71-90a8-9d32758c62e4"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3318), null, null, new TimeSpan(0, 22, 0, 0, 0), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3318), null },
                    { new Guid("0a3270cc-39d7-4183-b852-8fa7b270c348"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3310), null, null, new TimeSpan(0, 19, 0, 0, 0), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3310), null },
                    { new Guid("22780aaf-6f0e-4f2a-acc9-cff6ac0be736"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3248), null, null, new TimeSpan(0, 10, 0, 0, 0), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3249), null },
                    { new Guid("395adf58-6c89-4d61-a739-35fe5c77cadc"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3320), null, null, new TimeSpan(0, 23, 0, 0, 0), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3321), null },
                    { new Guid("46a028c0-5c36-4ff5-8f97-50c979d653d2"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3298), null, null, new TimeSpan(0, 16, 0, 0, 0), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3298), null },
                    { new Guid("47146887-5a4e-4d9d-bc93-72791a02a084"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3295), null, null, new TimeSpan(0, 15, 0, 0, 0), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3296), null },
                    { new Guid("5b88af9f-3b39-4125-baa4-1d20b0da5bb9"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3315), null, null, new TimeSpan(0, 21, 0, 0, 0), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3316), null },
                    { new Guid("64037c49-bcbd-462c-b7ea-5383527c5d08"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3286), null, null, new TimeSpan(0, 12, 0, 0, 0), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3286), null },
                    { new Guid("7f1b0ed6-4251-4763-9d7c-d52c5e631665"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3290), null, null, new TimeSpan(0, 13, 0, 0, 0), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3290), null },
                    { new Guid("ae2bf619-1c63-4261-baff-46c005a68be7"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3304), null, null, new TimeSpan(0, 18, 0, 0, 0), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3304), null },
                    { new Guid("b24ff4f1-bcc5-4978-a2ed-6911113ebe42"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3245), null, null, new TimeSpan(0, 9, 0, 0, 0), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3246), null },
                    { new Guid("de1d7c9e-8928-4356-9450-0ba0428e65b2"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3241), null, null, new TimeSpan(0, 8, 0, 0, 0), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3242), null },
                    { new Guid("e688747a-2636-4d44-a620-3945d9716c6d"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3301), null, null, new TimeSpan(0, 17, 0, 0, 0), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3302), null },
                    { new Guid("ec7b2675-c187-4239-a9b3-eeee9ad2aecf"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3312), null, null, new TimeSpan(0, 20, 0, 0, 0), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3313), null },
                    { new Guid("f5154370-2cf4-4cf1-9b8c-64320f3834ea"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3253), null, null, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3253), null },
                    { new Guid("f7baaff3-e4a0-4619-80e5-59f79adc9434"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3292), null, null, new TimeSpan(0, 14, 0, 0, 0), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3293), null }
                });

            migrationBuilder.InsertData(
                table: "ShowDates",
                columns: new[] { "Id", "DateName", "DateShow", "InsertedAt", "InsertedById", "IsDeleted", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("77c656f7-b7a2-4396-ab51-c44ce35805a0"), "Tomorrow", new DateTime(2024, 11, 1, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3380), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3383), null, null, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3384), null });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "InsertedAt", "InsertedById", "IsDeleted", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { new Guid("4a404919-1423-452e-aeb0-4f5753fb8ca6"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3525), null, null, "Action", new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3526), null },
                    { new Guid("f2ab13ac-c1d9-4b96-9446-0f13cdcc68a0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3527), null, null, "Romantic", new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3528), null }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "FullName", "Gender", "IdentityCard", "Image", "InsertedAt", "InsertedById", "IsDeleted", "Password", "PhoneNumber", "RegisterDate", "RoleId", "Status", "UpdatedAt", "UpdatedById", "Username" },
                values: new object[,]
                {
                    { new Guid("50623fc4-df8e-43dc-8284-a7c54d2cb7a4"), null, null, "employee@example.com", "Employee User", null, null, null, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2140), null, null, "employee123", null, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2139), new Guid("72611c8e-2e66-4487-959b-5dc518c63bf0"), null, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2140), null, "employee" },
                    { new Guid("522b95f8-a95b-456f-9a08-28011718a47b"), null, null, "member@example.com", "Member User", null, null, null, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2143), null, null, "member123", null, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2143), new Guid("dded4e77-fd32-4d63-aede-4161441f583a"), null, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2144), null, "member" },
                    { new Guid("feb565ad-dfa4-4e38-af1e-3b507db543e7"), null, null, "admin@example.com", "Admin User", null, null, null, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2119), null, null, "admin123", null, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2105), new Guid("35317719-3b20-49ca-b754-91ff85562eaa"), null, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2122), null, "admin" }
                });

            migrationBuilder.InsertData(
                table: "MovieSchedule",
                columns: new[] { "Id", "InsertedAt", "InsertedById", "IsDeleted", "MovieId", "ScheduleId", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("3ae60cee-dfe0-4d80-9d02-13253e53ded5"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3355), null, null, new Guid("baa8ac4c-51f3-4fad-bbab-3209c5e484a3"), new Guid("de1d7c9e-8928-4356-9450-0ba0428e65b2"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3356), null });

            migrationBuilder.InsertData(
                table: "MovieShowDates",
                columns: new[] { "Id", "InsertedAt", "InsertedById", "IsDeleted", "MovieId", "ShowDateId", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("b50075af-7796-4004-b739-ba455289ba15"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3406), null, null, new Guid("baa8ac4c-51f3-4fad-bbab-3209c5e484a3"), new Guid("77c656f7-b7a2-4396-ab51-c44ce35805a0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3406), null });

            migrationBuilder.InsertData(
                table: "MovieTypes",
                columns: new[] { "Id", "InsertedAt", "InsertedById", "IsDeleted", "MovieId", "TypeId", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { new Guid("5bec3fa5-6ab9-413e-8292-0cccf9fc36a8"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3552), null, null, new Guid("54274e99-c5ae-4700-9cb8-d1d688d7d114"), new Guid("f2ab13ac-c1d9-4b96-9446-0f13cdcc68a0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3552), null },
                    { new Guid("a8ec8d2c-09e4-4a78-87aa-7ee61c1a30b3"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3549), null, null, new Guid("baa8ac4c-51f3-4fad-bbab-3209c5e484a3"), new Guid("4a404919-1423-452e-aeb0-4f5753fb8ca6"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3550), null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CinemaRoomId", "InsertedAt", "InsertedById", "IsDeleted", "SeatColumn", "SeatRow", "SeatStatus", "SeatType", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { new Guid("017d2b50-2e80-47a6-aaaa-cd28d51820d5"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2495), null, null, "B", 2, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2495), null },
                    { new Guid("082a7f2b-8447-4819-8359-1057cf3bd822"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2544), null, null, "E", 2, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2545), null },
                    { new Guid("175444cd-4975-45b9-80d7-30a8c703697f"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2444), null, null, "D", 1, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2445), null },
                    { new Guid("18de1ef0-5f03-4a6e-b0c9-4839f9e242f7"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3011), null, null, "B", 3, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3011), null },
                    { new Guid("1d2614a4-1352-43cd-b72d-c33c5fcad214"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2773), null, null, "B", 5, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2773), null },
                    { new Guid("1ddc39e9-5f76-42c8-b69b-37b2da02ef19"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2995), null, null, "A", 3, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2995), null },
                    { new Guid("27768e1a-4873-4537-bbf7-1652bb1758f5"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2677), null, null, "A", 4, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2677), null },
                    { new Guid("2dff6e38-e29a-40e1-8b15-d449bf608908"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2661), null, null, "E", 3, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2662), null },
                    { new Guid("3a4a63be-d217-45e6-8e57-a0648daa0691"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2591), null, null, "C", 3, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2591), null },
                    { new Guid("3bf21d7a-b104-4002-8e47-e8ed79d4150f"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2789), null, null, "C", 5, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2789), null },
                    { new Guid("3cc47cb2-92a8-4bde-850a-30cbee2309f4"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2839), null, null, "C", 1, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2840), null },
                    { new Guid("42207f7f-2546-4651-8ac6-a86128d0d9df"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2726), null, null, "D", 4, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2727), null },
                    { new Guid("47c30741-b08f-499c-8a23-07dd3024cb3d"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2511), null, null, "C", 2, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2511), null },
                    { new Guid("48b3904a-d1e9-492d-ab74-6107ef430134"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3159), null, null, "C", 4, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3160), null },
                    { new Guid("4c1dcaf3-7400-4a7a-be5e-5aa12bfe0092"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3142), null, null, "B", 4, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3142), null },
                    { new Guid("4d8f5fe9-8406-400e-a498-480904479823"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2886), null, null, "A", 2, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2886), null },
                    { new Guid("548fef22-2d96-4fac-9700-b54c21808648"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2757), null, null, "A", 5, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2758), null },
                    { new Guid("60f1d761-0468-4852-9505-009c134a0dfd"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2606), null, null, "D", 3, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2607), null },
                    { new Guid("6900b9f4-b460-4367-aa41-ec37ddf86c44"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2870), null, null, "E", 1, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2870), null },
                    { new Guid("697b862b-050b-4437-81f7-d84e88baf8dc"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3057), null, null, "E", 3, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3058), null },
                    { new Guid("70a8d902-eba4-42a2-8ed3-4fc181410ac5"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2479), null, null, "A", 2, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2480), null },
                    { new Guid("72b09d14-d3a5-4e0c-84da-2b73b4b86bb3"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2855), null, null, "D", 1, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2855), null },
                    { new Guid("78eabd4c-a63c-4d00-9322-d3d20bd812fd"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2916), null, null, "C", 2, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2917), null },
                    { new Guid("79259013-cdac-4c68-b542-8bc26a11b09a"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2560), null, null, "A", 3, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2560), null },
                    { new Guid("7bfb3ad9-2f57-4804-afec-a9cb9e9abbac"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2528), null, null, "D", 2, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2528), null },
                    { new Guid("7db0e80e-fe54-4d74-9f8a-7006206d1174"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2427), null, null, "C", 1, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2427), null },
                    { new Guid("8059664c-a0b3-445e-a33e-d9d64517ce14"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3175), null, null, "D", 4, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3176), null },
                    { new Guid("8080fd9b-ac95-4962-83c9-0e24a63d289a"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2411), null, null, "B", 1, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2411), null },
                    { new Guid("8537172d-3102-4248-a3a0-ac225ead9938"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2961), null, null, "D", 2, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2961), null },
                    { new Guid("8a939670-32f8-40cc-8c5e-4b6c4d2f8e8b"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2901), null, null, "B", 2, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2902), null },
                    { new Guid("92a5d01d-4e31-47a8-aa18-752d7d1c1f7e"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2742), null, null, "E", 4, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2743), null },
                    { new Guid("934a81ad-4a2f-4464-b94a-8ee6cd095248"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2711), null, null, "C", 4, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2711), null },
                    { new Guid("951e0275-d577-40fc-be5d-d4ff1df45533"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2978), null, null, "E", 2, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2979), null },
                    { new Guid("9c9fcd13-6bcb-42e3-bd35-afd4e9c89f13"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2805), null, null, "A", 1, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2806), null },
                    { new Guid("a42179cf-8f08-495f-84fc-715c47c21dad"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3026), null, null, "C", 3, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3026), null },
                    { new Guid("b09dc3fb-dc53-4ad0-9684-1a7e6ac4aaf0"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2575), null, null, "B", 3, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2576), null },
                    { new Guid("b0d5e127-62c8-448f-8d00-87dc0da47131"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3191), null, null, "E", 4, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3192), null },
                    { new Guid("b278a59c-0cff-426a-abf5-ee431a6c718b"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2460), null, null, "E", 1, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2460), null },
                    { new Guid("bdec5278-fcf2-42ac-9352-3a2faec1d57f"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3125), null, null, "A", 4, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3126), null },
                    { new Guid("c033b7f5-d0a5-41b3-8f95-6fb824b8602c"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3207), null, null, "A", 5, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3208), null },
                    { new Guid("c46ead65-3429-4423-b1f2-dd7d54bdb64b"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2390), null, null, "A", 1, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2390), null },
                    { new Guid("c63c813c-18ba-4a06-97e7-1acacf348f7f"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2823), null, null, "B", 1, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2824), null },
                    { new Guid("ef2cfb69-b742-4728-b4b4-051aca5af1bd"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3223), null, null, "B", 5, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3223), null },
                    { new Guid("efa729fb-1395-45c3-8c26-272fcef97afc"), new Guid("2eacb0d0-46ce-4aa2-9c87-826844bc05e0"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3041), null, null, "D", 3, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3042), null },
                    { new Guid("f72d79fc-f319-4cd2-afd1-fbcf94d11c86"), new Guid("70e220a4-8297-4361-b9dd-85e1ddf80222"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2694), null, null, "B", 4, 0, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2695), null }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AccountId", "InsertedAt", "InsertedById", "IsDeleted", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("2c2e5979-7e49-4244-943a-143ffc5f21a6"), new Guid("50623fc4-df8e-43dc-8284-a7c54d2cb7a4"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2170), null, null, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2171), null });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "AccountId", "AddScore", "BookingDate", "InsertedAt", "InsertedById", "IsDeleted", "MovieName", "ScheduleShow", "ScheduleShowTime", "Seat", "Status", "TotalMoney", "UpdatedAt", "UpdatedById", "UseScore" },
                values: new object[] { new Guid("7ddbf4aa-a6fd-44f6-8337-86444f2f7005"), new Guid("522b95f8-a95b-456f-9a08-28011718a47b"), 10, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3451), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3482), null, null, "Action Movie", new DateOnly(2024, 11, 1), "18:00", "1A, 1B", 1, 150.00m, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3483), null, 0 });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "AccountId", "InsertedAt", "InsertedById", "IsDeleted", "Score", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("bb6755ed-043f-4e71-9e15-e044cda04884"), new Guid("522b95f8-a95b-456f-9a08-28011718a47b"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2196), null, null, 100, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(2197), null });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "InsertedAt", "InsertedById", "InvoiceId", "IsDeleted", "Price", "TicketType", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("99f1f44e-59d9-4ce0-ba38-204ef359fcaa"), new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3504), null, new Guid("7ddbf4aa-a6fd-44f6-8337-86444f2f7005"), null, 75.00m, 0, new DateTime(2024, 10, 31, 14, 20, 41, 248, DateTimeKind.Local).AddTicks(3504), null });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_InsertedById",
                table: "Accounts",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleId",
                table: "Accounts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UpdatedById",
                table: "Accounts",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaRooms_CurrentMovieId",
                table: "CinemaRooms",
                column: "CurrentMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaRooms_InsertedById",
                table: "CinemaRooms",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaRooms_UpdatedById",
                table: "CinemaRooms",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AccountId",
                table: "Employees",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_InsertedById",
                table: "Employees",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UpdatedById",
                table: "Employees",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_AccountId",
                table: "Invoices",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InsertedById",
                table: "Invoices",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UpdatedById",
                table: "Invoices",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Members_AccountId",
                table: "Members",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_InsertedById",
                table: "Members",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_Members_UpdatedById",
                table: "Members",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_InsertedById",
                table: "Movies",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_UpdatedById",
                table: "Movies",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSchedule_InsertedById",
                table: "MovieSchedule",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSchedule_MovieId",
                table: "MovieSchedule",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSchedule_ScheduleId",
                table: "MovieSchedule",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSchedule_UpdatedById",
                table: "MovieSchedule",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MovieShowDates_InsertedById",
                table: "MovieShowDates",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_MovieShowDates_MovieId",
                table: "MovieShowDates",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieShowDates_ShowDateId",
                table: "MovieShowDates",
                column: "ShowDateId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieShowDates_UpdatedById",
                table: "MovieShowDates",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTypes_InsertedById",
                table: "MovieTypes",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTypes_MovieId",
                table: "MovieTypes",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTypes_TypeId",
                table: "MovieTypes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTypes_UpdatedById",
                table: "MovieTypes",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_InsertedById",
                table: "Promotions",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_UpdatedById",
                table: "Promotions",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_InsertedById",
                table: "Roles",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UpdatedById",
                table: "Roles",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_InsertedById",
                table: "Schedules",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_UpdatedById",
                table: "Schedules",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSeats_InsertedById",
                table: "ScheduleSeats",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSeats_MovieId",
                table: "ScheduleSeats",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSeats_ScheduleId",
                table: "ScheduleSeats",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSeats_SeatId",
                table: "ScheduleSeats",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSeats_UpdatedById",
                table: "ScheduleSeats",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_CinemaRoomId",
                table: "Seats",
                column: "CinemaRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_InsertedById",
                table: "Seats",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_UpdatedById",
                table: "Seats",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ShowDates_InsertedById",
                table: "ShowDates",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_ShowDates_UpdatedById",
                table: "ShowDates",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_InsertedById",
                table: "Tickets",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_InvoiceId",
                table: "Tickets",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UpdatedById",
                table: "Tickets",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Types_InsertedById",
                table: "Types",
                column: "InsertedById");

            migrationBuilder.CreateIndex(
                name: "IX_Types_UpdatedById",
                table: "Types",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Roles_RoleId",
                table: "Accounts",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Roles_RoleId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "MovieSchedule");

            migrationBuilder.DropTable(
                name: "MovieShowDates");

            migrationBuilder.DropTable(
                name: "MovieTypes");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "ScheduleSeats");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "ShowDates");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "CinemaRooms");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
