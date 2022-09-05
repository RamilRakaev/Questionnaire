namespace Questionnaire.Blazor.Pages
{
    public class NavigationLinks
    {
        #region root
        public const string RootQuestionnaires = "/root/";
        public const string CreateQuestionnaire = "/root/createQuestionnaire";
        public const string ConcreteQuestionnaire = "/root/concreteQuestionnaire";
        public const string RootUsers = "/root/userManage/";
        public const string RootCreateUser = "/root/userManage/createUser";
        #endregion

        #region questioned
        public const string PassingTheQuestionnaire = "/questioned/passingTheQuestionnaire";
        public const string QuestionedQuestionnaires = "/questioned/";
        #endregion

        #region account
        public const string Login = "/Identity/Account/Login";
        #endregion
    }
}
