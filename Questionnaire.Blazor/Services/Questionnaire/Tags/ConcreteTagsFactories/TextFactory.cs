using System.Collections.Generic;

namespace Questionnaire.Blazor.Services.Questionnaire.Tags.ConcreteTagsFactories
{
    public class TextFactory : AbstractInputFactory
    {
        public TextFactory(string displayName) : base(displayName)
        {
        }

        public override List<HtmlTag> CreateTags()
        {
            return CreateInput();
        }
    }
}
