CREATE TABLE [dbo].[Address]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [CustomerId] INT CONSTRAINT fk_Address_CustomerId REFERENCES [Customer](Id) NOT NULL,
    [Address1] NVARCHAR(255) NOT NULL,
    [Address2] NVARCHAR(255) NULL,
    [State] NVARCHAR(50) NOT NULL,
    [Pincode] NVARCHAR(100) NOT NULL
);