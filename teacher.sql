/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [First Name]
      ,[Last Name]
      ,[Subject]
      ,[Username]
      ,[Password]
      ,[Confirm Password]
  FROM [MathAppDB].[dbo].[Teacher]