namespace Questionnaire.Blazor.Models.Questions.Tags.ConcreteTagsFactories
{
    public class TextFactory : AbstractInputFactory
    {
        public TextFactory(string displayName) : base(displayName)
        {
        }

        public override HtmlTag[] CreateTags()
        {
            return CreateInput();
        }
    }
}
