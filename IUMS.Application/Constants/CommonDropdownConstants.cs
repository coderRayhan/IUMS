namespace IUMS.Application.Constants
{
    public static class CommonDropdownConstants
    {
        public const string LMS_ADMISSION_YEAR_DROPDOWN_QUERY = "SELECT DISTINCT AdmissionYearId Id, AdmissionYearName Name, AdmissionYearNameBN NameBN FROM vwLMSCourseDetails";
        
        public const string LMS_ADMISSION_YEAR_DROPDOWN_QUERY_BY_TEACHER = "SELECT DISTINCT TA.AdmissionYearId Id, S.SessionName [Name], S.SessionNameBN NameBN FROM Aca_TeacherAssigns TA INNER JOIN Aca_Sessions S ON TA.AdmissionYearId = S.Id WHERE PartATeacherIdFK = {0} OR PartBTeacherIdFK = {0}";

        public const string LMS_FACULTY_DROPDOWN_QUERY = "SELECT DISTINCT FacultyId Id, FacultyName Name, FacultyNameBN NameBN FROM vwLMSCourseDetails WHERE AdmissionYearId = {0}";
        public const string LMS_FACULTY_DROPDOWN_QUERY_BY_TEACHER = "SELECT DISTINCT TA.FacultyId Id, F.FacultyName [Name], F.FacultyNameBN [NameBN] FROM Aca_TeacherAssigns TA INNER JOIN Aca_Faculties F ON TA.FacultyId = F.Id WHERE (PartATeacherIdFK = {0} OR PartBTeacherIdFK = {0}) AND AdmissionYearId = {1}";

        public const string LMS_DEPARTMENT_DROPDOWN_QUERY = "SELECT DISTINCT DepartmentId Id, DepartmentName Name, DepartmentNameBN NameBN FROM vwLMSCourseDetails WHERE FacultyId = {0}";

        public const string LMS_DEPARTMENT_DROPDOWN_QUERY_BY_TEACHER = "SELECT DISTINCT TA.DepartmentId Id, D.DepartmentName [Name], D.DepartmentNameBN [NameBN] FROM Aca_TeacherAssigns TA INNER JOIN Aca_Departments D ON TA.DepartmentId = D.Id WHERE (PartATeacherIdFK = {0} OR PartBTeacherIdFK = {0}) AND D.FacultyId = {1}";

        public const string LMS_PROGRAM_DROPDOWN_QUERY = "SELECT DISTINCT ProgramId Id, ProgramName Name, ProgramNameBN NameBN FROM vwLMSCourseDetails WHERE FacultyId = {0} AND DepartmentId = {1}";

        public const string LMS_PROGRAM_DROPDOWN_QUERY_BY_TEACHER = "SELECT DISTINCT TA.ProgramId Id, P.ProgramName [Name], P.ProgramNameBN [NameBN] FROM Aca_TeacherAssigns TA INNER JOIN Aca_Programs P ON TA.ProgramId = P.Id WHERE (PartATeacherIdFK = {0} OR PartBTeacherIdFK = {0}) AND P.FacultyId = {1} AND P.DepartmentId = {2}";

        public const string LMS_BATCH_DROPDOWN_QUERY = "SELECT DISTINCT BatchId Id, BatchName Name, BatchNameBN NameBN FROM vwLMSCourseDetails WHERE AdmissionYearId = {0} AND ProgramId = {1}";

        public const string LMS_BATCH_DROPDOWN_QUERY_BY_TEACHER = "SELECT DISTINCT TA.BatchId Id, B.BatchName [Name], B.BatchNameBN [NameBN] FROM Aca_TeacherAssigns TA INNER JOIN Aca_Batches B ON TA.BatchId = B.Id WHERE (PartATeacherIdFK = {0} OR PartBTeacherIdFK = {0}) AND TA.FacultyId = {1} AND TA.DepartmentId = {2} AND TA.ProgramId = {3}";

        public const string LMS_SEMESTER_DROPDOWN_QUERY = "SELECT DISTINCT SemesterId Id, SemesterName Name, SemesterNameBN NameBN FROM vwLMSCourseDetails WHERE BatchId = {0}";
        public const string LMS_PART_DROPDOWN_QUERY = "SELECT Id, IIF(TeacherType = 'PartATeacherIdFk', 'Part A', 'Part B') AS [Name] FROM (SELECT Id, PartATeacherIdFK, PartBTeacherIdFK FROM dbo.Aca_TeacherAssigns WHERE AdmissionYearId = {1} AND FacultyId =  {2} AND DepartmentId = {3} AND ProgramId = {4} AND BatchId = {5} AND SemesterId = {6} AND CourseId =  {7}) AS DerivedTable UNPIVOT ( TeacherId FOR TeacherType IN (DerivedTable.PartATeacherIdFk, DerivedTable.PartBTeacherIdFK)) AS UnPivotTable WHERE TeacherId =  {0}";

        public const string LMS_COURSE_DROPDOWN_QUERY_WITH_COURSE_ASSIGN_ID = "SELECT CourseAssignId Id, CONCAT(CourseCode, ' - ' ,CourseName) Name, CONCAT(CourseCode, ' - ' ,CourseName) NameBN FROM vwLMSCourseDetails WHERE FacultyId = {0} AND DepartmentId = {1} AND ProgramId = {2} AND BatchId = {3} AND SemesterId = {4}";

        public const string LMS_COURSE_DROPDOWN_QUERY_WITH_COURSE_ASSIGN_ID_BY_TEACHER = "SELECT CA.Id, C.CourseName [Name], C.CourseName [NameBN] FROM Aca_TeacherAssigns TA, Aca_CourseAssign CA, Aca_Courses C WHERE TA.AdmissionYearId = CA.AdmissionYearId AND TA.FacultyId = CA.FacultyId AND TA.DepartmentId = CA.DepartmentId AND TA.ProgramId = CA.ProgramId AND TA.CourseId = CA.CourseId AND CA.CourseId = C.Id AND (PartATeacherIdFK = {0} OR PartBTeacherIdFK = {0}) AND CA.FacultyId = {1} AND CA.DepartmentId = {2} AND CA.ProgramId = {3} AND CA.BatchId = {4} AND CA.SemesterId = {5}";

        public const string LMS_COURSE_DROPDOWN_QUERY_WITH_COURSE_MASTER_ID = "SELECT CourseMasterId Id, CONCAT(CourseCode, ' - ' ,CourseName) Name, CONCAT(CourseCode, ' - ' ,CourseName) NameBN FROM vwLMSCourseDetails WHERE AdmissionYearId = {0} AND FacultyId = {1} AND DepartmentId = {2} AND ProgramId = {3} AND BatchId = {4} AND SemesterId = {5}";
        
        public const string ECO_CODE_DROPDOWN_FROM_BUDGET_DEMAND = "SELECT DISTINCT ECE.Id, ECE.Name, ECE.NameBN FROM Fin_BudgetDemand BD INNER JOIN Fin_BudgetDemandDetails BDD ON BD.Id = BDD.BudgetDemandId INNER JOIN Fin_EconomicCodeEntry ECE ON BDD.EconomicCodeId = ECE.Id WHERE BD.FinancialYearId = {0} AND BD.BudgetTypeId = {1}";

        public const string LMS_ADMISSION_YEAR_DROPDOWN_BY_TEACHER_ID_QUERY = "SELECT AdmissionYearId Id, AdmissionYearName Name, AdmissionYearNameBN NameBN FROM vwLMSCourseDetails WHERE TeacherId = {0}";

        public const string LMS_CHAPTER_DROPDOWN_BY_COURSE_MASTER_ID = "SELECT Id, Title Name FROM LMS_CourseChapters WHERE CourseMasterId = {0}";

        public const string LMS_HOST_DROPDOWN = "SELECT Id, HostName Name FROM LMS_HostConfigs";

        public const string LMS_LIVE_CLASS_BY_CHAPTER_ID = "SELECT Id, Title Name FROM LMS_ChapterClasses WHERE ClassTypeId = {0} AND CourseChapterId = {1}";

        public const string RUNNING_SEMESTER_DROPDOWN_FROM_ADMISSION_FORM = "SELECT DISTINCT MAX(SemesterId) Id, Sem.Name, Sem.NameBN FROM Adms_AdmissionForms AF, Com_LookupDetails Sem WHERE AF.SemesterId = Sem.Id AND AdmissionYear = {0} AND FacultyId = {1} AND DepartmentId = {2} AND ProgramId = {3} AND BatchId = {4} GROUP BY Sem.Name, Sem.NameBN";

        public const string LMS_CLASS_BY_CHAPTER_ID = "SELECT Id, Title Name FROM LMS_ChapterClasses WHERE CourseChapterId = {0} and ClassTypeId=3";
        public const string GET_COURSE_TEACHER_FROM_TEACHER_ASSIGN = "SELECT TA.CourseId Id, CONCAT(C.CourseCode, ' - ', C.CourseName) [Name], CONCAT(C.CourseCode, ' - ', C.CourseName) [NameBN] FROM Aca_TeacherAssigns TA, Aca_Courses C WHERE TA.CourseId = C.Id AND BatchId = ${0} AND (PartATeacherIdFK = ${1} OR PartBTeacherIdFK = ${1})";
        public const string GET_EXAM_NAME_FROM_EXAM_DETAILS_FOR_LMS = "SELECT DISTINCT ED.ExamNameId Id, Exam.[Name], Exam.[NameBN] FROM Exm_ExamDetails ED, LMS_CourseMasters CM, Exm_LookupDetails Exam WHERE ED.CourseAssignId = CM.CourseAssignId AND ED.ExamNameId = Exam.Id AND CM.Id = {0} ORDER BY ED.ExamNameId";
        public const string GET_BUDGET_ELEMENT = "SELECT Id, Name, NameBN FROM Fin_LookupDetails WHERE LookupId = 31";
        public const string GET_BUDGET_SUB_ELEMENT = "SELECT Id, Name, NameBN FROM Fin_LookupDetails WHERE LookupId = 32 ORDER BY Name";


        #region Student Portal 
        public const string DISTRICT = "SELECT Id, Name, NameBN FROM Com_LookupDetails WHERE LookupId = 3";
        public const string UPAZILA = "SELECT Id, Name, NameBN, ParentId FROM Com_LookupDetails WHERE LookupId = 2008 AND ParentId = {0}";
        public const string BLOOD_GROUP_DROPDOWN_FROM_LOOK_UP = "SELECT Id, Name, NameBN FROM Com_LookupDetails WHERE LookupId = 2007";
        public const string GENDER_DROPDOWN_FROM_LOOK_UP = "SELECT Id, Name, NameBN FROM Com_LookupDetails WHERE LookupId = 2002";
        public const string NATIONALITY_DROPDOWN_FROM_LOOK_UP = "SELECT Id, Name, NameBN FROM Com_LookupDetails WHERE LookupId = 2004";
        public const string RELIGION_DROPDOWN_FROM_LOOK_UP = "SELECT Id, Name, NameBN FROM Com_LookupDetails WHERE LookupId = 2005";
        #endregion

        #region Movement Pass
        public const string GET_ALL_TRAININGS_REFERENCES = "SELECT Id, RefNo Name FROM dbo.HRA_TrainingConfigs";
        #endregion

        #region Finance
        public const string GET_ALL_BANK_ECONOMIC_CODES = "SELECT Id, CONCAT(AccountCode,' - ', Name) Name, CONCAT(AccountCode, ' - ', NameBN) NameBN FROM Fin_EconomicCodeEntry WHERE IsBank = 1";
        public const string GET_GOVT_ORDER = "SELECT Id, GovtOrderRefNo AS Name From Fin_GovtOrders";
        public const string GET_FOREIGN_GOVT_ORDER = "SELECT Id, FGONo Name FROM Fin_ForeignGovtOrders";
        public const string GET_TRAVEL_EXPENSE_ACCOUNT_CODE = "SELECT Id, CONCAT(AccountCode, '--', Name) [Name] FROM Fin_EconomicCodeEntry WHERE Id = 78";
        public const string GET_FOREIGN_MOVEMENT = "SELECT Id, OfficeOrderNo Name FROM Fin_ForeignMovements WHERE IsForAdvance = 0 AND FinacialStatusFlowId IN (2,4,9)";
        public const string GET_ADVANCE_FOREIGN_MOVEMENT = "SELECT Id, OfficeOrderNo Name FROM Fin_ForeignMovements WHERE IsForAdvance = 1";
        public const string GET_ALL_DEPARTMENT_FOR_DROPDOWN = "SELECT Id, Name, NameBN FROM vwDepartmentBranch";
        //public const string GET_ADVANCE_OFFICE_ORDER = "SELECT Id, OfficeOrderRefNo Name FROM Fin_LocalOrderTADAs WHERE IsAdvance = 1";
        public const string GET_ADVANCE_OFFICE_ORDER = "SELECT Id, OfficeOrderRefNo Name,Description,Title FROM Fin_LocalOrderTADAs WHERE IsAdvance = 1";
        public const string GET_LOCAL_MOVEMENT_DROPDOWN_BY_OFFICE_ORDER = "SELECT LM.Id, CONCAT(EMP.EmpId, ' -- ', EMP.FullName, ' - (', LM.LocalMovementId, ')') Name FROM Fin_LocalMovements LM INNER JOIN Emp_Employees EMP ON LM.EmployeeId = EMP.Id WHERE OrderTADAId = {0}";
        #endregion

        #region Admin
        public const string GET_ALL_TRANSECTION_TYPE_BY_USER_ID = "SELECT AAC.TransectionType Id, AAC.TransectionTypeName Name FROM  dbo.Adm_ApprovalCofigs AAC INNER JOIN dbo.Adm_ApprovalTeams AAT ON AAT.Id = AAC.ToTeamId INNER JOIN dbo.Adm_ApprovalTeamDetails AATD ON AATD.ApprovalTeamId = AAT.Id WHERE AATD.UserId = '{0}'";
        public const string GET_ALL_FLOW_BY_TRANSECTIONTYPE_ID = "SELECT Id, FlowName Name FROM dbo.Adm_ApprovalTransectionFlows WHERE TransectionType = {0}";

        #endregion

        #region HR Admin
        public const string GET_ALL_EXAMS_OF_RECRUITMENT_REFERENCES = "SELECT HRE.ExamTypeId Id, LD.Name, LD.NameBN FROM dbo.HRA_RecruitmentExams HRE INNER JOIN dbo.Com_LookupDetails AS LD ON LD.Id = HRE.ExamTypeId WHERE HRE.RecruitmentRefId = {0} AND HRE.RecruitmentRefDetailId = {1}";
        
        public const string GET_ALL_SHIFT_INFO = "SELECT Id, ShiftName Name FROM HRA_ShiftInformations";
        public const string GET_ALL_SALARY_SHIFT_CATEGORY = "SELECT Id, Name, NameBN FROM HRA_LookupDetails WHERE LookupId = 38";

        public const string GET_EMP_NAME_AND_USER_ID_BY_USER_ID = "SELECT E.Id, CONCAT(E.EmpId, '--', E.FullName) [Name] FROM [Identity].Users U INNER JOIN Emp_Employees E ON U.EmpId = E.Id WHERE U.Id = '{0}'";
        public const string GET_LEAVE_GROUP_FOR_DROPDOWN = "SELECT Id, LeaveGroupName Name FROM HRA_LeaveGroup";

        #endregion

        #region Affiliation
        public const string GET_ALL_BAFA_RANK = "SELECT Id, Name,  NameBN FROM dbo.Com_LookupDetails WHERE LookupId = 2045";
        public const string GET_ALL_BAFA_BRANCH = "SELECT Id, Name,  NameBN FROM dbo.Com_LookupDetails WHERE LookupId = 2046";
        public const string GET_ALL_AFFILIATED_USERS = "SELECT Id, FullName Name FROM [Identity].Users WHERE IsAffiliateInstitute = 1 AND AffiliateInstituteId = {0}";
        public const string GET_ALL_AFFILIATED_FACULTIES = "SELECT Id, FacultyName Name FROM dbo.Aca_Faculties WHERE HasAffiliatedInstitute = 1";
        public const string GET_ALL_AFFILIATED_DEPARTMENTS_BY_FACULTY_ID = "SELECT Id, DepartmentName Name, DepartmentNameBN NameBN FROM dbo.Aca_Departments WHERE FacultyId = {0}";
        public const string GET_ALL_AFFILIATED_PROGRAMS_BY_DEPARTMENT_ID = "SELECT Id, ProgramName Name, ProgramNameBN NameBN FROM dbo.Aca_Programs WHERE DepartmentId = {0}";
        public const string GET_ALL_AFFILIATED_FACULTIES_INSTITUTE_ID = "SELECT Id, FacultyName Name FROM dbo.Aca_Faculties WHERE HasAffiliatedInstitute = 1 AND AffiliatedInstituteId = {0}";
        public const string GET_ALL_AFFILIATED_FACULTIES_BY_AFFILIATED_USER = "SELECT DISTINCT Fac.Id, Fac.FacultyName Name, Fac.FacultyNameBN NameBN " +
            "FROM dbo.Aca_TeacherRoleAssigns TRA " +
            "INNER JOIN [Identity].Users U ON U.Id = TRA.AffiliatedUserId " +
            "LEFT JOIN dbo.Aca_Faculties AS Fac ON Fac.Id = TRA.FacultyId " +
            "WHERE TRA.IsAffiliateInstitute = 1 " +
            "AND TRA.AffiliatedUserId = '{0}'";
        public const string GET_ALL_AFFILIATED_DEPARTMENTS_BY_AFFILIATED_USER_ND_FACULTY = "SELECT DISTINCT DEPT.Id, DEPT.DepartmentName Name, DEPT.DepartmentNameBN NameBN\r\n" +
            "FROM dbo.Aca_TeacherRoleAssigns TRA " +
            "INNER JOIN [Identity].Users U ON U.Id = TRA.AffiliatedUserId " +
            "LEFT JOIN dbo.Aca_Departments AS DEPT ON DEPT.Id = TRA.DepartmentId " +
            "WHERE TRA.IsAffiliateInstitute = 1 " +
            "AND TRA.AffiliatedUserId = '{0}' " +
            "AND TRA.FacultyId = {1}";

        public const string GET_ALL_AFFILIATED_PROGRAMSS_BY_AFFILIATED_USER_ND_DEPARTMENT = "SELECT DISTINCT PROG.Id, PROG.ProgramName Name, PROG.ProgramNameBN NameBN " +
            "FROM dbo.Aca_TeacherRoleAssigns TRA " +
            "INNER JOIN [Identity].Users U ON U.Id = TRA.AffiliatedUserId " +
            "LEFT JOIN dbo.Aca_Programs AS PROG ON PROG.Id = TRA.ProgramId " +
            "WHERE TRA.IsAffiliateInstitute = 1 " +
            "AND TRA.AffiliatedUserId = '{0}' " +
            "AND TRA.DepartmentId = {1} ";

        public const string GET_ALL_AFFILIATED_BATCHES_BY_FAC_DEPT_PROG = "SELECT DISTINCT B.Id, B.BatchName Name, B.BatchNameBN NameBN\r\n" +
            "FROM dbo.Aca_TeacherRoleAssigns TRA\r\nINNER JOIN [Identity].Users U ON U.Id = TRA.AffiliatedUserId \r\n" +
            "INNER JOIN dbo.Aca_Batches B ON B.FacultyId = TRA.FacultyId AND B.DepartmentId = TRA.DepartmentId AND B.ProgramId = TRA.ProgramId \r\n" +
            "WHERE TRA.IsAffiliateInstitute = 1\r\n" +
            "AND TRA.AffiliatedUserId = '{0}'\r\n" +
            "AND B.FacultyId = {1}\r\n" +
            "AND B.DepartmentId = {2}\r\n" +
            "AND B.ProgramId = {3}" +
            "AND B.SessionId = {4} ";

        public const string GET_ALL_AFFILIATED_COURSES_BY_FAC_DEPT_PROG = "SELECT DISTINCT C.Id, CONCAT(C.CourseCode, ' - ' ,C.CourseName) Name, CONCAT(C.CourseCode, ' - ' ,C.CourseName) NameBN\r\n" +
            "FROM dbo.Aca_TeacherRoleAssigns TRA\r\n" +
            "INNER JOIN [Identity].Users U ON U.Id = TRA.AffiliatedUserId \r\n" +
            "INNER JOIN dbo.Aca_Courses C ON C.FacultyId = TRA.FacultyId AND C.DepartmentId = TRA.DepartmentId AND C.ProgramId = TRA.ProgramId \r\n" +
            "WHERE TRA.IsAffiliateInstitute = 1\r\n" +
            "AND TRA.AffiliatedUserId = '{0}'\r\n" +
            "AND C.FacultyId = {1}\r\n" +
            "AND C.DepartmentId = {2}\r\n" +
            "AND C.ProgramId = {3}";
        public const string GET_ALL_ACTIVE_SESSIONS = "SELECT Id, SessionName Name FROM Aca_Sessions WHERE EndDate > GETDATE()";

        public const string GET_ALL_FACULTIES = "SELECT Fac.Id Id, Fac.FacultyName Name, Fac.FacultyNameBN NameBN FROM dbo.Aca_Faculties Fac";

        public const string GET_ALL_DEPARTMENTS = "SELECT Id, DepartmentName Name, DepartmentNameBN NameBN FROM dbo.Aca_Departments WHERE FacultyId = {0}";

        public const string GET_ALL_PROGRAMS = "SELECT Id, ProgramName Name, ProgramNameBN NameBN FROM dbo.Aca_Programs WHERE DepartmentId = {0}";

        public const string GET_BATCH_BY_SESSION_PROGRAM = "SELECT Id, BatchName [Name], BatchNameBN [NameBN] FROM Aca_Batches WHERE SessionId = {0} AND ProgramId = {1}";
        public const string GET_COURSE_BY_PROGRAM = "SELECT Id, CONCAT(CourseCode, ' - ', CourseName) Name FROM Aca_Courses WHERE ProgramId = @ProgramId";

        public const string GET_TEACHER = "SELECT Id, CONCAT(EmpId, ' -- ', FullName) [Name], FullNameBN NameBN FROM Emp_Employees";
        #endregion

        #region Common
        public const string GET_LOOKUP_DATA_BY_TYPE = "SELECT LD.Id, LD.Name, LD.NameBN FROM Com_LookupDetails LD, Com_Lookups L WHERE LD.LookupId = L.Id AND LOWER(L.Name) LIKE '%{0}%'";
        public const string GET_ALL_ACTIVE_LOOKUPS = "SELECT Id, Name, NameBN FROM Com_Lookups WHERE Status = 'A'";
        public const string GET_DETAIL_PARENT_BY_LOOKUP_ID = "SELECT cld.Id, cld.Name, cld.NameBN FROM   dbo.Com_Lookups AS cl INNER JOIN dbo.Com_LookupDetails AS cld  ON cl.ParentId = cld.LookupId WHERE (0= @Id or cl.Id = @Id) AND cld.Status = 'A' ORDER BY cld.Name";
        #endregion
    }
}
