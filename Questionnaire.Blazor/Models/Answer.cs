﻿namespace Questionnaire.Blazor.Models
{
    public class Answer
    {
        public Answer()
        {

        }

        public Answer(int questionId)
        {
            QuestionId = questionId;
        }

        public Answer(string мalue)
        {
            Name = мalue;
        }

        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string Name { get; set; }
    }
}
