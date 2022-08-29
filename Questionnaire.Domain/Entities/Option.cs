namespace Questionnaire.Domain.Entities
{
    public class Option : BaseEntity
    {
        public int PropertyId { get; set; }
        public Property Property { get; set; }

        public string DisplayName { get; set; }
        public string JsonName { get; set; }
    }
}
