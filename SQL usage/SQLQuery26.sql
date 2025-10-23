INSERT INTO [dbo].[Lead_Details] (
    LeadId,
    SiteVisit_Schedule,
    Sitevisit_Photos,
    Sitevisit_Status,
    Notes
)
VALUES
(1, DATEADD(day, 3, GETDATE()), 'sitevisit1.jpg', 'Scheduled', 'Initial site visit planned'),
(2, DATEADD(day, 5, GETDATE()), 'sitevisit2.jpg', 'Completed', 'Site evaluation complete'),
(3, DATEADD(day, 7, GETDATE()), 'sitevisit3.jpg', 'Pending', 'Reschedule needed due to unavailability'),
(4, DATEADD(day, 2, GETDATE()), 'sitevisit4.jpg', 'Completed', 'Measurements taken successfully'),
(5, DATEADD(day, 4, GETDATE()), 'sitevisit5.jpg', 'Scheduled', 'Confirmation sent to customer');
