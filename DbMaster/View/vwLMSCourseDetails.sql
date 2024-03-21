

/****** Object:  View [dbo].[vwLMSCourseDetails]    Script Date: 3/21/2024 7:44:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



---		SELECT * FROM vwLMSCourseDetails
CREATE VIEW [dbo].[vwLMSCourseDetails]
AS
	SELECT CM.Id CourseMasterId, CM.CourseObjective, CM.CourseOutline, CM.TeacherId, CM.VideoUrl, CM.CourseAssignId,
		CA.SessionId, S.SessionName, S.SessionNameBN,
		CA.FacultyId, Faculty.FacultyName, Faculty.FacultyNameBN, CA.DepartmentId, Department.DepartmentName, Department.DepartmentNameBN,
		CA.ProgramId, Program.ProgramName, Program.ProgramNameBN, CA.BatchId, Batch.BatchName, Batch.BatchNameBN,
		CA.AcademicSemesterId, CA.CourseId, Course.CourseName, Course.CourseCode, Course.ConductHour, Course.CreditHour, CourseType.[Name] CourseTypeName, CourseType.[NameBN] CourseTypeNameBN
	FROM LMS_CourseMasters AS CM 
		INNER JOIN Aca_CourseAssigns AS CA ON CM.CourseAssignId = CA.Id
		LEFT JOIN Aca_Sessions AS S ON CA.SessionId = S.Id
		INNER JOIN Aca_Faculties AS Faculty ON CA.FacultyId = Faculty.Id
		INNER JOIN Aca_Departments AS Department ON CA.DepartmentId = Department.Id
		INNER JOIN Aca_Programs AS Program ON CA.ProgramId = Program.Id
		LEFT JOIN Aca_Batches AS Batch ON CA.BatchId = Batch.Id
		INNER JOIN Aca_Courses AS Course ON CA.CourseId = Course.Id
		INNER JOIN Com_LookupDetails AS CourseType ON Course.CourseTypeId = CourseType.Id
	--WHERE TeacherId = 12


--	SELECT * FROM LMS_CourseMasters
--	SELECT * FROM Aca_CourseAssign WHERE Id = 91
--	SELECT * FROM Exm_Lookups WHERE Name LIKE '%Part%'
--	SELECT * FROM Exm_LookupDetails WHERE LookupId = 4
--	SELECT * FROM Com_Lookups WHERE Name LIKE '%Semester%'
--	SELECT * FROM Com_LookupDetails WHERE LookupId = 1017
GO


