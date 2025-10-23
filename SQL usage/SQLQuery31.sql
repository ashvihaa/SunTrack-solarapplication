INSERT INTO [dbo].[Product_Details] (
    ItemName,
    SerialNo,
    Brand,
    Description,
    Quantity,
    QuantityUnits,
    Capacity,
    CapacityUnits,
    IsActive,
    CreatedDate,
    UpdatedDate,
    CreatedBy,
    UpdatedBy
)
VALUES
('Solar Panel', 'SN1001', 'Luminous', 'High efficiency monocrystalline panel', 50, 'Pieces', 335, 'Watts', 1, GETDATE(), NULL, 1, NULL),
('Inverter', 'SN1002', 'Microtek', '5KW hybrid inverter', 20, 'Units', 5000, 'Watts', 1, GETDATE(), NULL, 2, NULL),
('Battery', 'SN1003', 'Exide', '150 AH tubular battery', 30, 'Units', 150, 'AH', 1, GETDATE(), NULL, 3, NULL),
('Mounting Structure', 'SN1004', 'SolarTech', 'Aluminum mounting frames', 40, 'Sets', 0, 'N/A', 1, GETDATE(), NULL, 4, NULL),
('DC Cable', 'SN1005', 'Finolex', 'Copper DC wiring cable', 1000, 'Meters', 0, 'N/A', 1, GETDATE(), NULL, 5, NULL);
