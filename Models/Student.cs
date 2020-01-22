using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace App.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [StringLength(40, ErrorMessage = "Поле должно содержать не более 40 символов")]
        [Required(ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }
        [StringLength(40, ErrorMessage = "Поле должно содержать не более 60 символов")]
        [Display(Name = "Отчество")]      
        public string MiddleName { get; set; }
        [Display(Name = "Фамилия")]
        [StringLength(40, ErrorMessage = "Поле должно содержать не более 40 символов")]
        [Required(ErrorMessage = "Не указана фамилия")]
        public string LastNAme { get; set; }
        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Не указан пол")]
        public string Sex { get; set; }       
        [Display(Name = "Позывной")]
        [Remote(action: "CheckCallName", controller: "Home", ErrorMessage = "Позывной уже используется")]
        [StringLength(16, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 5 до 16 символов")]
        public string CallName { get; set; }
    }
}
