namespace Questionnaire.Blazor.Models.Questions.Tags.ConcreteTagsFactories
{
    public class NumberFactory : AbstractInputFactory
    {
        public NumberFactory(string displayName) : base(displayName)
        {
            _type = "number";
        }

        public override HtmlTag[] CreateTags()
        {
            return CreateInput();
        }
    }
}
