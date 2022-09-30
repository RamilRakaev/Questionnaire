using System.Collections.Generic;

namespace Questionnaire.Blazor.Services.Questionnaire.Tags.ConcreteTagsFactories
{
    public class NumberFactory : AbstractInputFactory
    {
        public NumberFactory(string displayName) : base(displayName)
        {
            _type = "number";
            defaultValue = "0";
        }

        public override List<HtmlTag> CreateTags()
        {
            return CreateInput();
        }
    }
}
