using System;
using System.Collections.Generic;

namespace Questionnaire.Blazor.Services.Questionnaire.Tags.ConcreteTagsFactories
{
    public class MultiTextFactory : AbstractTagsFactory
    {
        public MultiTextFactory(string displayName) : base(displayName)
        {
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
                            TagName = TagName.Label,
                            Value = _displayName,
                            Attrubutes = new()
                            {
                                { "for", inputId },
                            }
                        },
                        new()
                        {
                            TagName = TagName.MultiText,
                            Attrubutes = new()
                            {
                                { "class", "form-control" },
                                { "id", inputId },
                                { "rows", 5 },
                            },
                        },
                    },
                }
            };
        }
    }
}
