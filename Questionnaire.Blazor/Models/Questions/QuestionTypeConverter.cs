using Questionnaire.Domain.Entities;
using System;

namespace Questionnaire.Blazor.Models.Questions
{
    public class QuestionTypeConverter
    {
        public static PropertyType Convert(string questionType)
        {
            Enum.TryParse<PropertyType>(questionType, out var result);
            return result;
        }
    }
}
