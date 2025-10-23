INSERT INTO [dbo].[Project] (
    Customer_Id,
    Lead_Id,
    StatusId,
    Project_Name,
    Service_No,
    Category,
    SiteLocation,
    IsActive,
    CreatedDate,
    UpdatedDate,
    CreatedBy,
    UpdatedBy
)
VALUES
(1, 1, 1, 'Solar Rooftop Installation', 1001, 'Residential', 1, 1, GETDATE(), NULL, 1, NULL),
(2, 2, 2, 'Commercial Solar Setup', 1002, 'Commercial', 2, 1, GETDATE(), NULL, 2, NULL),
(3, 3, 1, 'Agricultural Solar Pump', 1003, 'Agriculture', 3, 1, GETDATE(), NULL, 3, NULL),
(4, 4, 3, 'Solar Street Lighting', 1004, 'Public', 4, 1, GETDATE(), NULL, 4, NULL),
(5, 5, 2, 'Off-grid Solar System', 1005, 'Residential', 5, 1, GETDATE(), NULL, 5, NULL);
