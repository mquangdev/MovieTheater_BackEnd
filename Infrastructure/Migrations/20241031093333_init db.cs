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
                    { new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), null, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7156), null, null, "Room 1", 30, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7157), null },
                    { new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), null, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7160), null, null, "Room 2", 25, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7161), null }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Actor", "Content", "Director", "Duration", "FromDate", "InsertedAt", "InsertedById", "IsDeleted", "LargeImage", "MovieNameEnglish", "MovieNameVN", "MovieProductionCompany", "SmallImage", "ToDate", "UpdatedAt", "UpdatedById", "Version" },
                values: new object[,]
                {
                    { new Guid("7bd8ac85-c907-44aa-a961-89bd9a487a2b"), "Actor 1", "Action packed movie.", "Director 1", new TimeSpan(0, 2, 0, 0, 0), new DateTime(2024, 9, 30, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7208), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7224), null, null, "path/to/large/image1.jpg", "Action Movie", "Phim Hành Động", null, "path/to/small/image1.jpg", new DateTime(2024, 12, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7221), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7225), null, null },
                    { new Guid("fd0d681e-708d-4835-9d3c-deb2c8036534"), "Actor 2", "Romantic movie.", "Director 2", new TimeSpan(0, 1, 30, 0, 0), new DateTime(2024, 9, 30, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7229), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7232), null, null, "path/to/large/image2.jpg", "Romantic Movie", "Phim Tình Cảm", null, "path/to/small/image2.jpg", new DateTime(2024, 11, 30, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7230), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7233), null, null }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Detail", "DiscountLevel", "EndTime", "Image", "InsertedAt", "InsertedById", "IsDeleted", "StartTime", "Title", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("95325ae9-a8eb-4139-a5f2-f8e5aa9b8926"), "Get 20% off for all tickets.", 20.0, new DateTime(2024, 11, 30, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9080), "path/to/promotion/image.jpg", new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9081), null, null, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9079), "New Year Discount", new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9082), null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "InsertedAt", "InsertedById", "IsDeleted", "RoleName", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { new Guid("4d5f4397-994b-499d-8c53-26cb09bbe652"), null, null, null, "Employee", null, null },
                    { new Guid("71b0500c-0b40-455b-ba72-63d1b06e468b"), null, null, null, "Member", null, null },
                    { new Guid("b0aff688-55b7-406f-97cd-c00c35b1bf95"), null, null, null, "Admin", null, null }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "InsertedAt", "InsertedById", "IsDeleted", "ScheduleTime", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { new Guid("06a65541-b7f6-4e49-99eb-4a58ec4eb26f"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8870), null, null, new TimeSpan(0, 18, 0, 0, 0), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8871), null },
                    { new Guid("37627142-c155-4b7c-b26c-f6a77ef51aa4"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8813), null, null, new TimeSpan(0, 15, 0, 0, 0), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8814), null },
                    { new Guid("485ead18-dd73-4254-a2c7-3d3233059778"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8818), null, null, new TimeSpan(0, 16, 0, 0, 0), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8819), null },
                    { new Guid("4c3d0d9d-2e27-4646-9007-be4d0ed61b42"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8866), null, null, new TimeSpan(0, 17, 0, 0, 0), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8867), null },
                    { new Guid("637e6b26-08e4-49bb-94a9-e41ddae1c096"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8773), null, null, new TimeSpan(0, 8, 0, 0, 0), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8774), null },
                    { new Guid("6af452a3-65a7-42d4-87b9-0019ed5d5b85"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8878), null, null, new TimeSpan(0, 19, 0, 0, 0), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8879), null },
                    { new Guid("7bc8fb25-ea41-430d-b1b8-e9a572b814b2"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8782), null, null, new TimeSpan(0, 9, 0, 0, 0), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8783), null },
                    { new Guid("88256255-83f4-4f04-9dee-5ec026664299"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8896), null, null, new TimeSpan(0, 23, 0, 0, 0), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8897), null },
                    { new Guid("b60122ec-0de2-44d7-afed-381a0c2e2926"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8798), null, null, new TimeSpan(0, 12, 0, 0, 0), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8799), null },
                    { new Guid("bc2445ae-fbee-43c5-bbd1-113d671816bf"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8887), null, null, new TimeSpan(0, 21, 0, 0, 0), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8888), null },
                    { new Guid("c61f8f88-a3c2-4e70-9dd2-2d3e70404340"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8809), null, null, new TimeSpan(0, 14, 0, 0, 0), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8810), null },
                    { new Guid("d04d0e1d-74c3-47cb-9007-dd0ec5e23f39"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8786), null, null, new TimeSpan(0, 10, 0, 0, 0), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8787), null },
                    { new Guid("d747db86-f107-4ab4-bdb2-e48e9091d978"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8891), null, null, new TimeSpan(0, 22, 0, 0, 0), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8892), null },
                    { new Guid("e30fd83b-bc55-4ab0-90f4-4099853248af"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8883), null, null, new TimeSpan(0, 20, 0, 0, 0), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8883), null },
                    { new Guid("f613ba7e-efd0-46e5-a06e-228ac16b1e19"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8804), null, null, new TimeSpan(0, 13, 0, 0, 0), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8805), null },
                    { new Guid("fd58b513-535d-4e7f-9d2e-be327af614b2"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8794), null, null, new TimeSpan(0, 11, 0, 0, 0), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8795), null }
                });

            migrationBuilder.InsertData(
                table: "ShowDates",
                columns: new[] { "Id", "DateName", "DateShow", "InsertedAt", "InsertedById", "IsDeleted", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("27274d94-45e4-4918-bbf1-e718a6705f19"), "Tomorrow", new DateTime(2024, 11, 1, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8992), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8997), null, null, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8998), null });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "InsertedAt", "InsertedById", "IsDeleted", "Name", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { new Guid("e4cb01f9-6a1a-4f7d-9a09-83bfaf04f054"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9224), null, null, "Action", new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9225), null },
                    { new Guid("ef4ef832-43e2-4a0a-8b0a-13746f79b46b"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9227), null, null, "Romantic", new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9228), null }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "FullName", "Gender", "IdentityCard", "Image", "InsertedAt", "InsertedById", "IsDeleted", "Password", "PhoneNumber", "RegisterDate", "RoleId", "Status", "UpdatedAt", "UpdatedById", "Username" },
                values: new object[,]
                {
                    { new Guid("29d3cceb-992e-4ed2-b4d3-44bea80a26ac"), null, null, "employee@example.com", "Employee User", null, null, null, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7023), null, null, "employee123", null, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7023), new Guid("4d5f4397-994b-499d-8c53-26cb09bbe652"), null, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7024), null, "employee" },
                    { new Guid("65541c65-31f0-4201-9000-3dffc82988da"), null, null, "admin@example.com", "Admin User", null, null, null, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7001), null, null, "admin123", null, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(6990), new Guid("b0aff688-55b7-406f-97cd-c00c35b1bf95"), null, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7005), null, "admin" },
                    { new Guid("bde7c978-94f0-44dc-ae36-9e0a0b52e593"), null, null, "member@example.com", "Member User", null, null, null, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7030), null, null, "member123", null, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7029), new Guid("71b0500c-0b40-455b-ba72-63d1b06e468b"), null, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7031), null, "member" }
                });

            migrationBuilder.InsertData(
                table: "MovieSchedule",
                columns: new[] { "Id", "InsertedAt", "InsertedById", "IsDeleted", "MovieId", "ScheduleId", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("35de3447-8412-42e8-bb2a-e13664fda24d"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8953), null, null, new Guid("7bd8ac85-c907-44aa-a961-89bd9a487a2b"), new Guid("637e6b26-08e4-49bb-94a9-e41ddae1c096"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8954), null });

            migrationBuilder.InsertData(
                table: "MovieShowDates",
                columns: new[] { "Id", "InsertedAt", "InsertedById", "IsDeleted", "MovieId", "ShowDateId", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("e10e7171-7c19-4b70-b6ad-5347674c7618"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9039), null, null, new Guid("7bd8ac85-c907-44aa-a961-89bd9a487a2b"), new Guid("27274d94-45e4-4918-bbf1-e718a6705f19"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9040), null });

            migrationBuilder.InsertData(
                table: "MovieTypes",
                columns: new[] { "Id", "InsertedAt", "InsertedById", "IsDeleted", "MovieId", "TypeId", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { new Guid("3d7e3ded-5534-4b8a-a3a8-33c0a7ec16f4"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9269), null, null, new Guid("fd0d681e-708d-4835-9d3c-deb2c8036534"), new Guid("ef4ef832-43e2-4a0a-8b0a-13746f79b46b"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9270), null },
                    { new Guid("9a35d5be-4b0c-4341-92e7-d6e118a9ee43"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9265), null, null, new Guid("7bd8ac85-c907-44aa-a961-89bd9a487a2b"), new Guid("e4cb01f9-6a1a-4f7d-9a09-83bfaf04f054"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9266), null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CinemaRoomId", "InsertedAt", "InsertedById", "IsDeleted", "SeatColumn", "SeatRow", "SeatStatus", "SeatType", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { new Guid("0196a0bc-6eaa-49e4-a6d2-edbcdc1aa9e2"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8214), null, null, "A", 2, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8215), null },
                    { new Guid("03c9e985-acbe-499f-9f0c-c924eed5717d"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7535), null, null, "A", 2, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7536), null },
                    { new Guid("0c8b3a75-045d-4501-ba7c-241d7e2c8811"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8162), null, null, "D", 1, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8163), null },
                    { new Guid("19e594c8-a329-4fb4-9c92-ffbb9250df82"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7697), null, null, "B", 3, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7698), null },
                    { new Guid("1a29db88-591e-441e-a1b7-d9dc96eb4487"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8267), null, null, "C", 2, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8268), null },
                    { new Guid("1cd8a793-184c-4a29-9c1f-5121f0334f9f"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8000), null, null, "A", 5, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8001), null },
                    { new Guid("21c033e1-07e0-4724-a379-3afbb22a7f6b"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8026), null, null, "B", 5, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8027), null },
                    { new Guid("327de444-0a3e-4992-9c26-2508548cc623"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7387), null, null, "A", 1, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7388), null },
                    { new Guid("33d514b8-e68c-4f45-9e8f-b63efebff93c"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7724), null, null, "C", 3, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7725), null },
                    { new Guid("4ac3d10a-28ae-4ce8-9108-7c2934888063"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8080), null, null, "A", 1, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8081), null },
                    { new Guid("4b2fa748-106d-4347-9fbc-85126c94b179"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8689), null, null, "E", 4, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8690), null },
                    { new Guid("50e8dea3-2d35-436b-b9fe-7098fd612dc9"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8496), null, null, "E", 3, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8497), null },
                    { new Guid("563b0278-4ce8-4ce1-b397-f48bec6ea1c1"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7776), null, null, "E", 3, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7776), null },
                    { new Guid("5789bdbc-fc82-405c-a830-8dd674ff4f7a"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8637), null, null, "C", 4, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8638), null },
                    { new Guid("582d9ba8-38b0-443b-826a-1d2b69cbd5b4"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8110), null, null, "B", 1, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8111), null },
                    { new Guid("5a334638-113e-40a3-a7b7-7ebac1b612f3"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8607), null, null, "B", 4, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8608), null },
                    { new Guid("65148b12-9568-4ccc-8231-7a4cee51b75d"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8715), null, null, "A", 5, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8716), null },
                    { new Guid("6bed961a-ed2d-4ccf-ac20-4e63cae87ea2"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8443), null, null, "C", 3, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8444), null },
                    { new Guid("702e5da1-974d-40e3-b1c8-e60a792d6bf0"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7480), null, null, "D", 1, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7481), null },
                    { new Guid("7113e37f-1099-4705-876d-038d223bd966"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7750), null, null, "D", 3, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7751), null },
                    { new Guid("73e3cc7c-8a2d-4317-8316-bc51be6bd5f2"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7947), null, null, "D", 4, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7948), null },
                    { new Guid("77724c08-c712-4648-bd33-4f76b008e60c"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7645), null, null, "E", 2, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7645), null },
                    { new Guid("77827c49-8b5f-4b26-b842-9d316b534800"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8293), null, null, "D", 2, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8294), null },
                    { new Guid("82620787-a096-4d25-b2cb-795cbea5a920"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7562), null, null, "B", 2, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7563), null },
                    { new Guid("82ae1f4d-7419-480e-87c1-b2985947171e"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7424), null, null, "B", 1, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7425), null },
                    { new Guid("87fefe30-8938-43f2-b6ce-ff085dd8b258"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7919), null, null, "C", 4, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7920), null },
                    { new Guid("8a08171a-666f-4fcf-b9e8-3351d41a240f"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7833), null, null, "B", 4, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7833), null },
                    { new Guid("94abe95c-f19c-4fd8-ae5c-cccf73bc4677"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7506), null, null, "E", 1, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7507), null },
                    { new Guid("99237463-861e-4b03-8f03-30dfb9606d6b"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8390), null, null, "A", 3, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8391), null },
                    { new Guid("a4c8d816-f5f2-491f-9bca-047b4cf7f9ff"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8322), null, null, "E", 2, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8323), null },
                    { new Guid("a8daeebc-3144-4be1-bb75-89cfb1ab82b4"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7802), null, null, "A", 4, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7803), null },
                    { new Guid("af92b48a-3463-4d5d-9d6f-ccf98f22ff58"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7453), null, null, "C", 1, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7453), null },
                    { new Guid("b28fca6d-0872-48d7-b06d-443263e90b7a"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8663), null, null, "D", 4, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8664), null },
                    { new Guid("b4041371-0f5f-408b-b9ac-153134f1af6e"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8417), null, null, "B", 3, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8418), null },
                    { new Guid("b67ee80e-5063-494c-9371-b6a2720000f7"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7671), null, null, "A", 3, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7672), null },
                    { new Guid("c32ae876-8545-47c9-b33c-6b08738404c0"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8470), null, null, "D", 3, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8471), null },
                    { new Guid("c56ea5ba-7025-4ea0-99e0-27316cc46e37"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8742), null, null, "B", 5, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8743), null },
                    { new Guid("c750463b-262b-4196-95b6-fb8bc8e0ad72"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8052), null, null, "C", 5, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8053), null },
                    { new Guid("c90a9c36-b622-45d6-bbe0-856dc149f158"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8188), null, null, "E", 1, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8189), null },
                    { new Guid("cd05cd6a-9c41-452f-ad01-402c35af7cda"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8137), null, null, "C", 1, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8138), null },
                    { new Guid("cd8bdf7e-c497-4410-a604-5c80015eb78e"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8580), null, null, "A", 4, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8581), null },
                    { new Guid("e526ae67-2050-4557-ab59-9b67c5500d15"), new Guid("ad68ca82-150c-4e7b-a726-d3ffe68a5088"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8241), null, null, "B", 2, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(8242), null },
                    { new Guid("f200350f-d129-472d-80f3-c2444624688d"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7588), null, null, "C", 2, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7589), null },
                    { new Guid("f98df641-e4b5-46a5-a2d5-3586a87340de"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7617), null, null, "D", 2, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7618), null },
                    { new Guid("fc1b2972-7fb3-4867-9116-be0af4801652"), new Guid("7bf4854d-82cc-4348-a585-2fb0dfa998d8"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7973), null, null, "E", 4, 0, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7974), null }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AccountId", "InsertedAt", "InsertedById", "IsDeleted", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("b374d263-13ee-43a9-8005-b029d087a985"), new Guid("29d3cceb-992e-4ed2-b4d3-44bea80a26ac"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7070), null, null, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7071), null });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "AccountId", "AddScore", "BookingDate", "InsertedAt", "InsertedById", "IsDeleted", "MovieName", "ScheduleShow", "ScheduleShowTime", "Seat", "Status", "TotalMoney", "UpdatedAt", "UpdatedById", "UseScore" },
                values: new object[] { new Guid("f7d22671-7074-4f4a-b37b-7d295f7b332e"), new Guid("bde7c978-94f0-44dc-ae36-9e0a0b52e593"), 10, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9115), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9149), null, null, "Action Movie", new DateOnly(2024, 11, 1), "18:00", "1A, 1B", 1, 150.00m, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9150), null, 0 });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "AccountId", "InsertedAt", "InsertedById", "IsDeleted", "Score", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("ce3b0557-af99-4f9c-aa4e-2b1705d45eaa"), new Guid("bde7c978-94f0-44dc-ae36-9e0a0b52e593"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7108), null, null, 100, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(7109), null });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "InsertedAt", "InsertedById", "InvoiceId", "IsDeleted", "Price", "TicketType", "UpdatedAt", "UpdatedById" },
                values: new object[] { new Guid("f3c86b92-0b9e-4e65-8bbb-7358c4b503d7"), new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9186), null, new Guid("f7d22671-7074-4f4a-b37b-7d295f7b332e"), null, 75.00m, 0, new DateTime(2024, 10, 31, 16, 33, 32, 684, DateTimeKind.Local).AddTicks(9187), null });

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
