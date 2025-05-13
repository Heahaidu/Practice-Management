IF DB_ID('Prescription') IS NULL 
	CREATE DATABASE Prescription

USE Prescription;
GO

-- Tạo các bảng (giữ nguyên)
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
	medicalHistory NVARCHAR(100),
	createDate DATETIME
)

CREATE TABLE Users (
	id INT PRIMARY KEY IDENTITY(1,1),
	username NVARCHAR(20),
	password NVARCHAR(200),
	displayName NVARCHAR(20),
	email NVARCHAR(50),
	authority_level TINYINT DEFAULT 1
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

CREATE TABLE TechnicalCatalog (
	id INT PRIMARY KEY IDENTITY(1,1),
	typeTech NVARCHAR(10),
	nameTech NVARCHAR(50),
	price FLOAT,
	discountPrice FLOAT,
	descriptionTech NVARCHAR(100)
)

CREATE TABLE Examination (
	id INT PRIMARY KEY IDENTITY(1,1),
	examinationDate DATETIME,
	doctorName NVARCHAR(50),
	medicalHistory NVARCHAR(100),
	diagnosisName NVARCHAR(100),
	notes NVARCHAR(200),
	patientId INT FOREIGN KEY REFERENCES Patient(id),
	doctorId INT FOREIGN KEY REFERENCES Users(id)
	 
)

CREATE TABLE Indication (
	id INT PRIMARY KEY IDENTITY(1,1),
	indicationDate DATETIME,
	indicationType NVARCHAR(20),
	doctorName NVARCHAR(50),
	diagnosisName NVARCHAR(100),
	notes NVARCHAR(200),
	patientId INT FOREIGN KEY REFERENCES Patient(id),
	doctorId INT FOREIGN KEY REFERENCES Users(id)
)

CREATE TABLE Details_Examination(
	id INT PRIMARY KEY IDENTITY(1,1),
	examination_id INT FOREIGN KEY REFERENCES Examination(id),
	medicine_id INT FOREIGN KEY REFERENCES Medicine(id),
	daysUse INT NOT NULL,
	morning INT NOT NULL,
	noon INT NOT NULL,
	evening INT NOT NULL
)

CREATE TABLE Details_Indication(
	id INT PRIMARY KEY IDENTITY(1,1),
	Indication_id INT FOREIGN KEY REFERENCES Indication(id),
	technicalCatalog_id INT FOREIGN KEY REFERENCES TechnicalCatalog(id),
	quantity INT NOT NULL,
	note NVARCHAR(200)
)

GO

CREATE TRIGGER createNewUser
ON Users
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

-- Thêm dữ liệu mẫu (giữ nguyên cho các bảng không liên quan đến Prescription/Details)
INSERT INTO Users (username, password, displayName, email, authority_level) VALUES
('admin', '2', N'Nguyen Van A', 'admin1@hospital.com', 3),
('hea', '2', N'Nguyen Van B', 'aaaa@hospital.com', 1)

INSERT INTO Patient (namePat, dob, gender, addressPat, phone, email, healthInsuranceId, idCard, medicalHistory, createDate) VALUES
(N'Nguyen Van An', '1990-05-15', 0, N'123 Le Loi, Hanoi', '0912345678', 'an.nguyen@gmail.com', 'BH123456789', '123456789012', N'Huyết áp cao', '2025-05-08'),
(N'Tran Thi Bich', '1985-11-20', 1, N'456 Tran Phu, HCMC', '0987654321', 'bich.tran@gmail.com', 'BH987654321', '987654321098', N'Tiểu đường', '2025-05-08'),
(N'Le Minh Chau', '1995-03-10', 1, N'789 Nguyen Trai, Da Nang', '0935123456', 'chau.le@gmail.com', 'BH456789123', '456789123456', N'', '2025-05-08'),
(N'Pham Quoc Dat', '1978-07-25', 0, N'101 Hai Ba Trung, Hanoi', '0909876543', 'dat.pham@gmail.com', 'BH321654987', '321654987654', N'Xơ vữa động mạch', '2025-05-09'),
(N'Hoang Thi Em', '1992-09-12', 1, N'321 Pham Van Dong, Hue', '0923456789', 'em.hoang@gmail.com', NULL, '147258369147', N'Xoang', '2025-05-09')

  INSERT INTO Medicine (nameMed, manufacturer, typeMed, discountPrice, price, quantity, manufacturingDate, expiryDate, importDate, usage, dosage) VALUES
(N'Paracetamol', N'PharmaCorp', N'Viên nén', 450, 500, 1000, '2024-01-10', '2026-01-10', '2024-02-01', N'Oral', N'500mg'),
(N'Amoxicillin', N'MediPharm', N'Viên nhộng', 900, 1000, 500, '2024-03-15', '2026-03-15', '2024-04-01', N'Oral', N'500mg'),
(N'Omeprazole', N'HealthCare', N'Viên nhộng', 1300, 1500, 300, '2024-02-20', '2026-02-20', '2024-03-10', N'Oral', N'20mg'),
(N'Aspirin', N'GlobalMed', N'Viên nén', 270, 300, 2000, '2024-05-01', '2026-05-01', '2024-06-01', N'Oral', N'100mg'),
(N'Ibuprofen', N'BioMed', N'Viên nén',  630, 700, 800, '2024-04-10', '2026-04-10', '2024-05-05', N'Oral', N'400mg')

INSERT INTO TechnicalCatalog (typeTech, nameTech, price, discountPrice, descriptionTech) VALUES
(N'Imaging', N'X-ray', 500000, 450000, N'Chest X-ray for diagnostic purposes'),
(N'Lab', N'Blood test', 200000, 180000, N'Complete blood count and glucose test'),
(N'Imaging', N'Ultrasound', 700000, 650000, N'Abdominal ultrasound for organ assessment'),
(N'Test', N'Spirometry', 300000, 270000, N'Lung function test for asthma patients'),
(N'Test', N'Allergy test', 400000, 360000, N'Skin prick test for allergen identification')

INSERT INTO Examination (examinationDate, doctorName, medicalHistory, diagnosisName, notes, patientId, doctorId) VALUES
('2025-04-01 09:00:00', N'Tran Thi B', N'High blood pressure', N'Hypertension', N'Advise lifestyle changes and medication', 1,1),
('2025-04-02 10:30:00', N'Le Van E', N'Diabetes', N'Type 2 Diabetes', N'Monitor blood sugar regularly', 2, 2),
('2025-04-03 14:00:00', N'Nguyen Thi F', N'No significant history', N'Common cold', N'Rest and hydration recommended', 3, 1),
('2025-04-04 11:15:00', N'Tran Thi B', N'Asthma', N'Asthma exacerbation', N'Prescribe inhaler and monitor symptoms', 4, 2),
('2025-04-05 08:45:00', N'Le Van E', N'Allergic rhinitis', N'Seasonal allergies', N'Prescribe antihistamine', 5, 1)

INSERT INTO Indication (indicationDate, indicationType, doctorName, diagnosisName, notes, patientId, doctorId) VALUES
('2025-04-01 09:30:00', N'X Quang', N'Nguyen Van A', N'Gãy xương đùi', N'', 1,1),
('2025-04-02 11:00:00', N'Huyết học', N'Nguyen Van A', N'Sốt xuất huyết', N'', 2, 1),
('2025-04-03 14:30:00', N'Siêu âm', N'Nguyen Van A', N'Loét dạ dày', N'', 3, 1),
('2025-04-05 09:15:00', N'Hóa sinh', N'Nguyen Van A', N'Viêm gan', N'Identify specific allergens', 5, 1)

INSERT INTO Details_Examination(examination_id, medicine_id, daysUse, morning, noon, evening) VALUES
(1, 1, 7, 1, 1, 1), 
(2, 2, 3, 1, 1, 1)  

INSERT INTO Details_Indication(Indication_id, technicalCatalog_id, quantity) VALUES
(1, 1, 1)

-- Stored procedures hiện có (giữ nguyên)
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
	INSERT INTO Patient (namePat, dob, gender, addressPat, phone, email, healthInsuranceId, idCard, medicalHistory, createDate)
	VALUES (@namePat, @dob, @gender, @addressPat, @phone, @email, @healthInsuranceId, @idCard, @medicalHistory, GETDATE())
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
	@patientId INT,
	@doctorId INT
AS
	BEGIN
		INSERT INTO Examination VALUES(@examinationDate, @doctorName, @medicalHistory, @diagnosisName, @notes, @patientId, @doctorId)
	END;
GO

CREATE PROC uspAddIndication 
	@indicationDate DATETIME,
	@indicationType NVARCHAR(20),
	@doctorName NVARCHAR(50),
	@diagnosisName NVARCHAR(100),
	@notes NVARCHAR(200),
	@patientId INT,
	@doctorId INT
AS
	BEGIN
		INSERT INTO Indication VALUES (@indicationDate, @indicationType, @doctorName, @diagnosisName, @notes, @patientId, @doctorId)
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

CREATE PROC uspUpdateTechnicalCatalog
	@id INT,
	@typeTech NVARCHAR(10),
	@nameTech NVARCHAR(50),
	@price FLOAT,
	@discountPrice FLOAT,
	@descriptionTech NVARCHAR(100)

AS
BEGIN
	UPDATE TechnicalCatalog
	SET
		typeTech = @typeTech,
		nameTech = @nameTech,
		price = @price,
		discountPrice = @discountPrice,
		descriptionTech = @descriptionTech
	WHERE id = @id
END;

GO
CREATE PROC uspDeletePatient
	@id INT
AS 
BEGIN
    UPDATE Patient SET namePat = '-'+namePat WHERE id = @id; 
	UPDATE Examination SET diagnosisName = '-'+diagnosisName WHERE patientId = @id;
	UPDATE Indication SET diagnosisName = '-'+diagnosisName WHERE patientId = @id;
END;
GO

CREATE PROC uspDeleteMedicine
	@id INT
AS
BEGIN
	UPDATE Medicine SET nameMed = '-' + nameMed WHERE id = @id;
END;

GO
CREATE PROC uspDeleteTech
	@id INT
AS 
BEGIN
	UPDATE TechnicalCatalog SET nameTech = '-' + nameTech WHERE id = @id;
END;

GO
CREATE PROC uspDeleteExam
	@id INT
AS
BEGIN
	UPDATE Examination SET diagnosisName = '-' + diagnosisName WHERE id = @id;
END;

GO
CREATE PROC uspDeleteIndication
	@id INT
AS 
BEGIN
	UPDATE Indication SET diagnosisName = '-' + diagnosisName WHERE id = @id;
END;

GO
CREATE PROC uspCreateAccount
	@username NVARCHAR(20),
	@password NVARCHAR(200),
	@displayName NVARCHAR(20),
	@email NVARCHAR(50),
	@authority_level TINYINT
AS
	BEGIN
		INSERT INTO Users (username, password, displayName, email, authority_level)
		VALUES (@username, @password, @displayName, @email, @authority_level)
	END;

GO
CREATE PROC uspDeleteAccount
	@username NVARCHAR(20)
AS
	UPDATE Users SET username = '-' + username WHERE username = @username;

GO
CREATE FUNCTION getPrescription(
	@id INT -- id của đơn thuốc tại bảng Examination
)
RETURNS TABLE
AS
	RETURN (SELECT * FROM Details_Examination WHERE examination_id=@id)


GO
CREATE PROC uspAddPrescriptionDetail
	@examination_id INT,
	@medicine_id INT,
	@daysUse INT,
	@morning INT,
	@noon INT,
	@evening INT
AS
BEGIN
	INSERT INTO Details_Examination(examination_id, medicine_id, daysUse, morning, noon, evening)
	VALUES (@examination_id, @medicine_id, @daysUse, @morning, @noon, @evening);
END;
GO

CREATE PROC uspAddTestsPrescriptionDetail
	@indication_id INT,
	@technicalCatalog_id INT,
	@quantity INT,
	@note NVARCHAR(200)
AS
INSERT INTO Details_Indication(Indication_id, technicalCatalog_id, quantity, note)
VALUES (@indication_id, @technicalCatalog_id, @quantity, @note)

CREATE FUNCTION dayStatistic()
RETURNS @new_table TABLE (
    patient_quality INT,
    new_patient_quality INT,
    prescription_quality INT,
    indication_quality INT,
    examination_quality INT
)
AS
BEGIN
    INSERT INTO @new_table (
        patient_quality,
        new_patient_quality,
        prescription_quality,
        indication_quality,
        examination_quality
    )
    SELECT 
        (
            SELECT COUNT(DISTINCT id)
            FROM
                (SELECT Patient.id
                 FROM Patient
                 INNER JOIN Examination 
                 ON Patient.id = Examination.patientId
                 WHERE CAST(examinationDate AS DATE) = CAST(GETDATE() AS DATE) AND NOT(namePat LIKE '-%')
                 UNION 
                 SELECT Patient.id
                 FROM Patient
                 INNER JOIN Indication
                 ON Patient.id = Indication.patientId
                 WHERE CAST(indicationDate AS DATE) = CAST(GETDATE() AS DATE) AND NOT(namePat LIKE '-%')
				 UNION
				 SELECT Patient.id
				 FROM Patient
				 WHERE CAST(createDate AS DATE) = CAST(GETDATE() AS DATE) AND NOT(namePat LIKE '-%')
				 ) AS SUB
        ) AS patient_quality,
        (
            SELECT COUNT(id) 
            FROM Patient 
            WHERE CAST(createDate AS DATE) = CAST(GETDATE() AS DATE) 
            AND NOT(namePat LIKE '-%')
        ) AS new_patient_quality,
        (
            SELECT COUNT(DISTINCT Examination.id)
            FROM Examination
            INNER JOIN Details_Examination
            ON Examination.id = Details_Examination.examination_id
            WHERE CAST(examinationDate AS DATE) = CAST(GETDATE() AS DATE) AND NOT(diagnosisName LIKE '-%')
        ) AS prescription_quality,
        (
            SELECT COUNT(id)
            FROM Indication
            WHERE CAST(indicationDate AS DATE) = CAST(GETDATE() AS DATE) AND NOT(diagnosisName LIKE '-%')
        ) AS indication_quality,
        (
            SELECT COUNT(id)
            FROM Examination
            WHERE CAST(examinationDate AS DATE) = CAST(GETDATE() AS DATE) AND NOT(diagnosisName LIKE '-%')
        ) AS examination_quality;

    RETURN;
END;

SET DATEFIRST 1; 


CREATE FUNCTION WEEKSTATISTIC()
RETURNS @new_table TABLE(
						weekday DATE,
						patient_quality INT,
						new_patient_quality INT,
						total_cost FLOAT
						)
BEGIN
	

	DECLARE @CurrentDate DATE = CAST(GETDATE() AS DATE);
	DECLARE @Monday DATE = DATEADD(DAY, -DATEPART(WEEKDAY, @CurrentDate) + 1, @CurrentDate);
	INSERT INTO @new_table(
		weekday,
		patient_quality,
		new_patient_quality,
		total_cost
	)
	SELECT 
		DATEADD(DAY, Number, @Monday) AS WeekDay, 
		(SELECT COUNT(DISTINCT id)
				FROM
					(SELECT Patient.id
					 FROM Patient
					 INNER JOIN Examination 
					 ON Patient.id = Examination.patientId
					 WHERE CAST(examinationDate AS DATE) = DATEADD(DAY, Number, @Monday) AND NOT(namePat LIKE '-%')
					 UNION 
					 SELECT Patient.id
					 FROM Patient
					 INNER JOIN Indication
					 ON Patient.id = Indication.patientId
					 WHERE CAST(indicationDate AS DATE) = DATEADD(DAY, Number, @Monday) AND NOT(namePat LIKE '-%')
					 UNION
					 SELECT Patient.id
					 FROM Patient
					 WHERE CAST(createDate AS DATE) = DATEADD(DAY, Number, @Monday) AND NOT(namePat LIKE '-%')
					 ) AS SUB
				) AS patient_quality,
		(
			SELECT COUNT(id) 
			FROM Patient 
			WHERE CAST(createDate AS DATE) = DATEADD(DAY, Number, @Monday)
			AND NOT(namePat LIKE '-%')
		) AS new_patient_quality,
		(
		SELECT SUM(TotalCost)
		FROM (
			SELECT SUM(
				daysUse*(morning+noon+evening)* (CASE WHEN NOT((healthInsuranceId = '') OR healthInsuranceId IS NULL) 
					THEN discountPrice ELSE price END
			)) AS TotalCost
			FROM Examination 
			INNER JOIN Details_Examination ON Examination.id = Details_Examination.examination_id
			INNER JOIN Medicine ON medicine_id = Medicine.id
			INNER JOIN Patient ON Patient.id = Examination.patientId
			WHERE CAST(examinationDate AS DATE) = DATEADD(DAY, Number, @Monday)
			UNION
			SELECT SUM(
				quantity * (CASE WHEN NOT((healthInsuranceId = '') OR healthInsuranceId IS NULL) 
					THEN discountPrice ELSE price END
				)) AS TotalCost
			FROM Indication 
			INNER JOIN Details_Indication ON Indication.id = Details_Indication.Indication_id
			INNER JOIN TechnicalCatalog ON technicalCatalog_id = TechnicalCatalog.id
			INNER JOIN Patient ON Patient.id = Indication.patientId
			WHERE CAST(indicationDate AS DATE) = DATEADD(DAY, Number, @Monday)
		) AS SUB
	)
	FROM (SELECT 0 AS Number UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 
		  UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6) AS Numbers
	ORDER BY WeekDay;
	RETURN;
END;

CREATE TABLE AGE (start_age INT, end_age INT)
INSERT INTO AGE(start_age, end_age) VALUES
(0, 3),
(4, 10),
(11, 18),
(19, 25),
(26, 32),
(33, 39),
(40, 999)

CREATE FUNCTION AGE_STATISTIC()
RETURNS @Result TABLE (
    male INT,
    female INT
)
AS
BEGIN
    INSERT INTO @Result
    SELECT 
        SUM(CASE WHEN p.gender = 0 THEN 1 ELSE 0 END) AS male,
        SUM(CASE WHEN p.gender = 1 THEN 1 ELSE 0 END) AS female
    FROM AGE a
    LEFT JOIN Patient p
        ON YEAR(GETDATE()) - YEAR(p.dob) + 1 BETWEEN a.start_age AND a.end_age
    GROUP BY a.start_age, a.end_age

    RETURN
END