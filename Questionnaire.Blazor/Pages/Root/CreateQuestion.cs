using Microsoft.AspNetCore.Components;
using Questionnaire.Blazor.Models;
using Questionnaire.Blazor.Models.Questions;
using Questionnaire.Blazor.Services.UserInterfaceDisplay;
using System.Linq;

namespace Questionnaire.Blazor.Pages.Root
{
    public class CreateQuestion : ComponentBase
    {
        protected readonly FormMessage message = new();

        protected QuestionnaireModel questionnaire = new();
        protected QuestionModel currentQuestion = new();

        protected bool CheckNameUniqueness()
        {
            message.Reset();

            var result = true;

            var displayNameIsBusy = questionnaire.Questions.Any(question => question.DisplayName == currentQuestion.DisplayName);
            var jsonNameIsBusy = questionnaire.Questions.Any(question => question.JsonName == currentQuestion.JsonName);

            if (displayNameIsBusy)
            {
                message.SetDangerText("Отображаемое имя уже занято");
                result = false;
            }
            else if (jsonNameIsBusy)
            {
                message.SetDangerText("Json-имя уже занято");
                result = false;
            }
            else
            {
                message.SetSuccessText("Добавлен вопрос");
            }

            return result;
        }
    }
}
