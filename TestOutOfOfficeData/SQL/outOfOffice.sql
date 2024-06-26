USE [master]
GO
/****** Object:  Database [OutOfOffice]    Script Date: 20.06.2024 23:45:19 ******/
CREATE DATABASE [OutOfOffice]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OutOfOffice', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\OutOfOffice.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OutOfOffice_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\OutOfOffice_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [OutOfOffice] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OutOfOffice].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OutOfOffice] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OutOfOffice] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OutOfOffice] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OutOfOffice] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OutOfOffice] SET ARITHABORT OFF 
GO
ALTER DATABASE [OutOfOffice] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OutOfOffice] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OutOfOffice] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OutOfOffice] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OutOfOffice] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OutOfOffice] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OutOfOffice] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OutOfOffice] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OutOfOffice] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OutOfOffice] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OutOfOffice] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OutOfOffice] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OutOfOffice] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OutOfOffice] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OutOfOffice] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OutOfOffice] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OutOfOffice] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OutOfOffice] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OutOfOffice] SET  MULTI_USER 
GO
ALTER DATABASE [OutOfOffice] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OutOfOffice] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OutOfOffice] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OutOfOffice] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OutOfOffice] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OutOfOffice] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [OutOfOffice] SET QUERY_STORE = ON
GO
ALTER DATABASE [OutOfOffice] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [OutOfOffice]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 20.06.2024 23:45:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApprovalRequests]    Script Date: 20.06.2024 23:45:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApprovalRequests](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Approver] [int] NOT NULL,
	[LeaverRequest] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_ApprovalRequests] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 20.06.2024 23:45:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 20.06.2024 23:45:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 20.06.2024 23:45:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 20.06.2024 23:45:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 20.06.2024 23:45:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 20.06.2024 23:45:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 20.06.2024 23:45:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeInProject]    Script Date: 20.06.2024 23:45:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeInProject](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
 CONSTRAINT [PK_EmployeeInProject] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 20.06.2024 23:45:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Subdivision] [int] NOT NULL,
	[Position] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[PeopleParthner] [int] NOT NULL,
	[OutOfOfficeBalance] [int] NOT NULL,
	[Photo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveRequests]    Script Date: 20.06.2024 23:45:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveRequests](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[AbsenceReason] [int] NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_LeaveRequests] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 20.06.2024 23:45:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectType] [int] NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NULL,
	[ProjectManager] [int] NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240616113941_InitialCreate', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240617194654_AddTables', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240618082636_UpdateProject', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240618122603_UpdateProjectText', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240619104931_UpdateLeaveRequest', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240619201618_UpdataApprovalRequest', N'8.0.6')
GO
SET IDENTITY_INSERT [dbo].[ApprovalRequests] ON 

