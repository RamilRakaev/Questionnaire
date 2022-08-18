namespace Questionnaire.Blazor.Models.Questions.Tags.ConcreteTagsFactories
{
    public abstract class AbstractInputFactory : AbstractTagsFactory
    {
        protected string _type = "text";

        protected AbstractInputFactory(string displayName) : base(displayName)
        {
        }

        protected HtmlTag[] CreateInput()
        {
            return new HtmlTag[]
            {
                new()
                {
                    TagName = TagName.Label,
                    Value = _displayName,
                },
                new()
                {
                    TagName = TagName.Input,
                    Attrubutes = new()
                    {
                        { "type", _type },
                        { "class", _cssClass },
                    },
                },
            };
        }
    }
}
