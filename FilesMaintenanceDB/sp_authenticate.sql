CREATE PROCEDURE [dbo].[sp_authenticate]
	@Option int = 0,
	@UserName nvarchar(50),
	@Password nvarchar(50)
	
AS
	
--Option = 1: Crear usuario
if @Option = 1
Begin
	insert into Usuarios
	(UserName,Password)
	values(@UserName,PWDENCRYPT(@Password))
End

--Option=2:Login
if @Option = 2
Begin
	Select count(*) from
	Usuarios
	Where UserName = @UserName
	and PWDCOMPARE(@Password,Password) = 1
End
