using System.Collections.Generic;

namespace Questionnaire.Blazor.Models.Questions.Tags
{
    public class HtmlTag
    {
        public TagName TagName { get; set; }

        public Dictionary<string, object> Attrubutes { get; set; }

        public HtmlTag[] ChildTags { get; set; }

        public string Value { get; set; }
        public string JsonValue { get; set; }
    }
}
