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
        [Required(ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Не указано отчество")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        public string LastNAme { get; set; }
        [Required(ErrorMessage = "Не указан пол")]
        public string Sex { get; set; }
        [StringLength(16, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 5 до 16 символов")]
        public string CallName { get; set; }
    }
}
