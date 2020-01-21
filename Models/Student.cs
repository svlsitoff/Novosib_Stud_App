using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace App.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }
        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Не указано отчество")]
        public string MiddleName { get; set; }
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Не указана фамилия")]
        public string LastNAme { get; set; }
        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Не указан пол")]
        public string Sex { get; set; }
        [Display(Name = "Позывной")]
        [StringLength(16, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 5 до 16 символов")]
        public string CallName { get; set; }
    }
}
