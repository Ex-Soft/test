using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonProject.Models
{
    public partial class SqlRepository
    {
        public IQueryable<Language> Languages
        {
            get
            {
                return Db.Languages;
            }
        }

        public bool CreateLanguage(Language instance)
        {
            if (instance.ID == 0)
            {
                Db.Languages.InsertOnSubmit(instance);
                Db.Languages.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateLanguage(Language instance)
        {
            Language cache = Db.Languages.Where(p => p.ID == instance.ID).FirstOrDefault();
            if (cache != null)
            {
                cache.Code = instance.Code;
                cache.Name = instance.Name;
                Db.Languages.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemoveLanguage(int idLanguage)
        {
            Language instance = Db.Languages.Where(p => p.ID == idLanguage).FirstOrDefault();
            if (instance != null)
            {
                Db.Languages.DeleteOnSubmit(instance);
                Db.Languages.Context.SubmitChanges();
                return true;
            }

            return false;
        }
        
    }
}
