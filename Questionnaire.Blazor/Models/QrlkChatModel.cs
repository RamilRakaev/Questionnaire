using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Blazor.Models
{
    public class QrlkChatModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        [MinLength(1, ErrorMessage = "Введите минимум один тэг")]
        public List<string> Tags { get; set; }

        [Required(ErrorMessage = "Введите токен")]
        public string Token { get; set; }
    }
}
