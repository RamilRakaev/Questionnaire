using Questionnaire.Domain.Entities;
using System;
using System.Linq;

namespace Questionnaire.Blazor.Models.Questions.Tags
{
    public static class TagsCreator
    {
        public static HtmlTag[] CreateTags(PropertyEntity propertyEntity)
        {
            var factoryType = typeof(AbstractTagsFactory).Assembly
                .GetTypes()
                .FirstOrDefault(type => type.Name == propertyEntity.Type.ToString() + "Factory");

            object obj;
            if (propertyEntity.Type == QuestionType.Enumeration)
            {
                var constructor = factoryType.GetConstructor(new Type[] { typeof(string), propertyEntity.Options.GetType() });
                obj = constructor.Invoke(new object[] { propertyEntity.DisplayName, propertyEntity.Options });
            }
            else
            {
                var constructor = factoryType.GetConstructor(new Type[] { typeof(string) });
                obj = constructor.Invoke(new object[] { propertyEntity.DisplayName });
            }
            var factory = obj as AbstractTagsFactory;

            return factory.CreateTags();
        }
    }
}
