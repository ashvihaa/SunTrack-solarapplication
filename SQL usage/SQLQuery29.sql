INSERT INTO [dbo].[Installation_Status] (
    Customer_Id,
    Project_Id,
    Structure_Mounting,
    Panel_Fixing,
    Inverter_Mounting,
    ACDB_And_DCDB,
    Earthing,
    ACCable,
    DCCable,
    Civil_Works,
    Light_Arrester,
    Net_Meter,
    IsActive,
    CreatedDate,
    UpdatedDate,
    CreatedBy,
    UpdatedBy
)
VALUES
(1, 1, 'Done', 'Done', 'Pending', 'Done', 'Ongoing', 'Done', 'Done', 'Done', 'Pending', 'Not Installed', 1, GETDATE(), NULL, 1, NULL),
(2, 2, 'Done', 'Done', 'Done', 'Done', 'Done', 'Done', 'Done', 'Done', 'Done', 'Installed', 1, GETDATE(), NULL, 2, NULL),
(3, 3, 'Ongoing', 'Done', 'Pending', 'Pending', 'Pending', 'Ongoing', 'Pending', 'Pending', 'Not started', 'Not Installed', 1, GETDATE(), NULL, 3, NULL),
(4, 4, 'Done', 'Done', 'Done', 'Ongoing', 'Pending', 'Done', 'Done', 'Done', 'Ongoing', 'Installed', 1, GETDATE(), NULL, 4, NULL),
(5, 5, 'Pending', 'Pending', 'Pending', 'Pending', 'Pending', 'Pending', 'Pending', 'Pending', 'Pending', 'Pending', 1, GETDATE(), NULL, 5, NULL);
