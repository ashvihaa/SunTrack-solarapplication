CREATE TABLE [dbo].[Customer]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [CustomerName] NVARCHAR(100) NOT NULL,
    [Email_Id] NVARCHAR(100) NOT NULL,
    [IsActive] BIT NOT NULL,
    [Created_Date] DATETIME NOT NULL,
    [Created_By] INT CONSTRAINT fk_Customer_CreatedBy REFERENCES [User](Id) NOT NULL,
    [Updated_Date] DATETIME NULL,
    [Updated_By] INT CONSTRAINT fk_Customer_UpdatedBy REFERENCES [User](Id) NULL
);
GO
