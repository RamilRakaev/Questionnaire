using Questionnaire.Blazor.Models.Questions.Tags;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Questionnaire.Blazor.Models.Questions
{
    public class QuestionaireManager
    {
        private readonly int userId;

        public QuestionaireManager(QuestionnaireModel questionnaire, int userId)
        {
            Questionnaire = questionnaire;
            this.userId = userId;
            PrepareQuestionnaireToDisplay(questionnaire);
        }

        public QuestionnaireModel Questionnaire { get; } = new();

        private void PrepareQuestionnaireToDisplay(QuestionnaireModel questionnaire)
        {
            questionnaire.QuestionsAnswers = new();
            questionnaire.QuestionAnswers = new();
            foreach (var question in questionnaire.Questions)
            {
                questionnaire.QuestionAnswers.Add(CreateQuestionAnswer(question));
            }
        }

        private QuestionAnswerModel CreateQuestionAnswer(QuestionModel question)
        {
            QuestionAnswerModel questionAnswer = new()
            {
                Question = question,
                Answer = new(userId, Questionnaire.Id),
            };

            switch (question.QuestionType)
            {
                case QuestionType.Enumeration:
                    Questionnaire.QuestionsAnswers.Add(questionAnswer.Answer, question);

                    questionAnswer.HtmlTags = CreateEnumeration(question);
                    return questionAnswer;

                case QuestionType.Custom:
                    questionAnswer.QuestionAnswers = new();

                    foreach (var subQuestion in question.CustomType.Questions)
                    {
                        questionAnswer.QuestionAnswers.Add(CreateQuestionAnswer(subQuestion));
                    }

                    return questionAnswer;

                default:
                    Questionnaire.QuestionsAnswers.Add(questionAnswer.Answer, question);

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
