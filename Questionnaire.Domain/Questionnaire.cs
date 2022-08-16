namespace Questionnaire.Domain
{
    public class QuestionnaireEntity
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }
        public string JsonName { get; set; }

        public List<QuestionEntity> Questions { get; set; }
    }
}
