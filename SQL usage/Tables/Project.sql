CREATE TABLE [dbo].[Project]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Customer_Id] INT CONSTRAINT fk_Project_CustomerId REFERENCES [Customer](Id) NOT NULL,
    [Lead_Id] INT CONSTRAINT fk_Project_LeadId REFERENCES [Lead](Id) NOT NULL,
    [StatusId] INT CONSTRAINT fk_Project_StatusId REFERENCES [Status](Id) NOT NULL,
    [Project_Name] NVARCHAR(100) NOT NULL,
    [Service_No] INT NOT NULL,
    [Category] NVARCHAR(100) NULL,
    [SiteLocation] INT CONSTRAINT fk_Project_SiteLocation REFERENCES [Address](Id) NOT NULL,
    [IsActive] BIT NOT NULL,
    [CreatedDate] DATETIME NOT NULL,
    [UpdatedDate] DATETIME NULL,
    [CreatedBy] INT CONSTRAINT fk_Project_CreatedBy REFERENCES [User](Id) NOT NULL,
    [UpdatedBy] INT CONSTRAINT fk_Project_UpdatedBy REFERENCES [User](Id) NULL
);
