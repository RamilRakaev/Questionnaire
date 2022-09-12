using Questionnaire.Blazor.Models.Questions.Tags;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Questionnaire.Blazor.Models.Questions
{
    public class QuestionModel
    {
        public int Id { get; set; }

        public int QuestionnaireId { get; set; }

        public int? CustomTypeId { get; set; }
        public QuestionnaireModel CustomType { get; set; }

        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Не введено имя в json")]
        public string JsonName { get; set; }

        public QuestionType QuestionType { get; set; }

        public List<OptionModel> Options { get; set; }

        public List<HtmlTag> HtmlTags { get; set; }

        public AnswerModel AnswerToCurrentQuestion { get; set; } = new();
    }
}
