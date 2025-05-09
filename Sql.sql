IF DB_ID('Prescription') IS NULL 
	CREATE DATABASE Prescription

USE Prescription;
GO

CREATE TABLE Patient (
	id INT PRIMARY KEY IDENTITY(1,1),
	namePat NVARCHAR(50),
	dob DATETIME,
	gender INT,
	addressPat NVARCHAR(100),
	phone NVARCHAR(10),
	email NVARCHAR(50),
	healthInsuranceId NVARCHAR(15),
	idCard NVARCHAR(12),
	medicalHistory NVARCHAR(100)
)

CREATE TABLE Examination (
	id INT PRIMARY KEY IDENTITY(1,1),
	examinationDate DATETIME,
	doctorName NVARCHAR(50),
	medicalHistory NVARCHAR(100),
	diagnosisName NVARCHAR(100),
	notes NVARCHAR(200),
	patientId INT FOREIGN KEY REFERENCES Patient(id)
)

CREATE TABLE Indication (
	id INT PRIMARY KEY IDENTITY(1,1),
	indicationDate DATETIME,
	indicationType NVARCHAR(20),
	doctorName NVARCHAR(50),
	diagnosisName NVARCHAR(100),
	notes NVARCHAR(200),
	patientId INT FOREIGN KEY REFERENCES Patient(id)
)

CREATE TABLE Medicine (
	id INT PRIMARY KEY IDENTITY(1,1),
	nameMed NVARCHAR(20),
	manufacturer NVARCHAR(50),
	typeMed NVARCHAR(10),
	descriptionMed NVARCHAR(100),
	discountPrice FLOAT,
	price FLOAT,
	quantity INT,
	manufacturingDate DATETIME,
	expiryDate DATETIME,
	importDate DATETIME,
	usage NVARCHAR(50),
	dosage NVARCHAR(50)
)


CREATE TABLE Prescription (
	id INT PRIMARY KEY IDENTITY(1,1),
	medicineId INT FOREIGN KEY REFERENCES Medicine(id),
	quantity INT,
	daysUse INT,
	morning INT,
	noon INT,
	evening INT
)

CREATE TABLE TechnicalCatalog (
	id INT PRIMARY KEY IDENTITY(1,1),
	typeTech NVARCHAR(10),
	nameTech NVARCHAR(50),
	price FLOAT,
	discountPrice FLOAT,
	descriptionTech NVARCHAR(100)
)

CREATE TABLE Users (
	id INT PRIMARY KEY IDENTITY(1,1),
	username NVARCHAR(20),
	password NVARCHAR(200),
	displayName NVARCHAR(20),
	email NVARCHAR(50),
	authority_level TINYINT DEFAULT 1
)


INSERT INTO Users (username, password, displayName, email, authority_level) VALUES
('admin', '2', N'Nguyen Van A', 'admin1@hospital.com', 3)

INSERT INTO Users (username, password, displayName, email, authority_level) VALUES
('aaa', '2', N'Nguyen Van B', 'aaaa@hospital.com', 1)

INSERT INTO Patient (namePat, dob, gender, addressPat, phone, email, healthInsuranceId, idCard, medicalHistory) VALUES
(N'Nguyen Van An', '1990-05-15', 0, N'123 Le Loi, Hanoi', '0912345678', 'an.nguyen@gmail.com', 'BH123456789', '123456789012', N'High blood pressure'),
(N'Tran Thi Bich', '1985-11-20', 1, N'456 Tran Phu, HCMC', '0987654321', 'bich.tran@gmail.com', 'BH987654321', '987654321098', N'Diabetes'),
(N'Le Minh Chau', '1995-03-10', 1, N'789 Nguyen Trai, Da Nang', '0935123456', 'chau.le@gmail.com', 'BH456789123', '456789123456', N'No significant history'),
(N'Pham Quoc Dat', '1978-07-25', 0, N'101 Hai Ba Trung, Hanoi', '0909876543', 'dat.pham@gmail.com', 'BH321654987', '321654987654', N'Asthma'),
(N'Hoang Thi Em', '1992-09-12', 1, N'321 Pham Van Dong, Hue', '0923456789', 'em.hoang@gmail.com', NULL, '147258369147', N'Allergic rhinitis');

