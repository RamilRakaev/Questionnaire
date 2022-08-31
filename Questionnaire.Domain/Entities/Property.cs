using System.Diagnostics.CodeAnalysis;

namespace Questionnaire.Domain.Entities
{
    public class Property : BaseEntity
    {
        public int StructureId { get; set; }
        public Structure Structure { get; set; }

        [NotNull]
        public string DisplayName { get; set; }

        [NotNull]
        public string JsonName { get; set; }

        public PropertyType Type { get; set; }
        public IEnumerable<Option> Options { get; set; }

        public IEnumerable<Structure> CustomTypes { get; set; }
    }
}
