CREATE DATABASE pruebapanda

CREATE TABLE candidates (
    IDCANDIDATE INT PRIMARY KEY IDENTITY(1,1),
    NAME VARCHAR(50) NOT NULL,
    SURNAME VARCHAR(150) NOT NULL,
    BIRTHDATE DATETIME NOT NULL,
    EMAIL VARCHAR(250) NOT NULL,
    INSERTDATE DATETIME NOT NULL,
    MODIFYDATE DATETIME NULL
);

CREATE TABLE candidateexperience (
    IDCANDIDATEEXPERIENCE INT PRIMARY KEY IDENTITY(1,1),
    IDCANDIDATE INT NOT NULL,
    COMPANY VARCHAR(100) NOT NULL,
    JOB VARCHAR(100) NOT NULL,
    DESCRIPTION VARCHAR(4000) NOT NULL,
    SALARY NUMERIC(18, 2) NOT NULL,
    BEGINDATE DATETIME NOT NULL,
    ENDDATE DATETIME NULL,
    INSERTDATE DATETIME NOT NULL,
    MODIFYDATE DATETIME NULL
);

ALTER TABLE candidateexperience  ADD  CONSTRAINT 
FK_candidateexperience_candidates FOREIGN KEY(IDCANDIDATE)
REFERENCES candidates(IDCANDIDATE)


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCandidate]
@id_candidate AS INT
AS
BEGIN
  Delete candidates
 WHERE IDCANDIDATE = @id_candidate
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCandidateExperience]    Script Date: 18/10/2023 11:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCandidateExperience]
 @idcandidateexperience AS INT
AS
BEGIN
 DELETE candidateexperience WHERE IDCANDIDATEEXPERIENCE = @idcandidateexperience
END
GO
/****** Object:  StoredProcedure [dbo].[InsertCandidate]    Script Date: 18/10/2023 11:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertCandidate]
@id_candidate AS INT,
@name AS VARCHAR(50),
@surname AS VARCHAR(150),
@birthdate AS DATETIME,
@email AS VARCHAR(250)
AS
BEGIN
 INSERT INTO [dbo].[candidates]
           ([NAME]
           ,[SURNAME]
           ,[BIRTHDATE]
           ,[EMAIL]
           ,[INSERTDATE]
          )
     VALUES(@name,@surname,@birthdate,@email,GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[InsertCandidateExperience]    Script Date: 18/10/2023 11:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertCandidateExperience] 

@idcandidateexperience as int,
@idcandidate as int,
@company as varchar(100),
@job as varchar(100),
@description as varchar(4000),
@salary as numeric(18,2),
@begindate as datetime,
@enddate as datetime

AS
BEGIN
	Insert Into candidateexperience
	(IDCANDIDATE,COMPANY,JOB,
	DESCRIPTION,SALARY,BEGINDATE,
	ENDDATE,INSERTDATE)
	values(@idcandidate,
	@company,@job,@description,@salary,@begindate,
	@enddate,GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[ModifyCandidate]    Script Date: 18/10/2023 11:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModifyCandidate]
@id_candidate AS INT,
@name AS VARCHAR(50),
@surname AS VARCHAR(150),
@birthdate AS DATETIME,
@email AS VARCHAR(250)
AS
BEGIN
 UPDATE [dbo].[candidates] SET
           [NAME] = @name
           ,[SURNAME] = @surname
           ,[BIRTHDATE] = @birthdate
           ,[EMAIL] = @email
           ,[MODIFYDATE] = GETDATE()
 WHERE IDCANDIDATE = @id_candidate
END
GO
/****** Object:  StoredProcedure [dbo].[ModifyCandidateExpreience]    Script Date: 18/10/2023 11:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModifyCandidateExpreience] 

@idcandidateexperience as int,
@idcandidate as int,
@company as varchar(100),
@job as varchar(100),
@description as varchar(4000),
@salary as numeric(18,2),
@begindate as datetime,
@enddate as datetime

AS
BEGIN
update candidateexperience 
set 
IDCANDIDATE = @idcandidate,
COMPANY = @company ,
JOB = @job ,
DESCRIPTION = @description ,
SALARY = @salary ,
BEGINDATE = @begindate ,
ENDDATE = @enddate,
MODIFYDATE = GETDATE()

Where IDCANDIDATEEXPERIENCE = @idcandidateexperience
END
GO
/****** Object:  StoredProcedure [dbo].[read_candidate]    Script Date: 18/10/2023 11:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[read_candidate]

AS
BEGIN
  SELECT * FROM candidates
END
GO
/****** Object:  StoredProcedure [dbo].[read_candidateExperience]    Script Date: 18/10/2023 11:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[read_candidateExperience]

AS
BEGIN
 SELECT * FROM candidateexperience
END
GO
/****** Object:  StoredProcedure [dbo].[SeacrhCandidateExperience]    Script Date: 18/10/2023 11:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SeacrhCandidateExperience]
 @idcandidateexperience AS INT
AS
BEGIN
 SELECT * FROM candidateexperience WHERE IDCANDIDATEEXPERIENCE = @idcandidateexperience
END
GO
/****** Object:  StoredProcedure [dbo].[SearchCandidate]    Script Date: 18/10/2023 11:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SearchCandidate]
@id_candidate AS INT
AS
BEGIN
  SELECT * FROM candidates
 WHERE IDCANDIDATE = @id_candidate
END
GO

