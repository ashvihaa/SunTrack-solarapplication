INSERT INTO [dbo].[Lead] (
    ResposibleId,
    CustomerId,
    Status_Id,
    LeadNo,
    Source,
    Follow_Up_Date,
    IsActive,
    Created_Date,
    Created_By,
    Updated_Date,
    Updated_By
)
VALUES
(1, 1, 1, 'LD001', 'Website', DATEADD(day, 5, GETDATE()), 1, GETDATE(), 1, NULL, NULL),
(2, 2, 2, 'LD002', 'Walk-in', DATEADD(day, 3, GETDATE()), 1, GETDATE(), 2, NULL, NULL),
(3, 3, 3, 'LD003', 'Referral', DATEADD(day, 7, GETDATE()), 1, GETDATE(), 3, NULL, NULL),
(4, 4, 1, 'LD004', 'Advertisement', DATEADD(day, 4, GETDATE()), 1, GETDATE(), 4, NULL, NULL),
(5, 5, 2, 'LD005', 'Cold Call', DATEADD(day, 6, GETDATE()), 1, GETDATE(), 5, NULL, NULL);
