using Microsoft.AspNetCore.Components;
using Questionnaire.Blazor.Models;
using System;

namespace Questionnaire.Blazor.Pages.ReusableComponents.Questions
{
    public abstract class BaseQuestionComponent : ComponentBase
    {
        protected string id;

        [CascadingParameter]
        public QuestionAnswerModel QuestionAnswer { get; set; }

        protected virtual void Input(ChangeEventArgs args)
        {
            QuestionAnswer.Answer.Value = args.Value.ToString();
        }

        protected override void OnInitialized()
        {
            id = Guid.NewGuid().ToString();
        }
    }
}
