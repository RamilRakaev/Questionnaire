using Questionnaire.Blazor.Models;
using Questionnaire.Blazor.Models.Questions;
using Questionnaire.Blazor.Services.UserInterfaceDisplay;
using System.Linq;

namespace Questionnaire.Blazor.Pages.ReusableComponents
{
    public abstract class QuestionnaireFormBase : QuestionnaireComponentBase
    {
        protected QuestionnaireModel questionnaire = new();
        protected QuestionModel currentQuestion = new();

        protected readonly FormMessage message = new();

        protected override void OnInitialized()
        {
            message.AfterTime = () => InvokeAsync(StateHasChanged);
        }

        protected bool ValidateQuestion(QuestionModel currentQuestion, string successMessage = "Добавлен вопрос")
        {
            message.Reset();

            bool questionIsCorrect = true;
            if (currentQuestion.QuestionType == QuestionType.Enumeration)
            {
                questionIsCorrect = EnumerationIsCorrect();
            }

            questionIsCorrect = CheckQuestionNameUniqueness() && questionIsCorrect;

            if (questionIsCorrect)
            {
                message.SetSuccessText(successMessage);
            }

            return questionIsCorrect;
        }

        private bool CheckQuestionNameUniqueness()
        {
            var nameIsUniqueness = true;

            var displayNameIsBusy = questionnaire.Questions.Any(question => question.DisplayName == currentQuestion.DisplayName);
            var jsonNameIsBusy = questionnaire.Questions.Any(question => question.JsonName == currentQuestion.JsonName);

            if (displayNameIsBusy)
            {
                message.SetDangerText("Отображаемое имя уже занято");
                nameIsUniqueness = false;
            }
            else if (jsonNameIsBusy)
            {
                message.SetDangerText("Json-имя уже занято");
                nameIsUniqueness = false;
            }

            return nameIsUniqueness;
        }

        private bool EnumerationIsCorrect()
        {
            if (currentQuestion.Options.Count < 2)
            {
                message.SetDangerText("Должно быть по крайне мере два варианта ответа");
                return false;
            }

            var uniqueDisplayNames = currentQuestion.Options.Select(option => option.DisplayName).Distinct().Count();
            var allDisplayNames = currentQuestion.Options.Count;

            var uniqueJsonNames = currentQuestion.Options.Select(option => option.JsonName).Distinct().Count();
            var allJsonNames = currentQuestion.Options.Count;

            if (uniqueDisplayNames < allDisplayNames)
            {
                message.SetDangerText("Отображаемые имена должны быть уникальными");
                return false;
            }

            if (uniqueJsonNames < allJsonNames)
            {
                message.SetDangerText("json-имена должны быть уникальными");
                return false;
            }

            return true;
        }
    }
}