INSERT INTO Medicine (nameMed, manufacturer, typeMed, descriptionMed, discountPrice, price, quantity, manufacturingDate, expiryDate, importDate, usage, dosage) VALUES
(N'Paracetamol', N'PharmaCorp', N'Tablet', N'Pain reliever and fever reducer', 4500, 5000, 1000, '2024-01-10', '2026-01-10', '2024-02-01', N'Oral', N'500mg, 1-2 tablets every 6 hours'),
(N'Amoxicillin', N'MediPharm', N'Capsule', N'Antibiotic for bacterial infections', 9000, 10000, 500, '2024-03-15', '2026-03-15', '2024-04-01', N'Oral', N'500mg, 1 capsule every 8 hours'),
(N'Omeprazole', N'HealthCare', N'Capsule', N'Treats acid reflux and ulcers', 13500, 15000, 300, '2024-02-20', '2026-02-20', '2024-03-10', N'Oral', N'20mg, 1 capsule daily before meal'),
(N'Aspirin', N'GlobalMed', N'Tablet', N'Pain relief and anti-inflammatory', 2700, 3000, 2000, '2024-05-01', '2026-05-01', '2024-06-01', N'Oral', N'100mg, 1 tablet daily'),
(N'Ibuprofen', N'BioMed', N'Tablet', N'Pain relief and anti-inflammatory', 6300, 7000, 800, '2024-04-10', '2026-04-10', '2024-05-05', N'Oral', N'400mg, 1 tablet every 8 hours');


INSERT INTO Prescription (medicineId, quantity, daysUse, morning, noon, evening) VALUES
(1, 20, 10, 1, 1, 0),
(2, 15, 5, 1, 0, 1),
(3, 10, 10, 1, 0, 0), 
(4, 30, 30, 0, 0, 1), 
(5, 15, 5, 1, 1, 1);  

INSERT INTO Examination (examinationDate, doctorName, medicalHistory, diagnosisName, notes, patientId) VALUES
('2025-04-01 09:00:00', N'Tran Thi B', N'High blood pressure', N'Hypertension', N'Advise lifestyle changes and medication', 1),
('2025-04-02 10:30:00', N'Le Van E', N'Diabetes', N'Type 2 Diabetes', N'Monitor blood sugar regularly', 2),
('2025-04-03 14:00:00', N'Nguyen Thi F', N'No significant history', N'Common cold', N'Rest and hydration recommended', 3),
('2025-04-04 11:15:00', N'Tran Thi B', N'Asthma', N'Asthma exacerbation', N'Prescribe inhaler and monitor symptoms', 4),
('2025-04-05 08:45:00', N'Le Van E', N'Allergic rhinitis', N'Seasonal allergies', N'Prescribe antihistamine', 5);

INSERT INTO Indication (indicationDate, indicationType, doctorName, diagnosisName, notes, patientId) VALUES
('2025-04-01 09:30:00', N'X-ray', N'Tran Thi B', N'Hypertension', N'Check for heart enlargement', 1),
('2025-04-02 11:00:00', N'Blood test', N'Le Van E', N'Type 2 Diabetes', N'Check HbA1c levels', 2),
('2025-04-03 14:30:00', N'Ultrasound', N'Nguyen Thi F', N'Common cold', N'Rule out sinus infection', 3),
('2025-04-04 11:45:00', N'Spirometry', N'Tran Thi B', N'Asthma exacerbation', N'Assess lung function', 4),
('2025-04-05 09:15:00', N'Allergy test', N'Le Van E', N'Seasonal allergies', N'Identify specific allergens', 5);

INSERT INTO TechnicalCatalog (typeTech, nameTech, price, discountPrice, descriptionTech) VALUES
(N'Imaging', N'X-ray', 500000, 450000, N'Chest X-ray for diagnostic purposes'),
(N'Lab', N'Blood test', 200000, 180000, N'Complete blood count and glucose test'),
(N'Imaging', N'Ultrasound', 700000, 650000, N'Abdominal ultrasound for organ assessment'),
(N'Test', N'Spirometry', 300000, 270000, N'Lung function test for asthma patients'),
(N'Test', N'Allergy test', 400000, 360000, N'Skin prick test for allergen identification');


GO

CREATE PROC uspAddPatient
	@namePat NVARCHAR(50),
	@dob DATETIME,
	@gender INT,
	@addressPat NVARCHAR(100),
	@phone NVARCHAR(10),
	@healthInsuranceId NVARCHAR(15),
	@idCard NVARCHAR(12),
	@email NVARCHAR(50),
	@medicalHistory NVARCHAR(100)
AS
	BEGIN 
		INSERT INTO Patient VALUES(@namePat, @dob, @gender, @addressPat, @phone, @email, @healthInsuranceId, @idCard, @medicalHistory)
	END;

