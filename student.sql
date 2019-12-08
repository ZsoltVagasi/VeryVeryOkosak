/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [First Name]
      ,[Last Name]
      ,[Class]
      ,[Year]
      ,[Username]
      ,[Password]
      ,[Confirm Password]
  FROM [MathAppDB].[dbo].[Student]