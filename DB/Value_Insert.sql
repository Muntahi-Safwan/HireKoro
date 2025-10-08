-- USER TYPES
INSERT INTO USER_TYPES (TypeName)
VALUES ('Client'), ('Freelancer'), ('Admin');

-- USERS
INSERT INTO USERS (UserTypeID, Username, Email, PasswordHash, Name, HourlyRate, Skills)
VALUES 
(1, 'client_john', 'john@example.com', 'hashed_pw1', 'John Doe', NULL, 'Project Management'),
(2, 'freelancer_amy', 'amy@example.com', 'hashed_pw2', 'Amy Smith', 25.00, 'React, Node.js'),
(2, 'freelancer_tom', 'tom@example.com', 'hashed_pw3', 'Tom Lee', 30.00, 'UI/UX Design');

-- PROJECTS
INSERT INTO PROJECTS (ClientID, FreelancerID, ProjectStatus, Title, ProjectDescription, StartDate, ProjectHours, Cost)
VALUES 
(1, 2, 'In Progress', 'Portfolio Website', 'Build a responsive portfolio site', GETDATE(), 50, 1250.00),
(1, 3, 'Completed', 'Mobile App UI Design', 'Design the UI for a new app', GETDATE(), 40, 1200.00);

-- TASKS
INSERT INTO TASKS (ProjectID, Name, Status, Description, Deadline, Priority)
VALUES 
(1, 'In Progress','React Project', 'Setup React project structure', '2025-10-15', 'High'),
(1, 'Completed','Contact Form', 'Implement contact form', '2025-10-20', 'Medium');

-- INVOICES
INSERT INTO INVOICES (ProjectID, Status, Amount, IssueDate, DueDate)
VALUES 
(1, 'Pending', 1250.00, GETDATE(), DATEADD(DAY, 7, GETDATE())),
(2, 'Paid', 1200.00, '2025-09-15', '2025-09-22');

-- REVIEWS
INSERT INTO REVIEWS (ProjectID, ReviewerID, Rating, Comment)
VALUES 
(2, 1, 5, 'Excellent work! Delivered before deadline.');

-- MESSAGES
INSERT INTO MESSAGES (ProjectID, SenderID, ReceiverID, Content, SendAt)
VALUES 
(1, 1, 2, 'Hi Amy, how’s the project going?', GETDATE()),
(1, 2, 1, 'Hi John, I’m almost done with the homepage!', GETDATE());

-- PROJECT LOG
INSERT INTO ProjectLog (ProjectID, Status, Comment)
VALUES 
(1, 'In Progress', 'Initial setup completed.'),
(2, 'Completed', 'Project successfully delivered.');

-- PAYMENT LOG
INSERT INTO PaymentLog (PaymentID, Status, Comment)
VALUES 
(1, 'Success', 'Payment processed via PayPal'),
(2, 'Pending', 'Awaiting payment confirmation');
