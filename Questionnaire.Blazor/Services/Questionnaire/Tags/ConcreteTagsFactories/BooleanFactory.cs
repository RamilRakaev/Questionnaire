using System;
using System.Collections.Generic;

namespace Questionnaire.Blazor.Services.Questionnaire.Tags.ConcreteTagsFactories
{
    public class BooleanFactory : AbstractInputFactory
    {
        public BooleanFactory(string displayName) : base(displayName)
        {
            _type = "checkbox";
            _cssClass = "form-check-inline";
            defaultValue = "False";
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
                        { "class", "form-group" },
                    },
                    ChildTags = new()
                    {
                        new()
                        {
                            TagName = TagName.Input,
                            Attrubutes = new()
                            {
                                { "id", inputId },
                                { "type", _type },
                                { "class", "form-check-inline mx-3" },
                            },
                            Value = defaultValue,
                        },

                        new()
                        {
                            TagName = TagName.Label,
                            Value = _displayName,
                            Attrubutes = new()
                            {
                                { "for", inputId },
                            },
                        },
                    },
                },
            };
        }
    }
}
