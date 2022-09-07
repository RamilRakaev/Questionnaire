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
            foreach (var question in questionnaire.Questions)
            {
                PrepareQuestion(question);
            }
        }

        private static object CreateFactory(Type factoryType, params object[] parameters)
        {
            var types = parameters.Select(parameter => parameter.GetType()).ToArray();
            var constructor = factoryType.GetConstructor(types);
            var result = constructor.Invoke(parameters);

            return result;
        }

        private static Type GetFactoryType(QuestionType questionType)
        {
            return typeof(AbstractTagsFactory).Assembly
                .GetTypes()
                .FirstOrDefault(type => type.Name == questionType.ToString() + "Factory");
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

        private void PrepareQuestion(QuestionModel question)
        {
            switch (question.QuestionType)
            {
                case QuestionType.Enumeration:
                    Questionnaire.QuestionsAnswers.Add(question, new(userId, Questionnaire.Id));
                    question.HtmlTags = CreateEnumeration(question);
                    break;

                case QuestionType.Custom:
                    List<HtmlTag> tags = new();
                    foreach (var subQuestion in question.CustomType.Questions)
                    {
                        PrepareQuestion(subQuestion);
                    }

                    tags.AddRange(tags);
                    break;

                default:
                    Questionnaire.QuestionsAnswers.Add(question, new());
                    question.HtmlTags = CreateDefault(question);
                    break;
            }
        }
    }
}
