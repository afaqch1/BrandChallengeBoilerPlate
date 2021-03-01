using System.ComponentModel.DataAnnotations;

namespace BrandChallenge.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}