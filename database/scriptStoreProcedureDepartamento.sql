USE [AvaliacaoIELDb]
GO
/****** Object:  StoredProcedure [dbo].[uspIncluirDepartamento]    Script Date: 10/04/2022 19:16:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspIncluirDepartamento]
(
  @Codigo int, 
  @NomeDepartamento varchar(50), 
  @NomeResponsavel varchar(80),
  @LoginResponsavel varchar(30),
  @EmailResponsavel varchar(40)
  )
AS

DECLARE @BuscaCodigo INT
SET @BuscaCodigo = (SELECT TOP 1 Codigo FROM  dbo.Departamento WHERE Codigo = @Codigo)

IF (@BuscaCodigo IS NOT NULL)
BEGIN
		UPDATE dbo.Departamento
		SET Codigo = @Codigo,
			NomeDepartamento=@NomeDepartamento, 
			NomeResponsavel=@NomeResponsavel, 
			LoginResponsavel=@LoginResponsavel,
			EmailResponsavel=@EmailResponsavel
		WHERE Codigo = @Codigo
END ELSE BEGIN
		INSERT INTO dbo.Departamento (Codigo,NomeDepartamento, NomeResponsavel, LoginResponsavel, EmailResponsavel )
		VALUES(@Codigo, @NomeDepartamento, @NomeResponsavel, @LoginResponsavel, @EmailResponsavel)
END
GO
