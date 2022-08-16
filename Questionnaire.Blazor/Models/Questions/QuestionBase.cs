using Questionnaire.Blazor.Models.Questions.Tags;
using System.Collections.Generic;
using System.Linq;

namespace Questionnaire.Blazor.Models.Questions
{
    public class QuestionBase
    {
        public QuestionBase(string label, string questionType, string cssClasses = "form-control")
        {
            HtmlTags = new HtmlTag[]
            {
                new()
                {
                    TagName = TagName.Label,
                    Value = label,
                },
                new()
                {
                    TagName = TagName.Input,
                    Attrubutes = new()
                    {
                        { "type", questionType },
                        { "class", cssClasses },
                    },
                },
            };
        }

        public QuestionBase(string label, string[] options, string cssClasses = "custom-select")
        {
            HtmlTags = new HtmlTag[]
            {
                new()
                {
                    TagName = TagName.Label,
                    Value = label,
                },
                new()
                {
                    TagName = TagName.Select,
                    Attrubutes = new()
                    {
                        { "class", cssClasses },
                    },
                    ChildTags = options.Select(option => new HtmlTag()
                    {
                        Value = option,
                        Attrubutes = new()
                        {
                            { "value", option }
                        },
                    })
                    .ToArray()
                }
            };
        }

        public QuestionBase()
        {

        }

        public int Id { get; set; }

        public HtmlTag[] HtmlTags { get; set; }

        public string JsonName { get; set; }
        public string DisplayName { get; set; }

        public List<QuestionBase> SubQuestions { get; set; }
    }
}
