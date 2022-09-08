using System;
using System.Collections.Generic;

namespace Questionnaire.Blazor.Models.Questions.Tags.ConcreteTagsFactories
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
                        { "class", "form-group" },
                    },
                    ChildTags = new()
                    {
                        new()
                        {
                            TagName = TagName.Label,
                            Value = _displayName,
                            Attrubutes = new()
                            {
                                { "for", inputId },
                            },
                        },

                        new()
                        {
                            TagName = TagName.Input,
                            Attrubutes = new()
                            {
                                { "type", _type },
                                { "class", _cssClass },
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
