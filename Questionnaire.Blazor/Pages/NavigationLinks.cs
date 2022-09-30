namespace Questionnaire.Blazor.Pages
{
    public class NavigationLinks
    {
        #region root
        public const string RootUsers = "/root/users/";
        public const string RootCreateUser = "/root/userManage/createUser";
        public const string RootAddQrlkChat = "/root/addQrlkChat";
        #endregion

        #region user
        public const string Questionnaires = "/user/questionnaires";
        public const string CompletedQuestionnaires = "/user/completedQuestionnaires";
        public const string PassingTheQuestionnaire = "/user/passingTheQuestionnaire";
        public const string ConcreteQuestionnaire = "/user/concreteQuestionnaire";
        public const string CreateQuestionnaire = "/user/createQuestionnaire";
        public const string Answers = "/user/answers";
        #endregion

        #region access
        public const string Login = "/Identity/Account/Login";
        public const string AccesksDenied = "/accessDenied";
        #endregion

    }
}
