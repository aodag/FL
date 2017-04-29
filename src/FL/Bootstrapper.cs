using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Unity;
using Microsoft.Practices.ServiceLocation;
using Prism.Modularity;

namespace FL
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            //Application.Current.MainWindow = Shell as Window;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            var m = (ModuleCatalog)this.ModuleCatalog;
            //m.AddModule(typeof(Modules.Hello.HelloModule));
            m.AddModule(typeof(Modules.FileList.FileListModule));
        }
    }
}
