using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Modularity;
using Prism.Regions;

namespace FL.Modules.Hello
{
    class HelloModule : IModule
    {
        private IRegionManager regionManager;

        public HelloModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion("ContentRegion", typeof(View));
        }
    }
}
