using Questionnaire.Blazor.Models;
using Questionnaire.Blazor.Models.Questions;
using System.Collections.Generic;

namespace Questionnaire.Blazor.Services.Questionnaire
{
    public static class QuestionaireExtensions
    {
        public static List<QuestionAnswerModel> GetQuestionAnswerPairs(this QuestionnaireModel modifiableQuestionnaire, long? userId)
        {
            List<QuestionAnswerModel> questionAnswers = new();
            foreach (var question in modifiableQuestionnaire.Questions)
            {
                modifiableQuestionnaire.QuestionAnswers.Add(CreateQuestionAnswer(question, userId, modifiableQuestionnaire.Id));
            }

            return questionAnswers;
        }

        private static QuestionAnswerModel CreateQuestionAnswer(QuestionModel question, long? userId, int questionnaireId)
        {
            QuestionAnswerModel questionAnswer = new()
            {
                Question = question,
                Answer = new(userId, questionnaireId),
            };

            if (question.CustomType != null)
            {
                foreach (var subQuestion in question.CustomType.Questions)
                {
                    questionAnswer.QuestionAnswers = new()
                    {
                        CreateQuestionAnswer(subQuestion, userId, questionnaireId)
                    };
                }
            }

            return questionAnswer;
        }

    }
}
