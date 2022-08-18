using Questionnaire.Blazor.Models.Questions.Tags;
using System.Collections.Generic;
using System.Linq;

namespace Questionnaire.Blazor.Models.Questions
{
    public class QuestionModel
    {
        public QuestionModel(string displayName, string jsonName, string questionType, string cssClasses = "form-control")
        {
            DisplayName = displayName;
            JsonName = jsonName;

            HtmlTags = new HtmlTag[]
            {
                new()
                {
                    TagName = TagName.Label,
                    Value = DisplayName,
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

        public QuestionModel(string displayName, string jsonName, string[] options, string cssClasses = "custom-select")
        {
            DisplayName = displayName;
            JsonName = jsonName;

            HtmlTags = new HtmlTag[]
            {
                new()
                {
                    TagName = TagName.Label,
                    Value = DisplayName,
                },
                new()
                {
                    TagName = TagName.Select,
                    Attrubutes = new()
                    {
                        { "class", cssClasses },
                    },
                    ChildTags = options
                    .Select(option => new HtmlTag()
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

        public QuestionModel()
        {

        }

        public int Id { get; set; }

        public HtmlTag[] HtmlTags { get; set; }

        public string JsonName { get; set; }
        public string DisplayName { get; set; }

        public List<QuestionModel> SubQuestions { get; set; }
    }
}
