INSERT INTO [dbo].[Customer] (
    CustomerName,
    Email_Id,
    IsActive,
    Created_Date,
    Created_By,
    Updated_Date,
    Updated_By
)
VALUES
('SunTrack Solutions', 'contact@suntrack.com', 1, GETDATE(), 1, NULL, NULL),
('Green Energy Ltd', 'info@greenenergy.com', 1, GETDATE(), 1, NULL, NULL),
('Solar Innovations', 'support@solarinnovations.com', 1, GETDATE(), 2, NULL, NULL),
('EcoPower Inc', 'sales@ecopower.com', 1, GETDATE(), 3, NULL, NULL),
('Bright Future Co.', 'service@brightfuture.com', 1, GETDATE(), 4, NULL, NULL);
