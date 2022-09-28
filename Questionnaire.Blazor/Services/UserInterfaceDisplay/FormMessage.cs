using System;
using System.Threading;

namespace Questionnaire.Blazor.Services.UserInterfaceDisplay
{
    public class FormMessage
    {
        private Timer timer;

        public Action AfterTime { get; set; }

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
            SetTimer();
        }

        private void SetTimer()
        {
            timer = new(TimerWork, null, 5000, 0);
        }

        private void TimerWork(object sender)
        {
            Reset();
            AfterTime?.Invoke();
        }

        public void Reset()
        {
            Text = "";
            timer?.Dispose();
        }
    }
}
