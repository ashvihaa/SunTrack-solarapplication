INSERT INTO [dbo].[Financial_Status] (
    Customer_Id,
    Project_Id,
    Project_Date,
    Amount,
    Document,
    ApprovedRejected,
    Status,
    Purchase_Invoice,
    IsActive,
    CreatedDate,
    UpdatedDate,
    CreatedBy,
    UpdatedBy
)
VALUES
(1, 1, GETDATE(), 250000.00, 'Invoice_1001.pdf', GETDATE(), 'Approved', 1001, 1, GETDATE(), NULL, 1, NULL),
(2, 2, GETDATE(), 480000.00, 'Invoice_1002.pdf', GETDATE(), 'Pending', 1002, 1, GETDATE(), NULL, 2, NULL),
(3, 3, GETDATE(), 320000.00, 'Invoice_1003.pdf', GETDATE(), 'Rejected', 1003, 1, GETDATE(), NULL, 3, NULL),
(4, 4, GETDATE(), 540000.00, 'Invoice_1004.pdf', GETDATE(), 'Approved', 1004, 1, GETDATE(), NULL, 4, NULL),
(5, 5, GETDATE(), 230000.00, 'Invoice_1005.pdf', GETDATE(), 'Pending', 1005, 1, GETDATE(), NULL, 5, NULL);
