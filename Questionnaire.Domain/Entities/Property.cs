namespace Questionnaire.Domain.Entities
{
    public class Property : BaseEntity
    {
        public int StructureId { get; set; }
        public Structure Structure { get; set; }

        public int? CustomTypeId { get; set; }
        public Structure CustomType { get; set; }

        public string DisplayName { get; set; }

        public string JsonName { get; set; }

        public PropertyType PropertyType { get; set; }
        public List<Option> Options { get; set; }
    }
}
