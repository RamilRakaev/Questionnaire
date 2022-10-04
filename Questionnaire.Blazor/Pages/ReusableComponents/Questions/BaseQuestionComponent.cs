using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Questionnaire.Blazor.Pages.ReusableComponents.Questions
{
    public abstract class BaseQuestionComponent<T> : ComponentBase
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public T Value { get; set; }

        public EventCallback<T> ValueChanged { get; set; }

        protected async Task SetValue(ChangeEventArgs eventArgs)
        {
            if (TryParse(eventArgs.Value.ToString(), out T newValue))
            {
                Value = newValue;
                await ValueChanged.InvokeAsync(newValue);
            }
        }

        protected abstract bool TryParse(string original, out T result);
    }
}
