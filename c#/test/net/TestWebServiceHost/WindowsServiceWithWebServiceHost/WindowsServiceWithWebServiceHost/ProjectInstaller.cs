﻿using System.ComponentModel;
using System.Configuration.Install;

namespace WindowsServiceWithWebServiceHost
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
