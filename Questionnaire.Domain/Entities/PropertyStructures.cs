namespace Questionnaire.Domain.Entities
{
    public class PropertyStructures : BaseEntity
    {
        public int PropertyId { get; set; }
        public Property Property { get; set; }

        public int StructureId { get; set; }
        public Structure Structure { get; set; }
    }
}
