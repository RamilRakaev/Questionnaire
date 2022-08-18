namespace Questionnaire.Blazor.Models.Questions.Tags.ConcreteTagsFactories
{
    public class DateTimeFactory : AbstractInputFactory
    {
        public DateTimeFactory(string displayName) : base(displayName)
        {
            _type = "datetime-local";
        }

        public override HtmlTag[] CreateTags()
        {
            return CreateInput();
        }
    }
}
