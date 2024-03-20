using AspNetCoreHero.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUMS.Domain.Entities.LMS
{
    [Table("LMS_StudentEvaluation")]
    public class StudentEvaluation : AuditableEntity
    {
        public int CourseMasterId { get; set; }
        public int ChapterId { get; set; }
        public int ChapterExamId { get; set; }
        public int StudentId { get; set; }
        public string FileUrl { get; set; }
        public bool IsAssignment { get; set; }
        public decimal TotalObtainMarks { get; set; }
        public DateTime SubmitDate { get; set; }
        public bool IsSubmitted { get; set; }
        public int SubmittedBy { get; set; }
        public int IsEvaluated { get; set; }
        public List<StudentEvaluationDetail> EvaluationDetail { get; set; } = new();
    }
}
