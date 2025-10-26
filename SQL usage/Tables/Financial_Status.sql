CREATE TABLE [dbo].[Financial_Status]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Customer_Id] INT CONSTRAINT fk_FinancialStatus_CustomerId REFERENCES [Customer](Id) NOT NULL,
    [Project_Id] INT CONSTRAINT fk_FinancialStatus_ProjectId REFERENCES [Project](Id) NOT NULL,
    [Project_Date] DATETIME NOT NULL,
    [Amount] DECIMAL(18,2) NOT NULL,
    [Document] NVARCHAR(MAX) NOT NULL,
    [ApprovedRejected] DATETIME NOT NULL,
    [Status] NVARCHAR(MAX) NOT NULL,
    [Purchase_Invoice] INT NOT NULL,
    [IsActive] BIT NOT NULL,
    [CreatedDate] DATETIME NOT NULL,
    [UpdatedDate] DATETIME NULL,
    [CreatedBy] INT CONSTRAINT fk_FinancialStatus_CreatedBy REFERENCES [User](Id) NOT NULL,
    [UpdatedBy] INT CONSTRAINT fk_FinancialStatus_UpdatedBy REFERENCES [User](Id) NULL
);
