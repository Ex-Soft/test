using System.ComponentModel;
using System.Configuration.Install;

namespace WinServiceWithWcfService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}
