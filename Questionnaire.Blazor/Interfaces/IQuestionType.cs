using Microsoft.AspNetCore.Components;

namespace Questionnaire.Blazor.Interfaces
{
    public interface IQuestionType 
    {
        public RenderFragment Draw();
    }
}
