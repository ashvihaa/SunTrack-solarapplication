INSERT INTO [dbo].[User] (
    UserName,
    Password,
    FirstName,
    LastName,
    Email,
    PhoneNumber,
    Date_Of_Birth,
    Gender
)
VALUES
('admin', 'Admin@123', 'Ravi', 'Kumar', 'ravi@suntrack.com', '9876543210', '1990-01-01', 'Male'),
('manager', 'Manager@123', 'Divya', 'Sharma', 'divya@suntrack.com', '9786543211', '1988-03-12', 'Female'),
('technician1', 'Tech@123', 'Ajay', 'Patel', 'ajay@suntrack.com', '9658741230', '1993-05-23', 'Male'),
('technician2', 'Tech@124', 'Maya', 'Reddy', 'maya@suntrack.com', '9648756321', '1995-08-30', 'Female'),
('sales', 'Sales@123', 'Kiran', 'Nair', 'kiran@suntrack.com', '9871234567', '1992-07-14', 'Male');
