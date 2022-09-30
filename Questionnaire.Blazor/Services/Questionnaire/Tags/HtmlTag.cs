using System.Collections.Generic;

namespace Questionnaire.Blazor.Services.Questionnaire.Tags
{
    public class HtmlTag
    {
        public TagName TagName { get; set; }

        public Dictionary<string, object> Attrubutes { get; set; }

        public List<HtmlTag> ChildTags { get; set; }

        public string Value { get; set; }
    }
}
