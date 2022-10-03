using System;
using System.Collections.Generic;

namespace Questionnaire.Blazor.Services.Questionnaire.Tags.ConcreteTagsFactories
{
    public abstract class AbstractInputFactory : AbstractTagsFactory
    {
        protected string _type = "text";
        protected string defaultValue = "";

        protected AbstractInputFactory(string displayName) : base(displayName)
        {
        }

        protected List<HtmlTag> CreateInput()
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
                            },
                        },

                        new()
                        {
                            TagName = TagName.Input,
                            Attrubutes = new()
                            {
                                { "type", _type },
                                { "class", $"{_cssClass} col-lg-9" },
                                { "id", inputId },
                            },
                            Value = defaultValue,
                        },
                    },
                },
            };
        }
    }
}
