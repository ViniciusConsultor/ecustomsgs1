USE [dbEcustoms]
GO

/****** Object:  View [dbo].[ViewDeclarationManagement]    Script Date: 08/22/2012 08:28:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewDeclarationManagement]
AS
SELECT     DeclarationID, Number, CustomsCode, PageNumbers, DateHandover, Type, CompanyName, CreatedDate, PersonReceiveSecond, DateHandoverSecond, 
                      PersonReceive, PersonHandoverSecondID, PersonHandoverID, RegisterDate, DateReturn
FROM         dbo.tblDeclaration

GO
