using System.Collections.Generic;
using System.Linq;

namespace Questionnaire.Blazor.Models.Questions.Tags.ConcreteTagsFactories
{
    public class EnumerationFactory : AbstractTagsFactory
    {
        private readonly IEnumerable<string> _options;

        public EnumerationFactory(string displayName, IEnumerable<string> options) : base(displayName)
        {
            _cssClass = "custom-select";
            _options = options;
        }

        public override HtmlTag[] CreateTags()
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
                    TagName = TagName.Select,
                    Attrubutes = new()
                    {
                        { "class", _cssClass },
                    },
                    ChildTags = _options
                    .Select(option => new HtmlTag()
                    {
                        Value = option,
                        Attrubutes = new()
                        {
                            { "value", option }
                        },
                    })
                    .ToArray(),
                }
            };
        }
    }
}
