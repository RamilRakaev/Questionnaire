using System;
using System.Collections.Generic;
using System.Linq;

namespace Questionnaire.Blazor.Services.Questionnaire.Tags.ConcreteTagsFactories
{
    public class EnumerationFactory : AbstractTagsFactory
    {
        private readonly IEnumerable<string> _options;

        public EnumerationFactory(string displayName, IEnumerable<string> options) : base(displayName)
        {
            _cssClass = "custom-select";
            _options = options;
        }

        public override List<HtmlTag> CreateTags()
        {
            var inputId = Guid.NewGuid().ToString();

            return new()
            {
                new()
                {
                    TagName = TagName.Div,
                    Attrubutes = new()
                    {
                        { "class", "form-group row justify-content-around" },
                    },
                    ChildTags = new()
                    {
                        new()
                        {
                            TagName = TagName.Label,
                            Value = _displayName,
                            Attrubutes = new()
                            {
                                { "class", "col-lg-2" },
                                { "for", inputId },
                            }
                        },
                        new()
                        {
                            TagName = TagName.Select,
                            Attrubutes = new()
                            {
                                { "class", $"{_cssClass} col-lg-9" },
                                { "id", inputId },
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
                                .ToList(),
                        },
                    },
                },
            };
        }
    }
}
