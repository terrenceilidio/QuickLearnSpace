using System.ComponentModel.DataAnnotations;

namespace QuickLearnSpace.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}