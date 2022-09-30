using System.Collections.Generic;

namespace Questionnaire.Blazor.Services.Questionnaire.Tags
{
    public abstract class AbstractTagsFactory
    {
        protected readonly string _displayName;

        protected string _cssClass = "form-control";

        public AbstractTagsFactory(string displayName)
        {
            _displayName = displayName;
        }

        public abstract List<HtmlTag> CreateTags();
    }
}
