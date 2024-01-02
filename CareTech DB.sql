create database CareTech;
use CareTech;
CREATE TABLE login (
email VARCHAR(50) Not NULL,
Password_ VARCHAR(50) Not NULL
);
CREATE TABLE admin (
    UserID INT AUTO_INCREMENT PRIMARY KEY,
    UserRole VARCHAR(50),
    Username VARCHAR(50),
    UserDOB DATE,
    UserAddress VARCHAR(100)
);
CREATE TABLE Queue (
    QueueID INT AUTO_INCREMENT PRIMARY KEY,
    Date DATE,
    TotalCount INT DEFAULT 0
);
CREATE TABLE PatientLog (
    LogID INT AUTO_INCREMENT PRIMARY KEY,
    QueueID INT,
    EntryTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (QueueID) REFERENCES Queue(QueueID)
);
CREATE TABLE Resources (
    ResourceID INT AUTO_INCREMENT PRIMARY KEY,
    ResourceType VARCHAR(50),
    ResourceDetails TEXT
);
CREATE TABLE role (
    RoleID INT AUTO_INCREMENT PRIMARY KEY,
    RoleTitle VARCHAR(50),
    RoleDescription VARCHAR(255),
    AdminUserID INT,
    FOREIGN KEY (AdminUserID) REFERENCES admin(UserID)
);
CREATE TABLE AccessRequests (
    RequestID INT AUTO_INCREMENT PRIMARY KEY,
    UserID INT,
    RequestedResourceID INT,
    RequestStatus ENUM('Pending', 'Approved', 'Denied'),
    FOREIGN KEY (UserID) REFERENCES admin(UserID),
    FOREIGN KEY (RequestedResourceID) REFERENCES Resources(ResourceID)
);
CREATE TABLE Permissions (
    PermissionID INT AUTO_INCREMENT PRIMARY KEY,
    UserID INT,
    ResourceID INT,
    CanView BOOLEAN,
    CanEdit BOOLEAN,
    FOREIGN KEY (UserID) REFERENCES admin(UserID),
    FOREIGN KEY (ResourceID) REFERENCES Resources(ResourceID)
);
CREATE TABLE Doctor (
doctor_id INT AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    specialization VARCHAR(100),
    email VARCHAR(50),
    Password_ VARCHAR(50),
    office_address TEXT,
    joining_date DATE

) ;
create table Patient(
PatientID INT PRIMARY KEY AUTO_INCREMENT,
FirstName VARCHAR(50),
LastName VARCHAR(50),
DateOfBirth DATE,
Gender ENUM('Male', 'Female'),
Address VARCHAR(255),
PhoneNumber VARCHAR(15),
Email VARCHAR(100),
InsuranceID VARCHAR(20),
EmergencyContact VARCHAR(100),
BloodType VARCHAR(5),
Allergies TEXT,
MedicalHistory TEXT,
CurrentMedications TEXT,
LastVisitDate DATE,
NextAppointment DATETIME
);

create table Appointment(
AppointmentID INT PRIMARY KEY AUTO_INCREMENT,
PatientID INT,
AppointmentDate DATETIME,
AppointmentType VARCHAR(50),
DoctorID INT,
Notes TEXT,

FOREIGN KEY (PatientID) REFERENCES Patient(PatientID),
FOREIGN KEY (DoctorID) REFERENCES Doctor(doctor_id)
);
create table Nurse(
nurseFName varchar (100),
nurseSName varchar (100),
nurseID int auto_increment,
PermissionID int,
nurseMobile varchar (30),
nurseAddress text,
nurseEmail varchar (50),
nurseUsername varchar (100),
nursePassword varchar (100),
primary key (nurseID),
FOREIGN KEY (PermissionID) REFERENCES Permissions(PermissionID)
);
create table Receptionist(
receptionistFName varchar (100),
receptionistSName varchar (100),
receptionistID int auto_increment,
PermissionID int,
receptionistMobile varchar (30),
receptionistAddress text,
receptionistEmail varchar (50),
receptionistUsername varchar (100),
receptionistPassword varchar (100),
primary key (receptionistID),
FOREIGN KEY (PermissionID) REFERENCES Permissions(PermissionID)
);
