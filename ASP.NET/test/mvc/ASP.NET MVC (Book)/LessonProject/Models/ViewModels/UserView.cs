using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LessonProject.Models.ViewModels
{

    public class UserView
    {
        public int ID { get; set; }

        [Required(ErrorMessage="Введите email")]
        public string Email { get; set; }

        [Required(ErrorMessage="Введите пароль")]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        public string ConfirmPassword { get; set; }

        public string Captcha { get; set; }

        public string AvatarPath { get; set; }

        public int BirthdateDay { get; set; }

        public int BirthdateMonth { get; set; }

        public int BirthdateYear { get; set; }

        public IEnumerable<SelectListItem> BirthdateDaySelectList
        {
            get
            {
                for (int i = 1; i < 32; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                        Selected = BirthdateDay == i
                    };
                }
            }
        }

        public IEnumerable<SelectListItem> BirthdateMonthSelectList
        {
            get
            {
                for (int i = 1; i < 13; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = new DateTime(2000, i, 1).ToString("MMMM"),
                        Selected = BirthdateMonth == i
                    };
                }
            }
        }

        public IEnumerable<SelectListItem> BirthdateYearSelectList
        {
            get
            {
                for (int i = 1910; i < DateTime.Now.Year; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                        Selected = BirthdateYear == i
                    };
                }
            }
        }
    }
}