using LessonProject.App_LocalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LessonProject.Models.ViewModels
{
    public class LoginView
    {
        [Required(ErrorMessageResourceType=typeof(GlobalRes), ErrorMessageResourceName="EnterEmail")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(GlobalRes), ErrorMessageResourceName = "EnterPassword")]
        public string Password { get; set; }

        public bool IsPersistent { get; set; }
    }
   
}