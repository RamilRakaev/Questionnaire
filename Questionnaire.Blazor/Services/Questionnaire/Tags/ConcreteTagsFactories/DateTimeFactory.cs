using System;
using System.Collections.Generic;

namespace Questionnaire.Blazor.Services.Questionnaire.Tags.ConcreteTagsFactories
{
    public class DateTimeFactory : AbstractInputFactory
    {
        public DateTimeFactory(string displayName) : base(displayName)
        {
            _type = "datetime-local";
            defaultValue = DateTime.MinValue.ToString("s");
        }

        public override List<HtmlTag> CreateTags()
        {
            return CreateInput();
        }
    }
}
