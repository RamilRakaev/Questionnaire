namespace Questionnaire.Blazor.Models
{
    public class AnswerModel
    {
        public AnswerModel()
        {

        }

        public AnswerModel(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public int QuestionnaireId { get; set; }
        public int UserId { get; set; }

        public string Name { get; set; }
    }
}
