Patient Information System
Overview
The Patient Information System is a web-based application built with ASP.NET Razor Pages, ADO.NET, and Bootstrap. It helps manage patient records efficiently, allowing users to search, add, edit, and soft-delete patient entries.
Key Features
•	Patient Management – Add, edit, search, and soft-delete patient records.
•	Message Notifications – Success and error messages appear as toast alerts.
•	Soft Delete – Patients are marked as deleted instead of being permanently removed.
Technologies Used
•	ASP.NET Razor Pages, C#, ADO.NET – Backend development and database management.
•	SQL Server – Database storage.
•	Bootstrap – Responsive design.
•	SweetAlert2 – User-friendly notifications.
Installation & Setup
1.	Prerequisites – Install the following:
o	.NET 8 SDK
o	SQL Server
o	Visual Studio Code
2.	Clone the Repository
git clone https://github.com/aymanM05/PatientInfoSystem.git  
cd PatientInfoSystem  
3.	Configure the Database
o	Open appsettings.json and update the database connection string:
"ConnectionStrings": {
  "DefaultConnection":"Server=DESKTOP-3PEF1B9\\MSQLSVR16; Database=patient_db;TrustServerCertificate=True;Trusted_Connection=True;"
}
o	Create SQL Database
o	DB NAME: patient_db
o	TABLE Script:
CREATE TABLE patient_db.dbo.tbl_Patient (
  Id INT IDENTITY
 ,FirstName NVARCHAR(100) NOT NULL
 ,MiddleName NVARCHAR(100) NULL
 ,LastName NVARCHAR(100) NOT NULL
 ,Suffix NVARCHAR(10) NULL DEFAULT ('N/A')
 ,Gender NVARCHAR(10) NOT NULL
 ,Birthday DATE NOT NULL
 ,ContactNo NVARCHAR(15) NULL
 ,Address NVARCHAR(255) NULL
 ,DateOfConsultation DATE NOT NULL
 ,ChiefComplaint NVARCHAR(255) NULL
 ,PurposeOfVisit NVARCHAR(255) NULL
 ,IsDeleted BIT NULL DEFAULT (0)
 ,PRIMARY KEY CLUSTERED (Id)
) ON [PRIMARY]
GO
4.	Run the Application
o	Start the application:
dotnet run  
o	Open http://localhost:5130 in your browser.
Usage Guide
•	Add a Patient – Click "Add Patient", fill out the form, and submit.
•	Edit a Patient – Click "Edit", update details, and save changes.
•	Search for a Patient – Enter a keyword in the search box, then click "Search".
•	Soft Delete – Click the trash icon, confirm deletion, and the record will be hidden.

