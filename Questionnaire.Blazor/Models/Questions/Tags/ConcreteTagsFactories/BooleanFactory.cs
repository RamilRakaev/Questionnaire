namespace Questionnaire.Blazor.Models.Questions.Tags.ConcreteTagsFactories
{
    public class BooleanFactory : AbstractInputFactory
    {
        public BooleanFactory(string displayName) : base(displayName)
        {
            _type = "checkbox";
            _cssClass = "form-check-inline";
        }

        public override HtmlTag[] CreateTags()
        {
            return CreateInput();
        }
    }
}
