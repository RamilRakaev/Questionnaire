using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Questionnaire.Blazor.Models;

namespace Questionnaire.Blazor.Interfaces
{
    public abstract class IQuestionType : ComponentBase
    {
        public Question Question { get; set; }
        public Answer Answer { get; set; }

        public abstract RenderFragment Draw();
    }
}
