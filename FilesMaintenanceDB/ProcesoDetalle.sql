CREATE TABLE [dbo].[ProcesoDetalle]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	File_Name nvarchar(MAX),
	IdProceso int ,
	Weight_file BIGINT,
	Extension nchar(5),
	DeleteDate datetime
)
