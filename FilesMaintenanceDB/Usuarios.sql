CREATE TABLE [dbo].[Usuarios]
(
	[Id] INT NOT NULL PRIMARY KEy identity,
    [UserName] NVARCHAR(50) NOT NULL, 
    [Password] VARBINARY(MAX) NULL, 
    [IsActive] BIT NULL DEFAULT 1
)

GO

CREATE UNIQUE INDEX  [IX_Usuarios_UserName] ON [dbo].[Usuarios] ([UserName]) 
