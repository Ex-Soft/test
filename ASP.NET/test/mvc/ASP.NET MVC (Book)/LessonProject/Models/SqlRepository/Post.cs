using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonProject.Models
{
    public partial class SqlRepository
    {
        public IQueryable<Post> Posts
        {
            get
            {
                return Db.Posts;
            }
        }

        public bool CreatePost(Post instance)
        {
            if (instance.ID == 0)
            {
                instance.AddedDate = DateTime.Now;
                Db.Posts.InsertOnSubmit(instance);
                Db.Posts.Context.SubmitChanges();
                var lang = Db.Languages.FirstOrDefault(p => p.ID == instance.CurrentLang);
                if (lang != null)
                {
                    CreateOrChangePostLang(instance, null, lang);
                    return true;
                }
            }

            return false;
        }

        public bool UpdatePost(Post instance)
        {
            Post cache = Db.Posts.Where(p => p.ID == instance.ID).FirstOrDefault();
            if (cache != null)
            {
                cache.Url = instance.Url;
                Db.Posts.Context.SubmitChanges();

                var lang = Db.Languages.FirstOrDefault(p => p.ID == instance.CurrentLang);
                if (lang != null)
                {
                    CreateOrChangePostLang(instance, cache, lang);
                    return true;
                }
                return true;
            }

            return false;
        }

        public bool RemovePost(int idPost)
        {
            Post instance = Db.Posts.Where(p => p.ID == idPost).FirstOrDefault();
            if (instance != null)
            {
                Db.Posts.DeleteOnSubmit(instance);
                Db.Posts.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        private void CreateOrChangePostLang(Post instance, Post cache, Language lang)
        {
            PostLang postLang = null;
            if (cache != null)
            {
                postLang = Db.PostLangs.FirstOrDefault(p => p.PostID == cache.ID && p.LanguageID == lang.ID);
            }
            if (postLang == null)
            {
                var newPostLang = new PostLang()
                {
                    PostID = instance.ID,
                    LanguageID = lang.ID,
                    Header = instance.Header,
                    Content = instance.Content,
                };
                Db.PostLangs.InsertOnSubmit(newPostLang);
            }
            else
            {
                postLang.Header = instance.Header;
                postLang.Content = instance.Content;
            }
            Db.PostLangs.Context.SubmitChanges();
        }

    }
}
