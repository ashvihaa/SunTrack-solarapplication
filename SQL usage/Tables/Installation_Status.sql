CREATE TABLE [dbo].[Installation_Status]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Customer_Id] INT CONSTRAINT fk_InstallationStatus_CustomerId REFERENCES [Customer](Id) NOT NULL,
    [Project_Id] INT CONSTRAINT fk_InstallationStatus_ProjectId REFERENCES [Project](Id) NOT NULL,
    [Structure_Mounting] NVARCHAR(50) NULL,
    [Panel_Fixing] NVARCHAR(50) NULL,
    [Inverter_Mounting] NVARCHAR(50) NULL,
    [ACDB_And_DCDB] NVARCHAR(50) NULL,
    [Earthing] NVARCHAR(50) NULL,
    [ACCable] NVARCHAR(50) NULL,
    [DCCable] NVARCHAR(50) NULL,
    [Civil_Works] NVARCHAR(50) NULL,
    [Light_Arrester] NVARCHAR(50) NULL,
    [Net_Meter] NVARCHAR(50) NULL,
    [IsActive] BIT NOT NULL,
    [CreatedDate] DATETIME NOT NULL,
    [UpdatedDate] DATETIME NULL,
    [CreatedBy] INT CONSTRAINT fk_InstallationStatus_CreatedBy REFERENCES [User](Id) NOT NULL,
    [UpdatedBy] INT CONSTRAINT fk_InstallationStatus_UpdatedBy REFERENCES [User](Id) NULL
);