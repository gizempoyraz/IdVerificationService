using System.ComponentModel.DataAnnotations;

namespace IdVerificationService.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}