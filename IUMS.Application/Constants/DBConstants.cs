namespace IUMS.Application.Constants
{
    public static class DBConstants
    {
        public static class STORE_PROCEDURE
        {
            public const string IS_EXIST_COLUMN_VALUE = "IsExistColumnValue";
            public const string IS_EXIST_COLUMN_VALUE_ON_UPDATE = "IsExistColumnValueOnUpdate";

            public const string GET_All_NOTICE = "GetNoticeList";
            public const string GET_NOTICE_BY_ID = "GetNoticeById";
            public const string GET_NOTICE_BY_FILTER = "GetNoticeListByFilter";
            public const string GET_NOTICE_BY_STUDENTID = "GetNoticeListByStudentId";
            public const string GET_NOTICE_BY_EMPLOYEEID = "GetNoticeListByEmployeeId";
            public const string GET_ADMISSION_TEST = "GetAdmissionTest";
            public const string GET_ALL_EXAM_TYPE = "GetAllExamType";
            public const string GET_ALL_EXAM_CENTER_OR_BUILDING_BY_ID = "GetAllExamCenterOrBuildingById";
            public const string GET_ALL_EXAM_CAMPUS_OR_BUILDING_BY_ID = "GetAllExamCampusOrBuildingById";
            public const string GET_ALL_EXAM_FLOOR_OR_ROOM_BY_ID = "GetAllExamFloorById";
            public const string GET_FLOOR_BY_BUILDING_ID = "GetFloorByBuildingId";
            public const string GET_ALL_EXAM_ROOM = "GetAllExamRoom";
            public const string GET_ALL_ADMISSION_DETAIL = "GetAllAdmissionDetail";
            public const string GET_CLASS_ROLL_BY_BATCH = "GetClassRollByBatch";
            public const string GET_MIGRATION_APPLICATION = "GetMigrationApplication";
            public const string GET_MIGRATION_APPLICATION_REPORT = "GetMigrationApplicationReport";
            public const string GET_EXAM_ROOM_BY_ROOM_NUMBER = "GetExamRoomByRoomNumber";
            public const string GET_STUDENT_NAME_AND_PROGRAM_BY_ID = "GetStudentNameAndProgramByID";
            public const string GET_CANCELLATION_APPLICATION = "GetCancellationApplication";
            public const string GET_CANCELLATION_APPLICATION_F0R_REPORT = "GetCancellationApplicationForReport";
            public const string GET_CLASS_ROLL_CONFIG = "GetClassRollConfig";
            public const string GET_STUDENT_LIST_FOR_REGISTRATION = "GetStudentListForRegistration";
            public const string GET_BATCH_BY_PROGRAM_ID = "GetBatchByProgramId";
            public const string GET_ALL_EXAM_SEAT = "GetAllExamSeat";
            public const string GET_FILTER_ATTENDANCE_BY_ROOM = "GetFilterAttendenceByRoom";
            public const string GET_ADMISSION_FORM = "GetAdmissionForm";
            public const string GET_COURSE_ASSIGN = "GetCourseAssign";
            public const string GET_ALL_CLASS_ROUTINE_DETAILS = "GetAllClassRoutineDetails";
            public const string SET_ADVISER_DETAILS = "SetAdviserDetails";
            public const string GET_EXAM_ROUTINE = "GetExamRoutine";
            public const string GET_EXAM_ROUTINE_DETAILS = "GetExamRoutineDetails";
            public const string GET_EXAM_ROUTINE_REPORT = "GetExamRoutineReport";
            public const string GET_EXAM_ROUTINE_BY_ID = "GetExamRoutineById";
            public const string GET_EXAM_ROUTINE_DETAILS_BY_EXAM_ROUTINE_ID = "GetExamRoutineDetailsByExamRoutineId";
            public const string GET_EXAM_ROUTINE_DETAILS_REPORT_BY_ID = "GetExamRoutineDetailsReportById";
            public const string GET_COURSE_LIST_WITH_TEACHER_ID = "GetCourseListWithTeacherID";
            public const string GET_BUILDING_LIST_BY_CAMPUSID = "GetBuildingListByCampusId";
            public const string GET_DATA_FROM_MARK_ENTRY_TABLE = "GetDataFromMarkEntryTable";
            public const string GET_DATA_FOR_CA_MARK_ENTRY = "GetDataForCAMarkEntry";
            public const string GET_DATA_FOR_TF_MARK_ENTRY = "GetDataForTFMarkEntry";
            public const string UPDATE_STUDENT_ADMITCARD_STATUS = "UpateStudentAdmitCardStatus";
            public const string GET_EMPLOYEE_BY_EMPID = "GetEmployeeByEmpId";
            public const string GET_EMPLOYEE_BY_LOCAL_EMPID = "GetEmployeeByLocalTADAEmpId";
            public const string GET_STUDENT_LIST_WITH_DETAILS = "GetStudentListWithDetails";
            public const string GET_ADMISSION_FORM_DETAILS = "GetAdmissionFormDetails";
            public const string GET_ALL_GRADE_POLICY = "GetAllGradePolicy";
            public const string GET_APPLICATION_DATA_BY_CODE = "GetApplicationDataByCode";
            public const string GET_ALL_ADMISSION_CIRCULAR = "GetAllAdmissionCircular";
            public const string GET_EXAM_TYPE_BY_ADMISSION_REFERENCE_ID = "GetExamTypeByAdmissionReferenceId";
            public const string GET_ALL_ADMISSION_REF = "GetAllAdmissionRef";
            public const string GET_DATA_FOR_ADMISSION_FORM_DETAILS = "GetDataForAdmissionFormDetails";
            public const string GET_COURSE_BY_PROGRAM = "GetCourseByProgram";
            public const string GET_COURSE_BY_PROGRAM_EXAMDATE = "GetCourseByProgramAndExamDate";
            public const string GET_COURSE_ASSIGN_BY_FILTER = "GetCourseAssignByFilter";
            public const string GET_EXAM_LOOKUP_DETAILS_ID_BY_TYPE = "GetExamLookUpDetailsIdByType";
            public const string GET_EXAM_NAME_BY_CATEGORY = "GetExamNameByCategory";
            public const string GET_ROOM_FOR_CLASS_ROUTINE = "GetRoomForClassRoutine";
            public const string GET_TOP_2_MARK_FILTER_WISE = "GetTop2MarkFilterWise";
            public const string GET_ALL_APPLICANT_ELIGIBLE_CRITERIA = "GetAllApplicantEligibleCriteria";
            public const string GET_TEACHER_ASSIGN_LIST_BY_ID = "GetTeacherAssignListById";
            public const string GET_TEACHERLIST_BY_COURSEID = "GetTeacherListByCourseId";
            public const string GET_SCRUITINIZER_LIST_BY_COURSEID = "GetScruitinizerListByCourseId";
            public const string GET_CA_DATA_FROM_MARK_ENTRY_TABLE = "GetCADataFromMarkEntryTable";
            public const string GET_COURSE_ASSIGN_BY_ACADEMIC_SEMESTER = "GetCourseAssignByAcademicSemester";
            public const string GET_ADVISER_LIST = "GetAdviserList";
            public const string GET_SESSION_FROM_SCRIPT_ALLOCATION_BY_EMPID = "GetSessionFromScriptAllocationByEmpId";
            public const string GET_ACADEMIC_SEMESTER_FROM_SCRIPT_ALLOCATION_BY_EMPID = "GetAcademicSemesterFromScriptAllocationByEmpId";
            public const string GET_FACULTY_FROM_SCRIPT_ALLOCATION_BY_EMPID = "GetFacultyFromScriptAllocationByEmpId";
            public const string GET_DEPARTMENT_FROM_SCRIPT_ALLOCATION_BY_EMPID = "GetDepartmentFromScriptAllocationByEmpId";
            public const string GET_PROGRAM_FROM_SCRIPT_ALLOCATION_BY_EMPID = "GetProgramFromScriptAllocationByEmpId";
            public const string GET_COURSE_FROM_SCRIPT_ALLOCATION_BY_EMPID = "GetCourseFromScriptAllocationByEmpId";
            public const string GET_PART_BY_EMP_ID = "GetPartByEmpId";
            public const string GET_OBJECT_FOR_ATTENDANCE_DISPLAY_VARIABLE = "GetObjectForAttendanceDisplayVariable";
            public const string GET_OBJECT_FOR_ROOMWISESTUDENT_DISPLAY_DATA = "GetObjectForRoomwiseStudentDisplayData";

            public const string GET_STUDENT_COURSE_CURRICULUM_DETAILS = "GetStudentCourseCurriculumDetails";
            public const string GET_TF_MARK_APPROVAL_LIST_BY_FILTER_DATA = "GetTFMarkApprovalListByFilter";
            public const string GET_EXAM_DATE_BY_FILTER = "GetExamDateByFilter";
            public const string GET_FACULTY_FROM_TEACHER_ROLE_ASSIGN_BY_EMPID = "GetFacultyFromTeacherRoleAssignByEmpId";
            public const string GET_Department_FROM_TEACHER_ROLE_ASSIGN_BY_EMPID = "GetDepartmentFromTeacherRoleAssignByEmpId";
            public const string GET_Program_FROM_TEACHER_ROLE_ASSIGN_BY_EMPID = "GetProgramFromTeacherRoleAssignByEmpId";

            public const string GET_AFFILIATION_WISE_USER = "GetAffiliationWiseUser";
            #region Study Board
            public const string GET_All_STUDY_BOARD = "GetStudyBoardList";
            public const string GET_STUDY_BOARD_BY_ID = "GetStudyBoardById";
            public const string GET_STUDY_BOARD_BY_FILTER = "GetStudyBoardListByFilter";
            public const string GET_STUDY_BOARD_BY_STUDENT_ID = "GetStudyBoardListByStudentId";
            #endregion

            public const string GET_All_COURSE = "GetCourseList";
            public const string GET_FILTER_COURSE_LIST = "GetFilterCourseList";
            public const string GET_All_AdmsFormConfig = "GetAllAdmsFormConfig";
            public const string GET_RegFormConfig_By_Id = "GetRegFormConfigById";
            public const string GET_All_MigrationConfig = "GetAllMigrationConfig";
            public const string GET_MigrationConfig_By_Id = "GetMigrationConfigById";
            public const string GET_REG_FROM_CONFIG_LIST = "GetRegFormConfigList";
            public const string GET_All_CANCEL_FormConfig_BY_ID = "GetAllCancelFormConfigById";
            public const string GET_All_CANCEL_FORMCONFIG_lIST = "GetAllCancelFormConfigList";
            public const string GET_All_BATCH = "GetBatchList";

            public const string GET_ALL_BANK_BRANCH_INFO = "GetAllBankBranchInfo";

            public const string GET_All_FACULTY = "GetAllFaculty";
            public const string GET_All_FACULTY_FOR_DROPDOWN = "GetAllFacultyForDropdown";
            public const string GET_All_PROGRAM = "GetAllProgram";
            public const string GET_All_PROGRAM_BY_ID = "GetAllProgramById";
            public const string GET_All_PROGRAM_BY_REF = "GetAllProgramByRef";
            public const string GET_TECHER_ASSIGN = "GetTeacherAssign";
            public const string GET_PROGRAM_BY_DEPT = "GetAllProgramByDept";
            public const string GET_PROGRAM_BY_DEPT_FOR_DROPDOWN = "GetAllProgramByDeptForDropdown";
            public const string GET_Batch_BY_ID = "GetBatchById";
            public const string GET_COURSE_BY_ID = "GetCourseById";
            public const string GET_ALL_ADMIT_CARD_ENABLE = "GetAllAdmitCardEnables";
            public const string GET_ADMIT_CARD_ENABLE_BY_ID = "GetAdmitCardEnablesById";
            public const string GET_All_COURSE_BY_DEPT_YEAR = "GetCourseListByDeptYear";
            public const string GET_COURSE_BY_FILTER = "GetCourseListByFilter";
            public const string GET_BATCH_BY_FILTER = "GetBatchListByFilter";
            public const string GET_STUDENT_ATTENDANCE_LIST = "GetStudentAttendanceList";
            public const string GET_STUDENT_ATT_COURSE_LIST = "GetStudentCourseList";
            public const string GET_STUDENT_COURSE_LIST_BY_FILTER = "GetStudentCourseListByFilter";
            public const string GET_COURSE_BY_SUB_EXAM = "GetCoursesBySubExamId";
            public const string GET_ACADEMIC_YEAR_BY_ID = "GetSessionById";
            public const string GET_ALL_ACADEMIC_YEAR = "GetAllSession";
            public const string GET_ALL_TEACHER_ASSIGN_ROLE = "GetAllTeacherRoleAssign";
            public const string GET_STUDENT_COURSE_Assign_LIST_BY_FILTER = "GetStudentCourseAssignList";
            public const string GET_ADVISER_COURSE_CONFIRM_LIST_BY_FILTER = "GetAdviserCourseConfirmList";
            public const string GET_STUDENT_COURSE_LIST_BY_ID_FILTER = "GetStudentCourseListById";
            public const string GET_COORDINATOR_APPROVAL_LIST_BY_FILTER = "GetCoordinatorApprovalList";
            public const string GET_COUR_MARK_ENTRY_DASHBOARD = "GetCourMarkEntryDashBoard";
            public const string GET_COUR_MARK_DASHBOARD = "GetCourMarkDashBoard";
            public const string GET_EXAM_STATUS_DASHBOARD = "GetExamStatusDashBoard";
            public const string GET_EXAM_PAPER_STATUS_DASHBOARD = "GetExamPaperStatusDashBoard";
            public const string GET_EXAM_MEETING_STATUS_DASHBOARD = "GetExamMeetingStatusDashBoard";
            public const string SAVE_Examiner_BY_SP = "Insert_Examiner";
            public const string GET_DEPT_BY_ID = "GetDepartmentById";
            public const string GET_ALL_DEPT = "GetAllDepartment";
            public const string GET_ALL_Previous_DEPT = "GetAllPreviousDepartment";
            public const string GET_DEPT_BY_FACULTY = "GetDeptByFaculty";
            public const string GET_DEPARTMENT_BY_OFFICE = "GetDepartmentByOffice";
            public const string GET_DEPT_BY_FACULTY_FOR_DROPDOWN = "GetDeptByFacultyForDropdown";
            public const string GET_STUDENT_COURSE_LIST = "GetStudentCourseListForReport";
            public const string GET_EMP_COURSE_ASSIGN_MARK_ENTRY = "GetEmpCourseAssignMarkEntry";
            public const string GET_EMP_COURSE_ASSIGN_STUDENT_ATTENDANCE = "GetEmpCourseAssignStuAtt";
            public const string GET_LOOKUP_WITH_PARENT = "GetLookupWithParent";
            public const string GET_FILTER_LOOKUPDETAIL_PARENT_BY_LOOKUPID = "GetFilterLookupDetailParentByLookupId";

            public const string GET_All_STUDENT = "GetStudentList";
            public const string GET_STUDENT_PROFILE_INFO = "GetStudentProfileInfo";
            public const string GET_STUDENT_INFO_BY_ID = "GetStudentInfoById";
            public const string GET_STUDENT_FEES_BY_ID = "GetStudentFeesById";
            public const string GET_STUDENT_RESULT_BY_ID = "GetStudentResultById";
            //demo
            public const string GET_STUDENT_RESULT_BY_ID_Test = "GetStudentResultByIdTest";
            //
            public const string GET_STUDENT_DASHBOARD_BY_ID = "GetStudentDashboardById";
            public const string GET_STUDENT_MIGRATION_BY_ID = "GetStudentMigrationById";
            public const string GET_STUDENT_CANCEL_BY_ID = "GetStudentCancelById";
            public const string GET_STUDENT_FOR_EXPEL_BY_ID = "GetStudentForExpelById";
            public const string GET_FOR_TYPEHEAD = "GetForTypehead"; //Type Head
            public const string GET_FOR_TYPEHEAD_STUDENTID = "GetForTypeheadStudentId"; //Type Head

            public const string GET_FILTER_STUDENTS_FOR_FEESBOOK = "GetStudentsForFeesBook"; //With Session-Program-Dept-Year
            public const string GET_FILTER_STUDENTS = "GetFilterStudents"; //With Session-Program-Dept-Year
            public const string GET_FEESDUE_STUDENTS = "GetFeesDueStudents"; //With Session-Program-Dept-Year
            public const string GET_FILTERED_STUDENT = "GetFilteredStudentList"; //With Program
            public const string GET_STUDENTLIST_BY_FILTER = "GetStudentListByFilter"; // Without Program
            public const string GET_STUDENT_SUMMARY_LIST_BY_FILTER = "GetStudentSummaryList"; // With Session - Faculty - Department - Status
            public const string GET_EXPELLED_STUDENTLIST_BY_FILTER = "GetFilteredExpelledStudentList";

            public const string GET_STUDENTS_FOR_HALL_CLEARANCE = "GetStudentsForHallClearance";
            public const string GET_STUDENTS_FOR_LIBRARY_CLEARANCE = "GetStudentsForLibraryClearance";
            public const string DELETE_CLEARANCE_BY_STUDENT_ID = "DeleteClearanceByStudentId";
            public const string DELETE_ROLEWISEMENU_BY_ID = "DeleteRoleWiseMenuById";


            public const string GET_STUDENT_ROUTINE_FOR_PORTAL = "GetStudentRoutineForPortal";
            public const string GET_STUDENT_FEES_BY_STUDENT = "GetStudentFeesByStudent";
            public const string GET_STUDENTLIST_BY_ACADEMIC_YEAR_DEPT = "GetStudentListBySessionDept";
            public const string GET_STUDENTLIST_BY_YEAR_DEPT = "GetStudentListByYearDept";
            public const string GET_STUDENTLIST_FOR_MARKS = "GetStudentListForMarkEntry";
            public const string GET_STUDENTLIST_Result = "GetStudentListForResult";
            public const string GET_STUDENTLIST_RESULT_FOR_REPORT = "GetStudentListForResultForReport";
            public const string GET_COURSEWISE_FAIL_RESULT_FOR_REPORT = "GetCourseWiseFailResultForReport";
            public const string GET_STUDENTLIST_FOR_ADMIT_CARD = "GetStudentListForAdmitCard";
            public const string GET_STUDENT_ADMIT_CARD = "GetStudentAdmitCard";
            public const string GET_STUDENT_INFO_FOR_FORM_FILLUP = "GetStdInfoForFormFillup";

            public const string ASSIGN_STUDENT_COURSE = "ProccesStudentCourse";
            public const string GET_STUDENTLIST_FOR_Attendance = "GetStudentListForAttendanceEntry";
            public const string GET_NEW_STUDENTID = "GetNewStudentID";

            public const string DELETE_MAINEXAMMARKS = "DeleteSubExamMarks";
            public const string SAVE_ALL_SUBEXAM_MARK = "SaveAllSubExamMarksEntry";
            public const string DELETE_ACADEMICCALENDAR = "DeleteAcademicCalendar";
            public const string DELETE_STUDENT_ATTENDANCE = "DeleteStudentAttendance";
            public const string DELETE_EXAMATTMARKS = "DeleteExamAttMarks";


            public const string GET_LOOKUPDETAIL_LIST_WITH_LOOKUP = "GetLookupDetailListWithLookup";


            public const string GET_USER_BY_EMAIL = "GetUserByEmail";
            public const string GET_USER_BY_ID = "GetUserById";
            public const string UPDATE_USER = "UpdateUser";

            #region Employee
            public const string GET_All_EMPLOYEE = "GetAllEmployee";
            public const string GET_EMPLOYEE_INFO_BY_ID = "GetEmployeeInfoById";
            public const string GET_EMPLIST_BY_DEPT = "GetEmpListByDept";
            public const string GET_EMP_DESIG_BY_ID = "GetEmpDesigById";
            public const string GET_EMP_DESIG_List = "GetEmpDesigList";
            public const string GET_FILTERED_EMPLOYEE = "GetFilteredEmpList";
            public const string GET_EMPLOYEE_BY_TYPEHEAD = "GetForTypeheadEmployeeId";
            public const string GET_FILTERED_TEACHER = "GetFilteredTeacherList";
            public const string GET_FILTERED_COURSE_TEACHER = "GetCourseTeacherListByFilter";
            public const string GET_CourseTeacher_Assign = "GetCourseTeacherAssignList";
            public const string GET_RPT_CourseTeacher_Assign = "GetRptCourseTeacherAssignList";
            public const string GET_EXAMINER_FOR_PAPER_ASSIGN = "GetExaminerListForPaperAssign";
            public const string GET_COURSE_TEACHER_ASSIGN_REPORT = "rptGetEmpCourseAssignMarkEntry";
            public const string GET_ALL_DISTRICT = "GetAllDistrict";
            public const string GET_ALL_UPAZILA = "GetAllUpazila";

            public const string GET_ALL_LEAVETYPE = "GetAllLeaveType";
            //External Teacher
            public const string GET_All_EXTERNAL_TEACHER = "GetAllExtTeacher";
            public const string GET_EXTERNAL_TEACHER_INFO_BY_ID = "GetExtTeacherInfoById";
            public const string GET_FILTERED_EXTERNAL_TEACHER = "GetFilteredExtTeacherList";
            public const string GET_EXTTEACHERLIST_BY_DEPT = "GetExtTeacherListByDept";
            public const string GET_EMPLOYEE_EDUCATIOIN_LIST = "GetEmployeeEducationList";
            #endregion


            #region Exam
            public const string GET_ALL_EXAM_ADMIT_CARD = "GetAllExamAdmitCard";
            public const string GET_EXAM_ADMIT_CARD = "GetExamAdmitCard";
            public const string GET_ALL_EXAM_ADMIT_CARD_FOR_PRINT = "GetAllExamAdmitCardForPrint";
            public const string GET_FILTER_BY_STUDENT_COUNT = "GetFilterStudentCount";
            public const string GET_ALL_EXAM_ADMIT_CARD_FOR_DELETE = "GetAllExamAdmitCardForDelete";
            public const string GET_Exam_BY_ID = "GetExamById";
            public const string GET_Exam_DETAILS_BY_ID = "GetExamDetailsById";
            public const string GET_ROLE_WISE_MENU = "GetRoleWiseMenuById";
            public const string GET_All_Exam = "GetAllExamList";
            public const string GET_All_Examiner = "GetAllExaminerList";
            public const string GET_All_ExaminerByExamcourse = "GetAllExaminerListByFilter";
            public const string GET_All_SubExam = "GetAllSubExamList";
            public const string GET_All_SubExamMarkSetup = "GetAllSubExamMarkSetupList";
            public const string GET_EXAM_COMMITTEE_LIST = "GetExamCommitteeList";
            public const string GET_FILTERED_EXAM = "GetExamByFilter";
            public const string GET_FILTERED_COURSE = "GetFilteredCourseList";
            public const string GET_EXAMLIST_BY_FILTER = "GetExamListByFilter";
            public const string GET_SUBEXAM_BY_EXAMID = "GetSubExamByExamId";
            public const string GET_SUBEXAMLIST_BY_SEARCH_FILTER = "GetSubExamListByFilter";
            public const string GET_SUBEXAM_MARKLIST_FOR_REPORT = "GetSubExamMarkListForReport";
            public const string GET_SUBEXAM_BY_ID = "GetSubExamById"; //by id
            public const string GET_EXAMINERLIST_BY_FILTER = "GetExaminerListByFilter";
            public const string GET_EXAMINER_BY_ID = "GetExaminerById"; //by id
            public const string COUSEWISE_PROCESS = "CourseWiseResultProcess";
            public const string EXAMWISE_PROCESS = "AcademicSemesterWiseResultProcess";
            public const string RETAKE_EXAM_WISE_RESULT_PROCESS = "RetakeExamWiseResultProcess";
            public const string ASSIGN_EXAM_PAPER = "AssignExamPaper";
            public const string SUBMIT_EXAM_PAPER = "SubmitExamPaper";
            public const string GET_EXAM_RESULT_FOR_REPORT = "GetExamResultForReport";
            public const string GET_ACADEMIC_TRANSCRIPT = "GetAcademicTranscript";
            public const string GET_TABULATION_SHEET = "GetTabulationSheet";
            public const string GET_MARKS_ENTRY_REPORT = "GetMarksEntryReport";
            public const string GET_PROMOTION_LIST = "GetPromotionList";
            public const string GET_PENDING_PROMOTION_LIST = "GetPendingStudentPromotionList";
            public const string INSERT_StudentPromotionHistory = "InsertStudentPromotionHistory";
            public const string UPDATE_StudentPromotionList = "UpdateStudentPromotionList";
            public const string GET_TABULATION_SHEET_Individual = "GetTabulationSheet_Individual";
            public const string GET_GRADE_POLICY_LIST = "GetGradePolicyList";
            public const string GET_FILTER_GRADE_DETAIL_BY_ID = "GetFilterGradeDetailById";
            public const string GET_ALL_BUILDING_INFO = "GetAllBuildingInfo";
            public const string GET_FILTER_INVIGILATOR_LIST = "GetFilterInvigilatorList";
            public const string GET_INVIGILATOR_LIST_BY_ROOM = "GetInvigilorListByRoom";
            public const string GET_EXAM_DATE_EXIST = "GetExamDateExist";
            public const string GET_FILTER_INVIGILATOR_BY_STDDISTRIBUTEID = "GetFilterInvigilatorByStdDistributionId";
            public const string GET_ALL_INVIGILATOR_LIST = "GetAllInvigilatorList";
            public const string GET_EXAM_LOOKUP_WITH_PARENT = "GetExamLookupWithParent";
            public const string GET_ALL_EXAM_LOOKUP_DETAIL = "GetAllExamLookupDetail";
            public const string GET_EXAM_LOOKUP_DETAIL_PARENT_BY_LOOKUPID = "GetExamLookupDetailParentByLookupId";
            public const string GET_EXAM_LOOKUP_DETAIL_BY_LOOKUPID = "GetExamLookupDetailByLookupId";
            public const string GET_EXAM_LIST_FOR_CA_MARK_ENTRY_FORM = "GetExamListForCAMarkEntryForm";
            public const string GET_EXAM_CONTROLLER_OFFICE_REPORT_FOOTER = "GetControllerOfficeReportFooter";
            public const string CHECK_MARK_ENTRY_STATUS_LIST_COURSE_WISE = "CheckMarkEntryStatusListCourseWise";
            public const string CHECK_CA_MARK_ENTRY_STATUS = "CheckCaMarkEntryStatus";
            public const string GET_EMPLOYEE_ATTENDANCE_DETAILS_LIST = "GetEmployeeAttendanceDetails";
            public const string GET_EMPLOYEE_ATTENDANCE_DETAILS_LIST_APPS = "GetEmployeeAttendanceDetailsApps";

            public const string GET_BATCH_FROM_SCRIPT_ALLOCATION_BY_EMP_ID = "GetBatchFromScriptAllocationByEmpId";
            public const string GET_COURSEDETAILS_FROM_TECHER_ASSIGN_BY_EMP_ID = "GetCourseDetailsFromTeacherAssignByEmpId";
            public const string GET_COURSE_DETAILS_FOR_MARK_ENTRY_PAGE = "GetCourseDetailsForMarkEntryPage";
            public const string GET_COURSE_LIST_WITH_DETAILS_FROM_SACT_BY_EMP_ID_ROLE_TYPE_ID = "GetCourseListWithDetailsFromSACTByEmpIdAndRoleTypeId";

            #region Report Download History
            public const string GET_REPORT_DOWNLOAD_HISTORY_BY_EXAM_ID = "GetReportDownloadHistoryByExamId";
            public const string REPORT_DOWNLOAD_HISTORY = "GetReportDownloadHistoryByExamStudentId";
            public const string REPORT_DOWNLOAD_HISTORY_BY_FILTER = "GetReportDownloadHistoryByFilter";
            #endregion 
            //for filter
            public const string GET_EXAM_BY_FILTER = "GetExamListForFilter";
            public const string GET_EXAM_SETUP_BY_FILTER = "GetExamSetupListForFilter";
            public const string GET_MARK_DISTRIBUTION_BY_SEMESTER = "GetMarkDistributionBySemester";
            public const string GET_CA_MARK_APPROVAL_BY_FILTER = "GetCAMarkApprovalForFilter";
            public const string GET_EXAM_CONTROLLER_OFFICE_MARK_VERIFY_BY_FILTER = "GetExamControllerOfficeMarkVerify";
            public const string GET_ROOMWISE_STUDENT_DISTRIBUTION_BY_FILTER = "GetRoomwiseStudentDistribution";
            public const string EXAM_COMMITTEE_BY_FILTER = "ExamCommitteeListByFilter";
            public const string EXAM_COMMITTEE_MEMBER_LIST_BY_ID = "ExamCommitteeMemberListById";
            public const string GET_EXAM_MEETING_LIST_BY_FILTER = "GetExamMeetingListByFilter";
            public const string GET_EXAM_MEETING_BY_ID = "GetExamMeetingById";
            public const string GET_EXAM_COMMITTEE_BY_ID = "GetExamCommitteeById";
            public const string GET_EXAM_COMMITTEE = "GetExamCommittee";
            public const string Get_AllSubExamMarkSetupList_ById = "GetAllSubExamMarkSetupListById";
            public const string GetStudentListForFinalMarkEntry = "GetStudentListForFinalMarkEntry";

            public const string GET_RETAKE_STUDENT_LIST = "GetRetakeStudentList";
            public const string GET_ENROLL_TEACHER_LIST = "GetEnrollTeacherList";
            public const string GET_ALL_SUBEXAM_MARKS_ENTRY = "GetAllSubExamMarksEntry";
            public const string GET_EXAM_COMMITTEE_MEMBER_LIST = "GetExamCommitteeMemberList";
            public const string GET_MEMBER_LIST_BY_COMMITTEE_ID = "GetMemberListByCommitteeId";
            public const string MARK_SETUP_REPORT = "MarkSetupReport";

            #endregion

            #region Fees
            public const string GET_FEES_HEAD = "GetAllFeesHead";
            public const string GET_ALL_FEES_PROCESS_CONFIG = "GetAllFeesProcessFormList";
            public const string GET_ALL_FEES_CONFIG = "GetAllFeesConfig";
            public const string GET_FEES_PROCESS_CONFIG_LIST = "GetFeesProcessConfigList";
            public const string GET_FEES_PROCESS_LIST_BY_FILTER = "GetFeesProcessListByFilter";
            public const string PROCESS_FEES = "ProcessFees";
            public const string PROCESS_FEES_MODIFICATION = "FeesProcessModification";
            public const string PROCESS_FEES_MODIFICATION_QUERY = "FeesProcessModificationQuery";
            public const string CLEAR_PROCESS_FEES = "ClearProcessFees";
            public const string APPROVE_PROCESS_FEES = "ApproveProcessFees";
            public const string MAKE_PAYMENT_PROCESS_FEES = "MakePaymentProcessFees";
            public const string GET_MONEY_RECEIPT_LIST = "GetMoneyReceiptNoList";
            public const string GET_PRINT_MONEY_RECEIPT_LIST = "GetPrintMoneyReceipList";
            public const string GET_COLLECTION_FOR_ROLLBACK = "GetColletionForRollback";
            public const string GET_FILTERED_FEESHEAD = "GetFilteredFeesHeadList";
            public const string GET_All_FEESHEAD_CONFIG = "GetFeesHeadConfigList";
            public const string GET_FEESHEAD_CONFIG_BY_FILTER = "GetFeesHeadConfigListByFilter";
            public const string GET_FEES_FOR_COLLECTION = "GetFeesForCollection";
            public const string GET_FEESDUE_FOR_MODIFY = "GetFeesDueForModify";
            public const string GET_STUDENT_FOR_FEES_COLLECTION = "GetStudentForFessCollection";
            public const string GET_FILTERED_FEESPROCESS_SETUP = "GetFilteredFeesProcessSetups";
            public const string GET_FEESPROCESS_SETUP_BY_ID = "GetFeesProcessSetupById";
            public const string DELETE_HEADAMOUNT_CONFIG = "DeleteHeadAmountConfig";
            public const string GET_FEES_REPORT = "GetFeesReport";
            public const string GET_FEES_MONEY_RECEIPT_REPORT = "GetFeesMoneyReceiptReport";
            public const string GET_FEES_BOOK = "GetFeesBook";
            public const string UPDATE_FEES_STUDENT_MODIFY = "UpdateFeesStudentModify";
            public const string FEES_PAYMENT_HISTORY = "PaymentHistory";
            public const string FEES_MONEY_RECEIPT = "PortalMoneyReceipt";
            public const string GET_ALL_APPLICATION_FEES = "GetAllApplicationFees";
            public const string APPLICATION_INITAIL_FEE_PROCESS = "ApplicationInitialFeesProcess";
            public const string APPLICATION_FINAL_FEE_PROCESS = "ApplicationFinalFeesProcess";
            public const string GET_APPLICATION_FEE_PAYMENT_LIST = "GetApplicationFeePaymentList";
            #endregion

            #region Attendance
            public const string GET_STUDENT_ATTENDANCE_SUMMARY_REPORT = "GetStudentAttendanceSummaryReport";
            public const string GET_STUDENT_ATTENDANCE_DETAILS_REPORT = "GetStudentAttendanceDetailsReport";
            public const string GET_ATTENDANCE_REPORT = "GetAttendanceReport";
            public const string GET_STU_CURR_SUMMARY = "GetStuCurrentSummary";
            public const string GET_PAPER_ASSIGN_REPORT = "GetPaperAssignReport";
            #endregion

            #region Admission

            public const string GET_ALL_SUBJECT = "GetAllSubject";
            public const string GET_ALL_AdmsDocUp = "GetAllAdmsDocUp";
            public const string GET_ALL_RESULT_GRADE = "GetAllResultGrade";

            #endregion

            public const string GET_PORTAL_USER_LIST = "GetPortalUserList";
            public const string PORTAL_COURSE_EXAM_DETAILS = "PortalCourseExamDetails";
            public const string GET_ALL_TEST_CONFIG_WITH_DETAILS = "GetAllTestConfigWithDetails";
            public const string GET_ALL_TEST_CONFIG = "GetAllTestConfig";
            public const string GET_ALL_TEST_CONFIG_DETAILS = "GetAllTestConfigDetails";
            public const string GET_ALL_TEST_CONFIG_DETAILS_BY_TEST_ID = "GetAllTestConfigDetailByTestId";
            public const string GET_APPLICANT_LIST = "GetApplicantList";
            public const string GET_ALL_ELIGIBLE_LIST = "GetAllEligibleList";
            public const string GET_ALL_ELIGIBLE_LIST2 = "GetAllEligibleList2";

            public const string GET_LOOKUP_LIST = "GetLookupList";
            public const string GET_EXAM_LOOKUP_LIST = "GetExamLookupList";
            public const string GET_FINANCE_LOOKUP_LIST = "GetFinanceLookupList";
            public const string GET_All_APPLICANT_ADMIT_CARD = "GetAllApplicantAdmitCard";
            public const string GET_ADMISSION_TEST_SEAT_TAG = "GetAdmissionTestSeatTag";
            public const string GET_ADMISSION_TEST_SEAT_PLAN = "GetAdmissionTestSeatPlan";
            public const string GET_FILTER_ROOM_BY_FLOORID = "GetFilterRoomByFloorId";
            public const string GET_DETAIL_BY_PARENTID = "GetDetailByParentId";
            public const string GET_EXAM_DETAIL_BY_PARENTID = "GetExamDetailByParentId";
            public const string GET_COURSEWISE_STUDENT = "GetCourseWiseStudentList";
            public const string GET_COURSEWISE_ALL_STUDENT = "GetCourseWiseAllStudentList";
            public const string GET_ROOMWISE_STUDENT_DISTRIBUTION_LIST = "GetRoomwiseStudentDistributionList";
            public const string GET_COURSEWISE_ALL_STUDENTROLL = "GetCourseWiseAllStudentList";
            public const string GET_APPLICANT_BY_ID = "GetApplicantById";
            public const string GET_COURSEWISE_STUDENT_ROLL = "GetCourseWiseStudentRoll";
            public const string GET_ROLL_FROM_GENERAL_FORM = "GetRollFromGeneralForm";
            public const string GET_ROLL_FROM_EXAM_SEATS = "GetRollFromExamSeats";
            public const string GET_OBJECT_FOR_STUDENT_INFO_DATA = "GetObjectForStudentInfoData";

            #region Menu /Application
            public const string GET_ALL_MENU_LIST = "GetAllMenuList";
            public const string GET_ALL_MENU_LIST_WITH_CONCATE = "GetAllMenuListWithConcat";
            public const string GET_ALL_MENU_LIST_URL = "GetAllMenuListUrl";
            public const string GET_ALL_APPLICATION_USER_LIST = "GetAllApplicationUserList";
            public const string GET_ALL_APPLICATION_USER_EMP_LIST = "GetAllApplicationUserEmpList";
            #endregion

            #region  Approval Key

            public const string GET_ALL_APPROVALKEY_LIST = "GetAllApprovalKeyList";
            public const string GET_APPKEY_LIST_BYUSER = "GetAppKeyListByUser";
            public const string UPDATE_APPROVALKEY_BYID = "UpdateApprovalKeyById";

            #endregion

            #region Admin
            public const string GET_ROLE_LIST = "GetRoleList";
            public const string GET_MENU_LIST = "GetMenuList";
            public const string GET_MENU_LIST_BYROLEID = "GetMenuListByRoleId";
            public const string INSERT_MENU_ASSIGN = "InsertMenuAssign";
            public const string DELETE_MENU_ASSIGN = "DeleteMenuAssign";

            public const string GET_ROLE_LIST_BYUSERID = "GetRoleListByUserId";
            public const string GET_USER_LIST = "GetUserList";
            public const string DELETE_ROLE_ASSIGN = "DeleteRoleAssign";
            public const string INSERT_ROLE_ASSIGN = "InsertRoleAssign";
            public const string GET_MODULE_LIST_BYUSER = "GetModuleListByUser";
            public const string GET_MENUGROUP_LIST_BYUSER = "GetMenuGroupListByUser";
            public const string GET_MENU_LIST_BYUSER = "GetMenuListByUser";
            public const string GET_PAGE_TITLEURL_BYID = "GetPageTitleUrlById";
            public const string GET_PAGE_EDIT_TITLE_BYID = "GetPageEditTitleById";
            public const string GET_JASPARSERVER_USERNAMEPASSURL = "GetJasparReportUserNamePassUrl";
            public const string GET_REPORT_MASTER_LIST = "GetAllReportMasterListData";
            public const string GET_PARAMETER_INFO_LIST_BY_REPORT_ID = "GetParameterInfoListBYReportId";
            public const string GET_DROPDOWNDAT_FOR_REPORT = "GetDropdownDataForReport";
            public const string GET_ALL_APPROVAL_CONFIG = "GetAllApprovalConfig";
            public const string INSERT_APPKEY_ASSIGN = "InsertAppkeyAssign";
            public const string GET_DETAIL_LIST_BYAPPKEYID = "GetDetailListByAppKeyId";
            public const string GET_SUB_LIST_BYAPPKEYID = "GetSubListByAppKeyId";
            public const string GET_USER_LIST_BY_APPKEY = "GetUserListByKeyId";
            public const string INSERT_APPKEY_CONFIG = "InsertAppkeyConfig";



            #endregion
            #region Admission Result
            public const string GET_EXCEL_MARK_ENTRY = "GetExcelMarkEntry";
            public const string GET_Admission_MARK = "GetAdmissionMark";
            public const string BULK_ADMISSION_RESULT = "BulkAdmissionResult";
            public const string DELETE_ADMISSION_MARK = "DeleteAdmissionMark";
            public const string GET_ADMISSION_RESULT = "GetAdmissionResult";
            public const string ADMISSION_EXAM_PROCESS = "AdmissionResultProcess";
            public const string GET_ADMISSION_MERIT_LIST = "GetAdmissionMeritList";
            public const string GET_RPT_APPLICANT_LIST = "GetRptApplicantList";
            public const string GET_PROCESS_SETUP_LIST = "GetProcessSetupList";
            public const string GET_PROCESS_STUDENT_LIST = "GetProcessStudentList";

            #endregion

            #region ClassManagement
            public const string GET_ALL_PeriodSetup = "GETALLPeriodSetup";
            public const string GET_PeriodSetup_BY_ID = "GetPeriodSetupById";
            public const string GET_ALL_PeriodConfig = "GETALLPeriodConfig";
            public const string GET_PeriodConfig_BY_ID = "GetPeriodConfigById";
            public const string GET_ALL_CLASS_ROUTINE = "GetAllClassRoutine";
            public const string GET_ClassRoutine_BY_ID = "GetClassRoutineById";
            public const string GET_RANGE_DATE = "GetRangeDate";
            public const string GET_ALL_CALENDAR = "GetAllCalendar";
            public const string GET_CALENDAR_BY_ID = "GetCalendarById";
            public const string INSERT_INTO_ACADEMIC_CALENDAR_DETAILS = "InsertIntoAcademicCalenderDetails";
            public const string GET_FILTER_CALENDAR_DETAIL = "GetFilterCalendarDetail";
            public const string GET_ALL_CALENDAR_YEAR_MONTH = "GetAllCalendarYearMonth";
            public const string GET_ALL_CALENDAR_YEAR = "GetAllCalendarYear";
            public const string GET_ALL_STUDENT_LIST_FOR_ATTENDANCE = "GetAllStudentListForAttendance";
            public const string GET_ALL_EXAM_SCRIPT_ALLOCATION_BY_FILTER = "GetAllExamScriptAllocationByFilter";
            public const string GET_ALL_CT_EXAM_SCRIPT_ALLOCATION_BY_FILTER = "GetAllCTExamScriptAllocationByFilter";
            public const string Get_ALL_CLASS_ROUTINES = "GetAllClassRoutines";
            public const string Get_CLASS_ROUTINES_PREVIEW = "GetClassRoutinePreview";

            #endregion

            #region Exan Report
            public const string GET_CA_APPROVAL_DATA_BY_FILTER = "GetCAMarkApprovalDataForRpt";
            public const string GET_ESAS_INVIGILATOR_DATA_BY_FILTER = "GetESASInvigilatorDataForRpt";
            #endregion

            #region Finance
            public const string GET_ALL_APPLICATION_USER = "GetAllApplicationUser";
            public const string GET_ALL_ECONOMIN_CODE_ENTRY = "GetAllEconomicCodeEntry";
            public const string GET_BANK_ECONOMIC_CODE_ENTRY = "GetBankEconomicCodeEntry";
            public const string GET_ALL_DEPT_WISE_ECONOMIN_CODE_ENTRY = "GetAllDeptWiseEconomicCodeEntry";
            public const string GET_ALL_ECONOMIN_CODE_GROUP = "GetAllEconomicCodeGroup";
            public const string GET_ALL_ACC_ECON_CODE_DROP_DOWN = "GetAllEconAccGroupDropDown";
            public const string GET_BUDGET_WING = "GetBudgetWing";
            public const string GET_BUDGET_FACULTY_OFFICE = "GetBudgetFacultyOffice";
            public const string GET_BUDGET_DEPT_BRANCH = "GetBudgetDepartmentBranch";
            public const string GET_ALL_BUDGET_DEMAND = "GetAllBudgetDemand";
            public const string GET_ALL_QTR_BUDGET_DEMAND = "GetAllQtrBudgetDemand";
            public const string GET_ALL_BUDGET_DEMAND_DETAILS = "GetAllBudgetDemandDetails";
            public const string GET_ALL_BUDGET_QTR_DEMAND_DETAILS = "GetAllQtrBudgetDemandDetails";


            public const string GET_ALL_FUND_POSITION = "GetAllFundPosition";

            public const string GET_ALL_BUDGET_REALLOCATION = "GetAllBudgetReallocation";


            public const string GET_RADP_BUDGET_EXPENSE_DETAILS = "GetRadpBudgetExpenseDetails";
            public const string UPDATE_PROPOSED_BUDGET_DEMAND = "UpdateProposedBudgetDemand";
            public const string UPDATE_APPROVED_BUDGET_DEMAND = "UpdateApprovedBudgetDemand";
            public const string UPDATE_PROPOSEDBUDGET_DEMAND = "UpdateProposeBudgetDemand";
            public const string GET_ALL_JOURNAL_BY_FILTER = "GetAllJournalByFilter";
            public const string GET_ALL_BUDGET_TOP_SHEET = "GetAllBudgetTopSheet";
            public const string GET_INCOME_PROJECTION = "GetIncomeProjection";
            public const string GET_INCOME_PROJECTION_LIST = "GetIncomeProjectionList";
            public const string GET_FINANCE_LOOKUP_WITH_PARENT = "GetAllFinanceLookupWithParent";
            public const string GET_FINANCE_LOOKUP_DATAILS = "GetAllFinanceLookupDetail";
            public const string GET_FINANCE_LOOKUP_DETAIL_BY_LOOKUPID = "GetFinanceLookupDetailByLookupId";
            public const string GET_GROUP_WISE_JOURNAL_TYPE = "GetGroupWiseJournalType";
            public const string GET_GROUP_WISE_USER = "GetGroupWiseUser";
            public const string GET_BUDGET_USER_GROUP = "GetBudgetUserGroup";
            public const string GET_All_USER_BUDGET = "GetAllUserBudget";
            public const string GET_BUDGET_GROUP = "GetBudgetGroup";
            public const string GET_GROUP_WISE_ECONOMIC_ACCOUNT_CODE = "GetGroupWiseEconomicAccountCode";
            public const string DELETE_GROUP_WISE_ECONOMIC_ACCOUNT_CODE = "DeleteGroupWiseEconomicAccountCode";
            public const string GET_ADVANCE_REQUISITION = "GetAdvanceRequisition";
            public const string GET_ADVANCE_REQUISITION_INDIVIDUAL = "GetAdvanceRequisitionIndividual";
            public const string GET_ALL_ADVANCE_LOCAL_TADA = "GetAllAdvanceLocalTADA";
            public const string GET_ALL_CONFIRMED_LOCAL_TADA = "GetAllConfirmedLocalTADAOrders";
            public const string GET_ALL_VOUCHER_NO_WITH_EMPLOYEE = "GetAllVoucherNoWithEmployee";
            public const string GET_ALL_ADVANCE_FOREIGN_VOUCHER_NO_WITH_EMPLOYEE = "GetAllAdvanceForeignVoucherNoWithEmployee";
            public const string GET_ALL_FOREIGN_GROUP_WISE_CONTRY = "GetAllForeignGroupWiseCountry";
            public const string GET_SALARY_WISE_FOREIGN_ALLOWANCE = "GetSalaryWiseForeignAllowance";
            public const string INSERT_AUTO_JOURNAL_ENTRY = "InsertAutoJournalEntry";
            public const string GET_AUTO_JOURNAL_NUMBER = "GetAutoJournalNumber";
            public const string GET_TEMP_AUTO_JOURNAL_NUMBER = "GetTempAutoJournalNumber";
            public const string GET_GENERAL_BILL_ENTRY = "GetGeneralBillEntry";
            public const string GET_GENERAL_BILL_PAYMENT = "GetGeneralBillPayment";
            public const string GET_ALL_RECEIVE_ENTRY = "GetAllReceiveEntry";
            public const string GET_TOTAL_AMOUNT_FOR_RECEVE_BY_CLIENT = "GetTotalAmountForReceiveByClient";
            public const string GET_ALL_HONORARIUM = "GetAllHonorarium";
            public const string GET_ALL_HONORARIUM_BY_ID = "GetAllHonorariumById";
            public const string GET_ALL_HONORARIUMDETAILS_BY_MASTER = "GetAllHonorariumDetailsByMaster";
            public const string GET_ADVANCE_FOREIGN_TADA = "GetAdvanceForeignTADA";
            public const string GET_LIST_FOR_ADVANCE_FOREIGN_TADA = "GetListForAdvanceForeignTADA";
            public const string GET_DATA_FOR_FOREIGN_ADVANCE_TADA_PAYMENT = "GetDataForForeignAdvanceTADAPayment";
            public const string GET_DATA_FOR_LOCAL_TADA_PAYMENT = "GetDataForLocalTADAPayment";
            public const string GET_DATA_FOR_ADVANCE_LOCAL_TADA_PAYMENT = "GetDataForAdvanceLocalTADAPayment";
            public const string GET_DATA_FOR_FOREIGN_TADA_PAYMENT = "GetDataForForeignTADAPayment";
            public const string GET_ALL_CLIENT_INFO = "GetAllClientInfo";
            public const string GET_ALL_UNIVERSITY_INCOME_LIST = "GetUniversityIncomeList";
            public const string GET_ALL_BANK_BALANCE_ENTRIES = "GetAllBankBalanceEntries";
            public const string GET_ALL_JOURNAL_DETAIL_FOR_BANK_RECONCILIATION = "GetAllJournalDetailForBankReconciliation";
            public const string Get_All_FGO_WITH_NOTE_LIST = "GetAllFGOWithNoteList";
            public const string GET_EMPLOYEE_LOCAL_ORDERS = "GetEmployeeLocalOrders";
            public const string GET_AUTO_JOURNAL_DATA_PREVIEW = "GetEmpEcoClientNameById";
            public const string GET_ADVANCE_LOCAL_TADA_BY_ORDER_ID = "GetAdvanceLocalTADAByOrderId";
            public const string GET_EMPLOYEE_INFO_LOCAL_TADA_BY_ORDER_ID = "GetEmployeeInfoLocalTADAByOrderId";
            #endregion
            #region HR & Admin
            public const string GET_EMPLOYEE_CURRENT_PROGRESS_BY_ID = "GetEmployeeCurrentProgressById";
            public const string GET_EMPLOYEE_PREVIOUS_INFO_BY_ID = "GetEmployeePreviousInfoById";
            public const string GET_EMPLOYEE_CARRER_PROGRESS_INFO_BY_ID = "GetEmployeeCarrerPogressInfoById";
            public const string GET_ALL_BROKEN_MONTH_EMPLOYEE_BY_ID = "GetBrokenMonthEmployeeById";
            public const string GET_HRALOOKUP_WITH_PARENT = "GetHRALookupWithParent";
            public const string GET_ALL_HRALOOKUP_DETAIL = "GetAllHRALookupDetail";
            public const string GET_HRA_LOOKUP_DETAIL_BY_LOOKUPID = "GetHRALookupDetailByLookupId";
            public const string GET_HRA_LOOKUP_DETAIL_BY_PARENTID = "GetHRALookupDetailByParentId";
            public const string GET_ALL_EMPLOYEE_ELIGIBLE_CRITERIA = "GetAllEmployeeEligibleCriteria";
            public const string GET_HR_ADMIN_LOOKUP_LIST = "GetHRAdminLookupList";
            public const string GET_EMPLOYEE_APPLICANT_LIST = "GetEmployeeApplicantList";
            public const string GET_ALL_EMPLOYEE_APPLICANT_PREREQUISITE = "GetAllEmployeeApplicantPrerequisite";
            public const string GET_RECRUITMENT_EXAM_LIST = "GetRecruitmentExamList";
            public const string GET_ALL_RECRUITMENT_EXAM_ROOM = "GetAllRecruitmentExamRoom";
            public const string GET_RECRUITMENT_EXAM_MARK_ENTRY = "GetRecruitmentExamMarkEntry";
            public const string GET_FILTER_RECRUITMENT_APPLICANTS = "GetFilterRecruitmentApplicants";
            public const string GET_RECRUITMENT_MERIT_LIST = "GetRecruitmentMeritList";
            public const string GET_FACULTY_OFFICE_LIST = "GetFacultyOfficeList";
            public const string GET_GRADE_LIST_BY_RECRUITMENT_REF_ID = "GetGradeListByRecruitmentRefId";
            public const string GET_DEPARTMENT_SECTION_LIST = "GetDepartmentSectionList";
            public const string GET_SECTION_LIST_BY_BRANCH_ID = "GetSectionListByBranchId";
            public const string GET_BRANCH_BY_OFFICE_ID = "GetBranchByOfficeId";
            public const string GET_DEPARTMENT_SECTION_ALL_LIST = "GetDepartmentSectionAllList";
            public const string GET_OFFICE_BY_RECRUITMENT_REF_ID = "GetOfficeByRecruitmentRefId";
            public const string GET_BRANCH_BY_RECRUITMENT_REF_ID = "GetBranchByRecruitmentRefId";
            public const string GET_DESIGNATION_FROM_REF_DETAILS = "GetDesignationFromRefDetails";
            public const string GET_RECRUITMENT_APPLICANT_LIST = "GetRecruitmentApplicantList";
            public const string GET_CONFIRMED_RECRUITMENT_APPLICANT_LIST = "GetConfirmedRecruitmentApplicantList";
            public const string GET_FILTERED_EMPLOYEE_LIST = "GetFilteredEmployeeList";
            public const string GET_LEAVE_GROUP = "GetLeaveGroup";
            public const string GET_LEAVE_GROUP_MASTER = "GetLeaveGroupMaster";
            public const string GET_ALL_LEAVE_GROUP = "GetAllLeaveGroup";
            public const string GET_LEAVE_APPLICATION = "GetLeaveApplication";
            public const string GET_LEAVE_APPLICATION_BY_ID = "GetLeaveApplicationById";
            public const string GET_APPROVED_LEAVE_APPLICATION_BY_DATE = "GetApprovedLeaveApplicationrByDate";
            public const string GET_AVAILABE_LEAVE_BY_EMPLOYEE = "GetEmployeeAvailabeLeave";
            public const string GET_LEAVE_APPLICATION_BY_EMPLOYEE = "GetLeaveApplicationByEmployee";
            public const string GET_LEAVE_APPLICATION_SUMMARY = "GetLeaveApplicationSummary";
            public const string GET_LEAVE_APPLICATION_All_EMPLOYEE = "GetLeaveApplicationAllEmployee";
            public const string GET_LEAVE_DASHBOARD_APP = "GetLeaveDashboardApp";
            public const string GET_EMPLOYEE_BASIC_INFO_FOR_DROPDOWN = "GetEmployeeBasicInfoForDropDown";

            public const string GET_EMPLOYEE_INFO_FOR_DROPDOWN = "GetEmpInfoForDropDown";
            public const string GET_INDIVIDUAL_EMPLOYEE_INFO = "GetIndividualEmpInfo";
            

            public const string GET_TEAM_USERS_BY_TEAMID = "GetTeamUsersByTeamId";
            public const string GET_ALL_SHIFT_INFORMATION_WITH_WEEKENDS = "GetAllShiftInfoWithWeekends";
            public const string GET_ALL_CALEMDAR_SETUP_LIST = "GetAllEmployeeCalendarSetupList";
            public const string GET_ALL_GRADE_WISE_SALARY_DETAILS = "GetAllGradeWiseSalaryDetails";
            public const string GET_ALL_BONUS = "GetAllBonus";
            public const string GET_ALL_HEADWISE_SALERY = "GetAllHeadwiseSalery";
            public const string GET_ALL_ACCOUNT_CODE_WISE_SALERY_HEAD = "GetAllAccountCodewiseSaleryHead";
            public const string GET_ALL_RECRUITMENT_REFERENCE = "GetAllRecruitmentReference";
            public const string GET_ACTIVE_RECRUITMENT_REF_FOR_VIEW_COMPONENT = "GetActiveRecruitmentRefForViewComponent";
            public const string GET_DESIGNATION_LIST_BY_GRADE_ID = "GetDesignationListByGradeId";
            public const string SELECT_AND_TRANSFER_APPLICANT_PROCESS = "SelectAndTransferApplicantProcess";
            public const string SELECT_AND_TRANSFER_APPLICANT_CONFIRMED_LIST = "SelectAndTransferApplicantToConfirmedList";
            public const string GET_PAY_SCALE_GRADE_LIST_WITH_EMPLOYEE_CLASS = "GetPayScaleGradeListWithEmployeeClass";
            public const string GET_EMPLOYEE_APPLICANT_PAYMENT = "GetEmployeeApplicantPayment";
            public const string GET_EMPLOYEE_FAMILY_MEMBER_LIST_BY_EMP_ID = "GetEmployeeFamilyMemberListByEmpId";
            public const string GET_HEAD_WISE_SALARY_BY_ACC_CODE_WISE_SALARY_HEAD_ID = "GetHeadWiseSalaryByAccCodeWiseSalaryHeadId";
            public const string GET_ALL_LOCAL_TA_DA = "GetAllLocalTADA";
            public const string GET_ALL_FOREIGN_TA_DA = "GetAllForeignTADA";
            public const string GET_FOREIGN_MOVEMENT_DETAILS_LIST = "GetForeignMovementDetailsList";
            public const string GET_ALL_LOCAL_MOVEMENTS = "GetAllLocalMovements";
            public const string GET_OFFICE_ORDER_BY_EMP_ID = "GetOfficeOrderByEmpId";
            public const string GET_EMPLOYEE_LIST_FROM_FOREIGN_MOVEMENT_EMPLOYEE_DROPDOWN = "GetEmployeeListFromForeignMovementEmployee";
            public const string GET_ALL_FOREINGN_SALARY_WISE_TADA = "GetAllForeignSalaryWiseTADA";
            public const string GET_EMPLOYEE_SALARY_FOR_SALARY_SHEET = "GetEmployeeSalaryForSalarySheetReport";
            public const string GET_EMPLOYEE_SALARY_FOR_LIST = "GetEmployeeSalaryForList";
            public const string GET_EMPLOYEE_BONUSES = "GetEmployeeBonuses";
            public const string DELETE_SHIFT_INFORMATION_WITH_DETAIL = "DeleteShiftInformationWithDetail";
            public const string LOCAL_TA_DA_PAYMENT_PROCESS = "LocalTADAPaymentProcess";
            public const string FOREIGN_TA_DA_PAYMENT_PROCESS = "ForeignTADAPaymentProcess";
            public const string GENERALBILL_PAYMENT_PROCESS = "GeneralBillPaymentProcess";
            public const string INDIVIDUAL_STUDENT_PAYMENT_PROCESS = "IndividualStudentPaymentProcess";
            public const string GET_ALL_EMPLOYEE_TRAINING_BY_EMPID = "GetAllEmployeeTrainingByEmpId";
            public const string GET_SECTION_BY_RECRUITMENT_REF_AND_OFFICE_ID = "GetSectionByRecruitmentRefAndOfficeId";
            public const string GET_LEAVE_APP_TRANS_HISTORY_BY_LEAVEAPP_ID = "GetLeaveAppTransHistroyByLeaveAppId";
            public const string GET_ALL_EVENT_CREATION = "GetAllEventCreation";
            public const string GET_ALL_Event_Approval = "GetAllEventApproval";
            public const string GET_ALL_MOVEMENT_PASSES = "GetAllMovementPasses";
            public const string CLOSE_TRAINING_CONFIG = "CloseTrainingConfig";
            public const string TRANSFER_EMPLOYEE_TRAINING_DATA = "TransferEmployeeTrainingData";
            #endregion
            #region LMS

            public const string GET_COURSE_DETAILS_BY_COURSE_ASSIGN_ID = "GetCourseDetailsByCourseAssignId";
            public const string GET_FILTERED_COURSE_FROM_LMS_COURSE_MASTER = "GetFilteredCourseFromLMSCourseMaster";
            public const string GET_COURSE_ASSIGN_DATA_BY_CHAPTER_ID = "GetCourseAssignDataByChapterId";
            public const string GET_COURSE_QUESTION_BY_COURSE_MASTER_ID = "GetCourseQuestionByCourseMasterId";
            public const string GET_ALL_COURSE_EXAMS = "GetAllCourseExams";
            public const string GET_COURSE_EXAM_BY_ID = "GetCourseExamById";
            public const string GET_EXAM_QUESTION_BY_COURSE_EXAM_ID = "GetExamQuestionByCourseExamId";
            public const string GET_LMS_COURSE_LIST_BY_STUDENT_ID = "GetLMSCourseListByStudentId";
            public const string GET_LMS_COURSE_DETAIL_BY_COURSE_MASTER_ID = "GetLMSCourseDetailByCourseMasterId";
            public const string GET_CHAPTER_AND_COURSE_DETAILS_BY_CHAPTER_ID = "GetChapterAndCourseDetailsByChapterId";
            public const string GET_ALL_LMS_COURSE_ASSIGNMENT = "GetAllLmsCourseAssignment";
            public const string GET_LMS_COURSE_LIST_BY_TEACHER_ID = "GetLMSCourseListByTeacherId";
            public const string GET_LMS_EXAM_LIST_BY_COURSE_MASTER_ID = "GetLMSExamListByCourseMasterId";

            public static string GET_ALL_TRAINING_CONFIG { get; internal set; }
            public const string GET_LMS_CHAPTER_WISE_EXAM_QUESTION_BY_EXAM_ID = "GetLMSChapterWiseExamQuestionByExamId";
            public const string GET_LMS_COURSE_WISE_EXAM_QUESTION_BY_EXAM_ID = "GetLMSCourseWiseExamQuestionByExamId";
            public const string GET_COURSE_DETAILS_BY_COURSE_MASTER_ID = "GetCourseDetailsByCourseMasterId";
            public const string EXECUTE_DYNAMIC_SQL = "ExecuteDynamicSQL";
            public const string GET_ALL_HOST_CONFIGS = "GetAllHostConfig";
            public const string GET_ZOOM_CLASS_LIST = "GetZoomClassList";
            public const string GET_STUDENT_LMS_EXAM_DATA_BY_COURSE_MASTER_ID = "GetStudentLMSExamDataByCourseMasterId";
            public const string GET_DATA_FOR_LMS_EXAM_EVALUATION_BY_ID = "GetDataForLMSExamEvaluationById";
            #endregion

            #region AutoJurnal
            public const string GET_STUDENT_FEES_RECEIVABLEHEAD = "GetStudentFeesreceivableHead";
            public const string GET_FINANCIAL_YEAR_ID_BY_CURRENTDATE_WISE = "GetFinancialYearIdByCurrentDateWise";
            #endregion

            #region
            public const string ADD_STUDENT_NOTIFICATION_COM = "AddEmpNotificationCom";
            public const string GET_NOTIFICATION_LIST_COM = "GetNotificationListCom";
            public const string DELETE_STUDENT_NOTIFICATION_COM = "DeleteStudentNotificationCom";
            #endregion NOTIFICATION
        }

        public static class QUERIES
        {

            public const string GET_ALL_SESSION = "SELECT Id, SessionName,SessionNameBN, StartDate, EndDate, SessionCode, CONVERT(VARCHAR, StartDate, 107) AS SessionStartDate, CONVERT(VARCHAR, EndDate, 107) AS SessionEndDate, Status = IIF(Status = 'Inactive', 'Inactive', CASE WHEN CAST( GETDATE() AS date) >= StartDate AND CAST( GETDATE() AS date) <= EndDate THEN 'Running' WHEN CAST( GETDATE() AS date) >= EndDate THEN 'Completed' WHEN CAST( GETDATE() AS date) <= StartDate THEN 'Active' ELSE 'Inactive' END) FROM Aca_Sessions ";

            public const string GET_SESSION_BY_ID = "SELECT Id, SessionName,SessionNameBN, StartDate, EndDate, SessionCode, CONVERT(VARCHAR, StartDate, 107) AS SessionStartDate, CONVERT(VARCHAR, EndDate, 107) AS SessionEndDate FROM Aca_Sessions WHERE Id = @Id";

            public const string GET_All_FACULTY = "SELECT Fac.Id, Fac.FacultyName, Fac.FacultyNameBN, fac.Code, Fac.Description FROM dbo.Aca_Faculties AS Fac";

            public const string GET_All_DEPARTMENT = "SELECT Dept.Id, Dept.DepartmentName, Dept.DepartmentNameBN, Dept.Code, Dept.Description , Fac.FacultyName, Fac.FacultyNameBN FROM dbo.Aca_Departments AS Dept  INNER JOIN dbo.Aca_Faculties AS Fac ON Dept.FacultyId = Fac.Id ORDER BY  Dept.Id  DESC";

            public const string GET_DEPT_BY_FACULTY_FOR_DROPDOWN = "SELECT Id, DepartmentName, DepartmentNameBN, FacultyId FacultyId FROM Aca_Departments WHERE FacultyId = @FacultyId";

            public const string CHECK_MENUITEM = " [dbo].[MenuItems] ";
            public const string CHECK_MENUITEM_WHERE = " id  IN ({0}) ";

            public const string CHECK_MAINEXAMMARKS = " Res_MainExamMarks ";
            public const string CHECK_MAINEXAMMARKS_WHERE = " ExaminerType IN ('First','Second','Third') AND ExaminerId IN({0}) AND ExamId =  {1} AND CourseId = {2}";

            public const string CHECK_SUBEXAM = " [dbo].[Res_SubExam] ";
            public const string CHECK_SUBEXAM_WHERE = " ExamId  IN({0}) ";

            public const string CHECK_SUBEXAM_MARKSETUP = " [dbo].[Res_SubExamMarkSetup] ";
            public const string CHECK_SUBEXAM_MARKSETUP_WHERE = " SubExamId IN({0}) ";

            public const string CHECK_HEAD_AMOUNT_CONFIG = " [dbo].[Fees_HeadAmountConfig] ";
            public const string CHECK_HEAD_AMOUNT_CONFIG_WHERE = " ProcessId IN({0}) ";

            public const string CHECK_ACADEMIC_YEAR_NAME_DUPLICATE = " SessionName = '{0}' ";
            public const string CHECK_ACADEMIC_YEAR_NAME_BN_DUPLICATE = " SessionName_BN = N'{0}' ";

            public const string CHECK_PROGRAM_NAME_DUPLICATE = " ProgramName = '{0}' ";
            public const string CHECK_PROGRAM_NAME_BN_DUPLICATE = " ProgramNameBN = N'{0}' ";

            public const string CHECK_FACULTY_NAME_DUPLICATE = " Name = '{0}' ";
            public const string CHECK_FACULTY_NAME_BN_DUPLICATE = " NameBN = N'{0}' ";

            public const string CHECK_DEPARTMENT_NAME_DUPLICATE = " Name = '{0}' ";
            public const string CHECK_DEPARTMENT_NAME_BN_DUPLICATE = " NameBN = N'{0}' ";

            public const string CHECK_YEAR_NAME_DUPLICATE = " YearName = '{0}' ";
            public const string CHECK_YEAR_NAME_BN_DUPLICATE = " YearNameBN = N'{0}' ";

            public const string CHECK_COURSE_NAME_DUPLICATE = " CourseTitle = '{0}' ";
            public const string CHECK_COURSE_NAME_BN_DUPLICATE = " CourseTitleBN = N'{0}' ";

            public const string CHECK_STUDENT_ACADEMIC_YEARID = " SessionId IN({0}) ";
            public const string CHECK_STUDENT_DEPARTMENTID = " DepartmentId IN({0}) ";
            public const string CHECK_STUDENT_PROGRAMID = " ProgramId IN({0}) ";
            public const string CHECK_STUDENT_BATCHID = "Id IN({0}) ";
            public const string CHECK_STUDENT_CAMPUSID = " CampusId IN({0}) ";
            public const string CHECK_EMPLOYEE_INSID = " EmpId ='{0}' AND IsDeleted = 0 ";
            public const string CHECK_EMAIL = " Email = '{0}' AND IsDeleted = 0 ";
            public const string CHECK_NID = " NIDNo = '{0}' AND IsDeleted = 0 ";
            public const string CHECK_PHONE_NUMBER = " PhoneNumber = '{0}' AND IsDeleted = 0 ";
            public const string CHECK_STUDENT_YEARID = " YearId IN({0}) ";
            public const string CHECK_STUDENT_HALLID = " HallId = {0} ";
            public const string CHECK_DEPARTMENT_FACULTYID = " FacultyId IN({0}) ";

            public const string CHECK_STUDENT_COURSEID = " CourseId IN({0}) ";
            public const string CHECK_FEES_HEADID = " CourseId IN({0}) ";

            public const string EMPLOYEE_COURSETEACHER_TEACHERID = " CourseTeacherId IN({0}) ";
            public const string EMPLOYEE_COURSETEACHER_THIRD_EXAMINERID = " EmpIdThirdExtExaminer IN({0}) ";
            public const string EMPLOYEE_COURSETEACHER_SECOND_EXAMINERID = " EmpIdSecondExtExaminer IN({0}) ";
            public const string EXAM_COMMITTEE_ID = " ExamCommitteeId={0} ";
            public const string EXAM_COMMITTEE_DELETE = "UPDATE Res_ExamCommitteeMember SET IsDeleted=1,DeletionTime=GETDATE(),DeletedBy='{1}' WHERE ExamCommitteeId={0} ";

            public const string CHECK_EMP_IN_COMMITTEE = " ExamCommitteeId={0} AND EmpId={1} AND EmpType='{2}'";
            public const string ACTIVE_INACTIVE_COMMITTEE = "UPDATE Res_ExamCommittee SET [Status]='{1}' WHERE Id={0}";
            #region LMS
            public const string CHECK_HOST_CONFIG_ID = " HostConfigId IN({0}) ";
            #endregion

            #region HRAdmin
            public const string GET_PAYMENT_DATE_FOR_PROCESSED_BONUS = "SELECT DISTINCT(CONVERT(DATE,PaymentDate)) FROM HRA_EmployeeBonuses WHERE PaymentYear = {0} AND BonusTypeId = {1} AND MONTH(PaymentDate) = MONTH({2})";
            #endregion
        }

        public static class TABLE
        {
            public const string ACADEMIC_YEAR = "Aca_Sessions";
            public const string COMMONLOOKUP = "Com_Lookups";
            public const string MASTERDETAILS = "Com_LookupsDetails";
            public const string PROGRAM = "Aca_Programs";
            public const string FACULTY = "Aca_Faculties";
            public const string DEPARTMENT = "Aca_Departments";
            public const string YEAR = "Aca_Year";
            public const string Batch = "Aca_Batches";
            public const string STUDENT_BASICINFO = "Student_BasicInfo";
            public const string EMPLOYEE_BASICINFO = "Emp_Employees";
            public const string STUDENT_COURSE = "Student_Course";
            public const string FEES_HEADAMOUNT = "Fees_HeadAmountConfig";
            public const string EMPLOYEE_COURSETEACHER = "Emp_CourseTeacher";
            public const string EXAM_MEETING = "Res_ExamMeeting";
            public const string EXAM_COMMITTEE = "Res_ExamCommittee";
            public const string EXAM_COMMITTEE_MEMBER = "Res_ExamCommitteeMember";
            //public const string REPORTMASTER = "Adm_ReportMasters";
            #region LMS
            public const string LMS_ZOOM_CLASSES = "LMS_ZoomClasses";
            #endregion
        }
    }
}
