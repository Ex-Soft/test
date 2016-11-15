using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonProject.Global.Config
{
    public interface IConfig
    {
        string Lang { get; }

        bool EnableMail { get; }

        IQueryable<IconSize> IconSizes { get; }

        IQueryable<MimeType> MimeTypes { get; }

        IQueryable<MailTemplate> MailTemplates { get; }

        MailSetting MailSetting { get; }

        SmsSetting SmsSetting { get; }
    }
}
