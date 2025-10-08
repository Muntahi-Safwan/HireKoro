CREATE TABLE USER_TYPES (
    UserTypeID INT IDENTITY(1,1) PRIMARY KEY,
    TypeName NVARCHAR(100) NOT NULL
);

CREATE TABLE USERS (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    UserTypeID INT NOT NULL,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Name NVARCHAR(150),
    ProfileImg NVARCHAR(255),
    Description NVARCHAR(MAX),
    HourlyRate FLOAT,
    Skills NVARCHAR(255),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserTypeID) REFERENCES USER_TYPES(UserTypeID)
);

CREATE TABLE PROJECTS (
    ProjectID INT IDENTITY(1,1) PRIMARY KEY,
    ClientID INT NOT NULL,
    FreelancerID INT NOT NULL,
    ProjectStatus NVARCHAR(50),
    Title NVARCHAR(200) NOT NULL,
    ProjectDescription NVARCHAR(MAX),
    StartDate DATETIME,
    ProjectHours FLOAT,
    Cost FLOAT,
    FOREIGN KEY (ClientID) REFERENCES USERS(UserID),
    FOREIGN KEY (FreelancerID) REFERENCES USERS(UserID)
);

CREATE TABLE TASKS (
    TaskID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectID INT NOT NULL,
    Name NVARCHAR(100),
    Status NVARCHAR(50),
    Description NVARCHAR(MAX),
    Deadline DATETIME,
    Priority NVARCHAR(50),
    IsCompleted BIT DEFAULT 0,
    FOREIGN KEY (ProjectID) REFERENCES PROJECTS(ProjectID)
);

INSERT INTO TASKS (ProjectID, Name, Status, Description, Deadline, Priority)
VALUES 
(1, 'In Progress','React Project', 'Setup React project structure', '2025-10-15', 'High'),
(1, 'Completed','Contact Form', 'Implement contact form', '2025-10-20', 'Medium');


CREATE TABLE INVOICES (
    InvoiceID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectID INT NOT NULL,
    Status NVARCHAR(50),
    Amount DECIMAL(10,2),
    IssueDate DATE,
    DueDate DATE,
    FOREIGN KEY (ProjectID) REFERENCES PROJECTS(ProjectID)
);

CREATE TABLE REVIEWS (
    ReviewID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectID INT NOT NULL,
    ReviewerID INT NOT NULL,
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    Comment NVARCHAR(MAX),
    FOREIGN KEY (ProjectID) REFERENCES PROJECTS(ProjectID),
    FOREIGN KEY (ReviewerID) REFERENCES USERS(UserID)
);

CREATE TABLE MESSAGES (
    MessageID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectID INT NOT NULL,
    SenderID INT NOT NULL,
    ReceiverID INT NOT NULL,
    Content NVARCHAR(MAX),
    Timestamp DATETIME DEFAULT GETDATE(),
    SendAt DATETIME,
    SeenAt DATETIME,
    FOREIGN KEY (ProjectID) REFERENCES PROJECTS(ProjectID),
    FOREIGN KEY (SenderID) REFERENCES USERS(UserID),
    FOREIGN KEY (ReceiverID) REFERENCES USERS(UserID)
);

CREATE TABLE ProjectLog (
    ProjectLogID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectID INT NOT NULL,
    Status NVARCHAR(100),
    Comment NVARCHAR(MAX),
    FOREIGN KEY (ProjectID) REFERENCES PROJECTS(ProjectID)
);

CREATE TABLE PaymentLog (
    PaymentLogID INT IDENTITY(1,1) PRIMARY KEY,
    PaymentID INT,
    Status NVARCHAR(100),
    Comment NVARCHAR(MAX)
);
