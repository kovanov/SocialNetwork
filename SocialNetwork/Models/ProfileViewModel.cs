using System;
using System.ComponentModel.DataAnnotations;
using SocialNetwork.BL;
using System.Web;

namespace SocialNetwork.Models
{
    public class ProfileViewModel
    {
        [Required]
        [Display(Name = "Ваше имя")]
        [StringLength(50, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 2)]
        public string Name { get; set; }
        
        [Display(Name = "Ваша фамилия")]
        [StringLength(50, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 2)]
        public string Surname { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "О себе")]
        [DataType(DataType.MultilineText)]
        public string About { get; set; }

        public string PhotoBase64 { get; set; }
    }
}
