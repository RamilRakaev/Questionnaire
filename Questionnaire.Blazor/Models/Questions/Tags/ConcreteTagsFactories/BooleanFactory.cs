using System.Collections.Generic;

namespace Questionnaire.Blazor.Models.Questions.Tags.ConcreteTagsFactories
{
    public class BooleanFactory : AbstractInputFactory
    {
        public BooleanFactory(string displayName) : base(displayName)
        {
            _type = "checkbox";
            _cssClass = "form-check-inline mx-2";
            defaultValue = "False";
        }

        public override List<HtmlTag> CreateTags()
        {
            return CreateInput();
        }
    }
}
