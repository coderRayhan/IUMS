using System.ComponentModel.DataAnnotations;

namespace IUMS.Application.Enums
{
    public enum QuestionType
	{
		[Display(Name = "MCQ")]
		MCQ = 1,
		[Display(Name= "Descriptive Question")]
		ShortQuestion = 2,
		[Display(Name = "Fill in the blanks")]
		FillInTheBlanks = 3,
		[Display(Name = "True / False")]
		TrueOrFalse = 4
	}
}
