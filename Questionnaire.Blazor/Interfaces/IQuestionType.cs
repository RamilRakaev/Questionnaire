using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Questionnaire.Blazor.Models;
using Questionnaire.Blazor.Models.Questions;

namespace Questionnaire.Blazor.Interfaces
{
    public abstract class IQuestionType : ComponentBase
    {
        public QuestionModel Question { get; set; }
        public AnswerModel Answer { get; set; }

        public abstract RenderFragment Draw();
    }
}
