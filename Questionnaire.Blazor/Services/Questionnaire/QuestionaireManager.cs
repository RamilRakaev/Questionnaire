using Questionnaire.Blazor.Models;
using Questionnaire.Blazor.Models.Questions;
using Questionnaire.Blazor.Services.Questionnaire.Tags;
using System;
using System.Collections.Generic;
using System.Linq;

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

            switch (question.QuestionType)
            {
                case QuestionType.Custom:
                    questionAnswer.QuestionAnswers = new();

                    foreach (var subQuestion in question.CustomType.Questions)
                    {
                        questionAnswer.QuestionAnswers.Add(CreateQuestionAnswer(subQuestion, userId, questionnaireId));
                    }

                    return questionAnswer;

                case QuestionType.Enumeration:
                    questionAnswer.HtmlTags = CreateEnumeration(question);
                    return questionAnswer;

                default:
                    questionAnswer.HtmlTags = CreateDefault(question);
                    return questionAnswer;
            }
        }

        private static List<HtmlTag> CreateEnumeration(QuestionModel question)
        {
            var factoryType = GetFactoryType(question.QuestionType);

            var options = question.Options.Select(option => option.DisplayName);

            object factoryObject = CreateFactory(factoryType, question.DisplayName, options);
            var factory = factoryObject as AbstractTagsFactory;

            return factory.CreateTags();
        }

        private static List<HtmlTag> CreateDefault(QuestionModel question)
        {
            var factoryType = GetFactoryType(question.QuestionType);

            object factoryObject = CreateFactory(factoryType, question.DisplayName);
            var factory = factoryObject as AbstractTagsFactory;

            return factory.CreateTags();
        }

        private static Type GetFactoryType(QuestionType questionType)
        {
            return typeof(AbstractTagsFactory).Assembly
                .GetTypes()
                .FirstOrDefault(type => type.Name == questionType.ToString() + "Factory");
        }

        private static object CreateFactory(Type factoryType, params object[] parameters)
        {
            var types = parameters.Select(parameter => parameter.GetType()).ToArray();
            var constructor = factoryType.GetConstructor(types);
            var result = constructor.Invoke(parameters);

            return result;
        }
    }
}
