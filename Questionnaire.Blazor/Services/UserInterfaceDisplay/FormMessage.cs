namespace Questionnaire.Blazor.Services.UserInterfaceDisplay
{
    public class FormMessage
    {
        public string CssClass { get; private set; }

        public string Text { get; private set; }

        public void ActionNotification(string messageTest, bool successed)
        {
            Text = messageTest;

            if (successed)
            {
                CssClass = "text-success";
            }
            else
            {
                CssClass = "text-danger";
            }
        }

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
