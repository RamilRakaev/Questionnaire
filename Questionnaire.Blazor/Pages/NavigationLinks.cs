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

        #region interviewee
        public const string PassingTheQuestionnaire = "/interviewee/passingTheQuestionnaire";
        public const string QuestionedQuestionnaires = "/interviewee/";
        #endregion

        #region account
        public const string Login = "/Identity/Account/Login";
        #endregion
    }
}
