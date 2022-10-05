using Questionnaire.Blazor.Models;
using Questionnaire.Blazor.Models.Questions;

namespace Questionnaire.Blazor.Services.Questionnaire
{
    public static class QuestionaireManager
    {
        public static void PrepareQuestionnaireToDisplay(QuestionnaireModel modifiableQuestionnaire, long? userId)
        {
            modifiableQuestionnaire.QuestionAnswers = new();
            foreach (var question in modifiableQuestionnaire.Questions)
            {
                modifiableQuestionnaire.QuestionAnswers.Add(CreateQuestionAnswer(question, userId, modifiableQuestionnaire.Id));
            }
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
