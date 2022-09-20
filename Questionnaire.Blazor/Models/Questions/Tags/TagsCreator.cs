using System;
using System.Collections.Generic;
using System.Linq;

namespace Questionnaire.Blazor.Models.Questions.Tags
{
    public class TagsCreator
    {
        private static object CreateFactory(Type factoryType, params object[] parameters)
        {
            var types = parameters.Select(parameter => parameter.GetType()).ToArray();
            var constructor = factoryType.GetConstructor(types);
            var result = constructor.Invoke(parameters);

            return result;
        }

        public static List<HtmlTag> CreateTags(QuestionModel question)
        {
            var factoryType = typeof(AbstractTagsFactory).Assembly
                .GetTypes()
                .FirstOrDefault(type => type.Name == question.QuestionType.ToString() + "Factory");

            object factoryObject;
            switch (question.QuestionType)
            {
                case QuestionType.Custom:

                    List<HtmlTag> tags = new();
                    foreach (var subQuestion in question.CustomType.Questions)
                    {
                        tags.AddRange(CreateTags(subQuestion));
                    }

                    return tags;

                case QuestionType.Enumeration:

                    var options = question.Options.Select(option => option.DisplayName);

                    factoryObject = CreateFactory(factoryType, question.DisplayName, options);
                    break;

                default:
                    factoryObject = CreateFactory(factoryType, question.DisplayName);
                    break;
            }

            var factory = factoryObject as AbstractTagsFactory;
            return factory.CreateTags();
        }
    }
}
