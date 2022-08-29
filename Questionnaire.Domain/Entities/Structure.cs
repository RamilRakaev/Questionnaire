namespace Questionnaire.Domain.Entities
{
    public class Structure : BaseEntity
    {
        public string DisplayName { get; set; }

        public List<string> Options { get; set; }

        public List<Property> Properties { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
