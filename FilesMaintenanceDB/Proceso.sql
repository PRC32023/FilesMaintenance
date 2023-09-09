CREATE TABLE [dbo].[Proceso]
(
	[IdProcess] INT NOT NULL PRIMARY KEY identity, 
    ProcessName nvarchar(50) not null,
    [Path] NVARCHAR(MAX) NOT NULL, 
    [Date] DATETIME NULL, 
    [FileCount] BIGINT NULL
)
