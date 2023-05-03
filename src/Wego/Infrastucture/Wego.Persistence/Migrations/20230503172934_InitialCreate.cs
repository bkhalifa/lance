using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wego.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "config");

            migrationBuilder.EnsureSchema(
                name: "profile");

            migrationBuilder.CreateTable(
                name: "BusinessSkills",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractTypes",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceYears",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Years = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrancoCountries",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "JobLevel",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationsSearch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRef = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LocationType = table.Column<short>(type: "smallint", nullable: false),
                    ParentName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IsPriority = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationsSearch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogEvent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Application = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Environment = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    StackTrace = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OffersSearch",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AmountMin = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    AmountMax = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    AmountUnit = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    LocationCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LocationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContractTypeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContractTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CategoryCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CatgeoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BusinessSkillCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BusinessSkillName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    JobLevelCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    JobLevelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WorkTypeCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WorkTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RemoteDays = table.Column<short>(type: "smallint", nullable: true),
                    ExperienceYear = table.Column<int>(type: "int", nullable: true),
                    SkillCodes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SkillNames = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SearchKeys = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OffersSearch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config.Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                schema: "profile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: true),
                    IsActif = table.Column<bool>(type: "bit", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UsId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Region = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Position = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ContractType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CategoryType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Completion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserProf__3214EC073DC57FDB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkTypes",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_config.WorkType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZipCodes",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ZipCodeSecondary = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NameSecondary = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gps = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Countries",
                        column: x => x.CountryId,
                        principalSchema: "config",
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                schema: "profile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserProfileId = table.Column<long>(type: "bigint", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DocName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Document__3214EC07E28C52AA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userprofile_documents",
                        column: x => x.UserProfileId,
                        principalSchema: "profile",
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                schema: "profile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserProfileId = table.Column<long>(type: "bigint", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: true),
                    StartMounth = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    EndMounth = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Experien__3214EC0712A2554F", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Experienc__UserP__08D548FA",
                        column: x => x.UserProfileId,
                        principalSchema: "profile",
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "profile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Laguage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Level = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserProfileId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Languages__UserP__09C96D33",
                        column: x => x.UserProfileId,
                        principalSchema: "profile",
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrainShip",
                schema: "profile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Diploma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    UserProfileId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TrainShi__3214EC07EC1EEEC2", x => x.Id);
                    table.ForeignKey(
                        name: "FK__TrainShip__UserP__0ABD916C",
                        column: x => x.UserProfileId,
                        principalSchema: "profile",
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserVisibility",
                schema: "profile",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isVisble = table.Column<bool>(type: "bit", nullable: false),
                    userProfileId = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserVisi__3213E83FC86C941F", x => x.id);
                    table.ForeignKey(
                        name: "FK__UserVisib__userP__0BB1B5A5",
                        column: x => x.userProfileId,
                        principalSchema: "profile",
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    SalaryMin = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    SalaryMax = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: true),
                    ContractTypeId = table.Column<long>(type: "bigint", nullable: true),
                    CatgeoryId = table.Column<long>(type: "bigint", nullable: true),
                    WorkTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ExperienceYearId = table.Column<long>(type: "bigint", nullable: true),
                    SearchPreference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Categories",
                        column: x => x.CatgeoryId,
                        principalSchema: "config",
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offers_ContractType",
                        column: x => x.CatgeoryId,
                        principalSchema: "config",
                        principalTable: "ContractTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offers_Customers",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offers_ExperienceLevels",
                        column: x => x.ExperienceYearId,
                        principalSchema: "config",
                        principalTable: "ExperienceYears",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offers_WorkType",
                        column: x => x.WorkTypeId,
                        principalSchema: "config",
                        principalTable: "WorkTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offers_ZipCodes",
                        column: x => x.ZipCodeId,
                        principalSchema: "config",
                        principalTable: "ZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrincipalCityCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Regions",
                        column: x => x.RegionId,
                        principalSchema: "config",
                        principalTable: "Regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cities_ZipCodes",
                        column: x => x.Id,
                        principalSchema: "config",
                        principalTable: "ZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocVisibility",
                schema: "profile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsNowVisible = table.Column<bool>(type: "bit", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserProfileId = table.Column<long>(type: "bigint", nullable: false),
                    DocId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DocVisib__3214EC07263E13BE", x => x.Id);
                    table.ForeignKey(
                        name: "FK__DocVisibi__DocId__07E124C1",
                        column: x => x.DocId,
                        principalSchema: "profile",
                        principalTable: "Documents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfferSkills",
                columns: table => new
                {
                    SkillId = table.Column<long>(type: "bigint", nullable: false),
                    OfferId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferCategories", x => new { x.SkillId, x.OfferId });
                    table.ForeignKey(
                        name: "FK_OfferSkills_Offers",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfferSkills_Skills",
                        column: x => x.SkillId,
                        principalSchema: "config",
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "AK_Unique_Code",
                schema: "config",
                table: "Categories",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RegionId",
                schema: "config",
                table: "Cities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "UQ__Document__9E267F635CEF096B",
                schema: "profile",
                table: "Documents",
                column: "UserProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__DocVisib__3EF188ACE3774004",
                schema: "profile",
                table: "DocVisibility",
                column: "DocId",
                unique: true,
                filter: "[DocId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_UserProfileId",
                schema: "profile",
                table: "Experiences",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_UserProfileId",
                schema: "profile",
                table: "Languages",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CatgeoryId",
                table: "Offers",
                column: "CatgeoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CustomerId",
                table: "Offers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ExperienceYearId",
                table: "Offers",
                column: "ExperienceYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_WorkTypeId",
                table: "Offers",
                column: "WorkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ZipCodeId",
                table: "Offers",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferSkills_OfferId",
                table: "OfferSkills",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CountryId",
                schema: "config",
                table: "Regions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainShip_UserProfileId",
                schema: "profile",
                table: "TrainShip",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "unqiue_usid",
                schema: "profile",
                table: "UserProfiles",
                column: "UsId",
                unique: true,
                filter: "[UsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserVisibility_userProfileId",
                schema: "profile",
                table: "UserVisibility",
                column: "userProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessSkills",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "config");

            migrationBuilder.DropTable(
                name: "DocVisibility",
                schema: "profile");

            migrationBuilder.DropTable(
                name: "Experiences",
                schema: "profile");

            migrationBuilder.DropTable(
                name: "FrancoCountries",
                schema: "config");

            migrationBuilder.DropTable(
                name: "JobLevel",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "profile");

            migrationBuilder.DropTable(
                name: "LocationsSearch");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "OfferSkills");

            migrationBuilder.DropTable(
                name: "OffersSearch");

            migrationBuilder.DropTable(
                name: "TrainShip",
                schema: "profile");

            migrationBuilder.DropTable(
                name: "UserVisibility",
                schema: "profile");

            migrationBuilder.DropTable(
                name: "Regions",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Documents",
                schema: "profile");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Skills",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "config");

            migrationBuilder.DropTable(
                name: "UserProfiles",
                schema: "profile");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ContractTypes",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ExperienceYears",
                schema: "config");

            migrationBuilder.DropTable(
                name: "WorkTypes",
                schema: "config");

            migrationBuilder.DropTable(
                name: "ZipCodes",
                schema: "config");
        }
    }
}
