using System.Diagnostics.CodeAnalysis;

namespace Questionnaire.Domain.Entities
{
    public class Structure : BaseEntity
    {
        public int? ParentPropertyId { get; set; }
        public Property ParentProperty { get; set; }

        [NotNull]
        public string DisplayName { get; set; }

        public List<string> Options { get; set; }

        public IEnumerable<Property> Properties { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}
