CREATE TABLE [dbo].[Product_Details]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [ItemName] NVARCHAR(100) NOT NULL,
    [SerialNo] NVARCHAR(100) NOT NULL,
    [Brand] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
    [Quantity] INT NOT NULL,
    [QuantityUnits] NVARCHAR(100) NOT NULL,
    [Capacity] INT NOT NULL,
    [CapacityUnits] NVARCHAR(100) NOT NULL,
    [IsActive] BIT NULL,
    [CreatedDate] DATETIME NOT NULL,
    [UpdatedDate] DATETIME NULL,
    [CreatedBy] INT CONSTRAINT fk_ProductDetails_CreatedBy REFERENCES [User](Id) NOT NULL,
    [UpdatedBy] INT CONSTRAINT fk_ProductDetails_UpdatedBy REFERENCES [Lead](Id) NULL
);
GO
