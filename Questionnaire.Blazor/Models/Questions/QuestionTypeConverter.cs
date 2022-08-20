using Questionnaire.Domain.Entities;
using System;

namespace Questionnaire.Blazor.Models.Questions
{
    public class QuestionTypeConverter
    {
        public static QuestionType Convert(string questionType)
        {
            Enum.TryParse<QuestionType>(questionType, out var result);
            return result;
        }
    }
}
