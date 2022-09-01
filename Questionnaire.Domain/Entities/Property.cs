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

        public PropertyType Type { get; set; }
        public IEnumerable<Option> Options { get; set; }
    }
}
