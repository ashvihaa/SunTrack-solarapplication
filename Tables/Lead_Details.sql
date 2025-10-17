CREATE TABLE [dbo].[Lead_Details]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [LeadId] INT CONSTRAINT fk_LeadDetails_LeadId REFERENCES [Lead](Id) NOT NULL,
    [SiteVisit_Schedule] DATETIME NOT NULL,
    [Sitevisit_Photos] NVARCHAR (100) NOT NULL,
    [Sitevisit_Status] NVARCHAR (100) NOT NULL,
    [Notes] NVARCHAR (MAX)
);
GO