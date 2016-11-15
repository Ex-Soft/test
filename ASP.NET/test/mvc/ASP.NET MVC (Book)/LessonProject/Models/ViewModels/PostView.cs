using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LessonProject.Models.ViewModels
{
    public class PostView
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public bool IsCorrectLang { get; set; }

        public int CurrentLang { get; set; }

        [Required(ErrorMessage = "Введите залоговок")]
        public string Header { get; set; }

        [Required]
        public string Url { get; set; }

        [Required(ErrorMessage = "Введите содержимое")]
        public string Content { get; set; }

        [Display(Name="Цена")]
        public int Price { get; set; }
    }

}