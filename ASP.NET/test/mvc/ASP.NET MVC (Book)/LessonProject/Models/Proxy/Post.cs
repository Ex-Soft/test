using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonProject.Models
{
    public partial class Post
    {
        private int _currentLang;

        public int CurrentLang
        {
            get
            {
                return _currentLang;
            }

            set
            {
                _currentLang = value;

                var currentLang = PostLangs.FirstOrDefault(p => p.LanguageID == value);
                if (currentLang == null)
                {
                    IsCorrectLang = false;
                    var anyLang = PostLangs.FirstOrDefault();
                    if (anyLang != null)
                    {
                        SetLang(anyLang);
                    }
                }
                else
                {
                    IsCorrectLang = true;
                    SetLang(currentLang);
                }
            }
        }

        private void SetLang(PostLang postLang)
        {
            Header = postLang.Header;
            Content = postLang.Content;
        }

        public bool IsCorrectLang { get; protected set; }

        public string Header { get; set; }

        public string Content { get; set; }
    }
}
