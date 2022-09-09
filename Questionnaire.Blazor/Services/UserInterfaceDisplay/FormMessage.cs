namespace Questionnaire.Blazor.Services.UserInterfaceDisplay
{
    public class FormMessage
    {
        public string CssClass { get; private set; }

        public string Text { get; private set; }

        public void SetDangerText(string text)
        {
            Text = text;
            CssClass = "text-danger";
        }

        public void SetSuccessText(string text)
        {
            Text = text;
            CssClass = "text-success";
        }

        public void Reset()
        {
            Text = "";
        }
    }
}
