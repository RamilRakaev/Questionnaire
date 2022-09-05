using System.Collections.Generic;

namespace Questionnaire.Blazor.Models.Questions.Tags.ConcreteTagsFactories
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
