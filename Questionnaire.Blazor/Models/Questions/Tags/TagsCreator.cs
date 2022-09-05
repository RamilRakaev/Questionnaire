using Questionnaire.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Questionnaire.Blazor.Models.Questions.Tags
{
    public static class TagsCreator
    {
        public static List<HtmlTag> CreateTags(Property propertyEntity)
        {
            if (propertyEntity.Type == PropertyType.Custom)
            {
                return new();
            }

            var factoryType = typeof(AbstractTagsFactory).Assembly
                .GetTypes()
                .FirstOrDefault(type => type.Name == propertyEntity.Type.ToString() + "Factory");

            object obj;
            if (propertyEntity.Type == PropertyType.Enumeration)
            {
                var options = propertyEntity.Options.Select(option => option.DisplayName);

                var constructor = factoryType.GetConstructor(new Type[] { typeof(string), options.GetType() });
                obj = constructor.Invoke(new object[] { propertyEntity.DisplayName, options });
            }
            else
            {
                var constructor = factoryType.GetConstructor(new Type[] { typeof(string) });
                obj = constructor.Invoke(new object[] { propertyEntity.DisplayName });
            }
            var factory = obj as AbstractTagsFactory;

            return factory.CreateTags();
        }

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
                case QuestionType.Enumeration:

                    var options = question.Options.Select(option => option.DisplayName);

                    factoryObject = CreateFactory(factoryType, question.DisplayName, options);
                    break;

                case QuestionType.Custom:

                    List<HtmlTag> tags = new();
                    foreach (var subQuestion in question.CustomType.Questions)
                    {
                        tags.AddRange(CreateTags(subQuestion));
                    }

                    return tags;

                default:
                    factoryObject = CreateFactory(factoryType, question.DisplayName);
                    break;
            }
            
            var factory = factoryObject as AbstractTagsFactory;
            return factory.CreateTags();
        }
    }
}
