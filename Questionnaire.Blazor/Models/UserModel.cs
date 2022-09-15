using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Blazor.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не введена почта")]
        [EmailAddress(ErrorMessage = "Неверный формат почты")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Неправильно введена почта")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не введён пароль")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Слишком простой пароль")]
        [MinLength(8, ErrorMessage = "Слишком короткий пароль")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string Role { get; set; }
    }
}
