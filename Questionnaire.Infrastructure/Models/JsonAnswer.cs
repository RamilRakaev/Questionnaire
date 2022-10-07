namespace Questionnaire.Infrastructure.Models
{
    public class JsonAnswer
    {
        public string Name { get; set; }

        public object Value { get; set; }

        public List<JsonAnswer> Answers { get; set; }
    }
}