INSERT [dbo].[ApprovalRequests] ([ID], [Approver], [LeaverRequest], [Status], [Comment]) VALUES (1, 2, 1, 1, N'accept')
INSERT [dbo].[ApprovalRequests] ([ID], [Approver], [LeaverRequest], [Status], [Comment]) VALUES (3, 0, 2, 3, NULL)
INSERT [dbo].[ApprovalRequests] ([ID], [Approver], [LeaverRequest], [Status], [Comment]) VALUES (4, 3, 6, 1, N'')
SET IDENTITY_INSERT [dbo].[ApprovalRequests] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'5ac784c4-ce4c-46ac-9de5-738511d27b90', N'Administrator', N'ADMINISTRATOR', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'6ddc9cec-043f-4cf4-a09e-a1635c556b09', N'Employee', N'EMPLOYEE', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'82bde306-d74a-498a-850b-c7ed5b2e5b01', N'HRManager', N'HRMANAGER', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'cbb40b0d-048c-4e46-b4b6-8912d146d1c6', N'ProjectManager', N'PROJECTMANAGER', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b863d404-b85b-49cf-acf8-4f3e85d501bb', N'5ac784c4-ce4c-46ac-9de5-738511d27b90')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0fab46b0-6cd5-4bcf-9059-08533a242952', N'6ddc9cec-043f-4cf4-a09e-a1635c556b09')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6d682dc2-2efc-4796-8e75-512ddc5ed89f', N'6ddc9cec-043f-4cf4-a09e-a1635c556b09')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b75aac86-370d-4bd8-a51c-e426591a4dd5', N'6ddc9cec-043f-4cf4-a09e-a1635c556b09')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'eeb7b980-e486-44c1-8eee-776cc79b5689', N'6ddc9cec-043f-4cf4-a09e-a1635c556b09')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a6d6def5-a80e-4c63-ac5a-07ec81797553', N'82bde306-d74a-498a-850b-c7ed5b2e5b01')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd083bffe-5228-446d-872d-836a0b9f9e1b', N'82bde306-d74a-498a-850b-c7ed5b2e5b01')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bb32cd38-9129-43ca-bb89-fcc0b5d6c1a3', N'cbb40b0d-048c-4e46-b4b6-8912d146d1c6')
GO
INSERT [dbo].[AspNetUsers] ([Id], [EmployeeId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0fab46b0-6cd5-4bcf-9059-08533a242952', 6, N'dad4@op.pl', N'DAD4@OP.PL', N'dad4@op.pl', N'DAD4@OP.PL', 1, N'AQAAAAIAAYagAAAAEPLc1keyDP4P8wg4AsvaxaDsm31BCV9pbNgduTGN4nB9EUvW/NM/OhzmyE60sSMT7Q==', N'', N'676df834-d945-49dc-8f2c-54927a126662', NULL, 0, 0, NULL, 0, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmployeeId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6d682dc2-2efc-4796-8e75-512ddc5ed89f', 8, N'employee2@example.com', N'EMPLOYEE2@EXAMPLE.COM', N'employee2@example.com', N'EMPLOYEE2@EXAMPLE.COM', 1, N'AQAAAAIAAYagAAAAEAmIuj9efx9J+EY4NjBuuHVNlEeDUM2FCnsWwnZZzPNR3AQ8svsX0Abzugdq5Ciktg==', N'', N'6ce50c50-cc21-49ce-9480-95480c424a58', NULL, 0, 0, NULL, 0, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmployeeId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a6d6def5-a80e-4c63-ac5a-07ec81797553', 2, N'hrmanager@example.com', N'HRMANAGER@EXAMPLE.COM', N'hrmanager@example.com', N'HRMANAGER@EXAMPLE.COM', 1, N'AQAAAAIAAYagAAAAEFQ6VP39idQ4rZBa8HEFfRMtuTGjPak//GBKIMkrjr8ocYudnJFIZ0SrzerR78Owtg==', N'', N'd03fbf6c-4c43-4029-839b-9f3cb3d886af', NULL, 0, 0, NULL, 0, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmployeeId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b75aac86-370d-4bd8-a51c-e426591a4dd5', 1, N'employee@example.com', N'EMPLOYEE@EXAMPLE.COM', N'employee@example.com', N'EMPLOYEE@EXAMPLE.COM', 1, N'AQAAAAIAAYagAAAAEK540+jBj7QKyDJub2A84xwGisT+b01GNd0Oi52o1Fo11rg9NlDYQ5kLKY/7VU/Y0A==', N'', N'3ee75824-baa5-4cc2-9f63-09cdd2bd10d1', NULL, 0, 0, NULL, 0, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmployeeId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b863d404-b85b-49cf-acf8-4f3e85d501bb', 4, N'administrator@example.com', N'ADMINISTRATOR@EXAMPLE.COM', N'administrator@example.com', N'ADMINISTRATOR@EXAMPLE.COM', 1, N'AQAAAAIAAYagAAAAEPHGeX/TOjK37VmZD0Dgr7EmRwS38AErxczV8wSsgknGZfGGTMtbytzOdR3CwZTDdQ==', N'', N'394621c1-5680-4428-bf35-6d67f2939d63', NULL, 0, 0, NULL, 0, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmployeeId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'bb32cd38-9129-43ca-bb89-fcc0b5d6c1a3', 3, N'projectmanager@example.com', N'PROJECTMANAGER@EXAMPLE.COM', N'projectmanager@example.com', N'PROJECTMANAGER@EXAMPLE.COM', 1, N'AQAAAAIAAYagAAAAEOF81BuDB9RYGGXJ3y9/wHQ0opvkk3Io9dtHeJCcEixBh/JrCN83apCIiB/V9EGriA==', N'', N'bf223602-5756-4e07-82c8-4b7d34af6913', NULL, 0, 0, NULL, 0, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmployeeId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd083bffe-5228-446d-872d-836a0b9f9e1b', 7, N'hrmanager2@example.com', N'HRMANAGER2@EXAMPLE.COM', N'hrmanager2@example.com', N'HRMANAGER2@EXAMPLE.COM', 1, N'AQAAAAIAAYagAAAAEBMo/K0KvtyusnHRdsrUnEZkY4k3pHihKAi1qrEu/D53fosWbIVOxS4sud8xWk4LPw==', N'', N'fb2f7054-968c-46dd-af34-7b83c85bab14', NULL, 0, 0, NULL, 0, 0)
INSERT [dbo].[AspNetUsers] ([Id], [EmployeeId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'eeb7b980-e486-44c1-8eee-776cc79b5689', 9, N'dad3@op.pl', N'DAD3@OP.PL', N'dad3@op.pl', N'DAD3@OP.PL', 1, N'AQAAAAIAAYagAAAAEPrun5KjsV5qx1pSb3yOu/q9ALbYo9e5bubhQ1MGmYU0f4J3aCVBHvQOEE4r4p/DPA==', N'', N'9a115b69-bd4e-4305-b514-0f03704ab93b', NULL, 0, 0, NULL, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[EmployeeInProject] ON 

INSERT [dbo].[EmployeeInProject] ([ID], [EmployeeID], [ProjectID]) VALUES (3, 1, 1)
INSERT [dbo].[EmployeeInProject] ([ID], [EmployeeID], [ProjectID]) VALUES (4, 6, 1)
INSERT [dbo].[EmployeeInProject] ([ID], [EmployeeID], [ProjectID]) VALUES (5, 1, 3)
INSERT [dbo].[EmployeeInProject] ([ID], [EmployeeID], [ProjectID]) VALUES (6, 8, 3)
SET IDENTITY_INSERT [dbo].[EmployeeInProject] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([ID], [FullName], [Subdivision], [Position], [Status], [PeopleParthner], [OutOfOfficeBalance], [Photo]) VALUES (1, N'Jon Snow', 3, 0, 0, 2, 4, N'')
INSERT [dbo].[Employees] ([ID], [FullName], [Subdivision], [Position], [Status], [PeopleParthner], [OutOfOfficeBalance], [Photo]) VALUES (2, N'Human Res', 0, 1, 0, 0, 0, N'')
INSERT [dbo].[Employees] ([ID], [FullName], [Subdivision], [Position], [Status], [PeopleParthner], [OutOfOfficeBalance], [Photo]) VALUES (3, N'Project Ma', 3, 2, 0, 2, 0, N'')
INSERT [dbo].[Employees] ([ID], [FullName], [Subdivision], [Position], [Status], [PeopleParthner], [OutOfOfficeBalance], [Photo]) VALUES (4, N'Admin', 5, 3, 0, 2, 0, N'')
INSERT [dbo].[Employees] ([ID], [FullName], [Subdivision], [Position], [Status], [PeopleParthner], [OutOfOfficeBalance], [Photo]) VALUES (6, N'Adam Nowak', 1, 0, 0, 2, 9, N'')
INSERT [dbo].[Employees] ([ID], [FullName], [Subdivision], [Position], [Status], [PeopleParthner], [OutOfOfficeBalance], [Photo]) VALUES (7, N'Hr manager2', 0, 1, 0, 0, 0, N'')
INSERT [dbo].[Employees] ([ID], [FullName], [Subdivision], [Position], [Status], [PeopleParthner], [OutOfOfficeBalance], [Photo]) VALUES (8, N'Luke Skywalker', 3, 0, 1, 2, 19, N'')
INSERT [dbo].[Employees] ([ID], [FullName], [Subdivision], [Position], [Status], [PeopleParthner], [OutOfOfficeBalance], [Photo]) VALUES (9, N'test', 0, 0, 0, 2, 44, N'')
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[LeaveRequests] ON 

INSERT [dbo].[LeaveRequests] ([ID], [EmployeeId], [AbsenceReason], [StartDate], [EndDate], [Comment], [Status]) VALUES (1, 1, 0, CAST(N'2024-06-20T00:00:00.0000000' AS DateTime2), CAST(N'2024-06-22T00:00:00.0000000' AS DateTime2), N'test comment for leave request ', 3)
INSERT [dbo].[LeaveRequests] ([ID], [EmployeeId], [AbsenceReason], [StartDate], [EndDate], [Comment], [Status]) VALUES (2, 1, 1, CAST(N'2024-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-07-06T00:00:00.0000000' AS DateTime2), N'vacation ', 2)
INSERT [dbo].[LeaveRequests] ([ID], [EmployeeId], [AbsenceReason], [StartDate], [EndDate], [Comment], [Status]) VALUES (3, 1, 4, CAST(N'2024-07-04T00:00:00.0000000' AS DateTime2), CAST(N'2024-07-05T00:00:00.0000000' AS DateTime2), N'sadasd', 0)
INSERT [dbo].[LeaveRequests] ([ID], [EmployeeId], [AbsenceReason], [StartDate], [EndDate], [Comment], [Status]) VALUES (4, 1, 9, CAST(N'2024-07-06T00:00:00.0000000' AS DateTime2), CAST(N'2024-08-31T00:00:00.0000000' AS DateTime2), N'asdasdasdas das d as das das das as', 2)
INSERT [dbo].[LeaveRequests] ([ID], [EmployeeId], [AbsenceReason], [StartDate], [EndDate], [Comment], [Status]) VALUES (5, 1, 13, CAST(N'2024-07-06T00:00:00.0000000' AS DateTime2), CAST(N'2024-07-06T00:00:00.0000000' AS DateTime2), N'sssss', 0)
INSERT [dbo].[LeaveRequests] ([ID], [EmployeeId], [AbsenceReason], [StartDate], [EndDate], [Comment], [Status]) VALUES (6, 8, 2, CAST(N'2024-06-23T00:00:00.0000000' AS DateTime2), CAST(N'2024-06-29T00:00:00.0000000' AS DateTime2), N'leave request comment ', 3)
INSERT [dbo].[LeaveRequests] ([ID], [EmployeeId], [AbsenceReason], [StartDate], [EndDate], [Comment], [Status]) VALUES (7, 8, 1, CAST(N'2024-07-07T00:00:00.0000000' AS DateTime2), CAST(N'2024-07-11T00:00:00.0000000' AS DateTime2), N'Vacation ', 0)
SET IDENTITY_INSERT [dbo].[LeaveRequests] OFF
GO
SET IDENTITY_INSERT [dbo].[Projects] ON 

INSERT [dbo].[Projects] ([ID], [ProjectType], [StartDate], [EndDate], [ProjectManager], [Comment], [Status]) VALUES (1, 0, CAST(N'2024-06-23T00:00:00.0000000' AS DateTime2), NULL, 3, N'New comment about this project', 0)
INSERT [dbo].[Projects] ([ID], [ProjectType], [StartDate], [EndDate], [ProjectManager], [Comment], [Status]) VALUES (2, 0, CAST(N'2024-06-19T00:00:00.0000000' AS DateTime2), NULL, 3, N'comment', 0)
INSERT [dbo].[Projects] ([ID], [ProjectType], [StartDate], [EndDate], [ProjectManager], [Comment], [Status]) VALUES (3, 2, CAST(N'2024-07-02T00:00:00.0000000' AS DateTime2), NULL, 3, NULL, 0)
INSERT [dbo].[Projects] ([ID], [ProjectType], [StartDate], [EndDate], [ProjectManager], [Comment], [Status]) VALUES (4, 5, CAST(N'2024-07-06T00:00:00.0000000' AS DateTime2), CAST(N'2024-07-13T00:00:00.0000000' AS DateTime2), 3, NULL, 0)
SET IDENTITY_INSERT [dbo].[Projects] OFF
GO
/****** Object:  Index [IX_ApprovalRequests_LeaverRequest]    Script Date: 20.06.2024 23:45:19 ******/
CREATE NONCLUSTERED INDEX [IX_ApprovalRequests_LeaverRequest] ON [dbo].[ApprovalRequests]
(
	[LeaverRequest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 20.06.2024 23:45:19 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 20.06.2024 23:45:19 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 20.06.2024 23:45:19 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 20.06.2024 23:45:19 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 20.06.2024 23:45:19 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 20.06.2024 23:45:19 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_EmployeeId]    Script Date: 20.06.2024 23:45:19 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_EmployeeId] ON [dbo].[AspNetUsers]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 20.06.2024 23:45:19 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeInProject_EmployeeID]    Script Date: 20.06.2024 23:45:19 ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeInProject_EmployeeID] ON [dbo].[EmployeeInProject]
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeInProject_ProjectID]    Script Date: 20.06.2024 23:45:19 ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeInProject_ProjectID] ON [dbo].[EmployeeInProject]
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_LeaveRequests_EmployeeId]    Script Date: 20.06.2024 23:45:19 ******/
CREATE NONCLUSTERED INDEX [IX_LeaveRequests_EmployeeId] ON [dbo].[LeaveRequests]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ApprovalRequests]  WITH CHECK ADD  CONSTRAINT [FK_ApprovalRequests_LeaveRequests_LeaverRequest] FOREIGN KEY([LeaverRequest])
REFERENCES [dbo].[LeaveRequests] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApprovalRequests] CHECK CONSTRAINT [FK_ApprovalRequests_LeaveRequests_LeaverRequest]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Employees_EmployeeId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[EmployeeInProject]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeInProject_Employees_EmployeeID] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeInProject] CHECK CONSTRAINT [FK_EmployeeInProject_Employees_EmployeeID]
GO
ALTER TABLE [dbo].[EmployeeInProject]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeInProject_Projects_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeInProject] CHECK CONSTRAINT [FK_EmployeeInProject_Projects_ProjectID]
GO
ALTER TABLE [dbo].[LeaveRequests]  WITH CHECK ADD  CONSTRAINT [FK_LeaveRequests_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LeaveRequests] CHECK CONSTRAINT [FK_LeaveRequests_Employees_EmployeeId]
GO
USE [master]
GO
ALTER DATABASE [OutOfOffice] SET  READ_WRITE 
GO
