CREATE TABLE [dbo].[Lead]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [UserId] INT CONSTRAINT fk_Lead_UserId REFERENCES [User](Id) NOT NULL,
    [CustomerId] INT CONSTRAINT fk_Lead_CustomerId REFERENCES [Customer](Id) NOT NULL,
    [Status_Id] INT CONSTRAINT fk_Lead_StatusId REFERENCES [Status](Id) NOT NULL,
    [LeadNo] NVARCHAR(100) NOT NULL,
    [Source] NVARCHAR(100) NOT NULL,
    [Follow_Up_Date] DATETIME NOT NULL,
    [IsActive] BIT NOT NULL,
    [Created_Date] DATETIME NOT NULL,
    [Created_By] INT CONSTRAINT fk_Lead_CreatedBy REFERENCES [User](Id) NOT NULL,
    [Updated_Date] DATETIME NULL,
    [Updated_By] INT CONSTRAINT fk_Lead_UpdatedBy REFERENCES [User](Id) NULL
);