GO

CREATE PROC uspAddMedicine
	@nameMed NVARCHAR(20),
	@manufacturer NVARCHAR(50),
	@typeMed NVARCHAR(10),
	@descriptionMed NVARCHAR(100),
	@discountPrice FLOAT,
	@price FLOAT,
	@quantity INT,
	@manufacturingDate DATETIME,
	@expiryDate DATETIME,
	@importDate DATETIME,
	@usage NVARCHAR(50),
	@dosage NVARCHAR(50)
AS
	BEGIN
		INSERT INTO Medicine VALUES (@nameMed, @manufacturer, @typeMed, @descriptionMed, @discountPrice, @price, @quantity, @manufacturingDate, @expiryDate, @importDate, @usage, @dosage)
	END;

GO

CREATE PROC uspAddTech
	@typeTech NVARCHAR(10),
	@nameTech NVARCHAR(50),
	@price FLOAT,
	@discountPrice FLOAT,
	@descriptionTech NVARCHAR(100)
AS
	BEGIN
		INSERT INTO TechnicalCatalog VALUES (@typeTech, @nameTech, @price, @discountPrice, @descriptionTech)
	END;
GO

CREATE PROC uspAddExam
	@examinationDate DATETIME,
	@doctorName NVARCHAR(50),
	@medicalHistory NVARCHAR(100),
	@diagnosisName NVARCHAR(100),
	@notes NVARCHAR(200),
	@patientId INT
AS
	BEGIN
		INSERT INTO Examination VALUES(@examinationDate, @doctorName, @medicalHistory, @diagnosisName, @notes, @patientId)
	END;

GO

CREATE PROC uspAddIndication 
	@indicationDate DATETIME,
	@indicationType NVARCHAR(20),
	@doctorName NVARCHAR(50),
	@diagnosisName NVARCHAR(100),
	@notes NVARCHAR(200),
	@patientId INT
AS
	BEGIN
		INSERT INTO Indication VALUES (@indicationDate, @indicationType, @doctorName, @diagnosisName, @notes, @patientId)
	END;
GO

CREATE PROC uspUpdatePatient
	@id INT,
    @namePat NVARCHAR(50),
    @dob DATETIME,
    @gender INT,
    @addressPat NVARCHAR(100),
	@email NVARCHAR(50),
    @phone NVARCHAR(10),
    @idCard NVARCHAR(12),
    @medicalHistory NVARCHAR(100)
AS
BEGIN
    UPDATE Patient
    SET 
        namePat = @namePat,
        dob = @dob,
        gender = @gender,
        addressPat = @addressPat,
        phone = @phone,
		email = @email,
        idCard = @idCard,
        medicalHistory = @medicalHistory
    WHERE id = @id;
END;

GO
CREATE PROC uspUpdateMedicine
	@id INT,
	@nameMed NVARCHAR(20),
	@manufacturer NVARCHAR(50),
	@typeMed NVARCHAR(10),
	@descriptionMed NVARCHAR(100),
	@discountPrice FLOAT,
	@price FLOAT,
	@quantity INT,
	@manufacturingDate DATETIME,
	@expiryDate DATETIME,
	@importDate DATETIME,
	@usage NVARCHAR(50),
	@dosage NVARCHAR(50)
AS 
	BEGIN
		UPDATE Medicine
		SET 
			nameMed = @nameMed,
			manufacturer = @manufacturer,
			typeMed = @typeMed,
			descriptionMed = @descriptionMed,
			discountPrice = @discountPrice,
			price = @price,
			quantity = @quantity,
			manufacturingDate = @manufacturingDate,
			expiryDate = @expiryDate,
			importDate = @importDate,
			usage = @usage,
			dosage = @dosage
		WHERE id = @id
	END;

GO

CREATE PROC uspDeletePatient
	@id INT
AS 
BEGIN
	DELETE FROM Examination WHERE patientId = @id;
	DELETE FROM Indication WHERE patientId = @id;
	DELETE FROM Patient WHERE id = @id;
END;

ALTER TRIGGER createNewUser
ON USERS
FOR INSERT, UPDATE
AS
BEGIN
	SELECT username FROM Users
	IF EXISTS (SELECT 1 FROM inserted WHERE username IN (SELECT username FROM Users WHERE inserted.id <> Users.id))
	BEGIN
		RAISERROR('Username already exists', 16, 1);
		Rollback Transaction;
	END
END