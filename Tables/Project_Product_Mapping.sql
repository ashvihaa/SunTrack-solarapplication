CREATE TABLE [dbo].[ProjectProductMapping]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [ProjectId] INT CONSTRAINT fk_ProjectProductMapping_ProjectId REFERENCES [Project](Id) NOT NULL,
    [ProductId] INT CONSTRAINT fk_ProjectProductMapping_ProductId REFERENCES [Product_Details](Id) NOT NULL
);
