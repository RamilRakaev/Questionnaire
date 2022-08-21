﻿using Questionnaire.Blazor.Models.Questions;
using System.Collections.Generic;

namespace Questionnaire.Blazor.Models
{
    public class QuestionnaireModel
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }
        public string JsonName { get; set; }

        public List<string> Options { get; set; }

        public List<QuestionModel> Properties { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
}
